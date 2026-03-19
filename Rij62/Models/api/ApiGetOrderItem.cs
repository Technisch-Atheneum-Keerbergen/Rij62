
using Rij62.Services;

namespace Rij62.Models.Api;

public class ApiGetOrderItem
{
    public int Id { get; set; }
    public MultiLangString Title { get; set; }
    public MultiLangString Description { get; set; }
    public int Price { get; set; }
    public int Btw { get; set; }

    public static ApiGetOrderItem FromOrderItem(OrderItem orderItem, Localizer localizer)
    {
        return new ApiGetOrderItem
        {
            Id= orderItem.Id,
            Title = localizer.MultiLangStringByKey(orderItem.TitleKey),
            Description=localizer.MultiLangStringByKey(orderItem.DescriptionKey),
            Price=orderItem.Price,
            Btw=orderItem.Btw,
        };
    }
}

