namespace SingletonApp.Domain
{
    public sealed class AppSettings
    {
        private static readonly AppSettings _instance = new AppSettings("Development", "https://localhost");

        public static AppSettings Instance => _instance;

        public string Environment { get; private set; }
        public string ApiBaseUrl { get; private set; }

        private AppSettings(string environment, string apiBaseUrl)
        {
            Environment = environment;
            ApiBaseUrl = apiBaseUrl;
        }

        public string GetSummary()
        {
            return $"Environment: {Environment}, API Base URL: {ApiBaseUrl}";
        }
    }
}
