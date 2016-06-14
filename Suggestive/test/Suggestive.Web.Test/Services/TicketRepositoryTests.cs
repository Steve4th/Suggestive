using System.Linq;
using Suggestive.Web.Services;
using Xunit;

namespace Suggestive.Web.Test.Services
{
    public class TicketRepositoryTests
    {
        [Fact]
        public void GetAllTickets_ReturnsTickets()
        {
            ITicketRepository repo = new TicketRepository();
            var tickets = repo.GetAllTickets();
            Assert.True(tickets.Any(), "Expected 1 or more tickets returned");
        }
    }
}
