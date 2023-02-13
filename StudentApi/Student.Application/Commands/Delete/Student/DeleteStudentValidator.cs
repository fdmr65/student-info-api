using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Delete.Student
{
    public class DeleteStudentValidator : AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentValidator()
        {
            RuleFor(v => v.Id)
                .NotNull();
        }
    }
}
