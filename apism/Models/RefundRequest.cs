using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class RefundRequest
{
    public int RefundId { get; set; }

    public int? BookingId { get; set; }

    public DateTime? RequestDate { get; set; }

    public decimal? RefundAmount { get; set; }

    public string? Status { get; set; }

    public virtual Booking? Booking { get; set; }
}
