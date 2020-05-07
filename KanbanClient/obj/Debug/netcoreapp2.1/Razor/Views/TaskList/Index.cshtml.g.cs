#pragma checksum "D:\Documents\Source-Code\ProjectKanban\KanbanClient\Views\TaskList\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "187e2b8f3d36de38695d34ab664a81ef82520c86"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_TaskList_Index), @"mvc.1.0.view", @"/Views/TaskList/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/TaskList/Index.cshtml", typeof(AspNetCore.Views_TaskList_Index))]
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
#line 1 "D:\Documents\Source-Code\ProjectKanban\KanbanClient\Views\_ViewImports.cshtml"
using KanbanClient;

#line default
#line hidden
#line 2 "D:\Documents\Source-Code\ProjectKanban\KanbanClient\Views\_ViewImports.cshtml"
using KanbanClient.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"187e2b8f3d36de38695d34ab664a81ef82520c86", @"/Views/TaskList/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"646b2085ccbf60c6530a52cb14132dc5b0e8fb25", @"/Views/_ViewImports.cshtml")]
    public class Views_TaskList_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/TaskListScript.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 2 "D:\Documents\Source-Code\ProjectKanban\KanbanClient\Views\TaskList\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Layouts/Layout.cshtml";

#line default
#line hidden
            BeginContext(90, 662, true);
            WriteLiteral(@"
<h2>Index</h2>
<div class=""container-fluid"">
    <!-- ============================================================== -->
    <!-- Bread crumb and right sidebar toggle -->
    <!-- ============================================================== -->
    <div class=""row page-titles"">
        <div class=""col-md-6 col-8 align-self-center"">
            <h3 class=""text-themecolor m-b-0 m-t-0"">Board TaskList</h3>
            <ol class=""breadcrumb"">
                <li class=""breadcrumb-item""><a href=""javascript:void(0)"">Home</a></li>
                <li class=""breadcrumb-item active"">Board TaskList</li>
            </ol>
        </div>
    </div>
");
            EndContext();
            BeginContext(767, 1072, true);
            WriteLiteral(@"    <div class=""container-fluid"">
        <div class=""card"">
            <div class=""card-body"">
                <h4 class=""card-title"">Project Chart</h4>
                <div id=""TaskListChart""></div>
                <div class=""row"">
                    <div class=""col-lg-6"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h4 class=""card-title"">TaskList Donut Chart</h4>
                                <div id=""DonutChart""></div>
                            </div>
                        </div>
                    </div>

                    <div class=""col-lg-6"">
                        <div class=""card"">
                            <div class=""card-body"">
                                <h4 class=""card-title"">TaskList Bar Chart</h4>
                                <div id=""BarChart""></div>
                            </div>
                        </div>
                    </div>
                </div>
");
            WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
            BeginContext(1860, 1755, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-12"">
            <div class=""card"">
                <div class=""card-body"">
                    <div class=""d-flex justify-content-between"">
                        <div>
                            <h2>Project</h2>
                        </div>
                        <div>
                            <button class=""btn pull-right hidden-sm-down btn-success"" id=""BtnAdd"" data-toggle=""modal"" data-target=""#myModal""><i class=""mdi mdi-plus-circle""></i> Add Project</button>
                        </div>
                    </div>

                    <div class=""table-responsive m-t-40"">
                        <table id=""TaskList"" class=""table table-striped"">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>Project</th>
                                    <th>Status</th>
                                    <th>Create Date</th>
      ");
            WriteLiteral(@"                              <th>Action</th>
                                </tr>
                            </thead>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>

<!-- Modal content-->
<div id=""myModal"" class=""modal fade"" role=""dialog"">
    <div class=""modal-dialog modal-lg"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"">Add TaskList</h4>
                <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
            </div>
            <div class=""modal-body"">
                <div class=""container"">
                    ");
            EndContext();
            BeginContext(3615, 1036, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0b41f47c244042308f7ae0f8fee15d4e", async() => {
                BeginContext(3621, 1023, true);
                WriteLiteral(@"
                        <div class=""form-group"" hidden>
                            <label>Id:</label>
                            <input type=""text"" class=""form-control"" id=""Id"" name=""Id"">
                        </div>

                        <div class=""form-group"">
                            <label for=""Name"">Name :</label>
                            <input type=""text"" class=""form-control"" id=""Name"" placeholder=""Name"">
                        </div>

                        <div class=""form-group"">
                            <label for=""Status"">Status :</label>
                            <input type=""text"" class=""form-control"" id=""Status"" placeholder=""Status"">
                        </div>

                        <div class=""form-group"">
                                <label for=""ProjectOption"">Project :</label>
                                <select class=""form-control"" id=""ProjectOption"" name=""ProjectOption""></select>
                            </div>
                    ");
                EndContext();
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
            EndContext();
            BeginContext(4651, 477, true);
            WriteLiteral(@"
                </div>
                <div class=""modal-footer"">
                    <button id=""UpdateBtn"" type=""button"" onclick=""Edit()"" class=""btn btn-success"">Update</button>
                    <button id=""SaveBtn"" type=""button"" onclick=""Save()"" class=""btn btn-success"">Save</button>
                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </div>



");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5149, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(5159, 51, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfd1b4259fee4d269eaae13df3840f5f", async() => {
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
                EndContext();
                BeginContext(5210, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
            }
            );
            BeginContext(5219, 2, true);
            WriteLiteral("\r\n");
            EndContext();
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
