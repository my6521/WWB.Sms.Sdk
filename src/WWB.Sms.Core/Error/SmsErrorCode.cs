using System.ComponentModel.DataAnnotations;

namespace WWB.Sms.Core.Error
{
    public enum SmsErrorCode
    {
        /// <summary>
        /// 没有错误
        /// </summary>
        [Display(Name = "没有错误")]
        None = 0,

        [Display(Name = "提供者未找到")]
        ProviderNotFound = 1000,

        /// <summary>
        /// 请求错误
        /// </summary>
        [Display(Name = "请求错误")]
        PostError = 1001,
    }
}