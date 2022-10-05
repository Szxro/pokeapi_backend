using Microsoft.EntityFrameworkCore;
using ModelDB;
using System.Security.Cryptography.X509Certificates;

namespace Data
{
    public class PokeContext : DbContext
    {
        public PokeContext(DbContextOptions<PokeContext> options) : base(options)
        {

        }

        public DbSet<PokemonDB> Pokemons { get; set; }

        public DbSet<AbilitiesDB> Abilities { get; set; }
        
        public DbSet<SpriteDB> Sprites { get; set; }

        public DbSet<TypesDB> Types { get; set; }

        public DbSet<StatsDB> Stats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //One to Many (PokemonDB => AbilitiesDB )
            modelBuilder.Entity<AbilitiesDB>().HasOne(x => x.Pokemon).WithMany(x => x.Abilities).HasForeignKey(x => x.PokemonId);

            //One to One (SpritesDB => PokemonDB)
            modelBuilder.Entity<SpriteDB>().HasOne(x => x.Pokemon).WithOne(x => x.PokeSprite).HasForeignKey<SpriteDB>(x => x.PokemonId);

            //One to One (TypesDB => PokemonDB)
            modelBuilder.Entity<TypesDB>().HasOne(x => x.PokemonDB).WithOne(x => x.Types).HasForeignKey<TypesDB>(x => x.PokemonId);

            //One to One (StatsDB => PokemonDB)
            modelBuilder.Entity<StatsDB>().HasOne(x => x.Pokemon).WithOne(x => x.Stats).HasForeignKey<StatsDB>(x => x.PokemonId);
        }
    }
}