using System.Linq;
using System.Threading.Tasks;
using Suggestive.Web.Services;
using Xunit;

namespace Suggestive.Web.Test.Services
{
    public class JsonTicketRepositoryTests
    {
        [Fact]
        public async Task GetAllTickets_ReturnsTickets()
        {
            ITicketRepository repo = new JsonTicketRepository();
            var tickets = await repo.GetAllTicketsAsync();
            Assert.True(tickets.Any(), "Expected 1 or more tickets returned");
        }
    }
}
