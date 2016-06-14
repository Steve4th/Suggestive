using System.Collections.Generic;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Services
{
    public interface ITicketRepository
    {
        IEnumerable<Ticket> GetAllTickets();
    }
}