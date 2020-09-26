using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using MusicArchive.Enumeration;
using System.Reflection;
using System.ComponentModel;

namespace MusicArchive.Models
{
    public class ApiResult<T> where T : new()
    {

        private string _message;

        /// <summary>回傳的結果</summary>
        public ApiResultCode Code { get; set; }

        /// <summary>回傳資料主體</summary>
        public T Data { get; set; }

        /// <summary>回傳的訊息</summary>
        public string Message
        {

            get
            {
                return string.IsNullOrEmpty(_message) ? GetEnumDescription(Code) : _message;
            }
            set
            {
                _message = value;
            }
        }

        public ApiResult()
        {
            Code = ApiResultCode.Ready;
            Data = default(T);
            Message = string.Empty;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }

        private static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null) return string.Empty;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }
    }
}
