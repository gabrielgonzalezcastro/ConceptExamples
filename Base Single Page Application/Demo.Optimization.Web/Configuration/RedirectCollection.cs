using System.Configuration;

namespace Base.SinglePageApplication.Configuration
{
    public class RedirectCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Redirect();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Redirect) element).Title;
        }
    }
}