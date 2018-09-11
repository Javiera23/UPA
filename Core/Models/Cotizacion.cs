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

        public DateTime fecha { get; set; }
        public List<Servicio> servicios = new List<Servicio>();
        public Persona persona { get; set; }
        public Estado estado { get; set; }

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

            return precio;
        }
    





}
}