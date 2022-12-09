using System.Collections.Generic;
using ERCTest.DAL.Models.Interfaces;
using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.EF;
using ERCTest.DAL.Models.ViewModels;


namespace ERCTest.DAL.Models.Interfaces
{
    public interface IFilterRepository<T> where T : class
    {
        List<PersonalAccount> GetByResidentsOnly();
        List<PersonalAccount> GetByDateOnly(string date);
        List<PersonalAccount> GetByNameOnly(string name);
        List<PersonalAccount> GetByAdressOnly(string adress); 
    }
}
