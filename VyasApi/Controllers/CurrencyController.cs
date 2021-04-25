using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VyasApi.Data.Dtos;
using VyasApi.Services.Interfaces;
using VyasApi.Utils;

namespace VyasApi.Controllers
{
	[ApiController]
	[Route("/api/currency")]
	public class CurrencyController : ControllerBase
	{
		private readonly ICurrencyService currencyService;

		public CurrencyController(ICurrencyService currencyService)
		{
			this.currencyService = currencyService;
		}


		// [HttpPost("metadata")]
		// public async Task<IActionResult> GetCurrencies([FromBody] CurrencyRequestDto currencyRequest)
		// {
		// 	try
		// 	{
		// 		var response = await currencyService.GetCurrencies(currencyRequest);
		// 		if (response.Code == "Success")
		// 		{
		// 			return Ok(response.Data);
		// 		}
		// 		else
		// 		{
		// 			return StatusCode(StatusCodes.Status500InternalServerError, response);
		// 		}
		// 	}
		// 	catch (System.Exception ex)
		// 	{
		// 		return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDto<string>(null)
		// 		{
		// 			Code = "Failure",
		// 			Message = ex.Message
		// 		});
		// 	}
		// }

		// [HttpPost("prices")]
		// public async Task<IActionResult> GetCurrencyPrices([FromBody] CurrencyPriceRequestDto currencyPriceRequest)
		// {
		// 	var response = await currencyService.GetCurrencyPrices(currencyPriceRequest);
		// 	if (response.Code == "Success")
		// 	{
		// 		return Ok(response.Data);
		// 	}
		// 	else
		// 	{
		// 		return StatusCode(StatusCodes.Status500InternalServerError, response);
		// 	}
		// }


		[HttpGet("metadata")]
		public async Task<IActionResult> GetMetadata()
		{
			try
			{
				var response = await currencyService.GetCurrenciesMetadata(Request.QueryString);
				this.HttpContext.Response.RegisterForDispose(response);
				return new HttpResponseMessageResult(response);
			}
			catch
			{
				//TODO: log the exception and respond with Internal Server error or appropriate.
				throw;
			}
		}

		[HttpGet("ticker")]
		public async Task<IActionResult> GetTicker()
		{
			try
			{
				var response = await currencyService.GetCurrenciesTicker(Request.QueryString);
				this.HttpContext.Response.RegisterForDispose(response);
				return new HttpResponseMessageResult(response);
			}
			catch
			{
				//TODO: log the exception and respond with Internal Server error or appropriate.
				throw;
			}
		}
	}
}