#pragma checksum "C:\Users\pawlenko\Desktop\TODO\ToDo\ToDo.API\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e5cdc47499077a70ccd20548d6ab35e37bcc56e3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Default/Index.cshtml", typeof(AspNetCore.Views_Default_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5cdc47499077a70ccd20548d6ab35e37bcc56e3", @"/Views/Default/Index.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\pawlenko\Desktop\TODO\ToDo\ToDo.API\Views\Default\Index.cshtml"
  
   Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
            BeginContext(53, 655, true);
            WriteLiteral(@"


<div class=""card text-center"">
    <div class=""card-header"">

        <form class=""form-inline justify-content-center "" id=""addTaskFrom"" >
            <div class=""input-group mb-2 mr-sm-2 mb-sm-0"">
                <input type=""text"" class=""form-control"" id=""name"" placeholder=""Task name""/>
            </div>
            <button type=""submit"" class=""btn btn-primary my-2 my-sm-0"">Add task</button>
        </form>


    </div>
    <div class=""card-body"">

        <ul class=""list-group"" id=""listGroup"">
            
        </ul>

    </div>
    <div class=""card-footer text-muted"">
        Your ToDo list
    </div>
</div>

");
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