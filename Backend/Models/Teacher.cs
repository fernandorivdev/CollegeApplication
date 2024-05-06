using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public int? Gender { get; set; }

}
