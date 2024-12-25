using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class TourOperator
{
    public int OperatorId { get; set; }

    public string? OperatorName { get; set; }

    public string? ContactEmail { get; set; }

    public string? ContactPhone { get; set; }

    public decimal? Rating { get; set; }

    public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
