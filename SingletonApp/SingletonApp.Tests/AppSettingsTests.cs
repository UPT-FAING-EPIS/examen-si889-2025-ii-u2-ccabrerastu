using Xunit;

public class AppSettingsTests
{
    [Fact]
    public void CrearConfiguracion_DeberiaRetornarResumenCorrecto()
    {
        AppSettings.ResetInstance();
        var settings = AppSettings.GetInstance("Producción", "https://api.miapp.com");

        var resumen = settings.GetSummary();

        Assert.Equal("Entorno: Producción, API: https://api.miapp.com", resumen);
    }

    [Fact]
    public void CambiarConfiguracion_DeberiaActualizarValores()
    {
        AppSettings.ResetInstance();
        var settings = AppSettings.GetInstance("Desarrollo", "http://localhost:5000");

        settings.Environment = "QA";
        settings.ApiBaseUrl = "https://qa.api.miapp.com";

        var resumen = settings.GetSummary();

        Assert.Equal("Entorno: QA, API: https://qa.api.miapp.com", resumen);
    }
}
