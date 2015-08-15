using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xml_Serialization_And_Deserialization.Serializer
{
    [CollectionDataContract(Name = "AllowedGroups", ItemName = "Group", Namespace = "")]
    public class AllowedGroupsList : List<string>
    {
    }
}