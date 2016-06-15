using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Services
{
    public class JsonTicketRepository : ITicketRepository
    {
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await Task.FromResult(this.GetAllTicketsFromJsonFile());
        }

        private IEnumerable<Ticket> GetAllTicketsFromJsonFile()
        {
            var jsonFilePath = "RequirementTickets.json";
            using (var textReader = System.IO.File.OpenText(jsonFilePath))
            {
                var reader = new JsonTextReader(textReader);
                var jsonDeseriliser = new JsonSerializer();
                var tickets = jsonDeseriliser.Deserialize<List<Ticket>>(reader);
                return tickets.AsEnumerable();
            }
        }

    }
}
