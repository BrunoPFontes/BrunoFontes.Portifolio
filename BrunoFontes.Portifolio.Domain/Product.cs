using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoFontes.Portifolio.Domain
{
    /// <summary>
    /// @author - Bruno Fontes
    /// @version - 20171127
    /// 
    /// Product's domain class that will receive an Id, Name, 
    /// BrandId because every product must have a Brand
    /// and an object Brand 
    /// </summary>
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
