# TCP Chat Server
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-blue?style=flat&logo=linkedin&labelColor=blue")](https://www.linkedin.com/in/andr%C3%A9-terra-2a7728145/)

![](https://github.com/AndreTerra5348/tcp-chat-server/actions/workflows/ci.yml/badge.svg)

## Introduction
A Worker-Service TCP chat server written in C# with .Net 6.0, using mvc approach, sockets, dependency injection, Serilog and FluentValidation

## Project Breakdown:
- ### Core
    - Models
    - Events
    - Provides Interfaces
    - Repositories Interfaces
    - Services Interfaces

- ### Core.Command
    - Models
    - Attributes
    - Factories Interfaces
    - Parsers Interfaces
    - Resolvers Interfaces
    - Services Interfaces

- ### Data Layer
    - Repositories Implementations
    - Unit of Work Implementations

- ### Service Layer
    - Services Implementations

- ### API
    - Controllers
    - Providers
    - Validators
    - Entry Point

## Diagrams
### Projects Dependency
<img src="docs\diagrams\project-dependency.svg" alt="project-dependency" width="100%">

### Core
<img src="docs\diagrams\core-project.svg" alt="core" width="100%">

### Core.Command
<img src="docs\diagrams\core.command-project.svg" alt="core.command" width="100%">

### Command
<img src="docs\diagrams\command-project.svg" alt="command" width="100%">

### Service
<img src="docs\diagrams\service-project.svg" alt="service" width="100%">

### Data
<img src="docs\diagrams\data-project.svg" alt="data" width="100%">

### API
<img src="docs\diagrams\api-project.svg" alt="api" width="100%">


## TODO
- [ ] Add unit tests
- [x] Add CI
- [ ] Add more commands
- [x] Add Diagrams
    - [x] Project Dependency Diagram
    - [x] Core Project Diagram
    - [x] Command.Core Project Diagram
    - [x] Command Project Diagram
    - [x] Data Project Diagram
    - [x] Service Project Diagram
    - [x] API Project Diagram


## Built with
- .Net 6.0
- Sockets
- [Microsoft.Extensions.Hosting](https://docs.microsoft.com/en-us/dotnet/core/extensions/generic-host)
- [Microsoft.Extensions.DependencyInjection](https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [Serilog](https://serilog.net/)
- [FluentValidation](https://fluentvalidation.net/)

## Getting Started

1. Clone the repository

```bash
git clone 
```

2. Install the dependencies

```bash
dotnet restore
```

3. Run the application

```bash
cd src/TcpChatServer.Api
dotnet run
```

## Acknowledgments and Resources
- [Microsoft TCP Services Docs](https://docs.microsoft.com/en-us/dotnet/framework/network-programming/using-tcp-services)
- [Microsoft .NET Generic Host Doc](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-6.0)
- [Serilog.net](https://serilog.net/)
- [datalust Serilog Article](https://blog.datalust.co/using-serilog-in-net-6/)

## License
Distributed under the MIT License. See LICENSE for more information.

## Author
[André Terra](https://www.linkedin.com/in/andr%C3%A9-terra-2a7728145/)