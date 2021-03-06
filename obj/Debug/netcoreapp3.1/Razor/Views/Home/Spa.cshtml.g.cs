#pragma checksum "C:\Users\sunay\source\repos\WebApplication2\SpaApplication\Views\Home\Spa.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2117ac8cc83d63b99f5906e1c70c5e1cb30657da"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Spa), @"mvc.1.0.view", @"/Views/Home/Spa.cshtml")]
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
#line 1 "C:\Users\sunay\source\repos\WebApplication2\SpaApplication\Views\_ViewImports.cshtml"
using SpaApplication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\sunay\source\repos\WebApplication2\SpaApplication\Views\_ViewImports.cshtml"
using SpaApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2117ac8cc83d63b99f5906e1c70c5e1cb30657da", @"/Views/Home/Spa.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82304cc179d22076e8eb3169bd200b940f0db398", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Spa : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Users\sunay\source\repos\WebApplication2\SpaApplication\Views\Home\Spa.cshtml"
  
    ViewData["Title"] = "Spa";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"">

        $(document).ready(function () {

            //var token = localStorage.getItem(""token"");

            //if (token == null) {
            //    $(""#loginDiv"").show();
            //    $(""#userDiv"").hide();

            //}
            //else {
            //    $(""#loginDiv"").hide();
            //    $(""#userDiv"").show(); 
            //}

            getUserData();

            function showProduct() {

                let url = ""https://localhost:44398/api/product"";

                let accestoken = localStorage.getItem(""token"");


                $.ajax({
                    type: ""GET"",
                    crossDomain: true,
                    url: url,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader(""Authorization"", ""Bearer "" + accestoken)
                    },
                    success: function (products) {

                        var table = `<table>< tr ><th>Company</t");
                WriteLiteral(@"h><th>Contact</th><th>Country</th></tr >`;

                        $.each(products, (key, val) => {


                            table += `<tr><td>${val.name}`




                        })
                        table += ""</table >"";


                        $(""productDiv"").html(table);

                    },
                    error: function (error) {
                        $(""productDiv"").html(""ürün bulunamadı"");

                    },

                    contentType: ""application/json"",
                    dataType: ""json""




                })

            }


            $(""#btnSave"").click(function () {

                //dataları formdan aldığımız bölüm
                let name = $(""#Name"").val();
                let SurName = $(""#SurName"").val();
                let Email = $(""#Email"").val();
                let Password = $(""#Password"").val();

                //aldığımız dataları 
                let user = { ""Name"": name, ""SurName"": SurName, ""E");
                WriteLiteral(@"mail"": Email, ""Password"": Password };

                //verileri göndereceğimiz url
                var url = ""https://localhost:44398/api/User"";

                //data bölümü aldığımız dataları json a dönüştürdüğümüz yer
                $.ajax({
                    type: ""POST"",
                    crossDomain: true,
                    url: url,
                    data: JSON.stringify(user),
                    success: function (data) {
                        console.table(data);

                    },
                    error: function (error) {  },
                    contentType: ""application/json"",
                    dataType:""json""


                })



            })

            function getUserDataRefreshToken() {


                let refreshToken = localStorage.getItem(""refreshToken"");

                let url = ""https://localhost:44398/api/Login/refreshToken"";

                var data = { ""RefreshToken"": refreshToken };

                $.ajax({

  ");
                WriteLiteral(@"                  type: ""POST"",
                    url: url,
                    async: false,
                    crossDomain: true,
                    data: JSON.stringify(data),
                    
                    success: function (data) {

                        console.table(data);
                        localStorage.setItem(""token"", data.token);
                        localStorage.setItem(""refreshToken"", data.refreshToken);
                        getUserData();


                    },
                    error: function (error) { },
                    contentType: ""application/json"",
                    dataType: ""json""

                })


            }


            function getUserData()
            {
                let url = ""https://localhost:44398/api/User"";

                let accestoken = localStorage.getItem(""token"");

                $.ajax({
                    type: ""GET"",
                    url: url,
                    async: false,
    ");
                WriteLiteral(@"                crossDomain: true,
                    beforeSend: function (xhr) {
                        xhr.setRequestHeader(""Authorization"", ""Bearer "" + accestoken)
                    },
                    statusCode: {
                        401: function () {

                            getUserDataRefreshToken();





                        },
                        

                    },
                    success: function (data) {
                        $(""#loginDiv"").hide();

                        $(""#userDiv"").show().html("""").append(${ data.SurName } ${ data.name });




                    },
                    error: function (error) { },
                    contentType: ""application/json"",
                    dataType: ""json""


                })



            }

            $(""#btnLogin"").click(function () {

                //dataları formdan aldığımız bölüm
               
                let Email = $(""#LoginEmail"").val();
            ");
                WriteLiteral(@"    let Password = $(""#LoginPassword"").val();

                //aldığımız dataları 
                let user = { ""LoginEmail"": Email, ""LoginPassword"": Password };

                //verileri göndereceğimiz url
                var url = ""https://localhost:44398/api/Login/AccessToken"";

                //data bölümü aldığımız dataları json a dönüştürdüğümüz yer
                $.ajax({
                    type: ""POST"",
                    crossDomain: true,
                    url: url,
                    data: JSON.stringify(user),
                    success: function (data) {
                        console.table(data);
                        localStorage.setItem(""token"", data.token);
                        localStorage.setItem(""refreshToken"", data.refreshToken);

                    },
                    error: function (error) { },
                    contentType: ""application/json"",
                    dataType: ""json""


                })



            })


         ");
                WriteLiteral("   \r\n\r\n\r\n\r\n\r\n\r\n        })\r\n    </script>\r\n   \r\n\r\n");
            }
            );
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-6\">\r\n            <h2>Üye kayıt formu</h2>\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2117ac8cc83d63b99f5906e1c70c5e1cb30657da10299", async() => {
                WriteLiteral(@"
                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" id=""Name"" placeholder=""isminiz"" value=""emre"" />
                </div>

                <div class=""form-group"">
                    <input type=""text"" class=""form-control"" id=""SurName"" placeholder=""Soy isminiz"" value=""sen"" />
                </div>


                <div class=""form-group"">
                    <input type=""email"" class=""form-control"" id=""Email"" placeholder=""Email adresiniz"" value=""emresen@zudunya.com"" />
                </div>

                <div class=""form-group"">
                    <input type=""password"" class=""form-control"" id=""Password"" placeholder=""şifreniz"" value=""1234"" />
                </div>

                <button type=""button"" id=""btnSave"" class=""btn btn-primary"">Kaydet</button>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n        </div>\r\n\r\n        <div class=\"col-md-6\">\r\n            <div id=\"userDiv\">\r\n\r\n            </div>\r\n\r\n            <div id=\"loginDiv\">\r\n                <h2>Üye Giriş Formu</h2>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2117ac8cc83d63b99f5906e1c70c5e1cb30657da12679", async() => {
                WriteLiteral(@"
                    <div class=""form-group"">
                        <input type=""email"" class=""form-control"" id=""LoginEmail"" placeholder=""mail adresiniz"" value=""eemmresen@gmail.com"" />
                    </div>

                    <div class=""form-group"">
                        <input type=""password"" class=""form-control"" id=""LoginPassword"" placeholder=""şifreniz"" value=""1234"" />
                    </div>
                    <button type=""button"" class=""btn btn-success"" id=""btnLogin"">Giriş</button>
                ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n\r\n    </div>\r\n\r\n    <div class=\"row\">\r\n\r\n\r\n        <div id=\"productDiv\"></div>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
