
namespace GeekPeeked.Common.Models.Api.v1.Response
{
    public class ResponseResult
    {
        public const string Success = "SUCCESS";
        public const string Failed = "FAILED";
    }

    public class BaseResponseModel
    {
        public string Result { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
    }
}