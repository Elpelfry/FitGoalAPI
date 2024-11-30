using Domain.DTO;

namespace Abstractions;

public interface IEjercicioService
{
    Task<EjerciciosDto> Add(EjerciciosDto ejercicio);
    Task<EjerciciosDto> Get(int id);
    Task<bool> Update(EjerciciosDto ejercicio);
    Task<bool> Delete(int id);
    Task<List<EjerciciosDto>> GetAll();
    Task<List<EjerciciosDto>> AddRange(List<EjerciciosDto> ejercicios);
}
