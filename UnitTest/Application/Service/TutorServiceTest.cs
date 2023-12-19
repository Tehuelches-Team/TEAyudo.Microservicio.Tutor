using Application.DTO;
using Application.Interface;
using Application.Model.DTO;
using Application.Model.Response;
using Application.Service.Tutores;
using Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTest.Application.Service
{
    public class TutorServiceTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async Task GetTutorById_FullUsuarioResponseOrNull(int TutorId)
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);

            if (TutorId > 0)
            {
                Tutor Tutor = new Tutor
                {
                    TutorId = TutorId,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                };
                UsuarioResponse UsuarioResponse = new UsuarioResponse
                {
                    UsuarioId = 1,
                    CUIL = 111,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };
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


                MockTutorQuery.Setup(q => q.GetTutorById(TutorId)).ReturnsAsync(Tutor);
                MockTutorQuery.Setup(q => q.GetUsuarioById(It.IsAny<int>())).ReturnsAsync(UsuarioResponse);
                MockFiltrarTutores.Setup(q => q.Filtrar(It.IsAny<Tutor>(), It.IsAny<UsuarioResponse>())).Returns(FullUsuarioResponse);
                //Act
                FullUsuarioResponse Result = await TutorService.GetTutorById(TutorId);

                //Assert
                Assert.IsType<FullUsuarioResponse>(Result);
                Result.TutorId.Should().NotBe(null);
                Result.CUIL.Should().Be(UsuarioResponse.CUIL);
                Result.UsuarioId.Should().Be(UsuarioResponse.UsuarioId);
                Result.Nombre.Should().Be(UsuarioResponse.Nombre);
                Result.Apellido.Should().Be(UsuarioResponse.Apellido);
                Result.CorreoElectronico.Should().Be(UsuarioResponse.CorreoElectronico);
                Result.Contrasena.Should().Be(UsuarioResponse.Contrasena);
                Result.FotoPerfil.Should().Be(UsuarioResponse.FotoPerfil);
                Result.Domicilio.Should().Be(UsuarioResponse.Domicilio);
                Result.FechaNacimiento.Should().Be(UsuarioResponse.FechaNacimiento);
                Result.EstadoUsuarioId.Should().NotBe(null);
            }
            else
            {
                //Arrange
                Tutor Tutor = null;
                UsuarioResponse UsuarioResponse = null;
                MockTutorQuery.Setup(q => q.GetTutorById(TutorId)).ReturnsAsync(Tutor);
                MockTutorQuery.Setup(q => q.GetUsuarioById(It.IsAny<int>())).ReturnsAsync(UsuarioResponse);

                //Act
                FullUsuarioResponse? Result = await TutorService.GetTutorById(TutorId);

                //Assert
                Result.Should().BeNull();
            }
        }





        [Fact]
        public async Task AddTutor_Int()
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);



            TutorDTO TutorDTO = new TutorDTO
            {
                UsuarioId = 1,
            };
            int numero = 0;
            MockTutorCommand.Setup(q => q.AddTutor(It.IsAny<Tutor>())).ReturnsAsync(numero);

            //act
            int Result = await TutorService.AddTutor(TutorDTO);

            //Assert
            Result.Should().Be(numero);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task PutTutor_FullUsuarioResponseOrNull(int TutorId)
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);

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
                Tutor Tutor = new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                };

                UsuarioResponse UsuarioResponse = new UsuarioResponse
                {
                    UsuarioId = 1,
                    CUIL = 111,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };


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


                MockTutorQuery.Setup(q => q.GetTutorById(It.IsAny<int>())).ReturnsAsync(Tutor);
                MockTutorCommand.Setup(q => q.PutUsuario(It.IsAny<int>(), It.IsAny<UsuarioDTO>())).ReturnsAsync(UsuarioResponse);
                MockFiltrarTutores.Setup(q => q.Filtrar(It.IsAny<Tutor>(), It.IsAny<UsuarioResponse>())).Returns(FullUsuarioResponse);


                //act
                FullUsuarioResponse Result = await TutorService.PutTutor(TutorId, FullUsuarioTutorDTO);

                //Assert
                Assert.IsType<FullUsuarioResponse>(Result);
                Result.TutorId.Should().NotBe(null);
                Result.CUIL.Should().Be(UsuarioResponse.CUIL);
                Result.UsuarioId.Should().Be(UsuarioResponse.UsuarioId);
                Result.Nombre.Should().Be(UsuarioResponse.Nombre);
                Result.Apellido.Should().Be(UsuarioResponse.Apellido);
                Result.CorreoElectronico.Should().Be(UsuarioResponse.CorreoElectronico);
                Result.Contrasena.Should().Be(UsuarioResponse.Contrasena);
                Result.FotoPerfil.Should().Be(UsuarioResponse.FotoPerfil);
                Result.Domicilio.Should().Be(UsuarioResponse.Domicilio);
                Result.FechaNacimiento.Should().Be(UsuarioResponse.FechaNacimiento);
                Result.EstadoUsuarioId.Should().NotBe(null);
            }
            else
            {
                //Arrange
                Tutor Tutor = null;

                MockTutorQuery.Setup(q => q.GetTutorById(It.IsAny<int>())).ReturnsAsync(Tutor);


                //act
                FullUsuarioResponse? Result = await TutorService.PutTutor(TutorId, FullUsuarioTutorDTO);

                //Assert
                Result.Should().BeNull();

            }
        }









        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task DeleteTutor_FullUsuarioResponse(int TutorId)
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);

            if (TutorId > 0)
            {
                Tutor Tutor = new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                };

                UsuarioResponse UsuarioResponse = new UsuarioResponse
                {
                    UsuarioId = 1,
                    CUIL = 111,
                    Nombre = "rodrigo",
                    Apellido = "Duarte",
                    CorreoElectronico = "roo3drigo@gmail.com",
                    Contrasena = "****",
                    FotoPerfil = "url",
                    Domicilio = "calle 109",
                    FechaNacimiento = "04/01/97",
                    EstadoUsuarioId = 0,
                };


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


                MockTutorCommand.Setup(q => q.DeleteTutor(It.IsAny<int>())).ReturnsAsync(Tutor);
                MockTutorCommand.Setup(q => q.DeleteUsuario(It.IsAny<int>())).ReturnsAsync(UsuarioResponse);
                MockFiltrarTutores.Setup(q => q.Filtrar(It.IsAny<Tutor>(), It.IsAny<UsuarioResponse>())).Returns(FullUsuarioResponse);


                //act
                FullUsuarioResponse Result = await TutorService.DeleteTutor(TutorId);

                //Assert
                Result.Should().NotBeNull();
            }
            else
            {
                //Arrange
                Tutor Tutor = null;

                MockTutorCommand.Setup(q => q.DeleteTutor(It.IsAny<int>())).ReturnsAsync(Tutor);


                //act
                FullUsuarioResponse Result = await TutorService.DeleteTutor(TutorId);

                //Assert
                Result.Should().BeNull();

            }
        }


        [Fact]
        public async Task GetAllTutor_ListFullUsuarioResponse()
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);

            List<Tutor> ListaTutor = new List<Tutor>
            {
                new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                }
            };
            List<UsuarioResponse> ListaUsuarioResponse = new List<UsuarioResponse>
            {
                new UsuarioResponse
                {
                    UsuarioId = 1,
                    CUIL = 111,
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
            List<FullUsuarioResponse> FinalList = new List<FullUsuarioResponse>
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


            MockTutorQuery.Setup(q => q.GetAllTutores()).ReturnsAsync(ListaTutor);
            MockTutorQuery.Setup(f => f.GetAllUsuarios()).ReturnsAsync(ListaUsuarioResponse);
            MockFiltrarTutores.Setup(q => q.Filtrar(It.IsAny<List<Tutor>>(), It.IsAny<List<UsuarioResponse>>())).Returns(FinalList);


            //act
            List<FullUsuarioResponse> Result = await TutorService.GetAllTutor();

            //Assert
            Result.Should().NotBeNull();

        }




        [Fact]
        public async Task GetAllTutor_Null()
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);

            List<Tutor> ListaTutor = new List<Tutor>();
            MockTutorQuery.Setup(q => q.GetAllTutores()).ReturnsAsync(ListaTutor);


            //act
            List<FullUsuarioResponse> Result = await TutorService.GetAllTutor();

            //Assert
            Result.Should().BeNull();
        }



        [Theory]
        [InlineData(1)]
        public async Task GetTutorIdbyUsuarioId(int UsuarioId)
        {
            //Arrange
            var MockTutorQuery = new Mock<ITutorQuery>();
            var MockTutorCommand = new Mock<ITutorCommand>();
            var MockFiltrarTutores = new Mock<IFiltrarUsuariosTutores>();
            ITutorService TutorService = new TutorService(MockTutorQuery.Object, MockTutorCommand.Object, MockFiltrarTutores.Object);
            int? TutorId = 1;

            MockTutorQuery.Setup(q => q.GetTutorByUsuarioId(It.IsAny<int>())).ReturnsAsync(TutorId);

            //Act
            var Result = await TutorService.GetTutorIdbyUsuarioId(UsuarioId);


            //Assert
            Result.Should().NotBeNull();
            Result.Value.Should().Be(TutorId);
        }




    }
}
