using MediatR;
using Monbsoft.Feeader.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Application.UseCases.GetFeed
{
    public class GetFeedQuery : IRequest<Feed>
    {
        public GetFeedQuery(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
