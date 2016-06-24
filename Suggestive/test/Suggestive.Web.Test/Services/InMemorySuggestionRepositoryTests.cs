using Suggestive.Web.Services;
using Suggestive.Web.Models.Suggestions;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace Suggestive.Web.Test.Services
{
    public class InMemorySuggestionRepositoryTests
    {
        [Fact]
        public async Task GetSuggestions_AfterAdd_ExpectAddedSuggestionReturned()
        {
            ISuggestionRepository repo = new InMemorySuggestionRepository();

            var intialSuggestions = await repo.GetSuggestionsAsync();
            Assert.Empty(intialSuggestions);

            var suggestionToBeAdded = new Suggestion()
            {
                Id = default(int),
                Title = "Suggestion One"
            };

            Suggestion savedSuggestion = await repo.AddSuggestionAsync(suggestionToBeAdded);

            Assert.True(savedSuggestion.Id != default(int), "Expected repo to assign an Id to the supplied record");

            var suggestions = await repo.GetSuggestionsAsync();

            Assert.NotEmpty(suggestions);
            Assert.Equal(1, suggestions.Count());
            Assert.Equal(suggestionToBeAdded.Title, suggestions.First(s => s.Id == savedSuggestion.Id).Title);


            suggestionToBeAdded.Title = "Suggestion Two";
            Suggestion secondSavedSuggestion = await repo.AddSuggestionAsync(suggestionToBeAdded);

            Assert.True(secondSavedSuggestion.Id != default(int), "Expected repo to assign an Id to the supplied record");
            Assert.NotEqual(savedSuggestion.Id, secondSavedSuggestion.Id);

            suggestions = await repo.GetSuggestionsAsync();

            Assert.NotEmpty(suggestions);
            Assert.Equal(2, suggestions.Count());
            Assert.Equal(suggestionToBeAdded.Title, suggestions.First(s => s.Id == secondSavedSuggestion.Id).Title);
        }
    }
}
