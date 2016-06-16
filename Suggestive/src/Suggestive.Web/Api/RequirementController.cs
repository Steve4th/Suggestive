using Microsoft.AspNetCore.Mvc;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.Api
{
    [Route("api/[controller]")]
    public class RequirementController: Controller
    {
        [HttpGet("{id:int}")]
        public Ticket Get(int id)
        {
            return new Ticket()
            {
                Description = "With this ticket you can access Wonka's chocolate factory",
                Summary = $"Golden Ticket #{id}",
                Status = TicketStatus.Complete
            };
        }
    }
}
