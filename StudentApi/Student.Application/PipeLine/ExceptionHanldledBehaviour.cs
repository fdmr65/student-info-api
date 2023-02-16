using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudentInfo.Application.PipeLine
{
    public  class ExceptionHanldledBehaviour<IRequest, IResponse> : IPipelineBehavior<IRequest, IResponse>
    {
        private readonly ILogger<IRequest> _logger;

        public ExceptionHanldledBehaviour(ILogger<IRequest> logger)
        {
            _logger = logger;
        }

        public async Task<IResponse> Handle(IRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<IResponse> next)
        {
            var requestName = typeof(IRequest).Name;
            try
            {
                //_logger.LogInformation( "Request : {Name} {@Request}", requestName, request);
                return await next();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Request : UnHandled Exception for request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
