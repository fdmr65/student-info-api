using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.Student
{
    public class CreateStudentValidator : AbstractValidator<CreateStudentCommand>
    {
        private readonly int minLength = 2;
        private readonly int maxLength= 50;
        public CreateStudentValidator()
        {
            RuleFor(v => v.Id)
                .NotNull();

            RuleFor(v => v.Name)
                  .NotEmpty()
                  .MinimumLength(minLength)
                  .MaximumLength(maxLength);

            RuleFor(v => v.Surname)
                  .NotEmpty()
                  .MinimumLength(minLength)
                  .MaximumLength(maxLength);

            
        }
    }
}
