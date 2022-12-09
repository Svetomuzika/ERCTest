using ERCTest.DAL.Models.Entities;
using System.Collections.Generic;

namespace ERCTest.DAL.Models.ViewModels
{
    public class PersonalAccountViewModel
    {
        public List<PersonalAccount> PersonalAccounts { get; set; }

        public int Id { get; set; }

        public List<Resident> Residents { get; set; }
    }
}
