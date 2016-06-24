using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Suggestions;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Suggestive.Web.Api
{
    [Route("api/[controller]")]
    public class SuggestionsController: Controller
    {
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
            await Task.Delay(300);

            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            return CreatedAtAction(nameof(Get), new { id = newSuggestion.Id }, newSuggestion);
        }

        private async Task<IEnumerable<Suggestion>> GetAllSuggestionsAsync()
        {
            return await Task.Run(() =>
            {
                return new List<Suggestion>()
                {
                    new Suggestion() { Title = "Suggestion One", Description = "Fly me to the moon...." },
                    new Suggestion() { Title = "Suggestion Two", Description = "Sail the seven seas of ryme.." }
                };
            });
        }
    }
}
