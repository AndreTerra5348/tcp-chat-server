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

### Projects Dependency Diagram
<img src="docs\diagrams-img\project-dependency.svg" alt="project-dependency" width="80%">

### Core Project Diagram
<img src="docs\diagrams-img\core-project.svg" alt="core-project" width="80%">

### Data Project Diagram
<img src="docs\diagrams-img\data-project.svg" alt="data-project" width="80%">


## TODO
- [ ] Add unit tests
- [x] Add CI
- [ ] Add more commands
- [ ] Add Diagrams
    - [x] Project Dependency Diagram
    - [x] Core Project Diagram
    - [ ] Command.Core Project Diagram
    - [ ] Command Project Diagram
    - [x] Data Project Diagram
    - [ ] Service Project Diagram
    - [ ] API Project Diagram


## Built with
- .Net 6.0
- Dependency Injection
- Serilog
- FluentValidation

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