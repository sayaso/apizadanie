using System;
using System.Collections.Generic;
using DataAccess.Models;


namespace DataAccess.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? PasswordHash { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<UserActivityLog> UserActivityLogs { get; set; } = new List<UserActivityLog>();

    public virtual ICollection<UserMessage> UserMessages { get; set; } = new List<UserMessage>();

    public virtual ICollection<UserSupportTicket> UserSupportTickets { get; set; } = new List<UserSupportTicket>();

    public virtual ICollection<Tour> Tours { get; set; } = new List<Tour>();
}
