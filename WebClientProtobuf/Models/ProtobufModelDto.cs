using ProtoBuf;

namespace WebClientProtobuf.Models
{
    [ProtoContract]
	public class ProtobufModelDTO
	{
            [ProtoMember(1)]
            public int Id { get; set; }
            [ProtoMember(2)]
            public string Name { get; set; }
            [ProtoMember(3)]
            public string StringValue { get; set; }
        
	}
}