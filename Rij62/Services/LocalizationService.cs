
using Microsoft.EntityFrameworkCore;
using Rij62.Data;
using Rij62.Models;

namespace Rij62.Services
{
    public class LocalizationService
    {

        private readonly AppDbContext _context;

        private Localizer? _localizer = null;

        public LocalizationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Localizer> GetLocalizer()
        {
            if (_localizer == null)
            {
                _localizer = new Localizer(await _context.Language.ToArrayAsync());
            }

            return _localizer;
        }

        public async Task DeleteLanguageEntry(string key)
        {
            await _context.Language.Where((e) => e.Key == key).ExecuteDeleteAsync();
        }

        public async Task CopyLanguageEntry(string key, string newKey)
        {
            var entries = await _context.Language.Where((p) => p.Key == key).ToArrayAsync();

            _context.Language.AddRange(entries.Select((e)=>
            {
                e.Key = newKey;
                return e;
            }));

            await _context.SaveChangesAsync();
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

