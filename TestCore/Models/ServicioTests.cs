using System;
using Core;
using Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Models
{
    public class ServicioTests
    {
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public ServicioTests(ITestOutputHelper output)
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
            
            //Crear servicio correcto
            Servicio servicio = new Servicio()
            {
                descripcion = "Video cumpleaños 20",
                etapa = Etapa.ENTREGADO,
                nombre = "Video 01",
                precio = 40000
                    
            };
            
            servicio.Validate();
            
            //Nombre vacio o nulo
            {
                servicio.nombre = null;
                Assert.Throws<ModelException>(() => servicio.Validate());
            }
           
            //Precio negativo
            {
                servicio.precio = -1000;
                Assert.Throws<ModelException>(() => servicio.Validate());
            }
            //Descripcion vacia o nula
            {
                servicio.descripcion = null;
                Assert.Throws<ModelException>(() => servicio.Validate());
            }
        

        }
    }
}