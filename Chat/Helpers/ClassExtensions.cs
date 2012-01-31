using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chat.Models;
using System.Security.Principal;

namespace Chat.Helpers
{
	public static class HtmlHelperExtensions
	{
	}

	public static class UrlHelperExtensions
	{
		public static MvcHtmlString Script(this HtmlHelper src, string scriptName, bool isExternal = false)
		{
			var tag = new TagBuilder("script");
			tag.Attributes.Add("type", "text/javascript");
			if(isExternal)
			{
				tag.Attributes.Add("src", scriptName);
			}
			else
			{
				var urlHelper = new UrlHelper(src.ViewContext.RequestContext);
				tag.Attributes.Add("src", urlHelper.Content("~/Content/Scripts/" + scriptName));
			}

			return tag.GetMvcHtmlString();
		}

		public static MvcHtmlString GetMvcHtmlString(this TagBuilder src)
		{
			return new MvcHtmlString(src.ToString());
		}

		public static MvcHtmlString Style(this HtmlHelper src, string styleSheetName, bool isExternal = false)
		{
			var tag = new TagBuilder("link");
			tag.Attributes.Add("type", "text/css");
			tag.Attributes.Add("rel", "stylesheet");
			if(isExternal)
			{
				tag.Attributes.Add("href", styleSheetName);
			}
			else
			{
				var urlHelper = new UrlHelper(src.ViewContext.RequestContext);
				tag.Attributes.Add("href", urlHelper.Content("~/Content/Styles/" + styleSheetName));
			}

			return tag.GetMvcHtmlString();
		}

		public static bool IsNullOrWhiteSpace(this string src)
		{
			return string.IsNullOrWhiteSpace(src);
		}
	}
}