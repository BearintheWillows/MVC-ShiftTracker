namespace ShiftTracker.Services;

using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public abstract class BaseCrudService<T> : IBaseCrudService<T> where T : class
{
	public BaseCrudService(ApplicationDbContext context)
	{
		Context = context;
	}

	internal ApplicationDbContext Context { get;}

	public async Task<T?> GetAsync(int id)
	{
		return await Context.Set<T>().FindAsync(id);
	}

	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await Context.Set<T>().ToListAsync();
	}

	public async Task<T> AddAsync(T entity)
	{
		await Context.Set<T>().AddAsync( entity );
		await Context.SaveChangesAsync();
		return entity;
	}

	public async Task<T> UpdateAsync(T entity)
	{
		Context.Set<T>().Update( entity );
		await Context.SaveChangesAsync();
		return entity;
	}
	public async Task DeleteAsync(int id) 
	{
		var entity = await Context.Set<T>().FindAsync(id);
		Context.Set<T>().Remove(entity);
		await Context.SaveChangesAsync();
	}
}