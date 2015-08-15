using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [DataContract(Name = "Group", Namespace = "")]
    public class MenuGroup
    {
        [DataMember(Order = 0)]
        public string Name { get; set; }

        [DataMember(Name = "MenuEntries", Order = 1)]
        public List<MenuEntry> MenuEntries { get; set; }

        public MenuGroup()
        {
            MenuEntries = new List<MenuEntry>();
        }

    }
}