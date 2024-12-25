using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class Guide
{
    public int GuideId { get; set; }

    public string? GuideName { get; set; }

    public string? Bio { get; set; }

    public int? ExperienceYears { get; set; }

    public int? OperatorId { get; set; }

    public virtual TourOperator? Operator { get; set; }

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
