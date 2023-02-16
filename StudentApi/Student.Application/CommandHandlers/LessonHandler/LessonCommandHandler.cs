using AutoMapper;
using MediatR;
using StudentInfo.Application.Commands.Create.Lesson;
using StudentInfo.Application.Commands.Update.Lesson;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LessonInfo.Application.CommandHandlers.LessonHandler
{
    internal class LessonCommandHandler  : 
        IRequestHandler<CreateLessonCommand, LessonResponse>,
        IRequestHandler<UpdateLessonCommand, LessonResponse>

    {

        private readonly ILessonRepository _lessonRepository;
         private readonly IMapper _mapper;

        public LessonCommandHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<LessonResponse> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Lesson>(request);

            if (entity == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            var lesson = await _lessonRepository.AddAsync(entity);

            var resp = _mapper.Map<LessonResponse>(lesson);

            return resp;
        }

        public async Task<LessonResponse> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Lesson>(request);

            if (entity == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            await _lessonRepository.UpdateAsync(entity);

            var resp = _mapper.Map<LessonResponse>(entity);

            return resp;
        }
    }
}
