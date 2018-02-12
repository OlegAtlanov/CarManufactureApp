using System;
using System.Linq;

namespace CarManufactureApp.Domain
{
    interface IRepository<T> : IDisposable
    {
        IQueryable<T> All { get; }
        void InsertOrUpdate(T item);
        void Delete(T item);
        void Save();
    }
}
