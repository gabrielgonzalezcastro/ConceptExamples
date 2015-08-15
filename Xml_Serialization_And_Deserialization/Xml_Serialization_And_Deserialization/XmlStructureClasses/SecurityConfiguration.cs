using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [DataContract(Name = "SecurityConfiguration", Namespace = "")]
    public class SecurityConfiguration
    {
        [DataMember(Name = "MenuGroups", Order = 0)]
        public List<MenuGroup> MenuGroups { get; set; }

        [DataMember(Name = "HomePageDefinitions", Order = 1)]
        public HomePageForList HomePageDefinitions { get; set; }
        
        public SecurityConfiguration()
        {
            MenuGroups = new List<MenuGroup>();
            HomePageDefinitions = new HomePageForList();
        }
    }

}