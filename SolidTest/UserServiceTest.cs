using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolidBLL.Services;
using SolidDAL.Context;
using SolidDAL.Entities;
using SolidDAL.UoW;

namespace SolidTest
{
    [TestClass]
    public class UserServiceTest
    {

        private static List<User> GetUserList()
        {
            return new List<User>
            {
                new("abc", "abc", "abc", "abc"),
                new("abc1", "abc1", "abc1", "abc1"),
                new("def2", "abc2", "abc2", "abc2"),
                new("qwe3", "abc3", "abc3", "abc3")
            };
        }
        [TestMethod]
        public void TestGuest()
        {
            var mockContext = new Mock<IStoreContext>(MockBehavior.Strict);
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);

            var unitOfWork = new UnitOfWork(mockContext.Object);

            var userService = new UserService(unitOfWork);
            
            Assert.IsFalse(userList.Contains(userService.Guest));
            Assert.AreEqual(userService.Guest.Role, Role.Guest);
        }

        [TestMethod]
        public void TestGetUserByEmail()
        {
            var mockContext = new Mock<IStoreContext>(MockBehavior.Strict);
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);

            var unitOfWork = new UnitOfWork(mockContext.Object);

            var userService = new UserService(unitOfWork);
            
            Assert.AreEqual(userService.GetUserByEmail("abc"), userList[0]);
        }

        [TestMethod]
        public void TestGetAllUsersByString()
        {
            var mockContext = new Mock<IStoreContext>(MockBehavior.Strict);
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);

            var unitOfWork = new UnitOfWork(mockContext.Object);

            var userService = new UserService(unitOfWork);
            Assert.AreEqual(userService.GetAllUsersByString("abc").Count(), 4);
        }


        [TestMethod]
        public void TestGetAllUsersByLogin()
        {
            var mockContext = new Mock<IStoreContext>(MockBehavior.Strict);
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);

            var unitOfWork = new UnitOfWork(mockContext.Object);

            var userService = new UserService(unitOfWork);
            Assert.AreEqual(userService.GetUserByLogin("qwe3"), userList[3]);
        }
    }
}