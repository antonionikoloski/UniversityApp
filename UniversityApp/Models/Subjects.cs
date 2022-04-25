using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace UnversityApp.Models;

public class Subjects
{
    [Required]
    public int Id { get; set; }
    [StringLength(100, MinimumLength = 3)]
    [Required]
    public String Title { get; set; }
    [Required] 
    public int Credits { get; set; }
    [Required] 
    public string Semester { get; set; }
    [StringLength(100, MinimumLength = 3)]
    public String Programme { get; set; }
    [StringLength(25, MinimumLength = 3)]
    [Required]
    public String EducationLevel { get; set; }


    public int FirstTeacherId{ get; set; }
    public int SecondTeacherId { get; set; }

    public Teachers Teachers1;
    public Teachers Teachers2;


    public ICollection<EnrollMent> EnrollMent { get; set; }
    public IList<Students> Studenti { get; set; }
}