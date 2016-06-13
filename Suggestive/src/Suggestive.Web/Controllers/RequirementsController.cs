using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.ViewModels.Requirements;

namespace Suggestive.Web.Controllers
{
    public class RequirementsController : Controller
    {
        public IActionResult Index()
        {
            var ticketStatusViewModel = new TicketStatusViewModel()
            {
                AllTickets = new List<Ticket>()
                {
                    new Ticket() { Summary = "A requirement", Status = TicketStatus.ToDo },
                    new Ticket() { Summary = "Requirement Two", Status = TicketStatus.ToDo },
                    new Ticket() { Summary = "Requirement Three", Status = TicketStatus.InProgress },
                    new Ticket() { Summary = "Requirement Four", Status = TicketStatus.Complete },
                    new Ticket() { Summary = "Requirement Five", Status = TicketStatus.Rejected }
                }
            };
            return View(ticketStatusViewModel);
        }
    }
}