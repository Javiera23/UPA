﻿using System;
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
<<<<<<< HEAD
            IList<Servicio> servicios = new List<Servicio>();
=======
            Servicio servicio = new Servicio()
            {
                descripcion = "Video cumpleaños 20",
                etapa = Etapa.ENTREGADO,
                nombre = "Video 01",
                precio = 10000
            };
            
              
            List<Servicio> servicios = new List<Servicio>();
            servicios.Add(servicio);
            
>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23
            
            
            // Crear cotizacion correcta
            Cotizacion cotizacion = new Cotizacion()
            {
                fecha = DateTime.Now,
                estado = Estado.ACEPTADO,
                persona = persona,
                servicios = servicios
<<<<<<< HEAD
=======
                    
>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23
            };
            
            cotizacion.Validate();

            // Fecha en el futuro
            {
                cotizacion.fecha=DateTime.Now.AddDays(1);
                Assert.Equal("Fecha  no puede ser en el futuro.", Assert.Throws<ModelException>(() => cotizacion.Validate()).Message);
            }
<<<<<<< HEAD
            
            // Precio negativo
=======
            //Precio
>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23
            {
                Assert.Equal(cotizacion.Precio(), servicio.precio);
            }
<<<<<<< HEAD
=======
           
        
>>>>>>> 81e7ee0a8f731b943987c5e894555071084cbc23

            // Persona es null
            {
                cotizacion.persona = null;
                Assert.Throws<ModelException>(() => cotizacion.Validate());
            }        
        }
    }
}