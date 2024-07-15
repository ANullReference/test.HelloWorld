
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using MSME.Core.Domain;
using MSME.Infrastructure.Data.POCO;

namespace MSME.Infrastructure.Data;


// public class MSMEDataContextContextFactory : IDesignTimeDbContextFactory<MSMEDataContextContext>
// {
//   private AppSettings _appSettings;

//   public MSMEDataContextContextFactory(IOptions<AppSettings> options)
//   {
//     _appSettings = options.Value;
//   }

//   public MSMEDataContextContext CreateDbContext(string[] args)
//   {
//     DbContextOptionsBuilder opt = new DbContextOptionsBuilder<MSMEDataContextContext>();
//     opt.UseNpgsql(_appSettings.ConnectionStrings.ArchilleTest);
//     var options =  opt.Options;
//     return new MSMEDataContextContext( options );
//   }

// }


public class MSMEDataContextContext : DbContext
{

  public MSMEDataContextContext() : base ()
  {

  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {

    string conn  = "host=localhost; database=ArchilleTest; search path=dbo;user id=postgres; password=Pointblank0;";
    //optionsBuilder.UseNpgsql("Provider=PostgreSQL OLE DB Provider;Data Source=ArchilleTest;location=localhost;User ID=userLogin;password=Pointblank0;timeout=1000;Pooling=true;Maximum Pool Size=1024;");
    optionsBuilder.UseNpgsql(conn);

  }

  public DbSet<Friends> Friends {get; set;}
}
