# Sample ASP .NET Architecture

Pattern [Domain-Driven Design](http://dddcommunity.org/) DDD

## 01 - Presentation

> The user interface layer

## 02 - Domain

> The data management layer

- Use "module" conception : services interfaces with their implementation (Module : aggregates/services [DDD])

- DTO : Data Transfer Object (sample: MyApp.Domain.DTO.SampleDataDTO).

- The [Specification Pattern](https://github.com/jnicolau/NSpecifications) (soon).

- "Select Builder" : Thanks to LINQ you are able to create custom expression for return directly DTO (sample: MyApp.Domain.SampleModule.Aggregates.SampleDataSelectBuilder).

## 03 - Data

> The data access layer 

- Use EntityFramework with DbSet for link an object to a class object (sample: MyApp.Domain.SampleModule.Aggregates.SampleData).
- The [Unit Of Work (UnitOfWork) Pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html) add transactions for the resolution of concurrency problems (MyApp.Data.UnitOfWorkContext).
- The [Repository Pattern](https://msdn.microsoft.com/en-us/library/ff649690.aspx). 
The Repository Pattern add a layer between DbSet (return IQueryable) with UoW and the data uses in "Domain" layer. 
Queryable manipulation is sensible, a Repository return an Enumerable or an Entity. (MyApp.Data.Core.Repository && MyApp.Domain.Core.IRepository)


## 04 - Infrastructure

> The app management layer

- CrossCutting : a layer can be used in all others.
- The [Inversion Of Control](https://msdn.microsoft.com/en-us/library/ff921087.aspx).
- Dependancy Injection (DI) & [LifeTimeManager](https://msdn.microsoft.com/en-us/library/ff647854.aspx).

