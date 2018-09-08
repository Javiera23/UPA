using System;
using Core;
using Core.Models;
using Xunit;
using Xunit.Abstractions;

namespace TestCore.Models
{
    /// <summary>
    /// Testing de la clase Cliente.
    ///</summary>

    public class ClienteTests
    {
        /// <summary>
        /// Logger de la Clase
        /// </summary>
        private readonly ITestOutputHelper _output;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name= "output"></param>
        public ClienteTests(ITestOutputHelper output)
        {
            _output = output ?? throw new ArgumentNullException(nameof(output));
        }

        /// <summary>
        /// Test del constructor
        /// </summary>
        [Fact]
        public void TestConstructor()
        {
            _output.WriteLine("Creating Cliente ...");
            Cliente cliente = new Cliente()
            {
            };

            // Error por Nombre null
            Assert.Equal("Nombre no puede ser null o vacio", Assert.Throws<ModelException>(() => cliente.Validate()).Message);
            cliente.Nombre = "Diego";
            
            // Error por Email null
            Assert.Equal("Email no puede ser null o vacio", Assert.Throws<ModelException>(() => cliente.Validate()).Message);
            cliente.Email = "durrutia@ucn.cl";
        }
    }
}