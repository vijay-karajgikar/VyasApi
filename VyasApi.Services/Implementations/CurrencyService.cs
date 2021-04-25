using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using VyasApi.Services.Interfaces;
using VyasApi.Data.Dtos;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.AspNetCore.Http;

namespace VyasApi.Services.Implementations
{
	public class CurrencyService : ICurrencyService
	{
		private readonly HttpClient httpClient;
		private readonly string apiKey = "";
		private readonly string tickerUrl = "https://api.nomics.com/v1/currencies/ticker";
		private readonly string metadataUrl = "https://api.nomics.com/v1/currencies";

		public CurrencyService(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}


		// public async Task<ResponseDto<List<CurrencyDto>>> GetCurrencies(CurrencyRequestDto currencyRequest)
		// {
		// 	var queryStringValues = new Dictionary<string, string>();
		// 	queryStringValues.Add("key", apiKey);
		// 	if (!string.IsNullOrEmpty(currencyRequest.CurrencyIds)) queryStringValues.Add("ids", currencyRequest.CurrencyIds);
		// 	if (!string.IsNullOrEmpty(currencyRequest.CurrencyAttributes)) queryStringValues.Add("attributes", currencyRequest.CurrencyAttributes);

		// 	var uri = QueryHelpers.AddQueryString(
		// 		uri: "https://api.nomics.com/v1/currencies",
		// 		queryString: queryStringValues
		// 	);

		// 	try
		// 	{
		// 		var response = await httpClient.GetAsync(uri);
		// 		response.EnsureSuccessStatusCode();
		// 		var results = await response.Content.ReadAsAsync<List<CurrencyDto>>();
		// 		return new ResponseDto<List<CurrencyDto>>(results);
		// 	}
		// 	catch
		// 	{
		// 		throw;
		// 	}
		// }

		// public async Task<ResponseDto<List<CurrencyPriceDto>>> GetCurrencyPrices(CurrencyPriceRequestDto currencyPriceRequest)
		// {
		// 	var queryStringValues = new Dictionary<string, string>();
		// 	queryStringValues.Add("key", apiKey);

		// 	if (!string.IsNullOrEmpty(currencyPriceRequest.CurrencyIds)) queryStringValues.Add("ids", currencyPriceRequest.CurrencyIds);
		// 	if (!string.IsNullOrEmpty(currencyPriceRequest.Interval)) queryStringValues.Add("interval", currencyPriceRequest.Interval);

		// 	var uri = QueryHelpers.AddQueryString(
		// 		uri: "https://api.nomics.com/v1/currencies/ticker",
		// 		queryString: queryStringValues
		// 	);

		// 	try
		// 	{
		// 		var response = await httpClient.GetAsync(uri);
		// 		response.EnsureSuccessStatusCode();
		// 		var results = await response.Content.ReadAsAsync<List<CurrencyPriceDto>>();
		// 		return new ResponseDto<List<CurrencyPriceDto>>(results);
		// 	}
		// 	catch
		// 	{
		// 		throw;
		// 	}
		// }


		public Task<HttpResponseMessage> GetCurrenciesMetadata(QueryString queryString)
		{
			var requestUrl = EvalRequestUri(queryString, metadataUrl, apiKey);
			return httpClient.GetAsync(requestUrl);
		}

		public Task<HttpResponseMessage> GetCurrenciesTicker(QueryString queryString)
		{
			var requestUrl = EvalRequestUri(queryString, tickerUrl, apiKey);
			return httpClient.GetAsync(requestUrl);
		}


		private static string EvalRequestUri(QueryString queryString, string url, string apiKey)
		{
			var requestQueryStrings = queryString.Value.Replace("?", "").Split("&");
			var queryStringDict = new Dictionary<string, string>();
			queryStringDict.Add("key", apiKey);

			foreach (var item in requestQueryStrings)
			{
				var keyValueItem = item.Split("=");
				queryStringDict.Add(keyValueItem[0], keyValueItem[1]);
			}

			return QueryHelpers.AddQueryString(
				uri: url,
				queryString: queryStringDict
			);
		}


	}
}