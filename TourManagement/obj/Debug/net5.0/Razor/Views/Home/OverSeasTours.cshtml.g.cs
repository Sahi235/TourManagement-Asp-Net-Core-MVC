#pragma checksum "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b4d35d3b3b8eed2ed73241878b3c3dbf02aec29"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OverSeasTours), @"mvc.1.0.view", @"/Views/Home/OverSeasTours.cshtml")]
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
#line 1 "E:\University project\TourManagement\TourManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\University project\TourManagement\TourManagement\Views\_ViewImports.cshtml"
using TourManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\University project\TourManagement\TourManagement\Views\_ViewImports.cshtml"
using TourManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\University project\TourManagement\TourManagement\Views\_ViewImports.cshtml"
using TourManagement.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\University project\TourManagement\TourManagement\Views\_ViewImports.cshtml"
using TourManagement.Constants;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b4d35d3b3b8eed2ed73241878b3c3dbf02aec29", @"/Views/Home/OverSeasTours.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a5cd46ac452bb789893884f1c991e1441d25179d", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OverSeasTours : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tour>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img-top"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TourRegister", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "TourRegistration", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success text-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""container-fluid pr-0 mt-2 main-part mb-4"">

    <!-- SIDEBAR START -->
    <aside class=""bd-sidebar main-part__1"">
        <nav class=""collapse bd-links"" id=""bd-docs-nav"" aria-label=""Docs navigation"">
            <ul class=""list-unstyled mb-0 py-3 pt-md-1"">
                ");
#nullable restore
#line 13 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
           Write(await Component.InvokeAsync("OverSeasCities"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </ul>\r\n        </nav>\r\n\r\n    </aside>\r\n    <!-- SIDEBAR END -->\r\n    <!-- MAIN START -->\r\n    <div class=\" main-part__2 row justify-content-center mt-3\">\r\n\r\n");
#nullable restore
#line 22 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
         foreach (var tour in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"card px-0 col-4\" style=\"width: 18rem;\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "9b4d35d3b3b8eed2ed73241878b3c3dbf02aec296467", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 4, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 704, "~/assets/images/", 704, 16, true);
#nullable restore
#line 25 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
AddHtmlAttributeValue("", 720, ImageOwners.TourImage, 720, 22, false);

#line default
#line hidden
#nullable disable
            AddHtmlAttributeValue("", 742, "/", 742, 1, true);
#nullable restore
#line 25 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
AddHtmlAttributeValue("", 743, tour.TourImages.FirstOrDefault()?.Image.ImageUrl, 743, 49, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                <div class=\"card-body pb-3 pt-3\">\r\n                    <h5 class=\"card-title text-center\">");
#nullable restore
#line 27 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                  Write(tour.TourName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n                    <p class=\"card-text text-center\"><strong>");
#nullable restore
#line 28 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                        Write(tour.From.ToString("dddd dd MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" &rarr;</strong> ");
#nullable restore
#line 28 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                                                                            Write(tour.Till.ToString("dddd dd MMMM"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                </div>\r\n                <ul class=\"list-group list-group-flush\">\r\n                    <li class=\"list-group-item list-group-item__1\">");
#nullable restore
#line 31 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                              Write(tour.InitialPrice.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 32 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                     foreach (var service in tour.Services)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li class=\"list-group-item list-group-item__1\">");
#nullable restore
#line 34 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                                  Write(service.Service.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 35 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n                <div class=\"card-body card-input\">\r\n");
#nullable restore
#line 38 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                     if (tour.Capacity > tour.TourRegistrations.Count)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b4d35d3b3b8eed2ed73241878b3c3dbf02aec2911233", async() => {
                WriteLiteral("Get Ticket");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-tourId", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 40 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                                                                                             WriteLiteral(tour.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tourId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-tourId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["tourId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 41 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"#\" class=\"btn btn-danger text-center\">Out of ticket</a>\r\n");
#nullable restore
#line 45 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n");
#nullable restore
#line 48 "E:\University project\TourManagement\TourManagement\Views\Home\OverSeasTours.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    </div>\r\n    <!-- MAIN END -->\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tour>> Html { get; private set; }
    }
}
#pragma warning restore 1591