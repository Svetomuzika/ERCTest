using ERCTest.DAL.Models.EF;
using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERCTest.DAL.Models.Repositories
{
    public class PersonalAccountRepository : IRepository<PersonalAccount>
    {
        private ApplicationContext DBContext;

        public PersonalAccountRepository(ApplicationContext context)
        {
            DBContext = context;
        }

        public IEnumerable<PersonalAccount> GetAll()
        {
            return DBContext.PersonalAccounts;
        }

        public void Create(PersonalAccount personalAccount)
        {
            var rand = new Random();
            var numb = rand.Next(0, 1000000).ToString("D6");
            personalAccount.Number = numb;

            personalAccount.Residents = personalAccount.Residents.Where(x => x.Name != null).ToList();

            DBContext.PersonalAccounts.Add(personalAccount);
            DBContext.SaveChanges();
        }

        public void Update(PersonalAccount personalAccount)
        {
            DBContext.Entry(personalAccount).State = EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void Delete(int id)
        {
            PersonalAccount personalAccount = DBContext.PersonalAccounts.Find(id);

            if (personalAccount != null)
            {
                DBContext.PersonalAccounts.Remove(personalAccount);
                DBContext.SaveChanges();
            }
        }
    }
}
