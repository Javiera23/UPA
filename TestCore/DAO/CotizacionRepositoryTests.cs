using System;
using System.Collections.Generic;
using System.Linq;
using Core.DAO;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.DAO
{
    /// <summary>
    /// Testing del repositorio de personas
    /// </summary>
    public sealed class CotizacionRepositoryTests
    {
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public CotizacionRepositoryTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException("Se requiere la consola");
        }

        /// <summary>
        /// Test de insercion y busqueda en el repositorio.
        /// </summary>
        /// 
        [Fact]
        public void InsercionBusquedaCotizacionTest()
        {
            // Contexto
            DbContext dbContext = BuildTestModelContext();

            // Repositorio de personas
            CotizacionRepository repo = new CotizacionRepository(dbContext);

            // Creacion

            Persona persona = new Persona()
                {
                    Rut = "194517319",
                    Nombre = "Diego",
                    Paterno = "Urrutia",
                    Materno = "Astorga",
                    Email = "durrutia@ucn.cl"
                };

            Servicio servicio = new Servicio()
                {
                    descripcion = "Video cumpleaños 20",
                    etapa = Etapa.ENTREGADO,
                    nombre = "Video 01",
                    precio = 40000

                };
            

            Cotizacion cotizacion = new Cotizacion()
            {
                fecha = DateTime.Now,
                estado = Estado.ACEPTADO,
                persona = persona
            };
            
            cotizacion.servicios.Add(servicio);
            
            //Agregar cotizacion
            {
                repo.Add(cotizacion);
                Assert.NotEmpty(repo.GetAll());
                _output.WriteLine(repo.GetAll().FirstOrDefault().persona.Rut);
            }
            
            //Busqueda por rut (exitosa)
            {
                List<Cotizacion> resultado = repo.GetByRut("194517319");
                Assert.NotEmpty(resultado);

            }
            //Busqueda por rut (no exitosa)
            {
                List<Cotizacion> resultado = repo.GetByRut("193992773");
                Assert.Empty(resultado);
            }
            
            //Busqueda por rut (nula)
            {
                List<Cotizacion> resultado = repo.GetByRut(null);
                Assert.Empty(resultado);
            }
                
            //Busqueda por id (exitosa)
            {
                Cotizacion busqueda = repo.GetById(cotizacion.Id);
                Assert.NotNull(busqueda); 
            }
            //Busqueda por id (no exitosa)
            {
                Cotizacion busqueda = repo.GetById(-1);
                Assert.Null(busqueda); 
            }
            //Eliminar
            {
                Cotizacion aux = repo.GetById(cotizacion.Id);
                repo.Remove(aux);
                Assert.Null(repo.GetById(cotizacion.Id));
                //Assert.Empty(repo.GetAll());
                
            }
            
           
            
            
        }

        /// <summary>
        /// Construccion del DbContext de prueba
        /// </summary>
        /// <returns></returns>
        private static DbContext BuildTestModelContext()
        {
            DbContextOptions<ModelDbContext> options = new DbContextOptionsBuilder<ModelDbContext>()
                // .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseSqlite(@"Data Source=cotizaciones.db") // SQLite
                .EnableSensitiveDataLogging()
                .Options;
            
            return new ModelDbContext(options);
        }
    }
}