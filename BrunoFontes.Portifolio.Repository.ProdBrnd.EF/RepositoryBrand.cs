using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrunoFontes.Portifolio.Domain;
using BrunoFontes.Portifolio.Persistent.EF.Context;
using BrunoFontes.Portifolio.Repository.Standard;

namespace BrunoFontes.Portifolio.Repository.ProdBrnd.EF
{
    /// <summary>
    /// @author - Bruno Fontes
    /// @version - 20171127
    /// 
    /// Create the brand's repository 
    /// </summary>
    public class RepositoryBrand : IRepositoryGeneric<Brand>
    {
        public Task<List<Brand>> SelectAll()
        {
            /*
             Task.Run() to load all brands in a different thread
             making the main's form load faster
             */
            return Task.Run(() =>
            {
                using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
                {
                    return context.Brands.ToList();
                }
            });

        }

        public Brand SelectById(int id)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                return context.Brands.Find(id);
            }
        }

        public void Insert(Brand entity)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                context.Brands.Add(entity);
                context.SaveChanges();
            }
        }

        public void Update(Brand entity)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                context.Brands.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }

        }

        public void Remove(Brand entity)
        {
            using (ProductsBrandsDbContext context = new ProductsBrandsDbContext())
            {
                context.Brands.Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();
            }

        }
    }
}
