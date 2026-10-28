using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApp.Models;

[Table("Enrollment")]
[Index("CourseID", Name = "IX_Enrollment_CourseID")]
[Index("LearnerID", Name = "IX_Enrollment_LearnerID")]
public partial class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; }

    public int CourseID { get; set; }

    public int LearnerID { get; set; }

    public float Grade { get; set; }

    [ForeignKey("CourseID")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("LearnerID")]
    [InverseProperty("Enrollments")]
    public virtual Learner Learner { get; set; } = null!;
}
