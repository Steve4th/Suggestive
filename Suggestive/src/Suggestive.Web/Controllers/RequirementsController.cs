using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.Services;
using Suggestive.Web.ViewModels.Requirements;

namespace Suggestive.Web.Controllers
{
    [Authorize]
    public class RequirementsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public RequirementsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ticket> tickets = await _ticketRepository.GetAllTicketsAsync();


            var ticketStatusViewModel = new TicketStatusViewModel()
            {
                AllTickets =  tickets
            };

            return View(ticketStatusViewModel);
        }
    }
}