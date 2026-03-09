namespace Rij62.Models;

public enum Language
{
    Enlish,
    Dutch,
}

public class MultiLangString : Dictionary<Language, string>
{
    public MultiLangString(IDictionary<Language, string> languages) : base(languages) {}
    public static MultiLangString FromLangEntryKey(LangEntry[] language, string key)
    {
        var languages = language.Where((l)=>l.key==key);
        return new MultiLangString(languages.ToDictionary((l)=>l.Language, (l)=>l.Value));
    }
}