using Igra80.Data;
using Igra80.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Igra80.Controllers
{
    [Route("api/incidences")]
    [ApiController]
    public class IncidencesController : ControllerBase
    {
        private readonly IIgraRepo _repository;
        private readonly INotificationRepo _notificationRepo;

        public IncidencesController(IIgraRepo repository, INotificationRepo notificationRepo)
        {
            _repository = repository;
            _notificationRepo = notificationRepo;
        }

        [HttpGet]
        public ActionResult <IEnumerable<Incidence>> GetAllIncidences()
        {

            //var incidences = _repository.GetAllIncidences();
            var incidences = _notificationRepo.GetIncidenceNotification();

            return Ok(incidences);
        }

        [HttpGet("{caid}", Name="GetIncidenceByCaId")]
        public ActionResult <Incidence> GetIncidenceByCaId(int caid)
        {
            var incidence = _repository.GetIncidenceByCaId(caid);
            if(incidence != null)
            {
                return Ok(incidence);
            }
            return NotFound();
        }
    }
}
