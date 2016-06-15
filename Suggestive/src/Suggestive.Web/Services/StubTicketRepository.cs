﻿using System.Collections.Generic;
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
                new Ticket() {Summary = "A requirement", Status = TicketStatus.ToDo},
                new Ticket() {Summary = "Requirement Two", Status = TicketStatus.ToDo},
                new Ticket() {Summary = "Requirement Three", Status = TicketStatus.InProgress},
                new Ticket() {Summary = "Requirement Four", Status = TicketStatus.Complete},
                new Ticket() {Summary = "Requirement Five", Status = TicketStatus.Rejected}
            };
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await Task.Run(() => this.GetAllTickets());
        }
    }
}
