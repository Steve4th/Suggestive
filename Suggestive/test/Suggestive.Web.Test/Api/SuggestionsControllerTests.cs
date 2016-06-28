using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Api;
using Suggestive.Web.Models.Suggestions;
using Suggestive.Web.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Suggestive.Web.Test.Api
{
    public class SuggestionsControllerTests
    {
        [Fact]
        public async Task Get_RequestAllTickets_ExpectTicketsReturned()
        {
            var suggestionRepo = new InMemorySuggestionRepository();
            await suggestionRepo.AddSuggestionAsync(new Suggestion()
            {
                Title = "Suggestion One"
            });

            var apiController = new SuggestionsController(suggestionRepo);
            var result = await apiController.Get();
            Assert.True(result.Any(), "Expected one or more suggestions returned");
        }


        [Fact]
        public async Task Post_NewSuggestion_ExpectNewSuggestionReturned()
        {
            var newSuggestion = new Suggestion()
            {
                Title = "Unit Test Suggestion Post",
                Description = "I am testing the Post method accepts a new suggestion and returns it back"
            };

            var suggestionRepo = new InMemorySuggestionRepository();
            var apiController = new SuggestionsController(suggestionRepo);

            var result = (CreatedAtActionResult) await apiController.Post(newSuggestion);

            Assert.Equal(201, result.StatusCode);
            
            var createdSuggestion = result.Value as Suggestion;
            Assert.Equal(newSuggestion.Title, createdSuggestion.Title);
            Assert.Equal(newSuggestion.Description, createdSuggestion.Description);
        }

        [Fact]
        public async Task Put_UpdatedSuggestion_ExpectStatusOKReturned()
        {
            var suggestionRepo = new InMemorySuggestionRepository();
            var apiController = new SuggestionsController(suggestionRepo);


            //add a suggestion
            var newSuggestion = new Suggestion()
            {
                Title = "Unit Test Suggestion Post",
                Description = "I am testing the Post method accepts a new suggestion and returns it back"
            };

            var addSuggestionResult = (CreatedAtActionResult) await apiController.Post(newSuggestion);
            Assert.Equal(201, addSuggestionResult.StatusCode);
            
            var createdSuggestion = addSuggestionResult.Value as Suggestion;
            Assert.Equal(newSuggestion.Title, createdSuggestion.Title);
            Assert.Equal(newSuggestion.Description, createdSuggestion.Description);

            var updatedSuggestion = new Suggestion() {
                Id = createdSuggestion.Id,
                CreatedOn = createdSuggestion.CreatedOn,
                Title = "Updated Suggestion Title",
                Description = "Updated Suggestion Description"
            };

            var updatedSuggestionResult = (NoContentResult) await apiController.Put(updatedSuggestion.Id, updatedSuggestion);
            Assert.Equal(204, updatedSuggestionResult.StatusCode);

            var fetchedSuggestion = await apiController.Get(updatedSuggestion.Id);
            Assert.Equal(updatedSuggestion.Title, fetchedSuggestion.Title);
            Assert.Equal(updatedSuggestion.Description, fetchedSuggestion.Description);                
        }
    }
}
