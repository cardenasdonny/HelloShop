using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelloShop.Models.Models
{
    public class Cliente
    {
        public int ClienteId { get; set;  }

        [Required(ErrorMessage ="El nombre y los apellidos son requeridos")]
        [StringLength(30, ErrorMessage = "Ingrese mínimo 5 caracteres y máximo 30", MinimumLength =5)]
        [Display(Name ="Nombres y apellidos")]
        public string Nombres { get; set; }

        [Required(ErrorMessage ="El email es requerido")]
        [EmailAddress(ErrorMessage = "El email es inválido")]
        public string Email { get; set; }

        [Display(Name = "Tipo de documento")]
        [Required(ErrorMessage = "El tipo de documento es requerido")]
        public int TipoDocumentoId { get; set; }


        [Required(ErrorMessage = "El documento es requerido")]
        [Range(9999, 999999999999999, ErrorMessage = "Documento inválido")]
        public string Documento { get; set; }

        public bool Estado { get; set; }
    }
}
