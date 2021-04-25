using System.Runtime.Serialization;

namespace VyasApi.Data.Dtos
{
	[DataContract]
	public class ResponseDto<T>
	{
		[DataMember(Name = "code")] public string Code { get; set; }
		[DataMember(Name = "message")] public string Message { get; set; }
		[DataMember(Name = "data")] public T Data { get; set; }

		public ResponseDto(T data)
		{
			Data = data;
			Code = "Success";
		}

		public ResponseDto(string code, string message)
		{
			Code = code;
			Message = message;
		}
	}
}