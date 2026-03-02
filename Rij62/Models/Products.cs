namespace Rij62.Models;

class Products
{
    public int Id { get; set; }
    public string TitleKey { get; set; }
    public string DescriptionKey { get; set; }
    public int PriceCent { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
    public string ImgUrl { get; set; }
    public int CategoryId { get; set; }
}