
namespace Rij62.Models.Api;

public class ApiPutStep
{
    public required MultiLangString Title { get; set; }

    public required bool MultipleChoice {get; set;}
    public int? DefaultOptionId {get; set;}
    public required List<int> Options { get; set; }
}