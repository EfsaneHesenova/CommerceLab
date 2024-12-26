using Ecommerce.Core.Entities.Base;
using Ecommerce.DAL.DAL;
using Ecommerce.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Implementations;

public class GenericRepository<Tentity> : IGenericRepository<Tentity> where Tentity : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }
    DbSet<Tentity> table => _context.Set<Tentity>();

    public Task<Tentity> CreateAsync(Tentity entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Tentity entity)
    {
        throw new NotImplementedException();
    }

    public async Task<ICollection<Tentity>> GetAllAsync()
    {
        return await
    }

    public Task<Tentity> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void SoftDelete(Tentity entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Tentity entity)
    {
        throw new NotImplementedException();
    }
}
