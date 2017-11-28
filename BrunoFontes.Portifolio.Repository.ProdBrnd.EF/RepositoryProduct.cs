using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoFontes.Portifolio.Domain;
using BrunoFontes.Portifolio.Persistent.EF.Context;
using BrunoFontes.Portifolio.Repository.Standard;

namespace BrunoFontes.Portifolio.Repository.ProdBrnd.EF
{
    public class RepositoryProduct : IRepositoryGeneric<Product>
    {
        /// <summary>
        /// @author - Bruno Fontes
        /// @version - 20171127
        /// 
        /// Create the product's repository 
        /// </summary>
        public Task<List<Product>> SelectAll()
        {
            /*
             Task.Run() to load all products in a different thread
             making the main's form load faster
             */
            return Task.Run(() =>
            {
                using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
                {
                    //includes brand, otherwise the product will come with brand empty 
                    return context.Products.Include("Brand").ToList();
                }
            });
        }

        public Product SelectById(int id)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                //includes brand, otherwise the product will come with brand empty 
                return context.Products.Include("Brand").Single(s => s.Id == id);
            }
        }

        public void Insert(Product entity)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                //avoiding duplicate brands
                Brand brand = context.Brands.Find(entity.BrandId);
                entity.Brand = brand;

                context.Products.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(Product entity)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                //avoiding duplicate brands
                Brand brand = context.Brands.Find(entity.BrandId);
                entity.Brand = brand;

                context.Products.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Remove(Product entity)
        {
            using (DbContext context = new ProductsBrandsDbContext())
            {
                context.Entry(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
