using Application.DTO;
using Application.Exceptions;
using Application.Interface;
using Application.Model.DTO;
using Application.Model.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TEAyudo.Controllers;
using Xunit;

namespace UnitTest.Presentacion
{
    public class TutorControllerTest
    {
        [Fact]
        public async Task GetAllTutor_Ok()
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            List<FullUsuarioResponse> ListaFullUsuarioResponse = new List<FullUsuarioResponse>
            {
                new FullUsuarioResponse
                {
                    TutorId = 1,
                    CUIL = 111,
                    UsuarioId = 1,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                }
            };
            MockTutorService.Setup(q => q.GetAllTutor()).ReturnsAsync(ListaFullUsuarioResponse);

            //Act
            var Result = await TutorController.GetAllTutor() as OkObjectResult;

            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(200);
        }



        [Fact]
        public async Task GetAllTutor_NotFound()
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            List<FullUsuarioResponse> ListaFullUsuarioResponse = null;
            MockTutorService.Setup(q => q.GetAllTutor()).ReturnsAsync(ListaFullUsuarioResponse);

            //Act
            var Result = await TutorController.GetAllTutor() as NotFoundObjectResult;

            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(404);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetTutorById_OkOrNotFound(int TutorId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            if (TutorId > 0)
            {
                FullUsuarioResponse FullUsuarioResponse = new FullUsuarioResponse
                {
                    TutorId = 1,
                    CUIL = 111,
                    UsuarioId = 1,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };
                MockTutorService.Setup(q => q.GetTutorById(It.IsAny<int>())).ReturnsAsync(FullUsuarioResponse);

                //Act
                var Result = await TutorController.GetTutorById(TutorId) as OkObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(200);
            }
            else
            {
                FullUsuarioResponse FullUsuarioResponse = null;
                MockTutorService.Setup(q => q.GetTutorById(It.IsAny<int>())).ReturnsAsync(FullUsuarioResponse);
                //Act
                var Result = await TutorController.GetTutorById(TutorId) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetTutorId_OkOrNotFound(int UsuarioId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            if (UsuarioId > 0)
            {
                int? UnUsuarioId = UsuarioId;

                MockTutorService.Setup(q => q.GetTutorIdbyUsuarioId(It.IsAny<int>())).ReturnsAsync(UnUsuarioId);

                //Act
                var Result = await TutorController.GetTutorId(UsuarioId) as OkObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(200);
            }
            else
            {
                int? UnUsuarioId = null;
                MockTutorService.Setup(q => q.GetTutorIdbyUsuarioId(It.IsAny<int>())).ReturnsAsync(UnUsuarioId);

                //Act
                var Result = await TutorController.GetTutorId(UsuarioId) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }



        [Fact]
        public async Task PostTutor_Created()
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            TutorDTO TutorDTO = new TutorDTO
            {
                UsuarioId = 1,
            };
            int numero = 1;
            MockTutorService.Setup(q => q.AddTutor(It.IsAny<TutorDTO>())).ReturnsAsync(numero);

            //Act
            var Result = await TutorController.PostTutor(TutorDTO) as JsonResult;

            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(201);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task PutTutor_CreatedOrNotFound(int TutorId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            FullUsuarioTutorDTO FullUsuarioTutorDTO = new FullUsuarioTutorDTO
            {
                CUIL = 111,
                Nombre = "rodrigo",
                Apellido = "Duarte",
                CorreoElectronico = "roo3drigo@gmail.com",
                Contrasena = "****",
                FotoPerfil = "url",
                Domicilio = "calle 109",
                FechaNacimiento = "04/01/97",
            };
            if (TutorId > 0)
            {
                FullUsuarioResponse FullUsuarioResponse = new FullUsuarioResponse
                {
                    TutorId = TutorId,
                    CUIL = 111,
                    UsuarioId = 1,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };
                MockTutorService.Setup(q => q.PutTutor(It.IsAny<int>(), It.IsAny<FullUsuarioTutorDTO>())).ReturnsAsync(FullUsuarioResponse);

                //Act
                var Result = await TutorController.PutTutor(TutorId, FullUsuarioTutorDTO) as JsonResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(201);
            }
            else
            {
                FullUsuarioResponse FullUsuarioResponse = null;
                MockTutorService.Setup(q => q.PutTutor(It.IsAny<int>(), It.IsAny<FullUsuarioTutorDTO>())).ReturnsAsync(FullUsuarioResponse);

                //Act
                var Result = await TutorController.PutTutor(TutorId, FullUsuarioTutorDTO) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }



        [Theory]
        [InlineData(1)]
        public async Task PutTutor_BadResquest(int TutorId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            FullUsuarioTutorDTO FullUsuarioTutorDTO = new FullUsuarioTutorDTO
            {
                CUIL = 111,
                Nombre = "rodrigo",
                Apellido = "Duarte",
                CorreoElectronico = "roo3drigo@gmail.com",
                Contrasena = "****",
                FotoPerfil = "url",
                Domicilio = "calle 109",
                FechaNacimiento = "aaaaaa",
            };

            MockTutorService.Setup(q => q.PutTutor(It.IsAny<int>(), It.IsAny<FullUsuarioTutorDTO>()))
                .Throws(new FormatException("fecha de nacimiento en formato incorrecto"));

            //Act
            var Result = await TutorController.PutTutor(TutorId, FullUsuarioTutorDTO) as BadRequestObjectResult;

            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(400);
        }



        [Theory]
        [InlineData(1)]
        public async Task PutTutor_Conlflict(int TutorId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);

            FullUsuarioTutorDTO FullUsuarioTutorDTO = new FullUsuarioTutorDTO
            {
                CUIL = 111,
                Nombre = "rodrigo",
                Apellido = "Duarte",
                CorreoElectronico = "roo3drigo@gmail.com",
                Contrasena = "****",
                FotoPerfil = "url",
                Domicilio = "calle 109",
                FechaNacimiento = "04/01/97",
            };

            MockTutorService.Setup(q => q.PutTutor(It.IsAny<int>(), It.IsAny<FullUsuarioTutorDTO>()))
                .Throws(new ConflictoException("Mail asociado a otra cuenta"));

            //Act
            var Result = await TutorController.PutTutor(TutorId, FullUsuarioTutorDTO) as ConflictObjectResult;

            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(409);
        }



        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async Task DeleteTutor_OkOrNotFound(int TutorId)
        {
            //Arrange
            var MockTutorService = new Mock<ITutorService>();
            TutorController TutorController = new TutorController(MockTutorService.Object);
            if (TutorId > 0)
            {
                FullUsuarioResponse FullUsuarioResponse = new FullUsuarioResponse
                {
                    TutorId = TutorId,
                    CUIL = 111,
                    UsuarioId = 1,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };
                MockTutorService.Setup(q => q.DeleteTutor(It.IsAny<int>())).ReturnsAsync(FullUsuarioResponse);

                //Act
                var Result = await TutorController.DeleteTutor(TutorId) as OkObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(200);
            }
            else
            {
                FullUsuarioResponse FullUsuarioResponse = null;
                MockTutorService.Setup(q => q.DeleteTutor(It.IsAny<int>())).ReturnsAsync(FullUsuarioResponse);

                //Act
                var Result = await TutorController.DeleteTutor(TutorId) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }
    }
}
