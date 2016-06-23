using System;

namespace Suggestive.Web.Models.Suggestions
{
    public class Suggestion
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
