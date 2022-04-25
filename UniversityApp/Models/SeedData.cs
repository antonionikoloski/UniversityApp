using Microsoft.EntityFrameworkCore;
using UniversityApp.Data;

namespace UnversityApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UniversityAppContext>>()))
            {
                // Look for any movies.
              
                context.Students.AddRange(
                
                    new Students  {  StudentID="Prv",FirstName = "Rob", LastName = "Reiner", EnrollmentDate = DateTime.Parse("1947-3-6"),AcquiredCredits = 15,CurrentSemestar = 2,EducationLevel = "Tret"},
                    new Students  {  StudentID = "Vtor", FirstName = "Ivan", LastName = "Reitman", EnrollmentDate = DateTime.Parse("1946-11-27"),AcquiredCredits = 12,CurrentSemestar = 5,EducationLevel = "Vtor"},
                    new Students  {  StudentID = "Tret", FirstName = "Howard", LastName = "Hawks", EnrollmentDate = DateTime.Parse("1896-5-30"),AcquiredCredits = 5,CurrentSemestar = 3,EducationLevel = "Prv"}
                );
                context.SaveChanges();

                context.Teachers.AddRange(
                    new Teachers { /*Id = 1, */FirstName = "Billy", LastName = "Crystal", HireDate = DateTime.Parse("1948-3-14"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141"},
                    new Teachers { /*Id = 2, */FirstName = "Meg", LastName = "Ryan", HireDate = DateTime.Parse("1961-11-19"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141" },
                    new Teachers { /*Id = 3, */FirstName = "Carrie", LastName = "Fisher", HireDate = DateTime.Parse("1956-10-21"),Degree = "Graduate" ,AcademicRank = "Nesto",OfficeNumber = "022211141"},
                    new Teachers { /*Id = 4, */FirstName = "Bill", LastName = "Murray", HireDate = DateTime.Parse("1950-9-21"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141"},
                    new Teachers { /*Id = 5, */FirstName = "Dan", LastName = "Aykroyd", HireDate = DateTime.Parse("1952-7-1"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141"},
                    new Teachers { /*Id = 6, */FirstName = "Sigourney", LastName = "Weaver", HireDate= DateTime.Parse("1949-11-8"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141" },
                    new Teachers { /*Id = 7, */FirstName = "John", LastName = "Wayne", HireDate = DateTime.Parse("1907-5-26"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141" },
                    new Teachers { /*Id = 8, */FirstName = "Dean", LastName = "Martin", HireDate = DateTime.Parse("1917-6-7"),Degree = "Graduate" ,AcademicRank = "Nesto",OfficeNumber = "022211141"}
                );
                context.SaveChanges();
                context.Subjects.AddRange(
                    new Subjects
                    {
                        FirstTeacherId = 1,
                        SecondTeacherId = 2,
                        Credits = 5,
                        Semester ="Prv",
                        Title="Math",
                        EducationLevel="None",
                        Programme = "None"

                    },
                     new Subjects
                     {
                         FirstTeacherId = 2,
                         SecondTeacherId = 3,
                         Credits = 5,
                         Semester = "Vtor",
                         Title = "English",
                          EducationLevel = "None",
                          Programme = "None"

                     },
                      new Subjects
                      {
                          FirstTeacherId = 4,
                          SecondTeacherId = 3,
                          Credits = 5,
                          Semester = "Tret",
                          Title = "OWEB",
                           EducationLevel = "None",
                           Programme="None"

                      }


                    ) ;
                  context.SaveChanges();


                context.Enrollment.AddRange
                    (
                    new EnrollMent
                    {
                      
                        Pom1Id = 9,
                        Pom2Id = 12,
                        ProjectUrl = "None",
                        Semester="Prv",
                        SeminalUrl="None"

                    },
                     new EnrollMent
                     {

                         Pom1Id = 15,
                         Pom2Id = 13,
                         ProjectUrl = "None",
                         Semester = "Prv",
                         SeminalUrl = "None"

                     },
                       new EnrollMent
                       {

                           Pom1Id = 15,
                           Pom2Id = 18,
                           ProjectUrl = "None",
                           Semester = "Prv",
                           SeminalUrl = "None"

                       }
                       ,
                           new EnrollMent
                           {

                               Pom1Id = 23,
                               Pom2Id = 21,
                               ProjectUrl = "None",
                               Semester = "Prv",
                               SeminalUrl = "None"

                           }

                );
                context.SaveChanges ();
            }
        }
    }
}

