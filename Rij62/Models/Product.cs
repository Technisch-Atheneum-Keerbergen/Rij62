// **********************************
//     *** Product Model Test  ***
// Author: Xavier Demaerel
// Date: 03/03/2026
// File: Rij26/models/Product.cs
// **********************************

using System.ComponentModel.DataAnnotations;
using Rij62.Models.Api;

namespace Rij62.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    public required string TitleKey { get; set; }
    public required string DescriptionKey { get; set; }
    public required int PriceCent { get; set; }
    public required int Btw { get; set; }
    public int Stock { get; set; }
    public bool IsAvailable { get; set; }
    public required string ImgUrl { get; set; }
    public int CategoryId { get; set; }

    public IEnumerable<ProductStep>? Steps { get; set; }


    public static Product FromApiPutProduct(ApiPutProduct apiProduct)
    {
        var descriptionKey = Localizer.UniqueKey("ProductDescription");
        var titleKey = Localizer.UniqueKey("ProductTitle");
        var createdProduct = new Product
        {
            Id = 0,
            TitleKey = titleKey,
            DescriptionKey = descriptionKey,
            PriceCent = apiProduct.Price,
            Btw = apiProduct.Btw,
            Stock = apiProduct.Stock,
            IsAvailable = apiProduct.IsAvailable,
            ImgUrl = apiProduct.ImgURL,
            CategoryId = apiProduct.CategoryId,
        };
        return createdProduct;
    }
}


