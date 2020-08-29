#pragma checksum "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0724525216316c2d2d29da0d04eaa9624e25a6f3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Venda_Index), @"mvc.1.0.view", @"/Views/Venda/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Venda/Index.cshtml", typeof(AspNetCore.Views_Venda_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0724525216316c2d2d29da0d04eaa9624e25a6f3", @"/Views/Venda/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92b8143e28e2ecf99681febd0458bd3a62631f08", @"/Views/_ViewImports.cshtml")]
    public class Views_Venda_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SistemaVendas.Models.VendaViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(51, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
  
    ViewData["Title"] = "Vendas";

#line default
#line hidden
            BeginContext(95, 303, true);
            WriteLiteral(@"
<h2>Vendas Realizadas</h2>
<hr />

<table class=""table table-bordered"">
    <thead>
        <tr style=""background-color:#f6f6f6"">
            <th>Código</th>
            <th>Data</th>
            <th>Cliente</th>
            <th>Total da Venda</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 20 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(447, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=", 462, "", 491, 3);
            WriteAttributeValue("", 471, "Editar(", 471, 7, true);
#line 22 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
WriteAttributeValue("", 478, item.Codigo, 478, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 490, ")", 490, 1, true);
            EndWriteAttribute();
            BeginContext(491, 63, true);
            WriteLiteral(">\r\n                <td style=\"cursor:pointer;font-weight:bold\">");
            EndContext();
            BeginContext(555, 11, false);
#line 23 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
                                                       Write(item.Codigo);

#line default
#line hidden
            EndContext();
            BeginContext(566, 67, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer;font-weight:bold\">");
            EndContext();
            BeginContext(634, 32, false);
#line 24 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
                                                       Write(item.Data.ToString("dd/MM/yyyy"));

#line default
#line hidden
            EndContext();
            BeginContext(666, 67, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer;font-weight:bold\">");
            EndContext();
            BeginContext(734, 17, false);
#line 25 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
                                                       Write(item.Cliente.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(751, 67, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer;font-weight:bold\">");
            EndContext();
            BeginContext(819, 10, false);
#line 26 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
                                                       Write(item.Total);

#line default
#line hidden
            EndContext();
            BeginContext(829, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 28 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Venda\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(866, 378, true);
            WriteLiteral(@"    </tbody>
</table>
<button class=""btn btn-block btn-primary"" onclick=""Cadastrar()"">Cadastrar</button>

<script>
    function Editar(Codigo) {
        console.log(Codigo)
        window.location = window.origin + ""\\Venda\\Cadastro\\"" + Codigo;
    }


    function Cadastrar() {
        window.location = window.origin + ""\\Venda\\Cadastro"";
    }


</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SistemaVendas.Models.VendaViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
