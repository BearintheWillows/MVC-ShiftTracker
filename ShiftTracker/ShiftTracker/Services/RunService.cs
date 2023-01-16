﻿namespace ShiftTracker.Services;

using Areas.Shifts.Models.DTO;
using Controllers;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

public interface IRunService : IBaseCrudService<Run>
{
	Task<List<Run>> GetAllAsync(bool includeDRP);
	Task<Run?>      GetAsync(int     id, bool includeDRP);
	Task<bool>      ExistsAsync(int  id);

	Task<List<Tuple<int, int>>> GetAllNumbersAndIds();
}

public class RunService : BaseCrudService<Run>, IRunService
{
	private readonly ApplicationDbContext _context;

	public RunService(ApplicationDbContext context) : base( context )
	{
		_context = context;
	}
	
	public async Task<List<Run>> GetAllAsync(bool includeDRP)
	{
		if ( includeDRP )
		{
			return await _context.Runs.Include( r => r.RoutePlans ).ThenInclude(r => r.Shop).ToListAsync(  );
		} else
		{
			return await _context.Runs.ToListAsync();
		}
	}
	
	public async Task<Run?> GetAsync(int id, bool includeDRP)
	{
		if ( !await ExistsAsync( id ) )
		{
			return null;
		} else
		{
			return await _context.Runs.AsQueryable()
            		                     .IncludeDailyDoutePlans(includeDRP)
            		                     .FirstOrDefaultAsync(s => s.Id == id);
		}
		
		
	}

	public async Task<bool> ExistsAsync(int id)
	{
		return await _context.Runs.AnyAsync( r => r.Id == id );
	}

	/// <summary>
	/// Returns a List of tuples containing the Run Id {0} and the Run Number {1}
	/// </summary>
	/// <returns>Tuple</returns>
	public async Task<List<Tuple<int, int>>> GetAllNumbersAndIds()
	{
		return await _context.Runs.Select( r => new Tuple<int, int>
			(r.Id, r.Number)).ToListAsync(  );
	}
}