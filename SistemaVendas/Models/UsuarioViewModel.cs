using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendas.Models
{
    public class UsuarioViewModel
    {
        public int? Codigo { get; set; }
        [Required(ErrorMessage = "Informe o Nome para cadastro")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Email para cadastro")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}
