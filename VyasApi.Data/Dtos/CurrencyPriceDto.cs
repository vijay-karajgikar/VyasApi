using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	[DataContract]
	public class CurrencyPriceDto
	{
		[DataMember(Name = "id")] public string Id { get; set; }
		[DataMember(Name = "price")] public string Price { get; set; }
		[DataMember(Name = "price_date")] public string PriceDate { get; set; }
		[DataMember(Name = "symbol")] public string Symbol { get; set; }
		[DataMember(Name = "1h")] public CurrencyDiffDto HourDiff { get; set; }
		[DataMember(Name = "1d")] public CurrencyDiffDto DayDiff { get; set; }
		[DataMember(Name = "7d")] public CurrencyDiffDto SevenDayDiff { get; set; }
		[DataMember(Name = "30d")] public CurrencyDiffDto MonthDiff { get; set; }
		[DataMember(Name = "365d")] public CurrencyDiffDto YearDiff { get; set; }
		[DataMember(Name = "ytd")] public CurrencyDiffDto YearToDate { get; set; }
	}
}