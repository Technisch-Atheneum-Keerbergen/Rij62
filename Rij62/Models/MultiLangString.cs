namespace Rij62.Models;

public enum Language
{
    Dutch,
    English,
}

public class MultiLangString : Dictionary<Language, string>
{
    public MultiLangString() : base() { }
    public MultiLangString(IDictionary<Language, string> languages) : base(languages) { }


}