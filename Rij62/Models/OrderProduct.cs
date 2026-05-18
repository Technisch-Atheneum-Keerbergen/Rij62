using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Rij62.Services;

namespace Rij62.Models;


public class OrderProduct
{
    [Key]
    public required int Id { get; set; }
    public required int ProductId { get; set; }
    public required string TitleKey { get; set; }
    public required string DescriptionKey { get; set; }
    public required decimal Price { get; set; }
    public required int Btw { get; set; }
    public required string ImgUrl { get; set; }

    public static async Task<OrderProduct> FromProduct(Product product, LocalizationService localizationService)
    {
        var titleKey = Localizer.UniqueKey("OrderProductTitle");
        var descriptionKey = Localizer.UniqueKey("OrderProductDescription");
        await localizationService.CopyLanguageEntry(product.TitleKey, titleKey);
        await localizationService.CopyLanguageEntry(product.DescriptionKey, descriptionKey);
        return new OrderProduct
        {
            Id = 0,
            ProductId = product.Id,
            TitleKey = titleKey,
            DescriptionKey = descriptionKey,
            Price = product.Price,
            Btw = product.Btw,
            ImgUrl = product.ImgUrl,
        };
    }
}
