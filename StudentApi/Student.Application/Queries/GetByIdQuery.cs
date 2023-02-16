using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInfo.Application.Queries
{
    public  class GetByIdQuery<T> : IRequest<T>
    {
        public Guid Id { get; set; }

        public GetByIdQuery(Guid ıd)
        {
            Id = ıd;
        }
    }
}
