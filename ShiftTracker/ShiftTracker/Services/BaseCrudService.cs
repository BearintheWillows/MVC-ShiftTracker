namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public abstract class BaseCrudService<T> : IBaseCrudService<T> where T : class
{
	public BaseCrudService(ApplicationDbContext context)
	{
		Context = context;
	}

	internal ApplicationDbContext Context { get;}

	/// <summary>
	/// Gets singular entity of type T
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Single Entity</returns>
	public async Task<T?> GetAsync(int id)
	{
		return await Context.Set<T>().FindAsync(id);
	}

	/// <summary>
	/// Gets all entities of type T
	/// </summary>
	/// <returns>List of type T entities</returns>
	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await Context.Set<T>().ToListAsync();
	}

	/// <summary>
	/// Adds a new entity to the database
	/// </summary>
	/// <param name="entity"></param>
	/// <returns>Created Entity</returns>
	public async Task<T> AddAsync(T entity)
	{
		await Context.Set<T>().AddAsync( entity );
		await Context.SaveChangesAsync();
		return entity;
	}

	/// <summary>
	/// Updated entity in database
	/// </summary>
	/// <param name="entity"></param>
	/// <returns>Updated Entity</returns>
	public async Task<T> UpdateAsync(T entity)
	{
		Context.Set<T>().Update( entity );
		await Context.SaveChangesAsync();
		return entity;
	}
	
	/// <summary>
	/// Deletes entity from database by id
	/// </summary>
	/// <param name="id"></param>
	public async Task DeleteAsync(int id) 
	{
		var entity = await Context.Set<T>().FindAsync(id);
		Context.Set<T>().Remove(entity);
		await Context.SaveChangesAsync();
	}
}