using Microsoft.EntityFrameworkCore;
using MyWebApp.Models;
namespace MyWebApp.Data;
public static class DbInitializer
{
    public static async Task InitializeAsync(SchoolContext db)
    {
        await db.Database.EnsureCreatedAsync();
        if (await db.Majors.AnyAsync()) return;
        await using var transaction = await db.Database.BeginTransactionAsync();
        var majors = new[]
        {
            new Major { MajorName = "IT" }, new Major { MajorName = "Economics" },
            new Major { MajorName = "Mathematics" }
        };
        db.Majors.AddRange(majors);
        await db.SaveChangesAsync();
        var learners = new[]
        {
            new Learner { FirstMidName = "Carson", LastName = "Alexander", EnrollmentDate = new DateTime(2005, 9, 1), MajorID = majors[0].MajorID },
            new Learner { FirstMidName = "Meredith", LastName = "Alonso", EnrollmentDate = new DateTime(2002, 9, 1), MajorID = majors[1].MajorID }
        };
        db.Learners.AddRange(learners);
        db.Courses.AddRange(
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 });
        await db.SaveChangesAsync();
        db.Enrollments.AddRange(
            new Enrollment { LearnerID = learners[0].LearnerID, CourseID = 1050, Grade = 5.5f },
            new Enrollment { LearnerID = learners[0].LearnerID, CourseID = 4022, Grade = 7.5f },
            new Enrollment { LearnerID = learners[1].LearnerID, CourseID = 1050, Grade = 3.5f },
            new Enrollment { LearnerID = learners[1].LearnerID, CourseID = 4041, Grade = 7f });
        await db.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}
