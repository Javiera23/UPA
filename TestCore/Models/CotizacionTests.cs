using System;
using System.Collections.Generic;
using Core;
using Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Models
{
    public class CotizacionTests
    {
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public CotizacionTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Test del constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            _output.WriteLine("Creating Servicio ..");

            Persona persona = new Persona()
            {
                Email = "javiera.munoz01@alumnos.ucn.cl",
                Nombre = "Javiera",
                Paterno = "Muñoz",
                Materno = "Melo",
                Rut = "193992773"
            };
            List<Servicio> servicios = new List<Servicio>();
            
            
            //Crear cotizacion correcta
            Cotizacion cotizacion = new Cotizacion()
            
            {
                fecha = DateTime.Now,
                estado = Estado.ACEPTADO,
                persona = persona,
                precio = 40000,
                servicios = servicios
                  
                    
            };
            
            cotizacion.Validate();
            
            //Persona nula
            {
                cotizacion.persona = null;
                Assert.Throws<ModelException>(() => cotizacion.Validate());
            }
          
            
            //Precio negativo
            {
                cotizacion.precio = -1000;
                Assert.Throws<ModelException>(() => cotizacion.Validate());
            }
        

        }
    }
}