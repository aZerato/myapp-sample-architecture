# Domain

- Use "module" conception : services interfaces with their implementation (Module : aggregates/services [DDD])

- DTO : Data Transfer Object (sample: MyApp.Domain.DTO.SampleDataDTO).

- "Select Builder" : Thanks to LINQ you are able to create custom expression for return directly an DTO (sample: MyApp.Domain.SampleModule.Aggregates.SampleDataSelectBuilder).