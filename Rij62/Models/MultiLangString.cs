
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Rij62.Models;

public enum Language
{
    Enlish,
    Dutch,
}

public class MultiLangString : Dictionary<Language, string>
{
    public MultiLangString(IDictionary<Language, string> languages) : base(languages) {}
}