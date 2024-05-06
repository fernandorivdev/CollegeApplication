using System;
using System.Collections.Generic;

namespace Backend.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int TeacherId { get; set; }

}
