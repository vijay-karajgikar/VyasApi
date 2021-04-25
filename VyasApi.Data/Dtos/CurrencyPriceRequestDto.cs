using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	public class CurrencyPriceRequestDto
	{
		public string CurrencyIds { get; set; }
		public string Interval { get; set; }
	}
}