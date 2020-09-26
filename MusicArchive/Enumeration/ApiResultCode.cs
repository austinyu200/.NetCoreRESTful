using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MusicArchive.Enumeration
{
    public enum ApiResultCode
    {
        [Description("Ready")]
        Ready = 0,

        [Description("呼叫成功")]
        Success = 200,

        [Description("未明確定義之錯誤")]
        Error = 1010,
    }
}
