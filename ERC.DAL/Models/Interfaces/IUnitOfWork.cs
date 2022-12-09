using ERCTest.DAL.Models.Entities;
using System;

namespace ERCTest.DAL.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PersonalAccount> PersonalAccounts { get; }
        IRepository<Resident> Residents { get; }
        void Save();
    }
}
