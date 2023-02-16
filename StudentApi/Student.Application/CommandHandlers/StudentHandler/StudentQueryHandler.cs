using AutoMapper;
using MediatR;
using StudentInfo.Application.Helper;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.CommandHandlers.StudentHandler
{
    public  class StudentQueryHandler :  
        IRequestHandler<GetByIdQuery<StudentResponse>,StudentResponse>,
         IRequestHandler<StudentsQuery,IEnumerable<StudentResponse>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(GetByIdQuery<StudentResponse> request, CancellationToken cancellationToken)
        {
            var test = await _studentRepository.GetByIdAsync(request.Id);

            var resp = _mapper.Map<StudentResponse>(test);

            return resp;
        }

        public async Task<IEnumerable<StudentResponse>> Handle(StudentsQuery request, CancellationToken cancellationToken)
        {
            var predicate = DynamicFilterExpressionQuery.GetExpression<Student>(request.FilterQueries);

            var students =  predicate == null ? 
                await _studentRepository.GetActivesByPageAsync(request.Skip, request.Take) :
                await _studentRepository.GetActiveByPageAsync(predicate,request.Skip, request.Take); 
            return _mapper.Map<IEnumerable<StudentResponse>>(students);
        }
    }
}
