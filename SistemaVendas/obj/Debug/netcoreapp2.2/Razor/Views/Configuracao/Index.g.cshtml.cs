#pragma checksum "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Configuracao\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "166e4d930378f86d6591bcb3576e8d96a5cfd7bf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Configuracao_Index), @"mvc.1.0.view", @"/Views/Configuracao/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Configuracao/Index.cshtml", typeof(AspNetCore.Views_Configuracao_Index))]
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
#line 1 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\_ViewImports.cshtml"
using SistemaVendas;

#line default
#line hidden
#line 2 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\_ViewImports.cshtml"
using SistemaVendas.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"166e4d930378f86d6591bcb3576e8d96a5cfd7bf", @"/Views/Configuracao/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92b8143e28e2ecf99681febd0458bd3a62631f08", @"/Views/_ViewImports.cshtml")]
    public class Views_Configuracao_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SistemaVendas.Entidades.Usuario>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(40, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Configuracao\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(83, 176, true);
            WriteLiteral("\r\n<h1>Dados do acesso</h1>\r\n\r\n<div class=\"container\">\r\n    <div class=\"form-group col-4\">\r\n        <label>Nome</label>\r\n        <input class=\"form-control\" type=\"text\" readonly");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 259, "\"", 278, 1);
#line 12 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Configuracao\Index.cshtml"
WriteAttributeValue("", 267, Model.Nome, 267, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(279, 92, true);
            WriteLiteral(" />\r\n        <label>E-mail</label>\r\n        <input class=\"form-control\" type=\"text\" readonly");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 371, "\"", 391, 1);
#line 14 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Configuracao\Index.cshtml"
WriteAttributeValue("", 379, Model.Email, 379, 12, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(392, 23, true);
            WriteLiteral(" />\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SistemaVendas.Entidades.Usuario> Html { get; private set; }
    }
}
#pragma warning restore 1591
