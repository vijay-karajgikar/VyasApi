using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	[DataContract]
	public class CurrencyDto
	{
		[DataMember(Name = "id")] public string Id { get; set; }
		[DataMember(Name = "original_symbol")] public string Symbol { get; set; }
		[DataMember(Name = "name")] public string Name { get; set; }
		[DataMember(Name = "description")] public string Description { get; set; }
		[DataMember(Name = "logo_url")] public string LogoUrl { get; set; }
	}
}