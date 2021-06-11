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
    [Route("api/computerstatus")]
    public class ComputerStatusController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public ComputerStatusController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetComputerStatuses()
        {
            var computerStatusesFromRepo = _udlaansRepository.GetComputerStatuses();
            return new JsonResult(computerStatusesFromRepo);
        }

        [HttpGet("{ComputerStatusId}", Name = "GetComputerStatus")]
        public IActionResult GetComputerStatus(int ComputerStatusId)
        {
            var computerStatusFromRepo = _udlaansRepository.GetComputerStatus(ComputerStatusId);
            if (computerStatusFromRepo == null) { return NotFound(); }
            return new JsonResult(computerStatusFromRepo);
        }

        [HttpPost()]
        public ActionResult<ComputerStatusDto> AddComputerStatus(ComputerStatusToAddDto computerStatus)
        {
            var computerStatusEntity = _mapper.Map<ComputerStatus>(computerStatus);
            _udlaansRepository.AddComputerStatus(computerStatusEntity);
            _udlaansRepository.Save();

            var computerStatusForReturn = _mapper.Map<ComputerStatusDto>(computerStatusEntity);
            return CreatedAtRoute("GetComputerStatus", new { ComputerStatusId = computerStatusForReturn }, computerStatusForReturn);
        }

        [HttpDelete("{ComputerStatusId}")]
        public ActionResult DeleteComputerStatus(int ComputerStatusId)
        {
            var computerStatusFromRepo = _udlaansRepository.GetComputerStatus(ComputerStatusId);
            if (computerStatusFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveComputerStatus(computerStatusFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{ComputerStatusId}")]
        public ActionResult UpdateComputerStatus(int ComputerStatusId, JsonPatchDocument<ComputerStatusToUpdateDto> patchDocument)
        {
            var computerStatusFromRepo = _udlaansRepository.GetComputerStatus(ComputerStatusId);
            if (computerStatusFromRepo == null)
            {
                return NotFound();
            }
            var computerStatusForUpdate = _mapper.Map<ComputerStatusToUpdateDto>(computerStatusFromRepo);
            patchDocument.ApplyTo(computerStatusForUpdate, ModelState);
            if (!TryValidateModel(computerStatusForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(computerStatusForUpdate, computerStatusFromRepo);
            _udlaansRepository.UpdateComputerStatus(computerStatusFromRepo);
            _udlaansRepository.Save();
            return Ok(computerStatusFromRepo);
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
