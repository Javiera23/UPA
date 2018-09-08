using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    /// <summary>
    /// Clase que representa un Cliente.
    /// </summary>

    public class Cliente : BaseEntity
    {
        /// <summary>
        /// Nombre del cliente
        /// </summary>
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Correo Electronico del cliente
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <inheritdoc cref= "BaseEntity.Validate"/>
        public override void Validate()
        {
            // Validacion de Nombre
            if (String.IsNullOrEmpty(Nombre))
            {
                throw new ModelException("Nombre no puede ser null o vacio");
            }
            // Validacion de Email
            if (String.IsNullOrEmpty(Email))
            {
                throw new ModelException("Email no puede ser null o vacio");
            }
        }
    }
}