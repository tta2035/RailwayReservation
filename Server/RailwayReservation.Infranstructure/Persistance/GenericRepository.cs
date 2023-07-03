using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RailwayReservation.Application.Common.Interfaces;
using RailwayReservation.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCore.Extensions;

namespace RailwayReservation.Infranstructure.Persistance;

public class GenericRepository<T, DTO> : IGenericRepository<T, DTO>
    where T : class
    where DTO : class
{
    protected readonly RailwayReservationDbContext _context;
    protected DbSet<T> table = null;

    public GenericRepository() { }

    public GenericRepository(RailwayReservationDbContext context)
    {
        if (context is null)
            throw new ArgumentNullException("context is null");
        _context = context;
        table = _context.Set<T>();
    }

    public async Task<int> Delete(Guid id)
    {
        var filteredData = await this.getById(id);
        table.Remove(filteredData);
        return await _context.SaveChangesAsync();
    }

    public virtual async Task<List<DTO>> GetAll()
    {
        return null;
        //return await table.ToListAsync();
    }

    public virtual async Task<T?> getById(Guid id)
    {
        //var entityType = _context.Model.FindEntityType(typeof(T));
        //var primaryKeyProperty = entityType.FindPrimaryKey().Properties.FirstOrDefault();
        //var primaryKeyColumnName = primaryKeyProperty?.GetColumnName();

        //var sql = $"SELECT * FROM Passenger WHERE {primaryKeyColumnName} = @id";
        //return await table.FromSqlRaw(sql, new SqlParameter("@id", id)).FirstOrDefaultAsync();
        var s = await table.FindAsync(id);
        return s;
    }

    public async Task<T> Insert(T obj)
    {
        var result = table.Add(obj);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<int> CheckSaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Save()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task<int> Update(T obj)
    {
        table.Update(obj);
        return await _context.SaveChangesAsync();
    }

    public virtual Task<DTO?> GetResponseById(Guid id)
    {
        throw new NotImplementedException();
    }
}
