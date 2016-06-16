using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.Services;

namespace Suggestive.Web.Api
{
    [Route("api/[controller]")]
    public class RequirementController: Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public RequirementController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<Ticket> Get(int id)
        {
            return new Ticket()
            {
                Description = "With this ticket you can access Wonka's chocolate factory",
                Summary = $"Golden Ticket #{id}",
                Status = TicketStatus.Complete
            };
        }
    }
}
