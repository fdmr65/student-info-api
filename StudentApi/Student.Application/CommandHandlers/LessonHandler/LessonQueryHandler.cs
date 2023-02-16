using AutoMapper;
using MediatR;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.CommandHandlers.LessonHandler
{
    public  class LessonQueryHandler : IRequestHandler<GetByIdQuery<LessonResponse>, LessonResponse>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<LessonResponse> Handle(GetByIdQuery<LessonResponse> request, CancellationToken cancellationToken)
        {
            var result = await _lessonRepository.GetByIdAsync(request.Id);

            var resp = _mapper.Map<LessonResponse>(result);

            return resp;
        }
    }
}
