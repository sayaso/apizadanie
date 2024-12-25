using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class UserSupportTicket
{
    public int TicketId { get; set; }

    public int? UserId { get; set; }

    public string? IssueDescription { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Status { get; set; }

    public virtual User? User { get; set; }
}
