using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Suggestions;
using System.Collections.Generic;
using System.Threading.Tasks;

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
