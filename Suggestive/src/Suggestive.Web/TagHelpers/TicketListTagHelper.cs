using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Suggestive.Web.Models.Requirements;

namespace Suggestive.Web.TagHelpers
{
    public class TicketListTagHelper: TagHelper
    {
        public IEnumerable<Ticket> Tickets { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (Tickets == null)
            {
                throw new InvalidOperationException($"{nameof(this.Tickets)} must be specified");
            }

            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            TagBuilder listGroupContainerBuilder = new TagBuilder("div");
            listGroupContainerBuilder.AddCssClass("list-group");

            foreach (var ticket in this.Tickets)
            {
                TagBuilder itemBuilder = new TagBuilder("a");
                itemBuilder.AddCssClass("list-group-item");
                itemBuilder.Attributes.Add("href", "#");

                TagBuilder headingBuilder = new TagBuilder("h4");
                headingBuilder.AddCssClass("list-group-item-heading");
                headingBuilder.InnerHtml.AppendHtml(
                    $"<span class=\"fa fa-puzzle-piece fa-lg\" aria-hidden=\"true\"></span>{ticket.Summary}");

                TagBuilder badgeBuilder = new TagBuilder("span");
                badgeBuilder.AddCssClass("badge");
                badgeBuilder.InnerHtml.Append(ticket.Id.ToString());

                TagBuilder descriptionBuilder = new TagBuilder("p");
                descriptionBuilder.AddCssClass("list-group-item-text");
                descriptionBuilder.InnerHtml.Append(ticket.Description);

                itemBuilder.InnerHtml.AppendHtml(headingBuilder);
                itemBuilder.InnerHtml.AppendHtml(badgeBuilder);
                itemBuilder.InnerHtml.AppendHtml(descriptionBuilder);

                listGroupContainerBuilder.InnerHtml.AppendHtml(itemBuilder);
            }
            output.Content.AppendHtml(listGroupContainerBuilder);
        }
    }
}
