using UnversityApp.Models;
using System.ComponentModel.DataAnnotations;
namespace UniversityApp.Krajno
{
    public class Pomosno
    {
        public EnrollMent enrollment { get; set; }

        [Display(Name = "Seminal File")]
        public IFormFile? seminalUrlFile { get; set; }

        public string? seminalUrlName { get; set; }
    }
}
