using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.Interfaces;
using ERCTest.DAL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;
using ERCTest.DAL.Models.Repositories;

namespace ERCTest.DAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BLLController : ControllerBase
    {
        IUnitOfWork unitOfWork;

        public BLLController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetByResidentsOnly")]
        public PersonalAccountViewModel GetResidentsOnly()
        {
            var filteringAccs = unitOfWork.Filter.GetByResidentsOnly();
            var viewModel = new PersonalAccountViewModel() { PersonalAccounts = filteringAccs };

            return viewModel;
        }

        [HttpPost("GetByStartDate")]
        public PersonalAccountViewModel GetStartDate(PersonalAccountViewModel vm)
        {
            var filteringAccs = unitOfWork.Filter.GetByDateOnly(vm.StartDate);
            var viewModel = new PersonalAccountViewModel() { PersonalAccounts = filteringAccs };

            return viewModel;
        }

        [HttpPost("GetByResidentsName")]
        public PersonalAccountViewModel GetResidentsName(PersonalAccountViewModel vm)
        {
            var filteringAccs = unitOfWork.Filter.GetByNameOnly(vm.Name.ToLower());
            var viewModel = new PersonalAccountViewModel() { PersonalAccounts = filteringAccs };

            return viewModel;
        }

        [HttpPost("GetByAdress")]
        public PersonalAccountViewModel GetByAdress(PersonalAccountViewModel vm)
        {
            var filteringAccs = unitOfWork.Filter.GetByAdressOnly(vm.Adress.ToLower());
            var viewModel = new PersonalAccountViewModel() { PersonalAccounts = filteringAccs };

            return viewModel;
        }
    }
}
