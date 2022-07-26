#pragma checksum "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee0164e02f18465cf4661e0e9d23204dfe2b236d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Quarter.Areas.Admin.Views.Dashboard.Areas_Admin_Views_Dashboard_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
namespace Quarter.Areas.Admin.Views.Dashboard
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
#line 4 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\_ViewImports.cshtml"
using DAL.Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\_ViewImports.cshtml"
using Business.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\_ViewImports.cshtml"
using DAL.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee0164e02f18465cf4661e0e9d23204dfe2b236d", @"/Areas/Admin/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f4da2a019e84ed5470921699febee6c0a8b82e54", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DashboardVM>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/uploads/images/NoProfilePhoto.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "dashboard", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "deletecomment", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("user"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<div class=""container content-wrapper"">
    <div class=""row"">
        <div class=""col-md-7 grid-margin stretch-card"">
              <div class=""card"">
                <div class=""card-body"">
                  <p class=""card-title mb-0"">Comments</p>
                  <div class=""table-responsive"">
                    <table class=""table table-striped table-borderless"">
                      <thead>
                        <tr>
                          <th>Image</th>
                          <th>Username</th>
                          <th>Comment</th>
                          <th>Setting</th>
                        </tr>  
                      </thead>
                      <tbody>
");
#nullable restore
#line 20 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                         foreach (var comment in Model.Comments)
                       {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n");
#nullable restore
#line 23 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                           if(comment.AppUser.Image is not null)
                          {

#line default
#line hidden
#nullable disable
            WriteLiteral("                              <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee0164e02f18465cf4661e0e9d23204dfe2b236d7017", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 994, "~/assets/uploads/images/", 994, 24, true);
#nullable restore
#line 25 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
AddHtmlAttributeValue("", 1018, comment.AppUser.Image.Url, 1018, 26, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 26 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                          }else
                          {

#line default
#line hidden
#nullable disable
            WriteLiteral("                              <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee0164e02f18465cf4661e0e9d23204dfe2b236d8848", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n");
#nullable restore
#line 29 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                          }

#line default
#line hidden
#nullable disable
            WriteLiteral("                          <td class=\"font-weight-bold\">");
#nullable restore
#line 30 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                  Write(comment.AppUser.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                          <td>");
#nullable restore
#line 31 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                         Write(comment.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                          <td>\r\n                              ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ee0164e02f18465cf4661e0e9d23204dfe2b236d10836", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 33 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                                                          WriteLiteral(comment.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                          </td>\r\n                        </tr>\r\n");
#nullable restore
#line 36 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                       }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
            </div>
            <div class=""col-md-5 stretch-card grid-margin"">
              <div class=""card"">
                <div class=""card-body"">
                  <p class=""card-title"">FeedBacks</p>
                  <ul class=""icon-data-list"">
");
#nullable restore
#line 48 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                     foreach (var feedBack in Model.FeedBacks)
                   {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li>\r\n                      <div class=\"d-flex\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ee0164e02f18465cf4661e0e9d23204dfe2b236d14657", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2253, "~/assets/uploads/images/", 2253, 24, true);
#nullable restore
#line 52 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
AddHtmlAttributeValue("", 2277, feedBack.UserImage.Url, 2277, 23, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        <div>\r\n                          <p class=\"text-info mb-1\">");
#nullable restore
#line 54 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                                               Write(feedBack.AppUser.Firstname);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 54 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                                                                           Write(feedBack.AppUser.Lastname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                          <p class=\"mb-0\">");
#nullable restore
#line 55 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                                     Write(feedBack.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                        </div>\r\n                      </div>\r\n                    </li>\r\n");
#nullable restore
#line 59 "C:\Users\hsyna\Desktop\QaurterProject\Quarter\Quarter\Areas\Admin\Views\Dashboard\Index.cshtml"
                   }

#line default
#line hidden
#nullable disable
            WriteLiteral("                  </ul>\r\n                </div>\r\n              </div>\r\n            </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DashboardVM> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
