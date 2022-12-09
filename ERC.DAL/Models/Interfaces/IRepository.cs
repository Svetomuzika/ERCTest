using System.Collections.Generic;

namespace ERCTest.DAL.Models.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        void Create(T item);

        abstract void Update(T item);

        void UpdateRange(List<T> item)
        {

        }

        void Delete(int id);
    }
}