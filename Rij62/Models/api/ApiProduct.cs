using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace Rij62.Models.Api;

public class ApiProduct
{

    public required int Id {get; set;}

    public required MultiLangString Title {get; set;}
    public required MultiLangString Description {get; set;}
    public required int Price {get; set;}
    public required int Stock {get; set;}

    public required bool IsAvailible {get; set;}
    public required string ImgURL {get; set;}
    public required int CategoryId {get; set;}
}


