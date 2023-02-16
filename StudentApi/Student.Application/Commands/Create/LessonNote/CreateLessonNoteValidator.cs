using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Commands.Create.LessonNote
{
    public  class CreateLessonNoteValidator : AbstractValidator<CreateLessonNoteCommand>
    {
        public CreateLessonNoteValidator()
        {
            RuleFor(v => v.Id)
                .NotNull();

            RuleFor(v => v.Note)
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(100);

            RuleFor(v => v.LessonId)
                    .NotNull();
        }
    }
}
