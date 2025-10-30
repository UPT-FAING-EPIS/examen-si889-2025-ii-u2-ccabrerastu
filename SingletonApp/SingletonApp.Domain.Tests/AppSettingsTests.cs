using NUnit.Framework;
using SingletonApp.Domain;

namespace SingletonApp.Domain.Tests
{
    [TestFixture]
    public class AppSettingsTests
    {
        [Test]
        public void Instance_ShouldReturnSameInstance_WhenCalledMultipleTimes()
        {
            // Arrange & Act
            var instance1 = AppSettings.Instance;
            var instance2 = AppSettings.Instance;

            // Assert
            Assert.That(instance2, Is.SameAs(instance1));
        }

        [Test]
        public void Instance_ShouldHaveCorrectInitialValues()
        {
            // Arrange
            var instance = AppSettings.Instance;

            // Assert
            Assert.That(instance.Environment, Is.EqualTo("Development"));
            Assert.That(instance.ApiBaseUrl, Is.EqualTo("https://localhost"));
        }

        [Test]
        public void GetSummary_ShouldReturnCorrectFormat()
        {
            // Arrange
            var instance = AppSettings.Instance;

            // Act
            var summary = instance.GetSummary();

            // Assert
            Assert.That(summary, Is.EqualTo("Environment: Development, API Base URL: https://localhost"));
        }
    }
}