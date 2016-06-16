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
            Assert.True(tickets.All(t => t.Id != default(int)),"Expected all tickets to have an Id value that is not the default - zero!");
        }
    }
}
