using TCPChatServer.Core.Models;

namespace TCPChatServer.Core.Events;

public class ReceivedDataEventArgs : EventArgs
{
    public ReceivedData Data { get; }

    public ReceivedDataEventArgs(ReceivedData data)
    {
        Data = data;
    }
}