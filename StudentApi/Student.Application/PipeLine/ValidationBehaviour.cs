using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.PipeLine
{
    public class ValidationBehaviour<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse>
    {
        private readonly IEnumerable<IValidator<IRequest>> _validators;

        public ValidationBehaviour(IEnumerable<IValidator<IRequest>> validators)
        {
            _validators = validators;
        }

        public Task<IResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResponse> next)
        {
            var context = new ValidationContext<IRequest>(request);
            var failures = _validators.Select(a => a.Validate(context))
                                      .SelectMany(a => a.Errors)
                                      .Where(a => a != null)
                                      .ToList();
            if (failures.Any())
            {
                throw new ValidationException(failures);
            }

            return next();
        }
    }
}
