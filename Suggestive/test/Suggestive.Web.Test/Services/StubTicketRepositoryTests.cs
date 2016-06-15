using System.Linq;
using System.Threading.Tasks;
using Suggestive.Web.Services;
using Xunit;

namespace Suggestive.Web.Test.Services
{
    public class StubTicketRepositoryTests
    {
        [Fact]
        public async Task GetAllTickets_ReturnsTickets()
        {
            ITicketRepository repo = new StubTicketRepository();
            var tickets = await repo.GetAllTicketsAsync();
            Assert.True(tickets.Any(), "Expected 1 or more tickets returned");
        }
    }
}
