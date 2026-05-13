using AutoFixture;
using AutoFixture.AutoMoq;

namespace MyApp.Domain.XUnit.Fixtures;

public static class AutoFixtureConfiguration
{
    static Fixture? _fixture;
    public static Fixture Fixture
    {
        get
        {
            if (_fixture == null)
            {
                _fixture = (Fixture)new Fixture()
                    .Customize(new AutoMoqCustomization());

                _fixture.Behaviors.OfType<ThrowingRecursionBehavior>()
                    .ToList()
                    .ForEach(b => _fixture.Behaviors.Remove(b));

                _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            }

            return _fixture;
        }
    }
}
