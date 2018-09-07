using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Servicio : BaseEntity
    {
        [Required] public string nombre { get; set; }
        [Required] public long precio { get; set; }
        [Required] public string descripcion { get; set; }
        [Required] public Etapa etapa { get; set; }
        
        
        public override void Validate()
        {
            if (string.IsNullOrEmpty(nombre))
            {
                throw new ModelException("El nombre no puede ser null");
            }

            if (precio < 0)
            {
                throw new ModelException("Precio no puede ser negativo");
            }

            if (string.IsNullOrEmpty(descripcion))
            {
                throw new ModelException("La descripcion no puede ser null o estar vacia");
            }
                
           
        }   
      
    }
}