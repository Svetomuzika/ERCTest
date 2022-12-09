using ERCTest.DAL.Models.Entities;
using ERCTest.DAL.Models.Interfaces;
using ERCTest.DAL.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Collections.Generic;

namespace ERCTest.DAL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DALController : ControllerBase
    {
        IUnitOfWork unitOfWork;
        
        public DALController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet("GetAll")]
        public PersonalAccountViewModel GetAll()
        {
            var accounts = unitOfWork.PersonalAccounts.GetAll().ToList();
            var residents = unitOfWork.Residents.GetAll().ToList();

            var viewModel = new PersonalAccountViewModel() { PersonalAccounts = accounts};

            return viewModel;
        }

        [HttpPost("Create")]
        public IActionResult Create(PersonalAccount personalAccount)
        {
            unitOfWork.PersonalAccounts.Create(personalAccount);

            return NoContent();
        }

        [HttpPut("Update")]
        public IActionResult Update(PersonalAccount personalAccount)
        {
            unitOfWork.PersonalAccounts.Update(personalAccount);
            unitOfWork.Residents.UpdateRange(personalAccount.Residents);

            return NoContent();
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(int id)
        {
            unitOfWork.Residents.GetAll().ToList();
            unitOfWork.PersonalAccounts.Delete(id);
        }
    }
}
