namespace Rij62.Models;

public class Product
{
    public int Id { get; set; }
    public required string TitleKey { get; set; }
    public required string DescriptionKey { get; set; }
    public required int PriceCent { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
    public required string ImgUrl { get; set; }
    public int CategoryId { get; set; }
}