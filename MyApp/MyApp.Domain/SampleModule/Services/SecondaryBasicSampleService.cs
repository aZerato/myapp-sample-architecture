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
    SampleDataDTO ISecondaryBasicSampleService.GetById(int ID)
    {
        var data = _unitOfWork.SampleDataRepository.GetById(ID);

        return new SampleDataDTO()
        {
            ID = data.ID,
            Status = EnumExtensions.GetDescription(data.Status),
            Title = data.Title
        };
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetAll" />
    IEnumerable<SampleDataDTO> ISecondaryBasicSampleService.GetAll()
    {
        return _unitOfWork.SampleDataRepository.GetAll(SampleDataSelectBuilder.SelectSampleData());
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetAll" />
    void ISecondaryBasicSampleService.Add(SampleDataDTO sampleDataDTO)
    {
        Enum.TryParse<SampleDataStatus>(sampleDataDTO.Status, out var status);

        _unitOfWork.SampleDataRepository.Add(new SampleData
        {
            Status = status,
            Title = sampleDataDTO.Title
        });

        _unitOfWork.SaveChanges();
    }
}