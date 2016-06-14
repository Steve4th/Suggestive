using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.Services;
using Suggestive.Web.ViewModels.Requirements;

namespace Suggestive.Web.Controllers
{
    public class RequirementsController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public RequirementsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Ticket> tickets = _ticketRepository.GetAllTickets();

            await Task.Delay(500);

            var ticketStatusViewModel = new TicketStatusViewModel()
            {
                AllTickets =  tickets
            };

            return View(ticketStatusViewModel);
        }
    }
}