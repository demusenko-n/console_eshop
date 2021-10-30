using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SolidDAL.Context;
using SolidDAL.Entities;
using SolidDAL.Repositories;

namespace SolidTest
{
    [TestClass]
    public class UserCollectionRepositoryTest
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
        public void TestGetById()
        {
            var mockContext = new Mock<IStoreContext>();
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);
            var userRepository = new UserCollectionRepository(mockContext.Object);

            var userToFind = userList[0];
            var foundUser = userRepository.GetById(userToFind.Id);

            Assert.AreEqual(userToFind, foundUser);
        }

        [TestMethod]
        public void TestGetByFilter()
        {
            var mockContext = new Mock<IStoreContext>();
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);
            var userRepository = new UserCollectionRepository(mockContext.Object);
            
            var foundUsers = userRepository.GetAllByFilter(user=>user.Login.Contains("abc"));

            Assert.IsTrue(foundUsers.Count() == 2);
        }

        [TestMethod]
        public void TestCreateUser()
        {
            var mockContext = new Mock<IStoreContext>();
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);
            var userRepository = new UserCollectionRepository(mockContext.Object);

            var newUser = new User("newUser", "newUser", "newUser", "newUser");
            userRepository.Create(newUser);

            Assert.IsTrue(userList.Contains(newUser));
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            var mockContext = new Mock<IStoreContext>();
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);
            var userRepository = new UserCollectionRepository(mockContext.Object);

            var userToDelete = userList[0];

            userRepository.Delete(userToDelete);

            Assert.IsFalse(userList.Contains(userToDelete));
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            var mockContext = new Mock<IStoreContext>();
            var userList = GetUserList();
            mockContext.Setup(cont => cont.Users).Returns(userList);
            var userRepository = new UserCollectionRepository(mockContext.Object);

            var userToUpdate = userList[0];
            userToUpdate.Name = "newname";

            userRepository.Update(userToUpdate);

            Assert.IsTrue(userList.Contains(userToUpdate));
        }
    }
}
