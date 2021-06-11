using Microsoft.AspNetCore.Mvc;
using Reti.Circolare.BL.DTO;
using Reti.Circolare.BL.Managers;
using Reti.Circolare.DAL.UnitOfWork;
using System;

namespace Reti.Circolare.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RisorsaController : ControllerBase
    {
        private readonly ManagerRisorsa managerRisorsa;
        private IUnitOfWork unitOfWork;
        public RisorsaController(IUnitOfWork unitOfWork)
        {
            managerRisorsa = new ManagerRisorsa(unitOfWork);
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(managerRisorsa.GetAll());
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CreaRisorsa([FromBody] DTORisorsa_Crea dtoRisorsaCrea)
        {
            try
            {
                return Ok(managerRisorsa.Add(dtoRisorsaCrea));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateState/{id}")]
        public IActionResult ModificaAbilitazioneRisorsa(Guid id)
        {
            try
            {
                return Ok(managerRisorsa.CambiaAbilitazioneRisorsa(id));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
