using Microsoft.EntityFrameworkCore;

namespace KiemTra.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Thêm các DbSet cho các model của bạn ở đây
        public DbSet<TongVanDoai> TongVanDoais { get; set; }
    }
} 