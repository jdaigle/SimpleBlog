using System.Web.Mvc;
using System.Web.Routing;

namespace SimpleBlog.Web.Html
{
    public static class ImageHelper
    {
        public static string ImageContent(this HtmlHelper helper, string imageContentUrl, string alt)
        {
            return ImageContent(helper, imageContentUrl, alt, string.Empty, null);
        }

        public static string ImageContent(this HtmlHelper helper, string imageContentUrl, string alt, string id)
        {
            return ImageContent(helper, imageContentUrl, alt, id, null);
        }

        public static string ImageContent(this HtmlHelper helper, string imageContentUrl, string alt, object htmlAttributes)
        {
            return ImageContent(helper, imageContentUrl, alt, string.Empty, htmlAttributes);
        }

        public static string ImageContent(this HtmlHelper helper, string imageContentUrl, string alt, string id, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);

            var builder = new TagBuilder("img");
            if (!string.IsNullOrEmpty(id))
                builder.GenerateId(id);
            builder.MergeAttribute("src", urlHelper.Content(imageContentUrl));
            builder.MergeAttribute("alt", alt);
            builder.MergeAttributes(new RouteValueDictionary(htmlAttributes));
            return builder.ToString(TagRenderMode.SelfClosing);
        }

        public static string ImageLink(this HtmlHelper helper, ActionResult result, string imageContentUrl, string alt)
        {
            return ImageLink(helper, result, imageContentUrl, alt, string.Empty, null, null);
        }

        public static string ImageLink(this HtmlHelper helper, ActionResult result, string imageContentUrl, string alt, string linkId)
        {
            return ImageLink(helper, result, imageContentUrl, alt, linkId, null, null);
        }

        public static string ImageLink(this HtmlHelper helper, ActionResult result, string imageContentUrl, string alt, object imgHtmlAttributes, object linkHtmlAttributes)
        {
            return ImageLink(helper, result, imageContentUrl, alt, string.Empty, imgHtmlAttributes, linkHtmlAttributes);
        }

        public static string ImageLink(this HtmlHelper helper, ActionResult result, string imageContentUrl, string alt, string linkId, object imgHtmlAttributes, object linkHtmlAttributes)
        {
            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            var linkUrl = urlHelper.Action(result);
            var imageSrc = ImageContent(helper, imageContentUrl, alt, imgHtmlAttributes);
            
            var builder = new TagBuilder("a");
            if (!string.IsNullOrEmpty(linkId))
                builder.GenerateId(linkId);
            builder.MergeAttribute("href", linkUrl);            
            builder.MergeAttributes(new RouteValueDictionary(linkHtmlAttributes));
            builder.AddCssClass("nounderline");
            if (!(builder.Attributes.ContainsKey("title") && string.IsNullOrEmpty(builder.Attributes["title"])))
                builder.MergeAttribute("title", alt);
            builder.InnerHtml = imageSrc;
            return builder.ToString(TagRenderMode.Normal);
        }

    }
}