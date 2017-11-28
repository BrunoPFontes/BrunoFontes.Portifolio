using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrunoFontes.Portifolio.Repository.Standard
{
    /// <summary>
    /// @author - Bruno Fontes
    /// @version - 20171127
    /// 
    /// Generic interface that all repositories must follow
    /// 
    /// Task of List of T that allow me creating an async SelectAll method
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public interface IRepositoryGeneric<TDomain>
    {
        Task<List<TDomain>> SelectAll();
        TDomain SelectById(int id);
        void Insert(TDomain entity);
        void Update(TDomain entity);
        void Remove(TDomain entity);
    }
}
