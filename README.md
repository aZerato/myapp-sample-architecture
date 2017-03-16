# Sample ASP .NET Architecture

Pattern [Domain-Driven Design](http://dddcommunity.org/) DDD

## 01 - Presentation

> Description : The user interface layer

## 02 - Domain

> Description : The data management layer

- Use "module" conception : services interfaces with their implementation (Module : aggregates/services [DDD])

- DTO : Data Transfer Object

- The [Specification Pattern](https://github.com/jnicolau/NSpecifications) (soon)


## 03 - Data

> Description : The data access layer 

- The [Repository Pattern](https://msdn.microsoft.com/en-us/library/ff649690.aspx)


## 04 - Infrastructure

> The app management layer

- CrossCutting : a layer can be used in all others
- The [Inversion Of Control](https://msdn.microsoft.com/en-us/library/ff921087.aspx)
- DI & [LifeTimeManager](https://msdn.microsoft.com/en-us/library/ff647854.aspx)

