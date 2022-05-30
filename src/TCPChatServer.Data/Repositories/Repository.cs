using TCPChatServer.Core.Models;
using TCPChatServer.Core.Repositories;

namespace TCPChatServer.Data.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected TCPChatServerContext Context;

    public Repository(TCPChatServerContext context)
    {
        Context = context;
    }

    public void Add(T entity)
    {
        Context.Set<T>()?.Add(entity);
    }

    public void Remove(T entity)
    {
        Context.Set<T>()?.Remove(entity);
    }
}