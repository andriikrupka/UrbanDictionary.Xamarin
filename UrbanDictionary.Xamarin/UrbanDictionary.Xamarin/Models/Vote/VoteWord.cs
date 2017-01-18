using System.Runtime.Serialization;

namespace UrbanDictionary.Models
{
    [DataContract]
    public class VoteWord
    {
        [DataMember(Name = "status")]
        public VoteStatus Status { get; set; }

        [DataMember(Name = "up")]
        public int Up { get; set; }

        [DataMember(Name = "down")]
        public int Down { get; set; }
    }
}