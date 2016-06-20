using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Suggestive.Web.Models.Requirements;
using Suggestive.Web.TagHelpers;
using Xunit;
using Xunit.Abstractions;

namespace Suggestive.Web.Test.TagHelpers
{
    public class TicketListTagHelperTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public TicketListTagHelperTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Process_EmptyTicketListSupplied_ExpectDivWithNoListItems()
        {
            var tickets = new List<Ticket>();
            var expectedHtmlContent = @"<div class=""list-group""></div>";

            Process_GeneratedExpectedOutput(tickets, expectedHtmlContent);
        }

        [Fact]
        public void Process_PopulatedTicketList_ExpectDivWithListItems()
        {
            var tickets = new List<Ticket>()
            {
                new Ticket() { Id= 1, Summary = "Summary One", Description = "Description One"},
                new Ticket() { Id= 2, Summary = "Summary Two", Description = "Description Two"},
            };
            var expectedHtmlContent = 
            @"<div class=""list-group"">
                    <a class=""list-group-item"" href=""#"">
                            <h4 class=""list-group-item-heading"">
                            <span class=""fa fa-puzzle-piece fa-lg"" aria-hidden=""true""></span>Summary One</h4>
                            <span class=""badge"">1</span>
                            <p class=""list-group-item-text"">Description One</p>
                    </a>
                    <a class=""list-group-item"" href=""#"">
                            <h4 class=""list-group-item-heading"">
                            <span class=""fa fa-puzzle-piece fa-lg"" aria-hidden=""true""></span>Summary Two</h4>
                            <span class=""badge"">2</span>
                            <p class=""list-group-item-text"">Description Two</p>
                    </a>
            </div>"
            .Replace("  ","")
            .Replace(Environment.NewLine, "");

            Process_GeneratedExpectedOutput(tickets, expectedHtmlContent);
        }

        [Fact]
        public void Process_NullTicketList_ExpectException()
        {
            IEnumerable<Ticket> tickets = null;
            var expectedHtmlContent = "<div></div>";

            Assert.Throws<InvalidOperationException>(() => Process_GeneratedExpectedOutput(tickets, expectedHtmlContent));
        }

        private void Process_GeneratedExpectedOutput(IEnumerable<Ticket> tickets, string expectedHtmlContent)
        {
            var tagHelper = new TicketListTagHelper {Tickets = tickets};

            var tagHelperContext = new TagHelperContext(
                new TagHelperAttributeList(),
                new Dictionary<object, object>(),
                Guid.NewGuid().ToString("N"));

            var tagHelperOutput = new TagHelperOutput("ticket-list",
                new TagHelperAttributeList(),
                (htmlEncoder, helperContextTask) =>
                {
                    var tagHelperContent = new DefaultTagHelperContent();
                    tagHelperContent.SetContent(string.Empty);
                    return Task.FromResult<TagHelperContent>(tagHelperContent);
                }
                );
            tagHelper.Process(tagHelperContext, tagHelperOutput);

            _outputHelper.WriteLine("Tag Helper Process completed. Content generated is :");
            _outputHelper.WriteLine(tagHelperOutput.Content.GetContent());

            _outputHelper.WriteLine("");
            _outputHelper.WriteLine("Expected tag helper output is:");
            _outputHelper.WriteLine(expectedHtmlContent);

            Assert.Equal("div", tagHelperOutput.TagName);
            Assert.Equal(expectedHtmlContent, tagHelperOutput.Content.GetContent());
        }



    }
}
