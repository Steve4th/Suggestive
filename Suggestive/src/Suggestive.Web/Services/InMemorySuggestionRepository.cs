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
            return await Task.Run(() => 
            {
                var suggestionToBeStored = suggestionToBeAdded.DeepCopy();

                suggestionToBeStored.Id = GetNextId();

                _SuggestionStore.Add(suggestionToBeStored);

                return suggestionToBeStored;
            });
        }

        public async Task<IEnumerable<Suggestion>> GetSuggestionsAsync()
        {
            return await Task.Run(() => 
            {
                 return _SuggestionStore.AsEnumerable(); 
            });
        }

        public async Task UpdateSuggestionAsync(Suggestion suggestionToUpdate)
        {
            await Task.Run(() => 
            {
                var previousVersion = _SuggestionStore.Single(s => s.Id == suggestionToUpdate.Id);
                var nextVersion = suggestionToUpdate.DeepCopy();
                _SuggestionStore.Remove(previousVersion);
                _SuggestionStore.Add(nextVersion);
            });
        }

        private int GetNextId()
        {
            return _SuggestionStore.Any() 
                ? _SuggestionStore.Max(s => s.Id) + 1 
                : 1;
        }
    }
}
