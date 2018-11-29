using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WineS.Models.Pages;

namespace WineS.Helpers
{
    public static class PageHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,
                                                   Catalog pagingInfo,
                                                   Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                TagBuilder tag1 = new TagBuilder("li");
                if (i == pagingInfo.CurrentPage)
                {
                    tag1.AddCssClass("active");
                }

                tag.InnerHtml = i.ToString();
                tag1.InnerHtml = tag.ToString();
                result.Append(tag1.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}