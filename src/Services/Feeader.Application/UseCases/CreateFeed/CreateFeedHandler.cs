using MediatR;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Application.UseCases.CreateFeed
{
    public class CreateFeedHandler : IRequestHandler<CreateFeedCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateFeedHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateFeedCommand request, CancellationToken cancellationToken)
        {
            var feed = new Feed(Guid.NewGuid(), request.Name, request.Url);
            await _dbContext.Feeds.AddAsync(feed, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return feed.Id;
        }
    }
}
