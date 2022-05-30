namespace TCPChatServer.Core.Repositories;

public interface IRepository<T>
{
    void Add(T entity);
    void Remove(T entity);
}