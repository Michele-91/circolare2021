using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reti.Circolare.BL.DTO;
using Reti.Circolare.BL.Managers;
using Reti.Circolare.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reti.Circolare.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaController : ControllerBase
    {
        private readonly ManagerSala managerSala;
        private IUnitOfWork unitOfWork;
        public SalaController(IUnitOfWork unitOfWork)
        {
            managerSala = new ManagerSala(unitOfWork);
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(managerSala.GetAll());
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CreaSala([FromBody] DTOSala_Crea dtoSalaCrea)
        {
            try
            {
                return Ok(managerSala.Add(dtoSalaCrea));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
