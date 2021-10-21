using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SolidTask.Domain.Entities;

namespace SolidTask.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        IEnumerable<T> GetAllByFilter(Func<T, bool> predicate);
        T GetById(Guid id);
        void Create(T item);
        void Delete(T item);
        void Update(T item);
    }
}