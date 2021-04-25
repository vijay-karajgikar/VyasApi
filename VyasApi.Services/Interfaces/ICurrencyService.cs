using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using VyasApi.Data.Dtos;

namespace VyasApi.Services.Interfaces
{
	public interface ICurrencyService
	{
		// Task<ResponseDto<List<CurrencyDto>>> GetCurrencies(CurrencyRequestDto currencyRequest);

		// Task<ResponseDto<List<CurrencyPriceDto>>> GetCurrencyPrices(CurrencyPriceRequestDto currencyPriceRequest);

		Task<HttpResponseMessage> GetCurrenciesMetadata(QueryString queryString);
		Task<HttpResponseMessage> GetCurrenciesTicker(QueryString queryString);
	}
}