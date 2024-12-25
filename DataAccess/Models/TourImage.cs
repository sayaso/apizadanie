using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class TourImage
{
    public int ImageId { get; set; }

    public int? TourId { get; set; }

    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public virtual Tour? Tour { get; set; }
}
