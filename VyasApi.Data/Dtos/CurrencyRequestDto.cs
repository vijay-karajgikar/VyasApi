using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	public class CurrencyRequestDto
	{
		public string CurrencyIds { get; set; }
		public string CurrencyAttributes { get; set; }
	}
}