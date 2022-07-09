using MediatR;

namespace Monbsoft.Feeader.Application.UseCases.CreateFeed
{
    public class CreateFeedCommand : IRequest<Guid>
    {
        public CreateFeedCommand(string name, string link)
        {
            Name = name;
            Link = link;
        }

        public string Name { get; }
        public string Link { get; }
    }
}
