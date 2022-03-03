using Monbsoft.Feeader.Models;
using System.Text.Json;

namespace Monbsoft.Feeader.Services
{
    public class SettingsService
    {
        private const string localFileName = "feeds.dat";
        private readonly string _localPath;

        public SettingsService()
        {
            _localPath = Path.Combine(FileSystem.AppDataDirectory, localFileName);
        }


        public async Task<List<Feed>> ReadFeedsAsync()
        {
            if (!File.Exists(_localPath))
                return new List<Feed>();

            using(var stream = File.OpenRead(_localPath))  
            {
                var feeds = await JsonSerializer.DeserializeAsync<List<Feed>>(stream);
                return feeds;
            }
        }

        public async Task SaveAsync(List<Feed> feeds)
        {
            using (var stream = File.OpenWrite(_localPath))
            {
               await JsonSerializer.SerializeAsync<List<Feed>>(stream, feeds);
            }
        }
    }
}
