using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentInfo.Application.Commands.Create.Student;
using StudentInfo.Application.Commands.Delete.Student;
using StudentInfo.Application.Commands.Update.Student;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using System;
using System.Threading.Tasks;

namespace StudentInfo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IMediator mediator, ILogger<StudentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var query = new GetByIdQuery<StudentResponse>(Id);

            var student = await _mediator.Send(query);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost("GetAllStudents")]
        public async Task<ActionResult> GetAllStudents([FromBody] StudentsQuery studentsQuery)
        {
            var student = await _mediator.Send(studentsQuery);
            return Ok(student);
        }


        [HttpPost("AddNewStudent")]
        public async Task<ActionResult<StudentResponse>> AddStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateStudent")]
        public async Task<ActionResult<StudentResponse>> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult<StudentResponse>> DeleteStudent(Guid id)
        {
            var command = new DeleteStudentCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
