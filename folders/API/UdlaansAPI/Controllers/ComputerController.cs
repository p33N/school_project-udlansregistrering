using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using UdlaansAPI.Entities;
using UdlaansAPI.Models;
using UdlaansAPI.Services;

namespace UdlaansAPI.Controllers
{
    [ApiController]
    [Route("api/computer")]
    public class ComputerController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public ComputerController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetComputers()
        {
            var computersFromRepo = _udlaansRepository.GetComputers();
            return new JsonResult(computersFromRepo);
        }

        [HttpGet("{ComputerId}", Name = "GetComputer")]
        public IActionResult GetComputer(string ComputerId)
        {
            var computerFromRepo = _udlaansRepository.GetComputer(ComputerId);
            if (computerFromRepo == null) { return NotFound(); }
            return new JsonResult(computerFromRepo);
        }

        [HttpPost()]
        public ActionResult<ComputerDto> AddComputer(ComputerToAddDto computer)
        {
            var computerEntity = _mapper.Map<Computer>(computer);
            _udlaansRepository.AddComputer(computerEntity);
            _udlaansRepository.Save();

            var computerForReturn = _mapper.Map<ComputerDto>(computerEntity);
            return Ok(computerForReturn);
        }

        [HttpDelete("{ComputerId}")]
        public ActionResult DeleteComputer(string ComputerId)
        {
            var computerFromRepo = _udlaansRepository.GetComputer(ComputerId);
            if(computerFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveComputer(computerFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{ComputerId}")]
        public ActionResult UpdateComputer(string ComputerId, JsonPatchDocument<ComputerToUpdateDto> patchDocument)
        {
            var computerFromRepo = _udlaansRepository.GetComputer(ComputerId);
            if(computerFromRepo == null)
            {
                return NotFound();
            }
            var computerForUpdate = _mapper.Map<ComputerToUpdateDto>(computerFromRepo);
            patchDocument.ApplyTo(computerForUpdate, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);
            if(!TryValidateModel(computerForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(computerForUpdate, computerFromRepo);
            _udlaansRepository.UpdateComputer(computerFromRepo);
            _udlaansRepository.Save();
            return Ok(computerFromRepo);
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
