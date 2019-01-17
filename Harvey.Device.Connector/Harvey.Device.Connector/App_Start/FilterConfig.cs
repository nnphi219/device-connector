using System.Web;
using System.Web.Mvc;

namespace Harvey.Device.Connector
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
