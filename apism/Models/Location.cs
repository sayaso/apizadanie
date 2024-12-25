using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string? Country { get; set; }

    public string? City { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
