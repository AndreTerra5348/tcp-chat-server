using System.Text;
using FluentValidation;
using TCPChatServer.Api.Validators;
using TCPChatServer.Core.Command.Services;
using TCPChatServer.Core.Models;
using TCPChatServer.Core.Services;

namespace TCPChatServer.Api.Controllers;

public class ReceivedDataController
{
    private readonly IDataService _dataService;
    private readonly ICommandService _commandService;
    private readonly ILogger<ReceivedDataController> _logger;

    public ReceivedDataController(IDataService dataService,
        ICommandService commandService,
        ILogger<ReceivedDataController> logger)
    {
        _dataService = dataService;
        _commandService = commandService;
        _logger = logger;
    }

    public ReceivedData Create(Guid clientId, byte[] data)
    {
        _logger.LogInformation($"Creating data");
        var receivedData = new ReceivedData(clientId, Encoding.UTF8.GetString(data));
        var dataValidator = new ReceivedDataValidator();
        var dataValidationResult = dataValidator.Validate(receivedData);
        if (!dataValidationResult.IsValid)
        {
            var errorMessages = String.Join(", ", dataValidationResult.Errors.Select(x => x.ErrorMessage));
            _dataService.Send(receivedData.SenderId, $"Data validation failed: {errorMessages}");
            _logger.LogError($"Data validation failed: {errorMessages}");
            throw new ValidationException(dataValidationResult.Errors);
        }

        _logger.LogInformation($"Received data: {receivedData.Content}");
        return receivedData;
    }
}