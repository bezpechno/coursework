using Microsoft.EntityFrameworkCore;

namespace coursework.Models
{
    public class FeedbackContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}