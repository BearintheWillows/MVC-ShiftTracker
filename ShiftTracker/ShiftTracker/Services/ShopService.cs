namespace ShiftTracker.Services;

using Data;
using Data.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public interface IShopService : IBaseCrudService<Shop>
{
	Task<bool>              ExistsAsync(int  id);
	Task<IEnumerable<Shop>> GetAllShopsWithDayData();
}

public class ShopService : BaseCrudService<Shop>, IShopService
{
	private readonly ApplicationDbContext _context;
	public ShopService(ApplicationDbContext context) : base(context)
	{
		_context = context;
	}

	public async Task<bool> ExistsAsync( int id )
	{
		return await _context.Shops.AnyAsync( s => s.Id == id);
	}

	public async Task<IEnumerable<Shop>> GetAllShopsWithDayData()
	{
		return await _context.Shops.Include(s => s.DayVariants).ToListAsync();
	}
}