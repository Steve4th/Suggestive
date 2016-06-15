using System.ComponentModel.DataAnnotations;

namespace Suggestive.Web.Models.Requirements
{
    public enum TicketStatus
    {
        [Display(Name = "Not Started")]
        ToDo = 0,
        [Display(Name="In Progress")]
        InProgress = 1,
        [Display(Name = "Completed")]
        Complete = 2,
        [Display(Name = "Rejected")]
        Rejected = 3
    }
}