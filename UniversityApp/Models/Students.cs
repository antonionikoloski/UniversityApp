using System.ComponentModel.DataAnnotations;

namespace UnversityApp.Models;

public class Students
{ 
      
    [Required]
    public int Id { get; set; }
    [StringLength(10, MinimumLength = 3)]
    [Required]
    public String StudentID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Required]
    public String FirstName { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public String LastName { get; set; }
    [DataType(DataType.Date)]
    public DateTime? EnrollmentDate { get; set; }

    public int AcquiredCredits { get; set; }
    public int CurrentSemestar { get; set; }
    
    [StringLength(25, MinimumLength = 3)] 
    public String EducationLevel { get; set; }
    
    public ICollection<EnrollMent> EnrollMent { get; set; }


}