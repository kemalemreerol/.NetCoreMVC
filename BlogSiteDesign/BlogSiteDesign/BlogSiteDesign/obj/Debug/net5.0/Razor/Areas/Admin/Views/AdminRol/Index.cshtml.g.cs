#pragma checksum "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d6cc576f2cb67a71845d970338586db327fe954b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_AdminRol_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/AdminRol/Index.cshtml")]
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
#line 1 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\_ViewImports.cshtml"
using BlogSiteDesign.Areas.Admin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\_ViewImports.cshtml"
using BlogSiteDesign.Areas.Admin.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
using EntitiyLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6cc576f2cb67a71845d970338586db327fe954b", @"/Areas/Admin/Views/AdminRol/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"892d9d89b8fc5a802e63b61fb733c54541b6102d", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_AdminRol_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<AppRole>>
    #nullable disable
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d6cc576f2cb67a71845d970338586db327fe954b3890", async() => {
                WriteLiteral(@"
    <div class=""wrapper wrapper-content animated fadeInRight"">
        <div class=""row"">
            <div class=""col-lg-12"">
                <div class=""ibox-title"">
                    <h5>Roller</h5>
                    <div class=""ibox-tools"">
                        <a class=""collapse-link"">
                            <i class=""fa fa-chevron-up""></i>
                        </a>
                        <a class=""dropdown-toggle"" data-toggle=""dropdown"" href=""#"">
                            <i class=""fa fa-wrench""></i>
                        </a>
                        <ul class=""dropdown-menu dropdown-user"">
                            <li>
                                <a href=""#"" class=""dropdown-item"">Config option 1</a>
                            </li>
                            <li>
                                <a href=""#"" class=""dropdown-item"">Config option 2</a>
                            </li>
                        </ul>
                        <a class=""close-link");
                WriteLiteral(@""">
                            <i class=""fa fa-times""></i>
                        </a>
                    </div>
                </div>
                <div class=""ibox-content"">
                    <table class=""table table-hover"">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>Başlık</th>
                                <th>Sil</th>
                                <th>Düzenle</th>
                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 47 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <tr>\r\n                                    <th>");
#nullable restore
#line 50 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
                                   Write(item.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</th>\r\n                                    <td>");
#nullable restore
#line 51 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
                                   Write(item.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                                    <td><a");
                BeginWriteAttribute("href", " href=\"", 2061, "\"", 2103, 2);
                WriteAttributeValue("", 2068, "/Admin/AdminRol/DeleteRole/", 2068, 27, true);
#nullable restore
#line 52 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
WriteAttributeValue("", 2095, item.Id, 2095, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-outline-danger\">Sil</a></td>\r\n                                    <td><a");
                BeginWriteAttribute("href", " href=\"", 2192, "\"", 2234, 2);
                WriteAttributeValue("", 2199, "/Admin/AdminRol/UpdateRole/", 2199, 27, true);
#nullable restore
#line 53 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
WriteAttributeValue("", 2226, item.Id, 2226, 8, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-outline-success\">Güncelle</a></td>\r\n\r\n                                </tr>\r\n");
#nullable restore
#line 56 "C:\Users\kemre\OneDrive\Masaüstü\MVC PROJE KEE\BlogSiteDesign\BlogSiteDesign\Areas\Admin\Views\AdminRol\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                        </tbody>
                    </table>
                    <a href=""/Admin/AdminRol/AddRole/"" class=""btn btn-outline-primary"">Yeni Rol Ekle</a>
                    <a href=""/Admin/AdminRol/UserRoleList/"" class=""btn btn-outline-primary"">Kullanıcı Rol Listesi</a>
                </div>
            </div>
        </div>
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<AppRole>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
