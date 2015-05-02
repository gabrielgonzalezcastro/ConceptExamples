using System.Runtime.Serialization;

namespace GeoLib.Contracts
{
    /// <summary>
    /// DataContract is used to serialize the data. It can be used inside the WPF scope or 
    /// It can be used just for serialize object.
    /// </summary>
    [DataContract]
    public class ZipCodeData
    {
        [DataMember]
        public string City { get; set; }
        
        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string ZipCode { get; set; }
    }
}
