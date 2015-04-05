using System.Runtime.Serialization;

namespace Model
{
    [DataContract]
    public class DevelopingTime
	{
        [DataMember(Order = 1)]
        public int Id { get; set; }
        [DataMember(Order = 2)]
        public int Iso { get; set; }
        [DataMember(Order = 3)]
        public int? PushedOrPulledTo { get; set; }
        [DataMember(Order = 4)]
        public double Development { get; set; }
        [DataMember(Order = 5)]
        public double Stop { get; set; }
        [DataMember(Order = 6)]
        public double Fix { get; set; }
        [DataMember(Order = 7)]
        public int AgitationInterval { get; set; }
        [DataMember(Order = 8)]
        public string Notes { get; set; }
    }
}