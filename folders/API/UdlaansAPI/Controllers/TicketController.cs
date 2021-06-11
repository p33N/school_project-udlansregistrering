using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdlaansAPI.Entities;
using UdlaansAPI.Models;
using UdlaansAPI.Services;

namespace UdlaansAPI.Controllers
{
    [ApiController]
    [Route("api/ticket")]
    public class TicketController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public TicketController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetTickets()
        {
            var ticketsFromRepo = _udlaansRepository.GetTickets();
            return new JsonResult(ticketsFromRepo);
        }

        [HttpGet("{TicketId}", Name = "GetTicket")]
        public IActionResult GetTicket(int TicketId)
        {
            var ticketFromRepo = _udlaansRepository.GetTicket(TicketId);
            if (ticketFromRepo == null) { return NotFound(); }
            return new JsonResult(ticketFromRepo);
        }

        [HttpPost()]
        public ActionResult<TicketDto> AddTicket(TicketToAddDto ticket)
        {
            var ticketEntity = _mapper.Map<Ticket>(ticket);
            _udlaansRepository.AddTicket(ticketEntity);
            _udlaansRepository.Save();

            var ticketForReturn = _mapper.Map<TicketDto>(ticketEntity);
            return CreatedAtRoute("GetTicket", new { TicketId = ticketForReturn }, ticketForReturn);
        }

        [HttpDelete("{TicketId}")]
        public ActionResult DeleteTicket(int TicketId)
        {
            var ticketFromRepo = _udlaansRepository.GetTicket(TicketId);
            if (ticketFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveTicket(ticketFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{TicketId}")]
        public ActionResult UpdateTicket(int TicketId, JsonPatchDocument<TicketToUpdateDto> patchDocument)
        {
            var ticketFromRepo = _udlaansRepository.GetTicket(TicketId);
            if (ticketFromRepo == null)
            {
                return NotFound();
            }
            var ticketForUpdate = _mapper.Map<TicketToUpdateDto>(ticketFromRepo);
            patchDocument.ApplyTo(ticketForUpdate, ModelState);
            if (!TryValidateModel(ticketForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(ticketForUpdate, ticketFromRepo);
            _udlaansRepository.UpdateTicket(ticketFromRepo);
            _udlaansRepository.Save();
            return Ok(ticketFromRepo);
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}
