using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApp.Models;

[Table("Learner")]
[Index("MajorID", Name = "IX_Learner_MajorID")]
public partial class Learner
{
    [Key]
    public int LearnerID { get; set; }

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(100)]
    public string FirstMidName { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public int MajorID { get; set; }

    [InverseProperty("Learner")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    [ForeignKey("MajorID")]
    [InverseProperty("Learners")]
    public virtual Major Major { get; set; } = null!;
}
