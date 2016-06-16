using System.IO;
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
            ITicketRepository repo = new JsonTicketRepository("RequirementTickets.json");
            var tickets = await repo.GetAllTicketsAsync();
            Assert.True(tickets.Any(), "Expected 1 or more tickets returned");
            Assert.True(tickets.All(t => t.Id != default(int)),
                "Expected all tickets to have an Id value that is not the default - zero!");
        }

        [Fact]
        public void Contructor_SupplyFileThatDoesNotExist_ExpectFileNotFoundException()
        {
            Assert.Throws<FileNotFoundException>(() => new JsonTicketRepository("AFileThatDoesNotExist.json"));
        }

        [Fact]
        public async Task GetTicket_IdMatchingExistingTicket_ExpectTicketReturned()
        {
            ITicketRepository repo = new JsonTicketRepository("RequirementTickets.json");
            var ticket = await repo.GetTicketAsync(1);
            Assert.Equal(1, ticket.Id);
        }

        [Fact]
        public async Task GetTicket_IdNotMatchingARecord_ExpectNullReturned()
        {
            ITicketRepository repo = new JsonTicketRepository("RequirementTickets.json");
            var ticket = await repo.GetTicketAsync(1);
            Assert.Null(ticket);
        }
    }
}
