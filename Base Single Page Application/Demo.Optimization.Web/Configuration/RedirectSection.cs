using System.Configuration;

namespace Base.SinglePageApplication.Configuration
{
    public class RedirectSection : ConfigurationSection
    {
        [ConfigurationProperty("",IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(RedirectCollection))]
        public RedirectCollection Redirects {
            get { return (RedirectCollection) base[""]; } }
    }
}