using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;
using SistemaVendas.Dominio.Entidades;
using SistemaVendas.Helpers;

namespace SistemaVendas.Controllers
{
    public class ConfiguracaoController : Controller
    {
        private ApplicationDbContext mContext;
        private IHttpContextAccessor HttpContextAccessor;

        public ConfiguracaoController(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            mContext = context;
            HttpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            var codigoUsuario = HttpContextAccessor.HttpContext.Session.GetInt32(Sessao.CODIGO_USUARIO);

            Usuario objUsuario = mContext.Usuario.Where(x => x.Codigo == codigoUsuario).FirstOrDefault();

            return View(objUsuario);
        }
    }
}