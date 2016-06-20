using System.Linq;
using System.Threading.Tasks;
using Suggestive.Web.Api;
using Suggestive.Web.Services;
using Xunit;

namespace Suggestive.Web.Test.Api
{
    public class RequirementControllerTests
    {
        [Fact]
        public async Task GetById_IdMatchesTicket_ExpectTicketReturned()
        {
            int ticketId = 1;
            var ticketRepository = new StubTicketRepository();
            var apiController = new RequirementsController(ticketRepository);
            var result = await apiController.Get(ticketId);
            Assert.Equal(ticketId, result.Id);
        }

        [Fact]
        public async Task GetById_IdNotMatchingTicket_ExpectNoTicketReturned()
        {
            int ticketId = -1;
            var ticketRepository = new StubTicketRepository();
            var apiController = new RequirementsController(ticketRepository);
            var result = await apiController.Get(ticketId);
            Assert.Null(result);
        }

        [Fact]
        public async Task Get_RequestAllTickets_ExpectTicketsReturned()
        {
            var ticketRepository = new StubTicketRepository();
            var apiController = new RequirementsController(ticketRepository);
            var result = await apiController.Get();
            Assert.True(result.Any(),"Expected one or more tickets returned");
        }

    }
    }
