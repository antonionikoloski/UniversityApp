using Microsoft.AspNetCore.Mvc.Rendering;
using UnversityApp.Models;

namespace UniversityApp.Krajno
{
    public class SearchView
    {
          public int Semestar { get; set; }
        public string Title { get; set; }
        public IList<Subjects> Subjects { get; set; }
        public SelectList Semester { get; set; }
    }
}
