using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WebAPiProtobuf.Models
{
    [DataContract]
	public class Film
	{
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public string Brand { get; set; }
        [DataMember(Order = 3)]
        public string Model { get; set; }
        [DataMember(Order = 4)]
        public bool Color { get; set; }
        [DataMember(Order = 5)]
        public IList<int> Iso { get; set; }
        [DataMember(Order = 6)]
        public int Frames { get; set; }
        [DataMember(Order = 7)]
        public int Size { get; set; }
        [DataMember(Order = 8)]
        public IList<DevelopingTime> DevelopingTimes { get; set; }
	}
}