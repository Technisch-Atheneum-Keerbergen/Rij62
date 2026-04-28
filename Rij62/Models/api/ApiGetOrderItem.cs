namespace Rij62.Models.Api;

public class ApiGetOrderItem
{
    public int Id { get; set; }
    public MultiLangString Title { get; set; }
    public MultiLangString Description { get; set; }
    public decimal Price { get; set; }
    public int Btw { get; set; }
    public string ImgUrl { get; set; }
    public required List<int> Choices { get; set; }
    public required OrderStatus Status { get; set; }
    public required int Quantity { get; set; }

    public static ApiGetOrderItem FromOrderItem(OrderItem orderItem, Localizer localizer)
    {
        if (orderItem.Choices == null)
        {
            throw new ArgumentNullException("OrderItem.Choices is null make shure you load it from the database");
        }

        return new ApiGetOrderItem
        {
            Id = orderItem.Id,
            ImgUrl = orderItem.ImgUrl,
            Title = localizer.MultiLangStringByKey(orderItem.TitleKey),
            Description = localizer.MultiLangStringByKey(orderItem.DescriptionKey),
            Price = orderItem.Price,
            Btw = orderItem.Btw,
            Choices = orderItem.Choices.Select((c) => c.ChosenProductId).ToList(),
            Status = orderItem.Status,
            Quantity = orderItem.Quantity
        };
    }
}

