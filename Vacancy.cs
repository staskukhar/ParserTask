using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TasteWork
{
    public class Vacancy
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VacancyId { get; set; }
        public string Title {get; set;}
        public string TypeVacancy {get; set;}
        public string Link {get; set;}

        public Vacancy() { }
        public Vacancy(string title, string type, string link)
        {
            Title = title;
            TypeVacancy = type;
            Link = link;
        }
    }
}