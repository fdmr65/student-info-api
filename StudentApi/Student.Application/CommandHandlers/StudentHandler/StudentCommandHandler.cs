using AutoMapper;
using MediatR;
using StudentInfo.Application.Commands.Create.Student;
using StudentInfo.Application.Commands.Delete.Student;
using StudentInfo.Application.Commands.Update.Student;
using StudentInfo.Application.Queries;
using StudentInfo.Application.Responses;
using StudentInfo.Domain.IRepositories;
using StudentInfo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.CommandHandlers.StudentHandler
{
    public class StudentCommandHandler :
        IRequestHandler<CreateStudentCommand, StudentResponse>,
        IRequestHandler<UpdateStudentCommand, StudentResponse>,
        IRequestHandler<DeleteStudentCommand, DeletedResponse>

    {

        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var entitiy = _mapper.Map<Student>(request);

            if (entitiy == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            var student = await _studentRepository.AddAsync(entitiy);

            var resp = _mapper.Map<StudentResponse>(student);

            return resp;
        }


        public async Task<DeletedResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {

             await _studentRepository.DeleteAsync(request.Id);
             var res = new DeletedResponse(){  IsOk = true,  Message = "Success"  };
             return res;
        }

        public async Task<StudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);

            if (studentEntity == null)
            {
                throw new ApplicationException("Entitiy couldnt be mapped");
            }

            await _studentRepository.UpdateAsync(studentEntity);

            var studentResponse = _mapper.Map<StudentResponse>(studentEntity);

            return studentResponse;
        }
    }
}
