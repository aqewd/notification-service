# Notification

<br/>

This is a solution template for creating a Notification emulator with .NET 5.

## Technologies

* [.NET 5](https://docs.microsoft.com/en-us/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-5.0)
* [MediatR](https://github.com/jbogard/MediatR)
* [FluentValidation](https://fluentvalidation.net/)
* [NUnit](https://nunit.org/), [FluentAssertions](https://fluentassertions.com/), [Moq](https://github.com/moq)
* [Docker](https://www.docker.com/)

## Getting Started

1. Install the latest [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
2. Navigate to `src/WebApi` and run `dotnet run` to launch the API (ASP.NET Core Web API)
3. Go To [swagger page](https://localhost:5001/swagger/index.html)

## Overview

### Domain

This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

### Application

This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, the application needed to access a notification service, a interface was added to application layer and an implementation was created within infrastructure.

### Infrastructure

This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.

### WebApi

This layer is a application based on .NET 5. This layer depends on both the Application and Infrastructure layers, however.
