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

namespace LessonInfo.Application.CommandHandlers.LessonNoteHandler
{
    public  class LessonNoteQueryHandler :  IRequestHandler<GetByIdQuery<LessonNoteResponse>, LessonNoteResponse>
    {
        private readonly ILessonNoteRepository _lessonNoteRepository;   
        private readonly IMapper _mapper;

        public LessonNoteQueryHandler(ILessonNoteRepository lessonNoteRepository, IMapper mapper)
        {
            _lessonNoteRepository = lessonNoteRepository;
            _mapper = mapper;
        }

        public async Task<LessonNoteResponse> Handle(GetByIdQuery<LessonNoteResponse> request, CancellationToken cancellationToken)
        {
            var result= await _lessonNoteRepository.GetByIdAsync(request.Id);

            var resp = _mapper.Map<LessonNoteResponse>(result);

            return resp;
        }
    }
}
