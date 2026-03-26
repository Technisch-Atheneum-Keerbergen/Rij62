using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rij62.Services;

namespace Rij62.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public string TitleKey { get; set; }
        public string DescriptionKey { get; set; }
        public int Price { get; set; }
        public int Btw { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        public IEnumerable<OrderItemChoice> Choices { get; set; }


        public static async Task<OrderItem> FromProduct(Product product, LocalizationService localizationService, int OrderId)
        {
            var titleKey = Localizer.UniqueKey("OrderItemTitle");
            var descriptionKey = Localizer.UniqueKey("OrderItemDescription");
            await localizationService.CopyLanguageEntry(product.TitleKey, titleKey);
            await localizationService.CopyLanguageEntry(product.DescriptionKey, descriptionKey);
            return new OrderItem
            {
                Id = 0,
                TitleKey = titleKey,
                DescriptionKey = descriptionKey,
                Price = product.PriceCent,
                Btw = product.Btw,
                OrderId = OrderId,
            };
        }
    }
}
