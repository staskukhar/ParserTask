using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AngleSharp;
using AngleSharp.Dom;

namespace TasteWork
{
    public class TagParcer
    {
        //method gets child links from some class of another link
        public static async Task<IEnumerable<string>> GetChildLinksFrom(string link, string fromClass, string parentLink)
        {
            IEnumerable<string> links = Enumerable.Empty<string>();
            if(link != null)
            {
                var config = Configuration.Default.WithDefaultLoader();
                var document = await BrowsingContext.New(config).OpenAsync(link);

                var linkLists = document.QuerySelectorAll(fromClass);
                foreach(var linkList in linkLists)
                {
                    var aTags = linkList.QuerySelectorAll("a");
                    foreach(var aTag in aTags)
                    {
                        links = links.Append(String.
                            Concat(parentLink, 
                            links.Append(aTag.GetAttribute("href")
                            )));
                    }
                }
                return links;
            }
            return Enumerable.Empty<string>();
        }
        //method gets some tags filtered by class tag from some link
        public static async Task<IEnumerable<IElement>> GetTagsFrom(string link, string fromClass, string tag)
        {
            IEnumerable<IElement> tags = Enumerable.Empty<Element>();
            if(link != null)
            {
                var config = Configuration.Default.WithDefaultLoader();
                var document = await BrowsingContext.New(config).OpenAsync(link);

                var linkLists = document.QuerySelectorAll(fromClass);
                foreach(var linkList in linkLists)
                {
                    var aTags = linkList.QuerySelectorAll(tag);
                    foreach(var aTag in aTags)
                    {
                        tags = tags.Append(aTag);
                    }
                }
                return tags;
            }
            return Enumerable.Empty<IElement>();
        }
        // method get tags filterd by class tag from link
        public static async Task<IEnumerable<IElement>> GetTagsFrom(string link, string fromClass)
        {
            IEnumerable<IElement> tags = Enumerable.Empty<Element>();
            if(link != null)
            {
                var config = Configuration.Default.WithDefaultLoader();
                var document = await BrowsingContext.New(config).OpenAsync(link);

                var TagLists = document.QuerySelectorAll(fromClass);
                foreach(var Tag in TagLists)
                {
                        tags = tags.Append(Tag);
                }
                return tags;
            }
            return Enumerable.Empty<IElement>();
        }
        //method gets tags with pagination from link
        public static async Task<IEnumerable<IElement>> GetTagsFromAllPages(string link, string fromClass)
        {
            IEnumerable<IElement> tags = Enumerable.Empty<Element>();
            if(link != null)
            {
                var config = Configuration.Default.WithDefaultLoader();
                var document = await BrowsingContext.New(config).OpenAsync(String.Concat(link));
                int totalPages = await DataParcer.GetTotalPages(link);
                if(totalPages != 0)
                {
                    for(int page = 1; page <= totalPages; page++)
                    {
                        document = await BrowsingContext.New(config).OpenAsync(String.Concat(link, $"&page={page}"));
                        var TagLists = document.QuerySelectorAll(fromClass);
                        foreach(var Tag in TagLists)
                        {
                            tags = tags.Append(Tag);
                        }
                    }
                    return tags;
                }
            }
            return Enumerable.Empty<IElement>();
        }
    }
}