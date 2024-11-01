﻿using System.ComponentModel.DataAnnotations;

namespace Tecnico.Data.Models
{
    internal class Clientes
    {
        [Key]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [StringLength(50)]
        [RegularExpression("^[a-zA-ZÀ-ÿ\\s]+$", ErrorMessage = "Solo se permiten letras.")]
        public string? Nombres { get; set; }

        [Required(ErrorMessage = "Campo Obligatorio")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Solo se permiten números.")]
        [StringLength(10)]
        public string? Telefono { get; set; }
    }
}
