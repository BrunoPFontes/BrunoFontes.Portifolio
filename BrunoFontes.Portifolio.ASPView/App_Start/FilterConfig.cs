using System.Web;
using System.Web.Mvc;

namespace BrunoFontes.Portifolio.ASPView
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
