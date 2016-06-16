using System.Collections.Generic;
using System.Threading.Tasks;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Services
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();

        Task<Ticket> GetTicketAsync(int id);
    }
}