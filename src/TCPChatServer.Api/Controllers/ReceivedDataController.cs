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

    public ReceivedDataController(IDataService dataService, ICommandService commandService, ILogger<ReceivedDataController> logger)
    {
        _dataService = dataService;
        _commandService = commandService;
        _logger = logger;

        _dataService.Received += (s, e) => DataService_Received(e.Data);
    }

    private void DataService_Received(ReceivedData data)
    {
        var dataValidator = new ReceivedDataValidator();
        var dataValidationResult = dataValidator.Validate(data);

        _logger.LogInformation($"Received data Content: {data.Content} from {data.SenderId}");

        if (!dataValidationResult.IsValid)
        {
            var errors = String.Join(", ", dataValidationResult.Errors.Select(x => x.ErrorMessage));
            _dataService.Send(data.SenderId, $"Data validation failed: {errors}");
            _logger.LogError($"Data validation failed: {errors}");
            return;
        }

        _logger.LogInformation($"Received data: {data.Content}");

        _commandService.Receive(data);
    }
}