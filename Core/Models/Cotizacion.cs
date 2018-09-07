using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    /// <summary>
    /// Clase que representa una Cotizacion en el sistema de presupuesto.
    /// </summary>
    public class Cotizacion : BaseEntity
    {
        [Required] public long precio { get; set;}
        [Required] public DateTime fecha { get; set; }
        [Required] public List<Servicio> servicios = new List<Servicio>();
        [Required] public Persona persona { get; set; }
        [Required] public Estado estado { get; set; }
        
        public override void Validate()
        {
            if (persona == null)
            {
                throw new ModelException("Persona no puede ser null");
            }

            if (fecha == null)
            {
                throw new ModelException("Fecha no puede ser null o vacio");
            }

            if (precio < 0)
            {
                throw new ModelException("El precio no puede ser negativo");
            }
            
            
        }


        


    }
}