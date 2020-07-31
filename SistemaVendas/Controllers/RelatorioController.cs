using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaVendas.DAL;

namespace SistemaVendas.Controllers
{
    public class RelatorioController : Controller
    {
        private ApplicationDbContext mContext;

        public RelatorioController(ApplicationDbContext _context)
        {
            mContext = _context;
        }


        public IActionResult Grafico()
        {
            return View();
        }
    }
}