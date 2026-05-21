namespace Rij62.Models.Api;

public class ApiCreateCategoryRequest
{
    public required MultiLangString Name { get; set; }
    public required RootCategory RootCategory { get; set; }
    public required string ImgUrl { get; set; }
}


