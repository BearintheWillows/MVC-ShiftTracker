namespace ShiftTracker.Areas.Shifts.Models.DTO;

public class ShopDto
{
	public int?    Id      { get; set; }
	public string  Street  { get; set; }
	public string? Street2 { get; set; }
	public string  City    { get; set; }
	public string County { get; set; }
	public string Postcode { get; set; }
	public int PhoneNumber { get; set; }
	
	public ICollection<ShopDayVariantDto> ShopDayVariants { get; set; }
}