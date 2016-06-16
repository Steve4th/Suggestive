using System.Collections.Generic;
using System.Threading.Tasks;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Services
{
    public class StubTicketRepository: ITicketRepository
    {
        private IEnumerable<Ticket> GetAllTickets()
        {
            return new List<Ticket>()
            {
                new Ticket() {Id = 1, Description = "A description of ... One", Summary = "A requirement", Status = TicketStatus.ToDo},
                new Ticket() {Id = 2, Description = "A description of ... Two", Summary = "Requirement Two", Status = TicketStatus.ToDo},
                new Ticket() {Id = 3, Description = "A description of ... Three", Summary = "Requirement Three", Status = TicketStatus.InProgress},
                new Ticket() {Id = 4, Description = "A description of ... Four", Summary = "Requirement Four", Status = TicketStatus.Complete},
                new Ticket() {Id = 5, Description = "A description of ... Five", Summary = "Requirement Five", Status = TicketStatus.Rejected}
            };
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await Task.Run(() => this.GetAllTickets());
        }

        public Task<Ticket> GetTicketAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
