using System;
using System.Linq.Expressions; 
using System.Text;
using System.Web.Mvc; 
using System.Web.Mvc.Html;
using System.Web.Mvc.Ajax;
using System.Web.Routing;
using Fasterflect;

namespace CodeWick.Helpers {
    public static class HtmlExtensions {
        public static MvcHtmlString ActionImage(this HtmlHelper htmlHelper, string imgSrc, string alt, string actionName, string controllerName, string AjaxUpdateTargetId, object routeValues, object linkAttributes, object imgAttributes) {
            TagBuilder imglink = new TagBuilder("a");
            try {
                UrlHelper urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
                string imgtag = Image(htmlHelper, imgSrc, alt, imgAttributes);
                string url = urlHelper.Action(actionName, controllerName, routeValues);
                imglink.MergeAttribute("href", url);
                if (AjaxUpdateTargetId != null) {
                    imglink.MergeAttribute("data-ajax", "true");
                    imglink.MergeAttribute("data-ajax-mode", "replace");
                    imglink.MergeAttribute("data-ajax-update", "#" + AjaxUpdateTargetId);
                }
                imglink.InnerHtml = imgtag;
                imglink.MergeAttributes(new RouteValueDictionary(linkAttributes), true);
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return MvcHtmlString.Create(imglink.ToString());
        }

        public static string Image(this HtmlHelper helper, string src, string alt, object imgAttributes) {
            TagBuilder tb = new TagBuilder("img");
            try {
                tb.Attributes.Add("src", helper.Encode(src));
                tb.Attributes.Add("alt", helper.Encode(alt));
                tb.MergeAttributes(new RouteValueDictionary(imgAttributes), true);
            } catch (Exception ex) { LogHelper log = new LogHelper(); log.LogException(ex); }
            return tb.ToString(TagRenderMode.SelfClosing);
        }
    }
}