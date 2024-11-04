namespace Shared.Abstractions;

public interface IGenericService<T>
{   
    Task<T> Add(T type);
    Task<T> Get(int id);
    Task<bool> Update(T type);
    Task<bool> Delete(int id);
    Task<List<T>> GetAll();
}
