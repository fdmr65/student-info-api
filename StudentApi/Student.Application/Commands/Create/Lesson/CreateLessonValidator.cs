using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.Lesson
{
    public  class CreateLessonValidator : AbstractValidator<CreateLessonCommand>
    {
        public CreateLessonValidator()
        {
            RuleFor(v => v.Id)
               .NotNull();

            RuleFor(v => v.Name)
                .NotNull()
               .MinimumLength(2);

            RuleFor(v => v.StudentId)
                    .NotNull();
        }
    }
}
