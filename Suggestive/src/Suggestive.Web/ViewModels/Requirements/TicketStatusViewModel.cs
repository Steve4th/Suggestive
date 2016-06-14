using System.Collections.Generic;
using System.Linq;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.ViewModels.Requirements
{
    public class TicketStatusViewModel
    {
        public IEnumerable<Ticket> AllTickets { get; set; }

        public IEnumerable<Ticket> ToDoTickets
        {
            get { return AllTickets.Where(t => t.Status == TicketStatus.ToDo); }
        }

        public IEnumerable<Ticket> InProgressTickets
        {
            get { return AllTickets.Where(t => t.Status == TicketStatus.InProgress); }
        }

        public IEnumerable<Ticket> CompletedTickets
        {
            get { return AllTickets.Where(t => t.Status == TicketStatus.Complete); } 
        }
    }
}
