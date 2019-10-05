using App00.Common.Extensions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace App03.AppService.Communication
{
    public class ApiResponse
    {
        public ApiResponse(string message, EStatusCode eStatusCode)
        {
            this.Message = message ?? eStatusCode.ToDisplay();
            this.StatusCodeString = eStatusCode;
            this.StatusCode = (int)StatusCodeString;
        }

        public ApiResponse(string message) : this(message, EStatusCode.None)
        {
        }

        public string Message { get; set; }

        public int StatusCode { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public EStatusCode StatusCodeString { get; set; }

        public static implicit operator ApiResponse(OkResult okResult)
        {
            return new ApiResponse(null, EStatusCode.Successed);
        } 
        
    }

    public class ApiResponse<TResponseData> : ApiResponse where TResponseData : class
    {

        public ApiResponse(string message, EStatusCode eStatusCode, TResponseData data) : base(message, eStatusCode)
        {
            this.ResponseData = data;
        }

        public ApiResponse(string message, TResponseData data) : this(message, EStatusCode.None, data)
        {

        }

        public ApiResponse(EStatusCode statusCode, TResponseData data) : this(null, statusCode, data)
        {

        }

        public TResponseData ResponseData { get; set; }

        public static implicit operator ApiResponse<TResponseData>(OkResult result)
        {
            return new ApiResponse<TResponseData>(EStatusCode.Successed, null);
        }

        public static implicit operator ApiResponse<TResponseData>(OkObjectResult result)
        {
            return new ApiResponse<TResponseData>(EStatusCode.Successed, (TResponseData)result.Value);
        }

        public static implicit operator ApiResponse<TResponseData>(BadRequestResult result)
        {
            return new ApiResponse<TResponseData>(EStatusCode.BadRequest, null);
        }

        public static implicit operator ApiResponse<TResponseData>(BadRequestObjectResult result)
        {
            return new ApiResponse<TResponseData>(EStatusCode.BadRequest, (TResponseData)result.Value);
        }

        public static implicit operator ApiResponse<TResponseData>(NoContentResult result)
        {
            return new ApiResponse<TResponseData>(EStatusCode.NotContent, null);
        }
    }

    public enum EStatusCode : byte
    {
        [Display(Description = "عملیات انجام شد")]
        None = 0,

        [Display(Description = "عملیات با موفقیت انجام شد")]
        Successed,

        [Display(Description = "عملیات باانجام نشد احتمالا خطایی رخ داده است")]
        Fail,

        [Display(Description = "آدرس یا URL اشتباه است")]
        NotFound,

        [Display(Description = "مقادیر ارسال شده صحیح نمی باشد")]
        BadRequest,

        [Display(Description = "دسترسی به این آدرس برای شما مجاز نمیباشد")]
        AccessDenied,
        [Display(Description = "تغییرات اعمال نشد")]
        NotModified,

        [Display(Description = "هیچ منابعی حذف نشد.پارامترهای ارسسالی را بررسی کنید")]
        NotContent,
    }
}
