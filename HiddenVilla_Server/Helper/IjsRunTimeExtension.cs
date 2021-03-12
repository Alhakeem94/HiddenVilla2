using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiddenVilla_Server.Helper
{
    public static class IjsRunTimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime jSRuntime ,string Message )
        {
            await jSRuntime.InvokeVoidAsync("ShowToaster", "Success", Message);
        }
        public static async ValueTask ToastrFailure(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("ShowToaster", "Error", Message);
        }
        public static async ValueTask SweetAlertSuccess(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("SweetAlert", "Success",Message);
        }
        public static async ValueTask SweetAlertFailed(this IJSRuntime jSRuntime, string Message)
        {
            await jSRuntime.InvokeVoidAsync("SweetAlert", "Error",Message);
        }
    }
}
