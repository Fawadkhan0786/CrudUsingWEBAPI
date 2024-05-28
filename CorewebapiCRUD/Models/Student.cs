using System;
using System.Collections.Generic;

namespace CorewebapiCRUD.Models;

public partial class Student
{
    public int Id { get; set; }

    public string? StudentName { get; set; }

    public string? StudentGender { get; set; }

    public int? Age { get; set; }

    public int? Standard { get; set; }

    public string? FathersName { get; set; }
}
