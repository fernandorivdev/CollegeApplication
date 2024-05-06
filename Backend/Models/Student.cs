using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public int Gender { get; set; }

    public DateTime Birthday { get; set; }

}
