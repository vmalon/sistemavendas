#pragma checksum "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "14c832829b4c827bbb27cb38a671bbe1a95cbf4a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cliente_Index), @"mvc.1.0.view", @"/Views/Cliente/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Cliente/Index.cshtml", typeof(AspNetCore.Views_Cliente_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"14c832829b4c827bbb27cb38a671bbe1a95cbf4a", @"/Views/Cliente/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"92b8143e28e2ecf99681febd0458bd3a62631f08", @"/Views/_ViewImports.cshtml")]
    public class Views_Cliente_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<SistemaVendas.Models.ClienteViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(53, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
  
    ViewData["Title"] = "Clientes";

#line default
#line hidden
            BeginContext(99, 318, true);
            WriteLiteral(@"
<h1>Clientes</h1>
<hr />

<table class=""table table-bordered"">
    <thead>
        <tr style=""background-color:#f6f6f6"">
            <th>Código</th>
            <th>Nome</th>
            <th>CNPJ / CPF</th>
            <th>Email</th>
            <th>Celular</th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 21 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(466, 15, true);
            WriteLiteral("            <tr");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=", 481, "", 510, 3);
            WriteAttributeValue("", 490, "Editar(", 490, 7, true);
#line 23 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
WriteAttributeValue("", 497, item.Codigo, 497, 12, false);

#line default
#line hidden
            WriteAttributeValue("", 509, ")", 509, 1, true);
            EndWriteAttribute();
            BeginContext(510, 46, true);
            WriteLiteral(">\r\n                <td style=\"cursor:pointer\">");
            EndContext();
            BeginContext(557, 11, false);
#line 24 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
                                      Write(item.Codigo);

#line default
#line hidden
            EndContext();
            BeginContext(568, 50, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer\">");
            EndContext();
            BeginContext(619, 9, false);
#line 25 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
                                      Write(item.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(628, 50, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer\">");
            EndContext();
            BeginContext(679, 13, false);
#line 26 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
                                      Write(item.CNPJ_CPF);

#line default
#line hidden
            EndContext();
            BeginContext(692, 50, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer\">");
            EndContext();
            BeginContext(743, 10, false);
#line 27 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
                                      Write(item.Email);

#line default
#line hidden
            EndContext();
            BeginContext(753, 50, true);
            WriteLiteral("</td>\r\n                <td style=\"cursor:pointer\">");
            EndContext();
            BeginContext(804, 12, false);
#line 28 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
                                      Write(item.Celular);

#line default
#line hidden
            EndContext();
            BeginContext(816, 26, true);
            WriteLiteral("</td>\r\n            </tr>\r\n");
            EndContext();
#line 30 "C:\Users\Vinícius\Desktop\Udemy\Curso Web MVC\SistemaVendas\SistemaVendas\Views\Cliente\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(853, 376, true);
            WriteLiteral(@"    </tbody>
</table>
<hr />
<div>
    <button class=""btn btn-block btn-primary"" onclick=""Cadastrar()"">Cadastrar</button>
</div>
<script>
    function Cadastrar() {
        window.location = window.origin = ""\\Cliente\\Cadastro"";
    }

    function Editar(codigo) {
        window.location = window.origin = ""\\Cliente\\Cadastro\\"" + codigo;
    }

</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<SistemaVendas.Models.ClienteViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
