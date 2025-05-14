using System.Web;
using System.Web.Mvc;

namespace UNLA_PS20251C_E07
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
