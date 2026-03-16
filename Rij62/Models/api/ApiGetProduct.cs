namespace Rij62.Models.Api;

public class ApiGetProduct
{

    public required int Id {get; set;}

    public required MultiLangString Title {get; set;}
    public required MultiLangString Description {get; set;}
    public required int Price {get; set;}
    public required int Btw {get; set;}
    public required int Stock {get; set;}

    public required bool IsAvailable {get; set;}
    public required string ImgURL {get; set;}
    public required int CategoryId {get; set;}
}


