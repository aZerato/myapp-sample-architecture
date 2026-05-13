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

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetSampleData(int)" />
    SampleDataDTO ISecondaryBasicSampleService.GetSampleData(int ID)
    {
        var data = _unitOfWork.SampleDataRepository.GetById(ID);

        return new SampleDataDTO()
        {
            ID = data.ID,
            Status = EnumExtensions.GetDescription(data.Status),
            Title = data.Title
        };
    }

    /// <inheritdoc cref="ISecondaryBasicSampleService.GetAllSampleData" />
    IEnumerable<SampleDataDTO> ISecondaryBasicSampleService.GetAllSampleData()
    {
        return _unitOfWork.SampleDataRepository.GetAll(SampleDataSelectBuilder.SelectSampleData());
    }
}