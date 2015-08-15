using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [DataContract(Name = "HomePageFor",Namespace = "")]
    public class HomePageFor
    {
        [DataMember(Order = 0)]
        public string Group { get; set; }

        [DataMember(Order = 1)]
        public string Url { get; set; }
    }
}