using System;
using Core;
using Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Models
{
    /// <summary>
    /// Testing de la clase Persona.
    /// </summary>
    public class PersonaTests
    {
        /// <summary>
        /// Logger de la clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="output"></param>
        public PersonaTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Test del constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            _output.WriteLine("Creating Persona ..");
            Persona persona = new Persona()
            {
            };

            // Error por rut null
            Assert.Equal("Rut no puede ser null", Assert.Throws<ModelException>(() => persona.Validate()).Message);

            // Error por rut incorrecto
            persona.Rut = "Hola Como estas?";
            Assert.Equal("Rut no valido", Assert.Throws<ModelException>(() => persona.Validate()).Message);
            persona.Rut = "130144918";
            
            // Error por Nombre null
            Assert.Equal("Nombre no puede ser null o vacio", Assert.Throws<ModelException>(() => persona.Validate()).Message);
            persona.Nombre = "Diego";

            // Error por Apellido null
            Assert.Equal("Apellido Paterno no puede ser null o vacio", Assert.Throws<ModelException>(() => persona.Validate()).Message);
            persona.Paterno = "Urrutia";

            // Error por Email null
            Assert.Equal("Email no puede ser null o vacio", Assert.Throws<ModelException>(() => persona.Validate()).Message);
            persona.Email = "durrutia@ucn.cl";

            _output.WriteLine(Utils.ToJson(persona));
        }
    }
}