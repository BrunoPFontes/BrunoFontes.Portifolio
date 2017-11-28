using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoFontes.Portifolio.Domain;

namespace BrunoFontes.Portifolio.Persistent.EF.Context
{   /// <summary>
    /// @author - Bruno Fontes
    /// @version - 20171127
    /// 
    /// Create the entity's context  
    /// </summary>
    public class ProductsBrandsDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Brand> Brands { get; set; }

        /// <summary>
        /// Removing the lazy loading, because I don't want to go to the database each
        /// iteration to load the brand's name 
        /// 
        /// Removing the proxy creation that entity auto create, since I don't want any 
        ///  tight coupling
        /// https://stackoverflow.com/questions/4596371/what-are-the-downsides-to-turning-off-proxycreationenabled-for-ctp5-of-ef-code-f
        /// 
        /// </summary>
        public ProductsBrandsDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        /// <summary>
        /// All products must have a brand and their FK is the brandId
        /// 
        /// One brand can have many products
        /// 
        /// I removed the cascade on delete since that I want to keep the brand 
        /// if I have to delete a product
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasRequired(p => p.Brand)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.BrandId)
                .WillCascadeOnDelete(false);
        }
    }
}
