using MediatR;

namespace Monbsoft.Feeader.Application.UseCases.CreateFeed
{
    public class CreateFeedCommand : IRequest<Guid>
    {
        public CreateFeedCommand(string name, string url)
        {
            Name = name;
            Url = url;
        }

        public string Name { get; }
        public string Url { get; }
    }
}
