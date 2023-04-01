using System;
using System.Linq;
using AngleSharp;
using AngleSharp.Dom;
using TasteWork;
using System.Threading.Tasks;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

internal class Program
{
    public static async Task Main(string[] args)
    {

        /*IEnumerable<IElement> divs = Enumerable.Empty<Element>();
        IEnumerable<Vacancy> vacancies = Enumerable.Empty<Vacancy>();
        var TagsA = await TagParcer.GetTagsFrom("https://www.work.ua/jobs/by-category/", ".text-gray-light", "a");
        TagsA = TagsA.SkipLast(6);

        foreach (var tagA in TagsA)
        {
            divs = await TagParcer.GetTagsFromAllPages(string.Concat("https://www.work.ua", tagA.GetAttribute("href")), ".card-visited");
            vacancies = vacancies.Concat(DataParcer.GetObjectsFromDivs(divs, tagA.TextContent, "https://www.work.ua"));
        }*/
        using (var db = new MyDbContext())
        {
            /*var vacancyList = vacancies.Select(v => new Vacancy(v.Title, v.TypeVacancy, v.Link)).ToList();
            db.Vacancy.AddRange(vacancies);
            db.SaveChanges();*/
            var sortedVacancy = db.Vacancy.OrderBy(v => v.TypeVacancy).Select(v => 
            new Vacancy{
                Title = v.Title,
                TypeVacancy = v.TypeVacancy,
                Link = v.Link
            });
            db.RemoveRange(db.Vacancy);
            db.AddRange(sortedVacancy.ToList());
            db.SaveChanges();
        }
    }
}