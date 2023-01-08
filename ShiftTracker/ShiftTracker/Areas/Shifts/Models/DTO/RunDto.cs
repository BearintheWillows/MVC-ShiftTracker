namespace ShiftTracker.Areas.Shifts.Models.DTO;

using System.Collections;
using System.Data.SqlTypes;
using Azure.Core;
using Data.Models;

public class RunDto
{
	public int Id     { get; set; }
	public int  Number { get; set; }
	public TimeSpan StartTime { get; set; }
	
	public IEnumerable<DailyRoutePlanDto>? DailyRoutes { get; set; }

	public static IEnumerable<RunDto> CreateDtoList(List<Run> run, bool includeDrp)
	{
		IEnumerable<RunDto> runDto = run.Select( r => new RunDto
				{
				Id = r.Id,
				Number = r.Number,
				StartTime = r.StartTime,
				DailyRoutes = includeDrp
					? r.RoutePlans.Select( dr => new DailyRoutePlanDto
							{
							Id = dr.Id,
							DayOfWeek = dr.DayOfWeek,
							Shop = r.RoutePlans.Select( s => new ShopDto
									{
									Id = s.Shop.Id,
									Name = s.Shop.Name,
									Number = s.Shop.Number,
									Street = s.Shop.Street,
									Street2 = s.Shop.Street2,
									City = s.Shop.City,
									Postcode = s.Shop.Postcode,
									PhoneNumber = s.Shop.PhoneNumber,
									}
							)
							}
					).ToList()
					: null,
				}
		);

		return runDto;
	}

	public static RunDto CreateDto(Run run, bool includeDrp)
	{
		RunDto runDto = new RunDto
			{
			Id = run.Id,
			Number = run.Number,
			StartTime = run.StartTime,
			DailyRoutes = includeDrp
				? run.RoutePlans.Select( dr => new DailyRoutePlanDto
						{
						Id = dr.Id,
						DayOfWeek = dr.DayOfWeek,
						Shop = run.RoutePlans.Select( s => new ShopDto
								{
								Id = s.Shop.Id,
								Name = s.Shop.Name,
								Number = s.Shop.Number,
								Street = s.Shop.Street,
								Street2 = s.Shop.Street2,
								City = s.Shop.City,
								Postcode = s.Shop.Postcode,
								PhoneNumber = s.Shop.PhoneNumber,
								}
						)
						}
				).ToList()
				: null,
			};
		return runDto;
	}
}
