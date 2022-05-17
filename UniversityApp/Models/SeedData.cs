using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityApp.Areas.Identity.Data;
using UniversityApp.Data;

namespace UnversityApp.Models
{
    public class SeedData
    {
        public static async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<UniversityAppUser>>();
            IdentityResult roleResult;
            //Add Admin Role
            var roleCheck = await RoleManager.RoleExistsAsync("Admin");
            if (!roleCheck) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Admin")); }
            UniversityAppUser user = await UserManager.FindByEmailAsync("admin@mvcmovie.com");
            if (user == null)
            {
                var User = new UniversityAppUser();
                User.Email = "admin@mvcmovie.com";
                User.UserName = "admin@mvcmovie.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Admin"); }
            }
            var roleCheck_teacher = await RoleManager.RoleExistsAsync("Teacher");
            if (!roleCheck_teacher) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Teacher")); }
            UniversityAppUser user_Teacher = await UserManager.FindByEmailAsync("teacher1@university.com");
            if (user_Teacher == null)
            {
                var User = new UniversityAppUser();
                User.Email = "teacher1@mvcmovie.com";
                User.UserName = "teacher1@mvcmovie.com";
                string userPWD = "Admin123";
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Teacher"); }
            }
            UniversityAppUser user_Teacher2 = await UserManager.FindByEmailAsync("teacher2@university.com");
            if (user_Teacher2 == null)
            {
                var User = new UniversityAppUser();
                User.Email = "teacher2@mvcmovie.com";
                User.UserName = "teacher2@mvcmovie.com";
                string userPWD = "Admin";
                IdentityResult chkUser1 = await UserManager.CreateAsync(User, userPWD);
                //Add default User to Role Admin
                if (chkUser1.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Teacher"); }
            }
            var roleCheck_za_studenti = await RoleManager.RoleExistsAsync("Students");
            if (!roleCheck_za_studenti) { roleResult = await RoleManager.CreateAsync(new IdentityRole("Students")); }
            UniversityAppUser user_student = await UserManager.FindByEmailAsync("student1@university.com");
            if (user_student == null)
            {
                var User_st = new UniversityAppUser();
                User_st.Email = "student1@university.com";
                User_st.UserName = "student1@university.com";
                string userPWD = "Admin123";
                IdentityResult chkUser_prv = await UserManager.CreateAsync(User_st, userPWD);
                //Add default User to Role Admin
                if (chkUser_prv.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User_st, "Students"); }
            }
        }
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new UniversityAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<UniversityAppContext>>()))
            {
                CreateUserRoles(serviceProvider).Wait();
                context.Students.AddRange(
                
                    new Students  {  StudentID="Prv",FirstName = "Rob", LastName = "Reiner", EnrollmentDate = DateTime.Parse("1947-3-6"),AcquiredCredits = 15,CurrentSemestar = 2,EducationLevel = "Tret", nadvoresen = context.Users.Single(x => x.Email == "student1@university.com").Id },
                    new Students  {  StudentID = "Vtor", FirstName = "Ivan", LastName = "Reitman", EnrollmentDate = DateTime.Parse("1946-11-27"),AcquiredCredits = 12,CurrentSemestar = 5,EducationLevel = "Vtor"},
                    new Students  {  StudentID = "Tret", FirstName = "Howard", LastName = "Hawks", EnrollmentDate = DateTime.Parse("1896-5-30"),AcquiredCredits = 5,CurrentSemestar = 3,EducationLevel = "Prv"}
                );
                context.SaveChanges();

                context.Teachers.AddRange(
                    new Teachers { /*Id = 1, */FirstName = "Billy", LastName = "Crystal", HireDate = DateTime.Parse("1948-3-14"),Degree = "Graduate",AcademicRank = "Nesto",OfficeNumber = "022211141",nadvoresen=context.Users.Single(x=>x.Email=="teacher1@mvcmovie.com").Id},
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
                      
                        Pom1Id = 1,
                        Pom2Id = 2,
                        ProjectUrl = "None",
                        Semester="Prv",
                        SeminalUrl="None",
                        Grade=10

                    },
                     new EnrollMent
                     {

                         Pom1Id = 2,
                         Pom2Id = 3,
                         ProjectUrl = "None",
                         Semester = "Prv",
                         SeminalUrl = "None",
                         Grade=8

                     },
                       new EnrollMent
                       {

                           Pom1Id = 3,
                           Pom2Id = 1,
                           ProjectUrl = "None",
                           Semester = "Prv",
                           SeminalUrl = "None",
                           Grade=7

                       }
                       ,
                           new EnrollMent
                           {

                               Pom1Id = 1,
                               Pom2Id = 2,
                               ProjectUrl = "None",
                               Semester = "Prv",
                               SeminalUrl = "None",
                               Grade=6

                           }

                );
                context.SaveChanges ();
            }
        }
    }
}

