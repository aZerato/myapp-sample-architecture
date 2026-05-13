using AutoFixture;
using MyApp.Domain.SampleModule.Services;
using MyApp.Domain.XUnit.Fixtures;

namespace MyApp.Domain.XUnit.SampleModule.Services;

public class BasicSampleServiceTests
{
    [Fact]
    public void IsAvailable_ReturnsTrue()
    {
        // Arrange

        // Act
        var svc = AutoFixtureConfiguration.Fixture
            .Create<BasicSampleService>();
        var result = svc.IsAvailable();

        // Assert
        Assert.True(result);
    }
}