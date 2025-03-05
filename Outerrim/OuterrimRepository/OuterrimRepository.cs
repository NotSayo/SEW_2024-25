using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Model;

namespace OuterrimRepository;


public class OuterrimRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private OuterrimContext _context;
    private DbSet<TEntity> Entity { get; set; }

    public OuterrimRepository(OuterrimContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }

    public async Task<TEntity> CreateAsync(TEntity t)
    {
        var result = await Entity.AddAsync(t);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<List<TEntity>> CreateRangeAsync(List<TEntity> list)
    {
        await Entity.AddRangeAsync(list);
        await _context.SaveChangesAsync();
        return list;
    }

    public async Task UpdateAsync(int id, TEntity t)
    {
        var entity = await Entity.FindAsync(id);
        _context.Entry(entity!).CurrentValues.SetValues(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity t)
    {
        _context.Entry(t).CurrentValues.SetValues(t);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(List<TEntity> list)
    {
        Entity.UpdateRange(list);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> ReadAsync(int id)
    {
        return await Entity.FindAsync(id);
    }

    public async Task<List<TEntity>> ReadAsync(int start, int count)
    {
        return await Entity.Skip(start).Take(count).ToListAsync();
    }

    public Task<List<TEntity>> ReadAllAsync()
    {
        return Entity.ToListAsync();
    }


    public async Task DeleteAsync(int id, TEntity t)
    {
        var entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await Entity.FindAsync(id);
        Entity.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity t)
    {
        Entity.Remove(t);
        await _context.SaveChangesAsync();
    }

    public Task DeleteRangeAsync(List<TEntity> list)
    {
        Entity.RemoveRange(list);
        return _context.SaveChangesAsync();
    }
}