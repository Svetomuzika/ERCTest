using System.Collections.Generic;

namespace ERCTest.DAL.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Create(T item);

        void Update(T item);

        void Delete(int id);

        void UpdateRange(List<T> item) { }
    }
}