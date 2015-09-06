using System.Web.Mvc;
using Base.SinglePageApplication.Filters;

namespace Base.SinglePageApplication
{
    /// <summary>
    /// Configuration of all global filters.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters.</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PageAuthorizationAttribute());
        }
    }
}