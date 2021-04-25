using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	[DataContract]
	public class CurrencyDiffDto
	{
		[DataMember(Name = "price_change")] public string PriceChange { get; set; }
		[DataMember(Name = "price_change_pct")] public string PriceChangePercent { get; set; }
		[DataMember(Name = "volume")] public string Volume { get; set; }
		[DataMember(Name = "volume_change")] public string VolumeChange { get; set; }
		[DataMember(Name = "volume_change_pct")] public string VolumeChangePercent { get; set; }
	}
}