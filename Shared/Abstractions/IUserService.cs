namespace Shared.Abstractions;

public interface IUserService<T>
{
    Task<T> Add(T type);
    Task<T> Get(string id);
    Task<bool> Update(T type);
    Task<bool> Delete(string id);
    Task<List<T>> GetListByUID(string UID);
}
