using System.ComponentModel.DataAnnotations;

namespace UnversityApp.Models;

public class Teachers
{
    [Required]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 3)]
    [Required]
    public String FirstName { get; set; }
    [StringLength(50, MinimumLength = 3)]
    [Required]
    public String LastName { get; set; }
    [StringLength(50, MinimumLength = 3)] 
    public String Degree { get; set; }
     
    [StringLength(25, MinimumLength = 3)] 
    public String AcademicRank { get; set; }
    [StringLength(10, MinimumLength = 3)] 
     public String  OfficeNumber{ get; set; }
     [DataType(DataType.Date)]
     public DateTime? HireDate { get; set; }
     
     public ICollection<Subjects> Subjects { get; set; }
    public ICollection<Subjects> Subjects2 { get; set; }
}