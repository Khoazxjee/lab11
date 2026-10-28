using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApp.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int CourseID { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    public int Credits { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
