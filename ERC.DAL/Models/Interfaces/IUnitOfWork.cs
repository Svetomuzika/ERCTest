using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.ViewModels;
using System;

namespace ERCTest.DAL.Models.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<PersonalAccount> PersonalAccounts { get; }
        IRepository<Resident> Residents { get; }
        IFilterRepository<PersonalAccountViewModel> Filter { get; }
        void Save();
    }
}
