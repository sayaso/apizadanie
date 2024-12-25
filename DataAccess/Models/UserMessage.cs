using System;
using System.Collections.Generic;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class UserMessage
{
    public int MessageId { get; set; }

    public int? UserId { get; set; }

    public string? MessageText { get; set; }

    public DateTime? SentAt { get; set; }

    public virtual User? User { get; set; }
}
