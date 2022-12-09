using ERCTest.DAL.Models.EF;
using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ERCTest.DAL.Models.Repositories
{
    public class ResidentRepository : IRepository<Resident>
    {
        private ApplicationContext DBContext;

        public ResidentRepository(ApplicationContext context)
        {
            DBContext = context;
        }

        public IEnumerable<Resident> GetAll()
        {
            return DBContext.Residents;
        }

        public void Create(Resident residents)
        {
            DBContext.Residents.Add(residents);
            DBContext.SaveChanges();
        }

        public void Update(Resident resident)
        {
            DBContext.Entry(resident).State = EntityState.Modified;
            DBContext.SaveChanges();
        }

        public void UpdateRange(List<Resident> residents)
        {
            foreach (Resident resident in residents)
            {
                DBContext.Entry(resident).State = EntityState.Modified;
                DBContext.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Resident resident = DBContext.Residents.Find(id);

            if (resident != null)
            {
                DBContext.Residents.Remove(resident);
                DBContext.SaveChanges();
            }
        }
    }
}
