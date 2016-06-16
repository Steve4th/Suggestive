namespace Suggestive.Web.Models.Requirements
{
    public class Ticket
    {
        public int Id { get; set; }

        public TicketStatus Status { get; set; }

        public string Summary { get; set; }

        public string Description { get; set; }
    }
}
