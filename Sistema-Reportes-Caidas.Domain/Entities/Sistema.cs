using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_Reportes_Caidas.Domain.Entities
{
    public class Sistema
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del sistema es obligatorio.")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres.")]
        [MaxLength(50, ErrorMessage = "El nombre no debe superar los 50 caracteres.")]
        public string? NombreSistema { get; set; }
    }
}
