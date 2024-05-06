using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class StudentGrade
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? GradeId { get; set; }

    public string? Section { get; set; }

}
