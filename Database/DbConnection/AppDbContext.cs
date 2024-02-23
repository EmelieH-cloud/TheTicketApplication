using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Database.DbConnection
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<TicketApiModel> Tickets { get; set; }
        public DbSet<TicketTag> TicketTag { get; set; }
        public DbSet<TagModel> Tags { get; set; }
        public DbSet<ResponseModel> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera många-till-många relationen mellan TicketModel och TagModel.
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TicketTag>()
                .HasKey(tt => new { tt.TicketId, tt.TagId });

            // Konfigurera många-till-en relationen mellan TicketModel och TicketTagModel.
            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Ticket)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TicketId);

            // Konfigurera många-till-en relationen mellan TagModel och TicketTagModel.
            modelBuilder.Entity<TicketTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TicketTags)
                .HasForeignKey(tt => tt.TagId);

            // Konfigurera en-till-många-relationen mellan TicketModel och ResponseModel.
            modelBuilder.Entity<ResponseModel>()
                .HasOne(r => r.Ticket)
                .WithMany(t => t.Responses)
                .HasForeignKey(r => r.TicketId);
        }
    }
}

