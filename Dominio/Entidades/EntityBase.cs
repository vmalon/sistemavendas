using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades
{
    public class EntityBase
    {
        [Key]
        public int? Codigo { get; set; }
    }
}
