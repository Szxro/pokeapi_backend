using Microsoft.EntityFrameworkCore;
using ModelDB;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //One to Many (PokemonDB => AbilitiesDB )
            modelBuilder.Entity<AbilitiesDB>().HasOne(x => x.Pokemon).WithMany(x => x.Abilities).HasForeignKey(x => x.PokemonId);

            //One to One (SpritesDB => PokemonDB)
           // modelBuilder.Entity<SpriteDB>().HasOne(x => x.Pokemon).WithMany(x => x.PokeSprite).HasForeignKey<SpriteDB>(x => x.PokemonId);
        }
    }
}