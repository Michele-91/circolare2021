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
    public class EdificioController : ControllerBase
    {
        private readonly ManagerEdificio managerEdificio;
        private IUnitOfWork unitOfWork;
        public EdificioController(IUnitOfWork unitOfWork)
        {
            managerEdificio = new ManagerEdificio(unitOfWork);
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(managerEdificio.GetAll());
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CreaEdificio([FromBody] DTOEdificio_Crea dtoEdificioCrea)
        {
            try
            {
                return Ok(managerEdificio.Add(dtoEdificioCrea));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
