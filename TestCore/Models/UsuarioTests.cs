using System;
using Core;
using Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Models
{
    /// <summary>
    /// Testing de la clase Usuario.
    /// </summary>
    public class UsuarioTests
    {
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public UsuarioTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Test del constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            _output.WriteLine("Creating Usuario ..");
            Usuario usuario=new Usuario
            {
            };

            // Error por persona Asociada null
            Assert.Equal(Assert.Throws<ModelException>(() => usuario.Validate()).Message, "Se requiere la Persona");

            usuario.Persona = new Persona()
                {
                    Rut = "130144918",
                    Nombre = "Diego",
                    Paterno = "Urrutia",
                    Materno = "Astorga",
                    Email = "durrutia@ucn.cl"
                };

            // Error por password null o vacio
            Assert.Equal(Assert.Throws<ModelException>(() => usuario.Validate()).Message, "Se requiere el Password");

            usuario.Password = "durrutia123";

        _output.WriteLine(Utils.ToJson(usuario));
        }
    }
}