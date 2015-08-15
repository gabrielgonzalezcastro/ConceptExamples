using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [DataContract(Name = "MenuEntry", Namespace = "")]
    public class MenuEntry
    {
        [DataMember(Order = 0)]
        public string Role { get; set; }

        [DataMember(Order = 1)]
        public string Title { get; set; }

        [DataMember(Order = 2)]
        public string Link { get; set; }

        [DataMember(Order = 3)]
        public AllowedGroupsList AllowedGroups { get; set; }

        public MenuEntry()
        {
            AllowedGroups = new AllowedGroupsList();
        }
    }
}