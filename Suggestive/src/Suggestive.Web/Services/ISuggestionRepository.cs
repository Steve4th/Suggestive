using Suggestive.Web.Models.Suggestions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Suggestive.Web.Services
{
    public interface ISuggestionRepository
    {
        Task<IEnumerable<Suggestion>> GetSuggestionsAsync();
        Task<Suggestion> AddSuggestionAsync(Suggestion suggestionToBeAdded);
        Task UpdateSuggestionAsync(Suggestion suggestionToUpdate);
    }
}
