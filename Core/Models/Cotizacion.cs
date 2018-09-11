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
<<<<<<< HEAD
        [Required] public long precio { get; set;}
        [Required] public DateTime fecha { get; set; }
        [Required] public IList<Servicio> servicios = new List<Servicio>();
        [Required] public Persona persona { get; set; }
        [Required] public Estado estado { get; set; }
        
=======

        public DateTime fecha { get; set; }
        public List<Servicio> servicios = new List<Servicio>();
        public Persona persona { get; set; }
        public Estado estado { get; set; }

>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23
        public override void Validate()
        {
            if (persona == null)
            {
                throw new ModelException("Persona no puede ser null");
            }
        }

        public Boolean rutEquals(string rut)
        {
            return persona.Rut.Equals(rut);
        }


        public int Precio()
        {
            int precio = 0;
            foreach (var servicio in servicios)
            {
                precio += servicio.precio;
            }
<<<<<<< HEAD
            
            if (fecha.CompareTo(DateTime.Now) >= 0)
            {
                throw new ModelException("Fecha  no puede ser en el futuro.");
            }
        }
    }
=======

            return precio;
        }
    





}
>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23
}