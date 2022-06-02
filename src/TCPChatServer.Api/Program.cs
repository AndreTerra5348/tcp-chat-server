using TCPChatServer.Api;
using TCPChatServer.Api.Controllers;
using TCPChatServer.Api.Providers;
using TCPChatServer.Command.Resolvers;
using TCPChatServer.Command.Parsers;
using TCPChatServer.Command.Services;
using TCPChatServer.Command.Commands;
using TCPChatServer.Command.Factories;
using TCPChatServer.Core;
using TCPChatServer.Core.Command.Resolvers;
using TCPChatServer.Core.Command.Parsers;
using TCPChatServer.Core.Command.Services;
using TCPChatServer.Core.Command.Factories;
using TCPChatServer.Core.Command;
using TCPChatServer.Core.Providers;
using TCPChatServer.Core.Services;
using TCPChatServer.Data;
using TCPChatServer.Service;
using Serilog;


Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");


try
{
    IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<EntryPoint>();

        services.AddTransient<ITCPListenerProvider, TCPListenerProvider>();

        services.AddSingleton<IConnectionService, ConnectionService>();

        services.AddScoped<IDataService, DataService>();
        services.AddScoped<ICommandResolver, CommandResolver>();

        services.AddTransient<ICommandParser, CommandParser>();

        services.AddTransient<ICommandValidatorFactory, CommandValidatorFactory>();

        services.AddScoped<ICommandService, CommandService>();

        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<TCPChatServerContext>();

        services.AddScoped<ClientController>();
        services.AddScoped<ReceivedDataController>();
        services.AddScoped<CommandController>();

        services.AddTransient<ICommand, NameCommand>();
        services.AddTransient<ICommand, BroadcastCommand>();
    })
    .UseSerilog((context, configuration) =>
    {
        configuration
            .ReadFrom.Configuration(context.Configuration)
            .Enrich.FromLogContext()
            .WriteTo.Console();
    })
    .Build();

    await host.RunAsync();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down");
    Log.CloseAndFlush();
}

