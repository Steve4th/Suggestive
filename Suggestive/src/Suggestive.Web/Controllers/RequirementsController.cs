using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {
            var ticketStatusViewModel = new TicketStatusViewModel()
            {
                AllTickets = _ticketRepository.GetAllTickets() 
            };
            return View(ticketStatusViewModel);
        }
    }
}