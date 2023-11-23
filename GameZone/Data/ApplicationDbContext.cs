namespace GameZone.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<GameDevice> GameDevices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[] 
                {
                    new Category {Id=1,Name="Shooting"},
                    new Category {Id=2,Name="Action"},
                    new Category {Id=3,Name="Adventure"},
                    new Category {Id=4,Name="Racing"},
                    new Category {Id=5,Name="Film"},
                    new Category {Id=6,Name="Sports"}
                });

            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device {Id=1,Name="XBox",Icon="bi bi-xbox"},
                    new Device {Id=2,Name="PlayStation",Icon = "bi bi-playstation"},
                    new Device {Id=3,Name="PC", Icon = "bi bi-pc-display"},
                });

            modelBuilder.Entity<GameDevice>().HasKey(e => new { e.GameId, e.DeviceId });
            base.OnModelCreating(modelBuilder);
        }
        
    }
    
}
