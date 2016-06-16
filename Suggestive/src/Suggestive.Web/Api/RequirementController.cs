using System.Linq;
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
            var tickets = await _ticketRepository.GetAllTicketsAsync();

            return tickets.FirstOrDefault(t => t.Id == id);
        }
    }
}
