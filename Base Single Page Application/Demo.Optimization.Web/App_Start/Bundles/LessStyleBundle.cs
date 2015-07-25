using System.Web.Optimization;

namespace Base.SinglePageApplication.Bundles
{
    /// <summary>
    /// Custom Bundle that use the LessTransform Class to transform the less files to css. the Css files are also allowed
    /// </summary>
    public class LessStyleBundle : Bundle
    {
        public LessStyleBundle(string virtualPath) : base(virtualPath, new LessTransform(), new CssMinify())
        {
            
        }
    }
}