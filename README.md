#Sample ASP .NET Architecture

Pattern (Domain-Driven Design)[http://dddcommunity.org/] DDD

## 01 - Presentation

Description : The user interface layer

In this sample is an WEB API but it can be an other type of project.

## 02 - Domain

Description : The data management layer

- Use "module" conception : service interfaces with their implementation

- DTO 

- The (Specification Pattern)[https://github.com/jnicolau/NSpecifications]


## 03 - Data

Description : The data access layer 

- The (Repository Pattern)[https://msdn.microsoft.com/en-us/library/ff649690.aspx]


## 04 - Infrastructure

Description : The app management layer

- CrossCutting : a project can be used with all others

- The (Inversion Of Control)[https://msdn.microsoft.com/en-us/library/ff921087.aspx]
	*	DI & LifeTimeManager : https://msdn.microsoft.com/en-us/library/ff647854.aspx

