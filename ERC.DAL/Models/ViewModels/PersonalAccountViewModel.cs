using ERCTest.DAL.Models.Entities;
using System.Collections.Generic;

namespace ERCTest.DAL.Models.ViewModels
{
    public class PersonalAccountViewModel
    {
        public List<PersonalAccount> PersonalAccounts { get; set; }

        public string StartDate { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }
    }
}
