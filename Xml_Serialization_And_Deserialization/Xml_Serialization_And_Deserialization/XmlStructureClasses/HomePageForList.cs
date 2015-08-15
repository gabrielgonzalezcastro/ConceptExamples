using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [CollectionDataContract(Name = "HomePageDefinitions", ItemName = "HomePageFor", Namespace = "")]
    public class HomePageForList : List<HomePageFor>
    {
    }
}