using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;

namespace DataAccess.Models;

public partial class TrsContext : DbContext
{
    public TrsContext()
    {
    }

    public TrsContext(DbContextOptions<TrsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<RefundRequest> RefundRequests { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<TourCategory> TourCategories { get; set; }

    public virtual DbSet<TourImage> TourImages { get; set; }

    public virtual DbSet<TourOperator> TourOperators { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserActivityLog> UserActivityLogs { get; set; }

    public virtual DbSet<UserMessage> UserMessages { get; set; }

    public virtual DbSet<UserSupportTicket> UserSupportTickets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=xewell;Database=trs;User Id=sa;Password=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__bookings__5DE3A5B1A03EFD9E");

            entity.ToTable("bookings");

            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.BookingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("booking_date");
            entity.Property(e => e.NumOfPeople).HasColumnName("num_of_people");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TotalAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total_amount");
            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__bookings__tour_i__4316F928");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__bookings__user_i__4222D4EF");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("PK__guides__04A82241E1EA604B");

            entity.ToTable("guides");

            entity.Property(e => e.GuideId).HasColumnName("guide_id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.ExperienceYears).HasColumnName("experience_years");
            entity.Property(e => e.GuideName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("guide_name");
            entity.Property(e => e.OperatorId).HasColumnName("operator_id");

            entity.HasOne(d => d.Operator).WithMany(p => p.Guides)
                .HasForeignKey(d => d.OperatorId)
                .HasConstraintName("FK__guides__operator__571DF1D5");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__location__771831EABCD2E9D7");

            entity.ToTable("locations");

            entity.Property(e => e.LocationId).HasColumnName("location_id");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Region)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("region");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842F7734D61D");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.NotificationText)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("notification_text");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("sent_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__notificat__user___778AC167");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__payments__ED1FC9EAB9C7D8DB");

            entity.ToTable("payments");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.PaymentAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("payment_amount");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("payment_method");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("payment_status");

            entity.HasOne(d => d.Booking).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__payments__bookin__48CFD27E");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__promotio__2CB9556B2041F5C1");

            entity.ToTable("promotions");

            entity.Property(e => e.PromotionId).HasColumnName("promotion_id");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discount_percentage");
            entity.Property(e => e.EndDate).HasColumnName("end_date");
            entity.Property(e => e.StartDate).HasColumnName("start_date");
            entity.Property(e => e.TourId).HasColumnName("tour_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.Promotions)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__promotion__tour___60A75C0F");
        });

        modelBuilder.Entity<RefundRequest>(entity =>
        {
            entity.HasKey(e => e.RefundId).HasName("PK__refund_r__897E9EA35D919268");

            entity.ToTable("refund_requests");

            entity.Property(e => e.RefundId).HasColumnName("refund_id");
            entity.Property(e => e.BookingId).HasColumnName("booking_id");
            entity.Property(e => e.RefundAmount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("refund_amount");
            entity.Property(e => e.RequestDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("request_date");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.Booking).WithMany(p => p.RefundRequests)
                .HasForeignKey(d => d.BookingId)
                .HasConstraintName("FK__refund_re__booki__7C4F7684");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__reviews__60883D9004373107");

            entity.ToTable("reviews");

            entity.Property(e => e.ReviewId).HasColumnName("review_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("review_date");
            entity.Property(e => e.ReviewText)
                .HasColumnType("text")
                .HasColumnName("review_text");
            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__reviews__tour_id__4E88ABD4");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__reviews__user_id__4D94879B");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PK__tours__4B16B9E636570926");

            entity.ToTable("tours");

            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.AvailableSpots).HasColumnName("available_spots");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DurationDays).HasColumnName("duration_days");
            entity.Property(e => e.EndLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("end_location");
            entity.Property(e => e.OperatorId).HasColumnName("operator_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StartLocation)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("start_location");
            entity.Property(e => e.TourName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tour_name");

            entity.HasOne(d => d.Operator).WithMany(p => p.Tours)
                .HasForeignKey(d => d.OperatorId)
                .HasConstraintName("FK__tours__operator___3D5E1FD2");

            entity.HasMany(d => d.Categories).WithMany(p => p.Tours)
                .UsingEntity<Dictionary<string, object>>(
                    "TourCategoryMapping",
                    r => r.HasOne<TourCategory>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_cate__categ__5441852A"),
                    l => l.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_cate__tour___534D60F1"),
                    j =>
                    {
                        j.HasKey("TourId", "CategoryId").HasName("PK__tour_cat__1642577D4A1539F2");
                        j.ToTable("tour_category_mapping");
                        j.IndexerProperty<int>("TourId").HasColumnName("tour_id");
                        j.IndexerProperty<int>("CategoryId").HasColumnName("category_id");
                    });

            entity.HasMany(d => d.Guides).WithMany(p => p.Tours)
                .UsingEntity<Dictionary<string, object>>(
                    "TourGuideMapping",
                    r => r.HasOne<Guide>().WithMany()
                        .HasForeignKey("GuideId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_guid__guide__5AEE82B9"),
                    l => l.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_guid__tour___59FA5E80"),
                    j =>
                    {
                        j.HasKey("TourId", "GuideId").HasName("PK__tour_gui__4B5C3BC2D13524DB");
                        j.ToTable("tour_guide_mapping");
                        j.IndexerProperty<int>("TourId").HasColumnName("tour_id");
                        j.IndexerProperty<int>("GuideId").HasColumnName("guide_id");
                    });

            entity.HasMany(d => d.Locations).WithMany(p => p.Tours)
                .UsingEntity<Dictionary<string, object>>(
                    "TourLocationMapping",
                    r => r.HasOne<Location>().WithMany()
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_loca__locat__6A30C649"),
                    l => l.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tour_loca__tour___693CA210"),
                    j =>
                    {
                        j.HasKey("TourId", "LocationId").HasName("PK__tour_loc__FC673AF85661FE44");
                        j.ToTable("tour_location_mapping");
                        j.IndexerProperty<int>("TourId").HasColumnName("tour_id");
                        j.IndexerProperty<int>("LocationId").HasColumnName("location_id");
                    });
        });

        modelBuilder.Entity<TourCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__tour_cat__D54EE9B4CF129A68");

            entity.ToTable("tour_categories");

            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_name");
        });

        modelBuilder.Entity<TourImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__tour_ima__DC9AC95538F3FE3C");

            entity.ToTable("tour_images");

            entity.Property(e => e.ImageId).HasColumnName("image_id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.TourId).HasColumnName("tour_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.TourImages)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("FK__tour_imag__tour___5DCAEF64");
        });

        modelBuilder.Entity<TourOperator>(entity =>
        {
            entity.HasKey(e => e.OperatorId).HasName("PK__tour_ope__9D9A8901FC28D245");

            entity.ToTable("tour_operators");

            entity.Property(e => e.OperatorId).HasColumnName("operator_id");
            entity.Property(e => e.ContactEmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contact_email");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("contact_phone");
            entity.Property(e => e.OperatorName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("operator_name");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FF2C62055");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ__users__AB6E6164404807E0").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("last_name");
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password_hash");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");

            entity.HasMany(d => d.Tours).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserFavorite",
                    r => r.HasOne<Tour>().WithMany()
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__user_favo__tour___6477ECF3"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__user_favo__user___6383C8BA"),
                    j =>
                    {
                        j.HasKey("UserId", "TourId").HasName("PK__user_fav__CD0F5C91866F1D4E");
                        j.ToTable("user_favorites");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("TourId").HasColumnName("tour_id");
                    });
        });

        modelBuilder.Entity<UserActivityLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__user_act__9E2397E0FA91F19B");

            entity.ToTable("user_activity_logs");

            entity.Property(e => e.LogId).HasColumnName("log_id");
            entity.Property(e => e.Action)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("action");
            entity.Property(e => e.ActionDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("action_date");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserActivityLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_acti__user___00200768");
        });

        modelBuilder.Entity<UserMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__user_mes__0BBF6EE6424696CC");

            entity.ToTable("user_messages");

            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.MessageText)
                .HasColumnType("text")
                .HasColumnName("message_text");
            entity.Property(e => e.SentAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("sent_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserMessages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_mess__user___6E01572D");
        });

        modelBuilder.Entity<UserSupportTicket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__user_sup__D596F96BB56829CF");

            entity.ToTable("user_support_tickets");

            entity.Property(e => e.TicketId).HasColumnName("ticket_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IssueDescription)
                .HasColumnType("text")
                .HasColumnName("issue_description");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserSupportTickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__user_supp__user___72C60C4A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
