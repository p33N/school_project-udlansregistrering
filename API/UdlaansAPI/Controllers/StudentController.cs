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
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private readonly IUdlaansRepository _udlaansRepository;
        private readonly IMapper _mapper;

        public StudentController(IUdlaansRepository udlaansRepository, IMapper mapper)
        {
            _udlaansRepository = udlaansRepository ??
                throw new ArgumentNullException(nameof(udlaansRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var studentsFromRepo = _udlaansRepository.GetStudents();
            return new JsonResult(studentsFromRepo);
        }

        [HttpGet("{StudentId}", Name = "GetStudent")]
        public IActionResult GetStudent(int StudentId)
        {
            var studentFromRepo = _udlaansRepository.GetStudent(StudentId);
            if (studentFromRepo == null) { return NotFound(); }
            return new JsonResult(studentFromRepo);
        }

        [HttpPost()]
        public ActionResult<StudentDto> AddStudent(StudentToAddDto student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            _udlaansRepository.AddStudent(studentEntity);
            _udlaansRepository.Save();

            var studentForReturn = _mapper.Map<StudentDto>(studentEntity);
            return CreatedAtRoute("GetStudent", new { StudentId = studentForReturn }, studentForReturn);
        }

        [HttpDelete("{StudentId}")]
        public ActionResult DeleteStudent(int StudentId)
        {
            var studentFromRepo = _udlaansRepository.GetStudent(StudentId);
            if (studentFromRepo == null)
            {
                return NotFound();
            }
            _udlaansRepository.RemoveStudent(studentFromRepo);
            _udlaansRepository.Save();
            return NoContent();
        }

        [HttpPatch("{StudentId}")]
        public ActionResult UpdateStudent(int StudentId, JsonPatchDocument<StudentToUpdateDto> patchDocument)
        {
            var studentFromRepo = _udlaansRepository.GetStudent(StudentId);
            if (studentFromRepo == null)
            {
                return NotFound();
            }
            var studentForUpdate = _mapper.Map<StudentToUpdateDto>(studentFromRepo);
            patchDocument.ApplyTo(studentForUpdate, ModelState);
            if (!TryValidateModel(studentForUpdate))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(studentForUpdate, studentFromRepo);
            _udlaansRepository.UpdateStudent(studentFromRepo);
            _udlaansRepository.Save();
            return Ok(studentFromRepo);
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
