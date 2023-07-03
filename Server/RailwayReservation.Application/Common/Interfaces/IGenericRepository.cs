using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Application.Common.Interfaces;

public interface IGenericRepository<T, DTO>
    where T : class
    where DTO : class
{
    Task<List<DTO>> GetAll();
    Task<T?> getById(Guid id);
    Task<DTO?> GetResponseById(Guid id);
    Task<T> Insert(T obj);
    Task<int> Update(T obj);
    Task<int> Delete(Guid id);
    Task<int> CheckSaveChangesAsync();
    Task<int> Save();
}
