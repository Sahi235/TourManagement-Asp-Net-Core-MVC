using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TourManagement.Models;

namespace TourManagement.Database
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, IdentityRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourClient> TourClients { get; set; }
        public DbSet<TourImage> TourImages { get; set; }
        public DbSet<TourRegistration> TourRegistrations { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<TourService> TourServices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<TourImage>().HasKey(k => new {k.TourId, k.ImageId});
            builder.Entity<TourImage>().HasOne(t => t.Tour).WithMany(c => c.TourImages).HasForeignKey(e => e.TourId);
            builder.Entity<TourImage>().HasOne(e => e.Image).WithMany(e => e.TourImages).HasForeignKey(e => e.ImageId);

            builder.Entity<TourService>().HasKey(e => new {e.TourId, e.ServiceId});
            builder.Entity<TourService>().HasOne(e => e.Tour).WithMany(e => e.Services).HasForeignKey(e => e.TourId);
            builder.Entity<TourService>().HasOne(e => e.Service).WithMany(e => e.Tours).HasForeignKey(e => e.ServiceId);

            builder.Entity<TourClient>().HasKey(e => new {e.TourId, e.ClientId});
            builder.Entity<TourClient>().HasOne(e => e.Tour).WithMany(e => e.TourClients).HasForeignKey(e => e.TourId);
            builder.Entity<TourClient>().HasOne(e => e.Client).WithMany(e => e.Tours).HasForeignKey(e => e.ClientId);

            builder.Entity<RegistrationService>().HasKey(e => new {e.RegistrationId, e.ServiceId});
            builder.Entity<RegistrationService>().HasOne(e => e.Service).WithMany(e => e.Registrations)
                .HasForeignKey(e => e.ServiceId);
            builder.Entity<RegistrationService>().HasOne(e => e.TourRegistration).WithMany(e => e.Services)
                .HasForeignKey(e => e.RegistrationId);

            builder.Entity<Tour>().HasIndex(e => e.TourName).IsUnique();
            builder.Entity<Client>().HasIndex(e => e.Name).IsUnique();

            const string userId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
            const string roleId = "d68ba8ab-7348-488f-ac65-34ff796f5476";

            var user = new ApplicationUser()
            {
                Id = userId,
                UserName = "Admin",
                NormalizedUserName = "admin".ToUpper(),
                Email = "Admin@gmail.com",
                NormalizedEmail = "Admin@gmail.com".ToUpper(),
                EmailConfirmed = true,
                ConcurrencyStamp = userId,
                PhoneNumberConfirmed = true,
            };
            var ph = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = ph.HashPassword(user, "123456");

            var role = new IdentityRole()
            {
                Id = roleId,
                Name = "Admin",
                NormalizedName = "Admin".ToUpper(),
                ConcurrencyStamp = roleId,
            };

            builder.Entity<ApplicationUser>().HasData(user);
            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<ApplicationUserRole>().HasData(new ApplicationUserRole
            {
                UserId = userId,
                RoleId = roleId
            });

        }
    }
}
