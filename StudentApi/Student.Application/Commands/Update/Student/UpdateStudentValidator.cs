using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Update.Student
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        private readonly int minLength = 2;
        private readonly int maxLength = 50;
        public UpdateStudentValidator()
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
