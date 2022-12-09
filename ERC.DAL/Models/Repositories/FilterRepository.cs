using ERCTest.DAL.Models.EF;
using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.Interfaces;
using ERCTest.DAL.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERCTest.DAL.Models.Repositories
{
    public class FilterRepository : IFilterRepository<PersonalAccountViewModel>
    {
        private ApplicationContext DBContext;

        public FilterRepository(ApplicationContext context)
        {
            DBContext = context;
        }

        public IEnumerable<PersonalAccount> GetAllPersonalAccounts() => DBContext.PersonalAccounts;
        public IEnumerable<Resident> GetAllResidents() => DBContext.Residents;

        public List<PersonalAccount> GetByResidentsOnly()
        {
            var residents = GetAllResidents().ToList();

            return GetAllPersonalAccounts().Where(x => x.Residents != null).ToList();
        }

        public List<PersonalAccount> GetByDateOnly(string date)
        {
            var residents = GetAllResidents().ToList();

            return GetAllPersonalAccounts().Where(x => x.StartDate == date).ToList();
        }

        public List<PersonalAccount> GetByNameOnly(string name)
        {
            var accounts = GetAllPersonalAccounts();
            var residents = GetAllResidents();

            var list = new List<PersonalAccount>();

            foreach (var resident in residents)
            {
                if (!list.Contains(accounts.Where(x => x.Id == resident.PersonalAccountId).SingleOrDefault()) && (resident.Name.ToLower().Contains(name) 
                    || resident.Surname.ToLower().Contains(name) || resident.Patronymic.ToLower().Contains(name)))
                {
                    list.Add(accounts.Where(x => x.Id == resident.PersonalAccountId).SingleOrDefault());
                }
            }

            if (list.Count == 0)
                return GetAllPersonalAccounts().ToList();
            else
                return list;
        }

        public List<PersonalAccount> GetByAdressOnly(string adress)
        {
            var residents = GetAllResidents().ToList();

            return GetAllPersonalAccounts().Where(x => x.Address.ToLower().Contains(adress)).ToList();
        }
    }
}
