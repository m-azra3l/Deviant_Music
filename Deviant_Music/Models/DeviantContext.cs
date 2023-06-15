using System.Data.Entity;

namespace Deviant_Music.Models
{
    public class DeviantContext : DbContext

    {
        public  DeviantContext()
        : base("DeviantMusic")
        {
        }

        public DbSet<AdsB> AdsBs { get; set; }
        public DbSet<AdsPB> AdsPBs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<DeviantSocial> DeviantSocials { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Download> Downloads { get; set; }
    }
}
