using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("api/mouse")]
    public class MouseController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public MouseController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetMice()
        {
            var miceFromRepo = _udlaansRepository.GetMice();
            return new JsonResult(miceFromRepo);
        }

        [HttpGet("{MouseId}", Name = "GetMouse")]
        public IActionResult GetMouse(int MouseId)
        {
            var mouseFromRepo = _udlaansRepository.GetMouse(MouseId);
            if (mouseFromRepo == null) { return NotFound(); }
            return new JsonResult(mouseFromRepo);
        }

        [HttpPost()]
        public ActionResult<MouseDto> AddMouse(MouseToAddDto mouse)
        {
            var mouseEntity = _mapper.Map<Mouse>(mouse);
            _udlaansRepository.AddMouse(mouseEntity);
            _udlaansRepository.Save();

            var mouseForReturn = _mapper.Map<MouseDto>(mouseEntity);
            return CreatedAtRoute("GetMouse", new { MouseId = mouseForReturn }, mouseForReturn);
        }

        [HttpDelete("{MouseId}")]
        public ActionResult DeleteMouse(int MouseId)
        {
            var mouseFromRepo = _udlaansRepository.GetMouse(MouseId);
            if (mouseFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveMouse(mouseFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{MouseId}")]
        public ActionResult UpdateMouse(int MouseId, JsonPatchDocument<MouseToUpdateDto> patchDocument)
        {
            var mouseFromRepo = _udlaansRepository.GetMouse(MouseId);
            if (mouseFromRepo == null)
            {
                return NotFound();
            }
            var mouseForUpdate = _mapper.Map<MouseToUpdateDto>(mouseFromRepo);
            patchDocument.ApplyTo(mouseForUpdate, ModelState);
            if (!TryValidateModel(mouseForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(mouseForUpdate, mouseFromRepo);
            _udlaansRepository.UpdateMouse(mouseFromRepo);
            _udlaansRepository.Save();
            return Ok(mouseFromRepo);
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
