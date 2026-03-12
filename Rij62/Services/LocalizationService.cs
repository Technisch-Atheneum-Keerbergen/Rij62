
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services
{
    public class LocalizationService
    {

        private readonly AppDbContext _context;

        public LocalizationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task DeleteLanguageEntry(string key)
        {
            await _context.Language.Where((e) => e.Key == key).ExecuteDeleteAsync();
        }
        public void UpdateLanguageEntry(MultiLangString multiLang, string key)
        {
            var titleEntries = _context.Language.Where((p) => p.Key == key);
            foreach (var (lang, value) in multiLang)
            {
                var entry = titleEntries.Where((e) => e.Language == lang).FirstOrDefault();
                if (entry == null)
                {
                    _context.Language.Add(new LangEntry
                    {
                        Key = key,
                        Value = value,
                        Language = lang,
                    });
                }
                else
                {
                    entry.Value = value;
                    _context.Entry(entry).State = EntityState.Modified;
                }

            }
        }
    }


}

