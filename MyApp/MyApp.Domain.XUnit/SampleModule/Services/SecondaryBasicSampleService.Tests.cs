using AutoFixture;
using Moq;
using MyApp.Domain.DTO;
using MyApp.Domain.XUnit.Fixtures;
using System.Linq.Expressions;

namespace MyApp.Domain.XUnit.SampleModule.Services;

public class SecondaryBasicSampleServiceTests
{
    [Fact]
    public void GetById_ObjectExist_ReturnsObjectDTO()
    {
        // Arrange
        var repoMock = new Mock<ISampleDataRepository>();
        var uowMock = new Mock<IUnitOfWork>();

        var id = AutoFixtureConfiguration.Fixture.Create<int>();
        var data = AutoFixtureConfiguration.Fixture.Build<SampleData>()
                          .With(x => x.ID, id)
                          .Create();

        repoMock.Setup(r => r.GetById(id))
                .Returns(data);

        uowMock.Setup(u => u.SampleDataRepository)
               .Returns(repoMock.Object);

        var svc = new SecondaryBasicSampleService(uowMock.Object);

        // Act
        var result = svc.GetById(id);

        // Assert
        Assert.NotNull(result);

        Assert.Equal(data.ID, result.ID);
        Assert.Equal(data.Title, result.Title);
        Assert.Equal(data.Status.GetDescription(), result.Status);

        repoMock.Verify(r => r.GetById(id), Times.Once);
    }

    [Fact]
    public void GetById_ObjectNotExist_ReturnsNull()
    {
        // Arrange
        var repoMock = new Mock<ISampleDataRepository>();
        var uowMock = new Mock<IUnitOfWork>();

        var id = AutoFixtureConfiguration.Fixture.Create<int>();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        repoMock.Setup(r => r.GetById(id))
                .Returns((SampleData?)null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        uowMock.Setup(u => u.SampleDataRepository)
               .Returns(repoMock.Object);

        var svc = new SecondaryBasicSampleService(uowMock.Object);

        // Act
        var result = svc.GetById(id);

        // Assert
        Assert.Null(result);

        repoMock.Verify(r => r.GetById(id), Times.Once);
    }


    [Fact]
    public void GetAll_ObjectsExist_ReturnsObjectDTOs()
    {
        // Arrange
        var repoMock = new Mock<ISampleDataRepository>();
        var uowMock = new Mock<IUnitOfWork>();

        var datas = AutoFixtureConfiguration.Fixture.CreateMany<SampleDataDTO>(10).ToList();

        repoMock.Setup(r =>
            r.GetAll(It.IsAny<Expression<Func<SampleData, SampleDataDTO>>>()))
            .Returns(datas);

        uowMock.Setup(u => u.SampleDataRepository)
               .Returns(repoMock.Object);

        var svc = new SecondaryBasicSampleService(uowMock.Object);

        // Act
        var results = svc.GetAll().ToList();

        // Assert
        Assert.Equal(datas.Count, results.Count);

        foreach (var res in results)
        {
            var dataOri = datas.Single(x => x.ID == res.ID);

            Assert.Equal(dataOri.Title, res.Title);
            Assert.Equal(dataOri.Status, res.Status);
        }

        repoMock.Verify(r =>
            r.GetAll(It.IsAny<Expression<Func<SampleData, SampleDataDTO>>>()),
            Times.Once);
    }

    [Fact]
    public void Add_Should_Call_Repository_And_SaveChanges()
    {
        // Arrange
        var repo = AutoFixtureConfiguration.Fixture
            .Freeze<Mock<ISampleDataRepository>>();
        var uow = AutoFixtureConfiguration.Fixture
            .Freeze<Mock<IUnitOfWork>>();

        uow.Setup(x => x.SampleDataRepository)
               .Returns(repo.Object);

        var statuses = Enum.GetValues<SampleDataStatus>();

        var dto = AutoFixtureConfiguration.Fixture
            .Build<SampleDataDTO>()
            .With(x => x.Status,
                statuses[new Random().Next(statuses.Length)].GetDescription())
            .Create();

        // Act
        var svc = AutoFixtureConfiguration.Fixture
            .Create<SecondaryBasicSampleService>();
        svc.Add(dto);

        // Assert
        repo.Verify(x => x.Add(It.Is<SampleData>(s =>
            s.Title == dto.Title &&
            EnumExtensions.GetDescription(s.Status) == dto.Status
        )), Times.Once);

        uow.Verify(x => x.SaveChanges(), Times.Once);
    }
}
