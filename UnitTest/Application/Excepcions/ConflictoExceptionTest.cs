using Application.Exceptions;
using FluentAssertions;
using Xunit;

namespace UnitTest.Application.Excepcions
{
    public class ConflictoExceptionTest
    {
        [Fact]
        public void Constructor_SetsMessage()
        {
            // Arrange
            string mensaje = "Mensaje de conflicto";

            // Act
            var excepcion = new ConflictoException(mensaje);

            // Assert
            excepcion.Message.Should().Be(mensaje);
        }
    }
}
