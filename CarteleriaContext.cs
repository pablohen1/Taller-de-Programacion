
using System.Data.Entity;


namespace Carteleria_Digital
{
    public class CarteleriaContext:DbContext
    {   //Se arma la estructura de la base de datos y se la prepara para migraciones.

        public CarteleriaContext(): base() 
       {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CarteleriaContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarteleriaContext, Migrations.Configuration>());
        }

        public DbSet<Campaña> Campañas { get; set; }
        public DbSet<RssReutilizable> RSSreutilizables { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Imagen> Imagens { get; set; }
        public DbSet<RSS> Rsses { get; set; }
        public DbSet<TextoFijo> TextoFijos { get; set; }
        public DbSet<ContenidoBanner> Fuentes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);

        }
    }
}
