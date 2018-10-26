using System.Data.Entity;

namespace EverythingWeb.Entity
{
    public class MyContext : DbContext
    {
        public MyContext() : base("name=MyContext") { }
        public DbSet<Musics> Musics { get; set; }
        public DbSet<MusicStyle> MusicStyles { get; set; }
    }
}