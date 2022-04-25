using System.ComponentModel.DataAnnotations;

namespace UnversityApp.Models;

public class EnrollMent
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int Pom1Id { get; set; }
    [Required]
    public int Pom2Id { get; set; }
    [StringLength(10, MinimumLength = 3)] 
    public String Semester { get; set; }

    public int Year { get; set; }
    public int Grade { get; set; }
    public int ExamPoints { get; set; }
    public int SeminalPoints { get; set; }
    public int ProjectPoints { get; set; }
    public int AdditionalPoints { get; set; }
    [DataType(DataType.Date)]
    public DateTime? FinishDate { get; set; }
    [StringLength(225, MinimumLength = 3)] 
    public String SeminalUrl { get; set; }
    [StringLength(225, MinimumLength = 3)] 
    public String ProjectUrl { get; set; }

    public Subjects Subjects;
    public Students Students;
    
}