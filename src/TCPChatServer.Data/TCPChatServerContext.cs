using TCPChatServer.Core.Models;

namespace TCPChatServer.Data;

public class TCPChatServerContext
{
    public List<User> Users { get; set; }
    public List<Client> Clients { get; set; }

    Dictionary<Type, object> _typeMap = new Dictionary<Type, object>();

    public TCPChatServerContext()
    {
        _typeMap.Add(typeof(User), Users = new List<User>());
        _typeMap.Add(typeof(Client), Clients = new List<Client>());
    }

    public List<T>? Set<T>() where T : class
    {
        if (_typeMap.ContainsKey(typeof(T)))
        {
            return _typeMap[typeof(T)] as List<T>;
        }
        throw new Exception($"Type {typeof(T)} not found in context");
    }

}