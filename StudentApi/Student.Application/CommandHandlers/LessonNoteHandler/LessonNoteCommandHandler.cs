using AutoMapper;
using MediatR;
using StudentInfo.Application.Commands.Create.LessonNote;
using StudentInfo.Application.Commands.Update.LessonNote;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.CommandHandlers.LessonNoteNoteHandler
{
    public  class LessonNoteNoteCommandHandler :
        IRequestHandler<CreateLessonNoteCommand, LessonNoteResponse>,
        IRequestHandler<UpdateLessonNoteCommand, LessonNoteResponse>

    {

        private readonly ILessonNoteRepository _lessonNoteRepository;
        private readonly IMapper _mapper;

        public LessonNoteNoteCommandHandler(ILessonNoteRepository lessonNoteRepository, IMapper mapper)
        {
            _lessonNoteRepository = lessonNoteRepository;
            _mapper = mapper;
        }

        public async Task<LessonNoteResponse> Handle(CreateLessonNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LessonNote>(request);

            if (entity == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            var lessonNote = await _lessonNoteRepository.AddAsync(entity);

            var resp = _mapper.Map<LessonNoteResponse>(lessonNote);

            return resp;
        }

        public async Task<LessonNoteResponse> Handle(UpdateLessonNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<LessonNote>(request);

            if (entity == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            await _lessonNoteRepository.UpdateAsync(entity);

            var resp = _mapper.Map<LessonNoteResponse>(entity);

            return resp;
        }
    }
}