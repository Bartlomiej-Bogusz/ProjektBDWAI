using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjektBDWAI.Areas.Identity.Data;
using ProjektBDWAI.Models;

namespace ProjektBDWAI.Data;

public class ProjektBDWAIContext : IdentityDbContext<ProjektBDWAIUser>
{
    public ProjektBDWAIContext(DbContextOptions<ProjektBDWAIContext> options)
        : base(options)
    {
    }

    public void Configure(EntityTypeBuilder<ProjektBDWAIUser> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(255);
        builder.Property(x => x.LastName).HasMaxLength(255);

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }


    public DbSet<Samochod> Samochody { get; set; }
    public DbSet<Rezerwacja> Rezerwacje { get; set; }
    public DbSet<Platnosc> Platnosci { get; set; }
}
