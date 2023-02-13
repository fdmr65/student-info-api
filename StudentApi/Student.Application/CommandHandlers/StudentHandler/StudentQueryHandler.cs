using AutoMapper;
using MediatR;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.CommandHandlers.StudentHandler
{
    public  class StudentQueryHandler :  IRequestHandler<StudentByIdQuery,StudentResponse>,
         IRequestHandler<StudentsQuery,IEnumerable<StudentResponse>>
    {
        private readonly IStudentRepository _testRepository;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentRepository testRepository, IMapper mapper)
        {
            _testRepository = testRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetByIdAsync(request.Id);

            var resp = _mapper.Map<StudentResponse>(test);

            return resp;
        }

        public async Task<IEnumerable<StudentResponse>> Handle(StudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _testRepository.GetAllByActiveAsync();
            return _mapper.Map<IEnumerable<StudentResponse>>(students);
        }
    }
}
