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
        Success = 1000,

        [Description("未明確定義之錯誤")]
        Error = 1010,

        [Description("輸入參數錯誤")]
        InputError = 1020,

        [Description("查無資料")]
        DataNotFound = 1030,

        [Description("新增資料失敗")]
        DBUpdateFail = 1040,
    }
}
