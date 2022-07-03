using MediatR;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Application.UseCases.ListFeeds;

public class ListFeedsRequest : IStreamRequest<Feed>
{
}
