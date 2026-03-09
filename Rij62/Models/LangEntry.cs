using Microsoft.EntityFrameworkCore;

namespace Rij62.Models;

/// <summary>
/// Entry in the language table of the db
/// </summary>
[Keyless]
public class LangEntry
{
    public string key {get; set;}
    public string Value {get; set;}
    public Language Language {get; set;}
}