using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? BookingId { get; set; }

    public string? PaymentMethod { get; set; }

    public DateTime? PaymentDate { get; set; }

    public decimal? PaymentAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public virtual Booking? Booking { get; set; }
}
