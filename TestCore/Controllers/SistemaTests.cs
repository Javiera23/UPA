using System;
using System.Collections.Generic;
using Core;
using Core.Controllers;
using Core.DAO;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Controllers
{
    /// <summary>
    /// Test del sistema
    /// </summary>
    public class SistemaTests
    {
        
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public SistemaTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Test principal de la clase.
        /// </summary>
        [Fact]
        public void AllMethodsTest()
        {
            _output.WriteLine("Starting Sistema test ...");
            ISistema sistema = Startup.BuildSistema();
            
            // Insert null
            {
                Assert.Equal("Persona es null", Assert.Throws<ModelException>(() => sistema.Save(null)).Message);
            }
            
            // Insert persona/Save
            {
                _output.WriteLine("Testing insert ..");
                Persona persona = new Persona()
                {
                    Rut = "130144918",
                    Nombre = "Diego",
                    Paterno = "Urrutia",
                    Materno = "Astorga",
                    Email = "durrutia@ucn.cl"
                };

                sistema.Save(persona);
            }
            
            // GetPersonas
            {
                _output.WriteLine("Testing getPersonas ..");
                Assert.NotEmpty(sistema.GetPersonas());
            }
            
            // Buscar persona/Find
            {
                _output.WriteLine("Testing Find ..");
                // Error por rutEmail null
                Assert.Equal("rutEmail es null.", Assert.Throws<ModelException>(() => sistema.Find(null)).Message);
                Assert.NotNull(sistema.Find("durrutia@ucn.cl"));
                Assert.NotNull(sistema.Find("130144918"));
            }
            
            // Busqueda de usuario/login
            {
                Exception usuarioNoExiste =
                    Assert.Throws<ModelException>(() => sistema.Login("notfound@ucn.cl", "durrutia123"));
                Assert.Equal("Usuario no encontrado", usuarioNoExiste.Message);
                
                Exception usuarioNoExistePersonaSi =
                    Assert.Throws<ModelException>(() => sistema.Login("durrutia@ucn.cl", "durrutia123"));
                Assert.Equal("Existe la Persona pero no tiene credenciales de acceso", usuarioNoExistePersonaSi.Message);
            }
            
            // Insertar usuario
            {
                // persona es null, password correcto
                Assert.Equal("persona y/o password es null.", Assert.Throws<ModelException>(() => sistema.Save(null,"durrutia123")).Message);
                Persona persona = sistema.Find("durrutia@ucn.cl");
                Assert.NotNull(persona);
                _output.WriteLine("Persona: {0}", Utils.ToJson(persona));
                
                // password es null, persona correcta
                Assert.Equal("persona y/o password es null.", Assert.Throws<ModelException>(() => sistema.Save(persona,null)).Message);

                // persona y password correctos
                sistema.Save(persona, "durrutia123");
            }

            // Busqueda de usuario/login
            {
                Exception usuarioExisteWrongPassword =
                    Assert.Throws<ModelException>(() => sistema.Login("durrutia@ucn.cl", "este no es mi password"));
                Assert.Equal("Password no coincide", usuarioExisteWrongPassword.Message);

                Usuario usuario = sistema.Login("durrutia@ucn.cl", "durrutia123");
                Assert.NotNull(usuario);
                _output.WriteLine("Usuario: {0}", Utils.ToJson(usuario));
            }

            // Agregar Cotizaion
            {
                _output.WriteLine("Testing Agregar Cotizacion ...");
                Assert.Equal("La cotizacion es null", Assert.Throws<ModelException>(() => sistema.Agregar(null)).Message);
                Persona persona = new Persona()
                {
                    Email = "javiera.munoz01@alumnos.ucn.cl",
                    Nombre = "Javiera",
                    Paterno = "Muñoz",
                    Materno = "Melo",
                    Rut = "193992773"
                };

                Cotizacion cotizacion = new Cotizacion()
                {
                    fecha = DateTime.Now,
                    estado = Estado.ACEPTADO,
                    persona = persona,
                    precio = 40000,
                    servicios = new List<Servicio>()
                };

                sistema.Agregar(cotizacion);
            }

            // Buscar Cotizacion
            {
                Assert.Equal("Rut no puede ser null.", Assert.Throws<ModelException>(() => sistema.Buscar(null)).Message);
            }

            // Modificar cotizacion
            {
                _output.WriteLine("Testing Modificar Cotizacion ...");
                // nueva cotizacion es null
                Assert.Equal("Cotizacion no puede ser null.", Assert.Throws<ModelException>(() => sistema.Modificar(null)).Message);
            }

            // Eliminar Cotizacion
            {
                _output.WriteLine("Testing Eliminar Cotizacion ...");
            }
        }
    }
}