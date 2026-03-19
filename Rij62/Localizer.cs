
using Rij62.Models;

namespace Rij62;

public class Localizer
{
    LangEntry[] _entries;

    public Localizer(LangEntry[] entries)
    {
        _entries = entries;
    }

    public MultiLangString MultiLangStringByKey(string key)
    {
        var languages = _entries.Where((l)=>l.Key==key);
        return new MultiLangString(languages.ToDictionary((l)=>l.Language, (l)=>l.Value));
    }

}