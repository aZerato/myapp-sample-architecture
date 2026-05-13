using MyApp.Domain.SampleModule.Aggregates;
using MyApp.Domain.DTO;

/// <inheritdoc cref="ISecondaryBasicSampleService"/>
public class SecondaryBasicSampleService 
    : ISecondaryBasicSampleService
{
    IUnitOfWork _unitOfWork;

    /// <summary>
    /// Default SecondaryBasicSampleService constructor.
    /// </summary>
    public SecondaryBasicSampleService(
            IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetById(int)" />
    public SampleDataDTO? GetById(int ID)
    {
        var data = _unitOfWork.SampleDataRepository
            .GetById(ID);

        if (data == null)
            return null;

        return new SampleDataDTO()
        {
            ID = data.ID,
            Status = EnumExtensions.GetDescription(data.Status),
            Title = data.Title
        };
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetAll" />
    public IEnumerable<SampleDataDTO> GetAll()
    {
        return _unitOfWork.SampleDataRepository
            .GetAll(SampleDataSelectBuilder.SelectSampleData());
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetAll" />
    public void Add(SampleDataDTO sampleDataDTO)
    {
        Enum.TryParse<SampleDataStatus>(sampleDataDTO.Status, out var status);

        _unitOfWork.SampleDataRepository
            .Add(new SampleData
            {
                Status = status,
                Title = sampleDataDTO.Title
            });

        _unitOfWork.SaveChanges();
    }
}