using System.Text.Json.Serialization;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum RootCategory
{
    Food,
    Drinks,
    Shop
}
