using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Application.Commands.Create.Lesson;
using StudentInfo.Application.Commands.Update.Lesson;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using System;
using System.Threading.Tasks;

namespace StudentInfo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var query = new GetByIdQuery<LessonResponse>(Id);

            var lesson = await _mediator.Send(query);

            if (lesson == null)
            {
                return NotFound();
            }

            return Ok(lesson);
        }


        [HttpPost("AddNewLesson")]
        public async Task<ActionResult<LessonResponse>> AddStudent([FromBody] CreateLessonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateLessont")]
        public async Task<ActionResult<LessonResponse>> UpdateStudent([FromBody] UpdateLessonCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


    }
}