#pragma checksum "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\Booking\History.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c4c1b7ac84bf781987ab6ad086ae89cbe8395d0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking_History), @"mvc.1.0.view", @"/Views/Booking/History.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\_ViewImports.cshtml"
using BookingMeetingRoom;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\_ViewImports.cshtml"
using BookingMeetingRoom.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c4c1b7ac84bf781987ab6ad086ae89cbe8395d0", @"/Views/Booking/History.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36cccc290f50f8c46077eb744da51c6e1baf2d4f", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Booking_History : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/iRoom.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("30"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded me-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("..."), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\Booking\History.cshtml"
  
    ViewData["Title"] = "History Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""container mt-4"">
    <div class=""row justify-content-start"">
        <div class=""col-lg-10 col-md-12 col-sm-12"">
            <h3 class=""text-uppercase fw-bold blog-graphic-text col-2"">
                <i class=""bi bi-check-circle""></i> History
            </h3>
        </div>
    </div>

    
</div>

<button type=""button"" id=""liveToastBtn"" style=""display: none;""></button>

<div class=""toast-container position-fixed top-0 end-0 p-3"">
    <div id=""liveToast"" class=""toast"" role=""alert"" aria-live=""assertive"" aria-atomic=""true"">
        <div class=""toast-header"">
            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "1c4c1b7ac84bf781987ab6ad086ae89cbe8395d05576", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
            <strong class=""me-auto"">iRoom</strong>
            <small>just now</small>
            <button type=""button"" class=""btn-close"" data-bs-dismiss=""toast"" aria-label=""Close""></button>
        </div>
        <div class=""toast-body"">
            Your booking has been booked.
        </div>
    </div>
</div>

<script src=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/js/bootstrap.min.js""
        integrity=""sha384-IDwe1+LCz02ROU9k972gdyvl+AESN10+x7tBKgc9I5HFtuNz0wWnPclzo6p9vxnk""
        crossorigin=""anonymous""></script>
<link href=""https://cdn.jsdelivr.net/npm/bootstrap@5.2.2/dist/css/bootstrap.min.css"" rel=""stylesheet""
          integrity=""sha384-Zenh87qX5JnK2Jl0vWa8Ck2rdkQ2Bzep5IDxbcnCeuOxjzrPF/et3URy9Bv1WTRi""
          crossorigin=""anonymous"">
<script type=""text/javascript"">

    const toastTrigger = document.getElementById('liveToastBtn')
    const toastLiveExample = document.getElementById('liveToast')
    if (toastTrigger) 
    {
        toastTrigger.addEventListener('cli");
            WriteLiteral("ck\', () => {\r\n            const toast = new bootstrap.Toast(toastLiveExample);\r\n\r\n            toast.show();\r\n        })\r\n    }\r\n\r\n    function ClickShowToast()\r\n    {\r\n        document.getElementById(\'liveToastBtn\').click();\r\n    }\r\n\r\n</script>\r\n\r\n");
#nullable restore
#line 59 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\Booking\History.cshtml"
 if (ViewBag.JavaScriptFunction != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <script type=\"text/javascript\">\r\n        ");
#nullable restore
#line 62 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\Booking\History.cshtml"
   Write(Html.Raw(ViewBag.JavaScriptFunction));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </script>\r\n");
#nullable restore
#line 64 "C:\Users\Suttipong Tanmuangma\source\Workspaces\Workspace\BookingMeetingRoom\BookingMeetingRoom\Views\Booking\History.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
