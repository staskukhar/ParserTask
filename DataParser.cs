using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;
//using TasteWork;

namespace TasteWork
{
    //class which takes Vacancies from divs
    public class DataParser
    {
        //method gets objects from divs
        public static IEnumerable<Vacancy> GetObjectsFromDivs(IEnumerable<IElement> divs, string type, string parentLink)
        {
            IEnumerable<Vacancy> vacancy = Enumerable.Empty<Vacancy>();
            foreach(var div in divs)
            {
                if(div != null)
                {
                    vacancy = vacancy.Append(new Vacancy(
                    div.QuerySelector("h2")?.TextContent,
                    type,
                    String.Concat(parentLink, div.QuerySelector("h2")?.QuerySelector("a")?.GetAttribute("href")) 
                ));
                }
            }
            return vacancy;
        }
        //method gets amount of the pages of pagination
        public static async Task<int> GetTotalPages(string url)
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);

            var pagination = document.QuerySelector("ul.pagination.hidden-xs");

            if (pagination != null)
            {
                var pages = pagination.QuerySelectorAll("li");

                int totalPages = (pages.Length < 2) ? 1 : int.Parse(pages[pages.Length - 2].TextContent);
                return totalPages;
            }
            else
            {
                throw new Exception("can`t find the amount of pages: DataParcer.GetTotalPages()");
            }
        }
    }
}