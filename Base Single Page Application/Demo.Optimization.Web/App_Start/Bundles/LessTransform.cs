using System.Web.Optimization;

namespace Base.SinglePageApplication.Bundles
{
    /// <summary>
    /// This class is used to transform the less files to css files using bundle.
    /// </summary>
    public class LessTransform : IBundleTransform
    {
        public void Process(BundleContext context, BundleResponse response)
        {
            //perform the transformation using the dotless library downloaded by nuget 
            response.Content = dotless.Core.Less.Parse(response.Content);
            response.Content = "text/css";
        }
    }
}