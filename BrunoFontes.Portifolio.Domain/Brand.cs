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
    /// Brand's domain class that will receive an Id, Name and a list of Products 
    /// </summary>
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
