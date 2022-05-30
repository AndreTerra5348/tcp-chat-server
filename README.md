# TCP Chat Server
[![License: MIT](https://img.shields.io/badge/License-MIT-green.svg)](https://opensource.org/licenses/MIT)
[![LinkedIn](https://img.shields.io/badge/LinkedIn-blue?style=flat&logo=linkedin&labelColor=blue")](https://www.linkedin.com/in/andr%C3%A9-terra-2a7728145/)

## Introduction
A Worker-Service TCP chat server written with .Net 6.0, using mvc approach, dependency injection, Serilog and FluentValidation

## Project Breakdown:
- ### Core
    - Interfaces
    - Models
    - Events
    - Provides
    - Repositories
    - Services

- ### Core.Command
    - Interfaces
    - Models
    - Attributes
    - Factories
    - Parsers
    - Resolvers
    - Services

- ### Data Layer
    - Implementations
    - Repositories
    - Unit of Work

- ### Service Layer
    - Implementations
    - Services

- ### API
    - Implementations
    - Controllers
    - Providers
    - Validators
    - Entry Point

## TODO
- [ ] Add unit tests
- [ ] Add CI
- [ ] Add more commands


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