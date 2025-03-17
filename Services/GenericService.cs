using Microsoft.EntityFrameworkCore;
using Aflevering_2.Models;
using Aflevering_2;

public class GenericService<T> where T : class
{
    protected readonly ExperienceDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericService(ExperienceDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task addAsync(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, T entity)
    {
        // _context.Entry(entity).State = EntityState.Modified;
        var currentEntity = await GetByIdAsync(id);
        currentEntity = entity;
        _dbSet.Update(currentEntity);

        await _context.SaveChangesAsync();
    }

    /*
         public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    */

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}

/*
public class UserService : GenericService<User>
{
    public UserService(AppDbContext context) : base(context) { }
}
*/