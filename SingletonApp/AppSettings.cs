public class AppSettings
{
    private static AppSettings _instance;
    private static readonly object _lock = new object();

    public string Environment { get; set; }
    public string ApiBaseUrl { get; set; }

    private AppSettings(string environment, string apiBaseUrl)
    {
        Environment = environment;
        ApiBaseUrl = apiBaseUrl;
    }

    public static AppSettings GetInstance(string environment = "Producción", string apiBaseUrl = "https://api.miapp.com")
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new AppSettings(environment, apiBaseUrl);
                }
            }
        }
        return _instance;
    }

    public string GetSummary()
    {
        return $"Entorno: {Environment}, API: {ApiBaseUrl}";
    }

    public static void ResetInstance()
    {
        _instance = null;
    }
}
