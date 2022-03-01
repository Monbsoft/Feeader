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


        public async Task<List<string>> ReadFeedsAsync()
        {
            if (!File.Exists(_localPath))
                return new List<string>();
            var contents = await File.ReadAllTextAsync(_localPath);
            return null;
        }

        public Task SaveAsync(string feeds)
        {
           return File.WriteAllTextAsync(_localPath, feeds);
        }
    }
}
