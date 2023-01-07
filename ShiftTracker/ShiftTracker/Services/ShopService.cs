namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public interface IShopService : IBaseCrudService<Shop>
{
	Task<bool>              ExistsAsync(int id);
	Task<IEnumerable<Shop>> GetAllShopsWithDayData();
	Task<Shop?>             GetShopWithDayData(int id);
}

public class ShopService : BaseCrudService<Shop>, IShopService
{
	private readonly ApplicationDbContext _context;
	public ShopService(ApplicationDbContext context) : base(context)
	{
		_context = context;
	}

	/// <summary>
	/// Checks if a shop with the given id exists
	/// </summary>
	/// <param name="id"></param>
	/// <returns>bool</returns>
	public async Task<bool> ExistsAsync( int id )
	{
		return await _context.Shops.AnyAsync( s => s.Id == id);
	}

	/// <summary>
	/// Get List of Shops with DayData
	/// </summary>
	/// <returns>List of Shops</returns>
	public async Task<IEnumerable<Shop>> GetAllShopsWithDayData()
	{
		return await _context.Shops.Include(s => s.DayVariants).ToListAsync();
	}
	
	/// <summary>
	/// Gets Singular Shop with Day data
	/// </summary>
	/// <param name="id"></param>
	/// <returns>Shop Entity</returns>
	public async Task<Shop?> GetShopWithDayData(int id)
	{
		return await _context.Shops.Include(s => s.DayVariants).FirstOrDefaultAsync(s => s.Id == id);
	}
}