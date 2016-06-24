using Suggestive.Web.Models.Suggestions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suggestive.Web.Services
{
    public class InMemorySuggestionRepository : ISuggestionRepository
    {
        private readonly List<Suggestion> _SuggestionStore = new List<Suggestion>();

        public async Task<Suggestion> AddSuggestionAsync(Suggestion suggestionToBeAdded)
        {
            var suggestionToBeStored = suggestionToBeAdded.DeepCopy();

            suggestionToBeStored.Id = GetNextId();

            _SuggestionStore.Add(suggestionToBeStored);

            return suggestionToBeStored;
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestionsAsync()
        {
            return _SuggestionStore.AsEnumerable();
        }

        private int GetNextId()
        {
            return _SuggestionStore.Any() 
                ? _SuggestionStore.Max(s => s.Id) + 1 
                : 1;
        }
    }
}
