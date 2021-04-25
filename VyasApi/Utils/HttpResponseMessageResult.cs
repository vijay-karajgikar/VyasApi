using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace VyasApi.Utils
{
	public class HttpResponseMessageResult : IActionResult
	{
		private readonly HttpResponseMessage responseMessage;

		public HttpResponseMessageResult(HttpResponseMessage responseMessage)
		{
			this.responseMessage = responseMessage;
		}

		public async Task ExecuteResultAsync(ActionContext context)
		{

			var response = context.HttpContext.Response;
			if (responseMessage == null)
			{
				var message = "Response Message cannot be null";
				throw new InvalidOperationException(message);
			}

			using (responseMessage)
			{
				response.StatusCode = (int)responseMessage.StatusCode;
				var responseFeatures = context.HttpContext.Features.Get<IHttpResponseFeature>();
				if (responseFeatures != null)
				{
					responseFeatures.ReasonPhrase = responseMessage.ReasonPhrase;
				}
				var responseHeaders = responseMessage.Headers;
				if (responseHeaders.TransferEncodingChunked == true && responseHeaders.TransferEncoding.Count == 1)
				{
					responseHeaders.TransferEncoding.Clear();
				}

				foreach (var header in responseHeaders)
				{
					response.Headers.Append(header.Key, header.Value.ToArray());
				}

				if (responseMessage.Content != null)
				{
					var contentHeaders = responseMessage.Content.Headers;
					var unusedLength = contentHeaders.ContentLength;

					foreach (var header in contentHeaders)
					{
						response.Headers.Append(header.Key, header.Value.ToArray());
					}

					await responseMessage.Content.CopyToAsync(response.Body);
				}
			}

			// context.HttpContext.Response.ContentType = "application/json";
			// context.HttpContext.Response.StatusCode = (int)responseMessage.StatusCode;
			// foreach (var header in responseMessage.Headers)
			// {
			// 	context.HttpContext.Response.Headers.TryAdd(header.Key, new StringValues(header.Value.ToArray()));
			// }

			// using (var stream = await responseMessage.Content.ReadAsStreamAsync())
			// {
			// 	await stream.CopyToAsync(context.HttpContext.Response.Body);
			// 	await context.HttpContext.Response.Body.FlushAsync();
			// }
		}
	}
}