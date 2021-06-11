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
    [Route("api/keyboard")]
    public class KeyboardController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public KeyboardController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetKeyboards()
        {
            var keyboardsFromRepo = _udlaansRepository.GetKeyboards();
            return new JsonResult(keyboardsFromRepo);
        }

        [HttpGet("{KeyboardId}", Name = "GetKeyboard")]
        public IActionResult GetKeyboard(int KeyboardId)
        {
            var keyboardFromRepo = _udlaansRepository.GetKeyboard(KeyboardId);
            if (keyboardFromRepo == null) { return NotFound(); }
            return new JsonResult(keyboardFromRepo);
        }

        [HttpPost()]
        public ActionResult<KeyboardDto> AddKeyboard(KeyboardToAddDto keyboard)
        {
            var keyboardEntity = _mapper.Map<Keyboard>(keyboard);
            _udlaansRepository.AddKeyboard(keyboardEntity);
            _udlaansRepository.Save();

            var keyboardForReturn = _mapper.Map<KeyboardDto>(keyboardEntity);
            return CreatedAtRoute("GetKeyboard", new { KeyboardId = keyboardForReturn }, keyboardForReturn);
        }

        [HttpDelete("{KeyboardId}")]
        public ActionResult DeleteKeyboard(int KeyboardId)
        {
            var keyboardFromRepo = _udlaansRepository.GetKeyboard(KeyboardId);
            if (keyboardFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveKeyboard(keyboardFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{KeyboardId}")]
        public ActionResult UpdateKeyboard(int KeyboardId, JsonPatchDocument<KeyboardToUpdateDto> patchDocument)
        {
            var keyboardFromRepo = _udlaansRepository.GetKeyboard(KeyboardId);
            if (keyboardFromRepo == null)
            {
                return NotFound();
            }
            var keyboardForUpdate = _mapper.Map<KeyboardToUpdateDto>(keyboardFromRepo);
            patchDocument.ApplyTo(keyboardForUpdate, ModelState);
            if (!TryValidateModel(keyboardForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(keyboardForUpdate, keyboardFromRepo);
            _udlaansRepository.UpdateKeyboard(keyboardFromRepo);
            _udlaansRepository.Save();
            return Ok(keyboardFromRepo);
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
