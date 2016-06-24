using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Suggestions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Suggestive.Web.Services;

namespace Suggestive.Web.Api
{
    [Route("api/[controller]")]
    public class SuggestionsController: Controller
    {
        private readonly ISuggestionRepository _suggestionRepository;

        public SuggestionsController(ISuggestionRepository suggestionRepository)
        {
            _suggestionRepository = suggestionRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Suggestion>> Get()
        {
            return await GetAllSuggestionsAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<Suggestion> Get(int id)
        {
            var suggestions = await GetAllSuggestionsAsync();

            return suggestions.FirstOrDefault(s => s.Id == id);
        }
        
        [HttpPost]
        [Produces("application/json", Type = typeof(Suggestion))]
        [Consumes("application/json")]
        public async Task<IActionResult> Post([FromBody] Suggestion newSuggestion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var savedSuggestion = await _suggestionRepository.AddSuggestionAsync(newSuggestion);

            return CreatedAtAction(nameof(Get), new { id = savedSuggestion.Id }, savedSuggestion);
        }

        private async Task<IEnumerable<Suggestion>> GetAllSuggestionsAsync()
        {
            return await _suggestionRepository.GetSuggestionsAsync();
        }
    }
}
