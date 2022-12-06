using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmptyMVCTesting.StaticClass
{
    public static class CustomHelpers
    {
        public static IHtmlString ImgStr(string Src, string Alt, string Height, string Width)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' Height='{2}' Width='{3}'></img>", Src, Alt, Height, Width));
        }

        public static IHtmlString Img(this HtmlHelper helper,string Src, string Alt, string Height, string Width)
        {
            return new MvcHtmlString(string.Format("<img src='{0}' alt='{1}' Height='{2}' Width='{3}'></img>", Src, Alt, Height, Width));
        }

        public static IHtmlString ImgTag(this HtmlHelper helper, string Src, string Alt, string Height, string Width)
        {
            TagBuilder tg = new TagBuilder("img");
            tg.Attributes.Add("src", Src);
            tg.Attributes.Add("alt", Alt);
            tg.Attributes.Add("Height", Height);
            tg.Attributes.Add("Width", Width);

            return new MvcHtmlString(tg.ToString());
        }
    }
}