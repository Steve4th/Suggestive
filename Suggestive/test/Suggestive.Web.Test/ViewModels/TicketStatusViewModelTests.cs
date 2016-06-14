using System.Collections.Generic;
using System.Linq;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.ViewModels.Requirements;
using Xunit;

namespace Suggestive.Web.Test.ViewModels
{
    public class TicketStatusViewModelTests
    {
        [Fact]
        public void ToDoTickets_OneOrMoreToDoTickets_ExpectPropertyToContainsRecords()
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
            var expectedNumberOfTodoItems = 2; 

            Assert.Equal(expectedNumberOfTodoItems, ticketStatusViewModel.ToDoTickets.Count());
        }
    }
}
