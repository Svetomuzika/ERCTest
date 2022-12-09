using ERCTest.DAL.Models.Interfaces;
using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.EF;
using ERCTest.DAL.Models.ViewModels;
using System;

namespace ERCTest.DAL.Models.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationContext DBContext;
        private PersonalAccountRepository personalAccountRepository;
        private ResidentRepository residentRepository;
        private FilterRepository filterRepository;

        public EFUnitOfWork(ApplicationContext context)
        {
            DBContext = context;
        }

        public IRepository<PersonalAccount> PersonalAccounts
        {
            get
            {
                if (personalAccountRepository == null)
                    personalAccountRepository = new PersonalAccountRepository(DBContext);

                return personalAccountRepository;
            }
        }

        public IFilterRepository<PersonalAccountViewModel> Filter
        {
            get
            {
                if (filterRepository == null)
                    filterRepository = new FilterRepository(DBContext);

                return filterRepository;
            }
        }

        public IRepository<Resident> Residents
        {
            get
            {
                if (residentRepository == null)
                    residentRepository = new ResidentRepository(DBContext);

                return residentRepository;
            }
        }

        public void Save()
        {
            DBContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    DBContext.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
