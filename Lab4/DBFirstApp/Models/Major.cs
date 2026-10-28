using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstApp.Models;

[Table("Major")]
public partial class Major
{
    [Key]
    public int MajorID { get; set; }

    [StringLength(100)]
    public string MajorName { get; set; } = null!;

    [InverseProperty("Major")]
    public virtual ICollection<Learner> Learners { get; set; } = new List<Learner>();
}
