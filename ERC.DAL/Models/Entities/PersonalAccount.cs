using System;
using System.Collections.Generic;

namespace ERCTest.DAL.Models.Entities
{
    public class PersonalAccount
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public string Address { get; set; }

        public double Area { get; set; }

        public List<Resident> Residents { get; set; }
    }
}
