namespace ShiftTracker.Controllers;

using Areas.Shifts.Models.DTO;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Services;

[ApiController, Route( "api/shops" )]
public class ShopApiController : ControllerBase
{
	private readonly IShopService _shopService;

	public ShopApiController(IShopService shopService)
	{
		_shopService = shopService;
	}
	[HttpGet]
	public async Task<ActionResult<List<ShopDto>>> GetAllShifts([FromQuery] bool includeDayData = false)
	{
		var shops = new List<Shop>();
		try
		{
			switch ( includeDayData )
			{
			case true:
				shops = await _shopService.GetAllShopsWithDayData() as List<Shop>;
				break;
			default:
				shops = await _shopService.GetAllAsync() as List<Shop>;
				break;

			}

			if ( shops.Count == 0 )
			{
				return NotFound();
			}

			var shopResultDto = shops.Select( s => new ShopDto
					{
					Id = s.Id,
					Name = s.Name,
					Number = s.Number,
					Street = s.Street,
					Street2 = s.Street2,
					City = s.City,
					County = s.County,
					Postcode = s.Postcode,
					PhoneNumber = s.PhoneNumber,
					DayVariants = includeDayData
						? s.DayVariants.Select( dv => new DayVariantDto
								{
								Id = dv.Id,
								ShopId = dv.ShopId,
								DayOfWeek = dv.DayOfWeek,
								WindowOpenTime = dv.WindowOpenTime,
								WindowCloseTime = dv.WindowCloseTime,
								RunId = dv.RunId
								}
						).ToList()
						: null,
					}
			).ToList();

			return Ok( shopResultDto );
		}
		catch ( Exception e )
		{
			Log.Error( e, "Error getting shifts" );
			Console.WriteLine( e );
			return BadRequest();
		}
	}

	[HttpGet("{id}")]
	 public async Task<IActionResult> GetShiftById(int id, [FromQuery] bool includeDayData = false)
	 {
	 	try
	    {
		    Shop? shopResultAsync;

		    if ( includeDayData == true )
		    {
			    shopResultAsync = await _shopService.GetShopWithDayData( id );
		    }
		    else
		    {
			    shopResultAsync = await _shopService.GetAsync( id );
		    }
		    
	 		if ( shopResultAsync == null )
	 		{
	 			return new NotFoundResult();
	 		}
	 		
	 		var shopDto = new ShopDto
	 		{
	 			Id = shopResultAsync.Id,
				Name = shopResultAsync.Name,
				Number = shopResultAsync.Number,
	 			Street = shopResultAsync.Street,
	 			Street2 = shopResultAsync.Street2,
	 			City = shopResultAsync.City,
	 			County = shopResultAsync.County,
	 			Postcode = shopResultAsync.Postcode,
	 			PhoneNumber = shopResultAsync.PhoneNumber,
	 			DayVariants = includeDayData
	 				? shopResultAsync.DayVariants.Select(
	 					dv => new DayVariantDto
	 						{
	 						Id = dv.Id,
	 						ShopId = dv.ShopId,
	 						DayOfWeek = dv.DayOfWeek,
	 						WindowOpenTime = dv.WindowOpenTime,
	 						WindowCloseTime = dv.WindowCloseTime,
	 						RunId = dv.RunId
	 						}
	 				).ToList()
	 				: null,
	 		};
	 		
	 		return Ok( shopDto );
	 	}
	 	catch ( Exception e )
	 	{
	 		Log.Error( e, "Error getting shifts" );
	 		Console.WriteLine( e );
	 		return BadRequest("Error getting shifts");
	 	}
	 }
	
	 [HttpDelete("{id}")]
	 public async Task<IActionResult> DeleteShiftById(int id)
	 {
	 	try
	    {
		    if ( await _shopService.ExistsAsync( id ) == false )
	 		{
	 			return NotFound("No Shops found with that ID");
	 		}

		    await _shopService.DeleteAsync( id );
		    
		    return Ok( "Deleted Successfully" );
	 	}
	 	catch ( Exception e )
	 	{
	 		Log.Error( e, "Error getting shifts" );
	 		Console.WriteLine( e );
	 		return BadRequest("Error deleting shop");
	 	}
	 }

	 [HttpPost]
	 public async Task<IActionResult> CreateShop([FromBody] ShopDto shopDto)
	 {
		 
		 try
		 {
			 if ( await _shopService.IsNameAndNumberUnique( shopDto ) )
			 {
				 return BadRequest("Shop Name and Number must be unique");
			 }
			 
			 Shop shop = new Shop
				 
				 {
				 Id = shopDto.Id,
				 Name = shopDto.Name,
				 Street = shopDto.Street,
				 Street2 = shopDto.Street2,
				 City = shopDto.City,
				 County = shopDto.County,
				 Postcode = shopDto.Postcode,
				 PhoneNumber = shopDto.PhoneNumber,
				 DayVariants = new List<DayVariant>()
				 };

			 await _shopService.UpdateAsync(  shop );

			 return Ok(shop);
		 }
		 catch ( Exception e )
		 {
			 Log.Error( e, "Error getting shifts" );
			 Console.WriteLine( e );
			 return BadRequest("Error creating shop");
		 }
	 }
}
