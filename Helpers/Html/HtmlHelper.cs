//using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Helpers.Html
{
    public class HtmlHelper
    {
        //public static string CleanHtml(string input)
        //{
        //    if (string.IsNullOrEmpty(input)) return string.Empty;

        //    var document = new HtmlDocument();
        //    document.LoadHtml(input);

        //    var acceptableTags = new String[] { "em", "u", "br", "p", "h1", "h2", "h3", "h4", "h5", "h6", "span", "div", "ul", "li", "a" };

        //    var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
        //    while (nodes.Count > 0)
        //    {
        //        var node = nodes.Dequeue();
        //        var parentNode = node.ParentNode;

        //        if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
        //        {
        //            var childNodes = node.SelectNodes("./*|./text()");

        //            if (childNodes != null)
        //            {
        //                foreach (var child in childNodes)
        //                {
        //                    nodes.Enqueue(child);
        //                    parentNode.InsertBefore(child, node);
        //                }
        //            }

        //            parentNode.RemoveChild(node);

        //        }
        //        else
        //        {
        //            if(node.Name == "a")
        //            {
        //                var hrefVal = node.Attributes.FirstOrDefault(a => a.Name == "href");
        //                if (hrefVal != null && !hrefVal.Value.StartsWith("/"))
        //                {
        //                    parentNode.RemoveChild(node);
        //                }
        //            }
        //        }
        //    }

        //    return document.DocumentNode.InnerHtml;
        //}
    }
}
