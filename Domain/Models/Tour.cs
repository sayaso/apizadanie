using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class Tour
{
    public int TourId { get; set; }

    public string? TourName { get; set; }

    public string? Description { get; set; }

    public int? OperatorId { get; set; }

    public decimal? Price { get; set; }

    public int? DurationDays { get; set; }

    public string? StartLocation { get; set; }

    public string? EndLocation { get; set; }

    public int? AvailableSpots { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual TourOperator? Operator { get; set; }

    public virtual ICollection<Promotion> Promotions { get; set; } = new List<Promotion>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<TourImage> TourImages { get; set; } = new List<TourImage>();

    public virtual ICollection<TourCategory> Categories { get; set; } = new List<TourCategory>();

    public virtual ICollection<Guide> Guides { get; set; } = new List<Guide>();

    public virtual ICollection<Location> Locations { get; set; } = new List<Location>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
