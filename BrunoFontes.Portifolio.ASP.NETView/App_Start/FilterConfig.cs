using System.Web;
using System.Web.Mvc;

namespace BrunoFontes.Portifolio.ASP.NETView
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
