using HONASTEAK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HONASTEAK.Helpers
{
    public static class MenuHelper
    {
        public static MvcHtmlString Menu(this HtmlHelper helper)
        {
            string hostUrl = HttpContext.Current.Request.Url.Authority;
            string host = "https://" + hostUrl + "";

            StringBuilder result = new StringBuilder();
            using (var context = new ApplicationDbContext())
            {
                var categories = context.Categories.ToList();

                foreach (var category in categories)
                {
                    result.Append("<li class='third-level'></li>");
                    result.AppendFormat("<a href='{0}/Collections/{1}'>{2}</a>", host, category.Slug, category.Name);
                    result.Append("</li>");
                }
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}