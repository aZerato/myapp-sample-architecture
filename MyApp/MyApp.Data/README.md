# Data

The data access layer 

- Use EntityFramework (EF) with DbSet/Annotations for link a SQL/Table to a class/object (sample: MyApp.Domain.SampleModule.Aggregates.SampleData).
- The [Unit Of Work (UnitOfWork / UoW) Pattern](https://martinfowler.com/eaaCatalog/unitOfWork.html) add transactions for the resolution of concurrency problems (MyApp.Data.UnitOfWorkContext).
- The [Repository Pattern](https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application) add a layer between DbSet (return IQueryable) with UoW and the data used in "Domain" layer. 
Queryable manipulation is sensible, a Repository return an Enumerable or an Entity. (MyApp.Data.Core.Repository && MyApp.Domain.Core.IRepository)
