using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Services
{
    public class JsonTicketRepository : ITicketRepository
    {
        private readonly string _jsonFilePath;

        public JsonTicketRepository(string jsonFilePath)
        {
            if (!File.Exists(jsonFilePath))
                throw new FileNotFoundException("The specified requirements file store cannot be found.", jsonFilePath);

            _jsonFilePath = jsonFilePath;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await Task.FromResult(this.GetAllTicketsFromJsonFile());
        }

        private IEnumerable<Ticket> GetAllTicketsFromJsonFile()
        {
            using (var textReader = System.IO.File.OpenText(_jsonFilePath))
            {
                var reader = new JsonTextReader(textReader);
                var jsonDeseriliser = new JsonSerializer();
                var tickets = jsonDeseriliser.Deserialize<List<Ticket>>(reader);
                return tickets.AsEnumerable();
            }
        }

    }
}
