using Microsoft.EntityFrameworkCore;

namespace IntrogamiAPI.Models
{
    public class IntrogamiAPIDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public IntrogamiAPIDBContext(DbContextOptions<IntrogamiAPIDBContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString("IntrogamiService");
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Following> Followings { get; set; } = null!;

        public DbSet<Origami> Origamis { get; set; } = null!;

    }
}
