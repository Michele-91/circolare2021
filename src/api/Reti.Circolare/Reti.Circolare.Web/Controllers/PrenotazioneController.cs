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
    public class PrenotazioneController : ControllerBase
    {
        private readonly ManagerPrenotazione managerPrenotazione;
        private IUnitOfWork unitOfWork;
        public PrenotazioneController(IUnitOfWork unitOfWork)
        {
            managerPrenotazione = new ManagerPrenotazione(unitOfWork);
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(managerPrenotazione.GetAll());
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult CreaPrenotazione([FromBody] DTOPrenotazione_Crea dtoPrenotazioneCrea)
        {
            try
            {
                return Ok(managerPrenotazione.Add(dtoPrenotazioneCrea));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("Filter/{input}")]
        public IActionResult FiltraPrenotazione(string input)
        {
            try
            {
                return Ok(managerPrenotazione.Filter(input));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult CancellaPrenotazione(int id)
        {
            try
            {
                return Ok(managerPrenotazione.Delete(id));
            }
            catch (Exception ex)
            {
                unitOfWork.RollBack();
                return StatusCode(500, ex.Message);
            }
        }
    }
}
