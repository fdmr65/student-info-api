using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInfo.Application.Commands.Create.Lesson;
using StudentInfo.Application.Commands.Create.LessonNote;
using StudentInfo.Application.Commands.Update.Lesson;
using StudentInfo.Application.Commands.Update.LessonNote;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using System;
using System.Threading.Tasks;

namespace StudentInfo.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonNoteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LessonNoteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetById/{Id}")]
        public async Task<ActionResult> GetById(Guid Id)
        {
            var query = new GetByIdQuery<StudentResponse>(Id);

            var lessonNote = await _mediator.Send(query);

            if (lessonNote == null)
            {
                return NotFound();
            }

            return Ok(lessonNote);
        }

     
        [HttpPost("AddNewLesson")]
        public async Task<ActionResult<LessonNoteResponse>> AddStudent([FromBody] CreateLessonNoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut("UpdateLessont")]
        public async Task<ActionResult<LessonNoteResponse>> UpdateStudent([FromBody] UpdateLessonNoteCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        
    }
}
