using Application.DTO;
using Application.Interface.Pacientes;
using Application.Model.Response;
using Application.Service;
using Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace UnitTest.Application.Service
{
    public class PacienteServiceTest
    {
        [Fact]
        public async Task GetPacientes_ListaPacienteResponse()
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            List<Paciente> listaPaciente = new List<Paciente> {
                new Paciente
                {
                    PacienteId = 1,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    CertUniDisc = "eee",
                    TutorId = 1,
                    Tutor = new Tutor
                    {
                        TutorId = 1,
                        UsuarioId = 1,
                        Pacientes = new List<Paciente>(),
                    },
                }
            };
            //Configura lo que devuelve el metodo del mockQuery
            MockPacienteQuery.Setup(q => q.GetPacientes()).ReturnsAsync(listaPaciente);

            //Act
            List<PacienteResponse> Result = await PacienteService.GetPacientes();

            //Assert
            Assert.IsType<List<PacienteResponse>>(Result);
            Assert.NotNull(Result[0].PacienteId);
            Assert.NotNull(Result[0].Nombre);
            Assert.NotNull(Result[0].Apellido);
            Assert.NotNull(Result[0].FechaNacimiento);
            Assert.NotNull(Result[0].DiagnosticoTEA);
            Assert.NotNull(Result[0].Sexo);
            Assert.NotNull(Result[0].CertUniDisc);
            Assert.NotNull(Result[0].TutorId);
        }


        [Theory]
        [InlineData(1)]
        public async Task GetPacienteById_PacienteResponse(int Id)
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);


            Paciente Paciente = new Paciente
            {
                PacienteId = 1,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
                TutorId = 1,
                Tutor = new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                }
            };
            //Configura lo que devuelve el metodo del mockQuery
            MockPacienteQuery.Setup(q => q.GetPacienteById(Id)).ReturnsAsync(Paciente);
            //Act
            PacienteResponse Result = await PacienteService.GetPacienteById(Id);

            //Assert
            Assert.IsType<PacienteResponse>(Result);
            Assert.NotNull(Result.PacienteId);
            Assert.NotNull(Result.Nombre);
            Assert.NotNull(Result.Apellido);
            Assert.NotNull(Result.FechaNacimiento);
            Assert.NotNull(Result.DiagnosticoTEA);
            Assert.NotNull(Result.Sexo);
            Assert.NotNull(Result.CertUniDisc);
            Assert.NotNull(Result.TutorId);
        }






        [Theory]
        [InlineData(0)]
        public async Task GetPacienteById_null(int Id)
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            Paciente Paciente = null;
            //Configura lo que devuelve el metodo del mockQuery
            MockPacienteQuery.Setup(q => q.GetPacienteById(Id)).ReturnsAsync(Paciente);


            //Act
            PacienteResponse? Result = await PacienteService.GetPacienteById(Id);

            //Assert
            Assert.Null(Result);

        }







        [Fact]
        public async Task PostPaciente_PacienteResponse()
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            PacienteDTO PacienteDTO = new PacienteDTO
            {
                TutorId = 1,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
            };

            Paciente PacienteDevuelto = new Paciente
            {
                PacienteId = 1,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
                TutorId = 1,
                Tutor = new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                }
            };
            // Configura lo que devuelve el método del mockCommand
            MockPacienteCommand.Setup(q => q.PostPaciente(It.IsAny<Paciente>())).ReturnsAsync(PacienteDevuelto);


            //Act
            PacienteResponse Result = await PacienteService.PostPaciente(PacienteDTO);

            //Assert
            Assert.IsType<PacienteResponse>(Result);
            Assert.NotNull(Result.PacienteId);
            Assert.NotNull(Result.Nombre);
            Assert.NotNull(Result.Apellido);
            Assert.NotNull(Result.FechaNacimiento);
            Assert.NotNull(Result.DiagnosticoTEA);
            Assert.NotNull(Result.Sexo);
            Assert.NotNull(Result.CertUniDisc);
            Assert.NotNull(Result.TutorId);
        }







        [Fact]
        public async Task PostPaciente_null()
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            PacienteDTO PacienteDTO = new PacienteDTO
            {
                TutorId = 0,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
            };

            Paciente PacienteDevuelto = null;
            // Configura lo que devuelve el método del mockCommand
            MockPacienteCommand.Setup(q => q.PostPaciente(It.IsAny<Paciente>())).ReturnsAsync(PacienteDevuelto);


            //Act
            PacienteResponse? Result = await PacienteService.PostPaciente(PacienteDTO);

            //Assert
            Assert.Null(Result);
        }





        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async Task PutPaciente_PacienteResponseOrNull(int PacienteId)
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            if (PacienteId != 0)
            {
                PacienteDTO PacienteDTO = new PacienteDTO
                {
                    TutorId = 1,
                    Nombre = "roko",
                    Apellido = "Duarteeee",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    CertUniDisc = "eee",
                };

                Paciente PacienteDevuelto = new Paciente
                {
                    PacienteId = 1,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    CertUniDisc = "eee",
                    TutorId = 1,
                    Tutor = new Tutor
                    {
                        TutorId = 1,
                        UsuarioId = 1,
                        Pacientes = new List<Paciente>(),
                    }
                };

                // Configura lo que devuelve el método del mockCommand
                MockPacienteCommand.Setup(q => q.PutPaciente(It.IsAny<Paciente>())).ReturnsAsync(PacienteDevuelto);


                //Act
                PacienteResponse Result = await PacienteService.PutPaciente(PacienteId, PacienteDTO);

                //Assert
                Assert.IsType<PacienteResponse>(Result);
                Result.PacienteId.Should().NotBe(null);
                Result.Nombre.Should().Be(PacienteDevuelto.Nombre);
                Result.Apellido.Should().Be(PacienteDevuelto.Apellido);
                Result.FechaNacimiento.Should().Be(PacienteDevuelto.FechaNacimiento);
                Result.DiagnosticoTEA.Should().Be(PacienteDevuelto.DiagnosticoTEA);
                Result.Sexo.Should().Be(PacienteDevuelto.Sexo);
                Result.CertUniDisc.Should().Be(PacienteDevuelto.CertUniDisc);
                Result.TutorId.Should().Be(PacienteDevuelto.TutorId);
            }
            else
            {
                PacienteDTO PacienteDTO = new PacienteDTO
                {
                    TutorId = 1,
                    Nombre = "roko",
                    Apellido = "Duarteeee",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    CertUniDisc = "eee",
                };

                Paciente PacienteDevuelto = null;

                // Configura lo que devuelve el método del mockCommand
                MockPacienteCommand.Setup(q => q.PutPaciente(It.IsAny<Paciente>())).ReturnsAsync(PacienteDevuelto);


                //Act
                PacienteResponse? Result = await PacienteService.PutPaciente(PacienteId, PacienteDTO);

                //Assert
                Result.Should().BeNull();
            }
        }






        [Theory]
        [InlineData(1)]
        public async Task DeletePaciente_Bool(int PacienteId)
        {
            //Arrange
            var MockPacienteQuery = new Mock<IPacienteQuery>();
            var MockPacienteCommand = new Mock<IPacienteCommand>();
            IPacienteService PacienteService = new PacienteService(MockPacienteQuery.Object, MockPacienteCommand.Object);

            // Configura lo que devuelve el método del mockCommand
            MockPacienteCommand.Setup(q => q.DeletePaciente(It.IsAny<int>()));


            //Act
            bool Result = await PacienteService.DeletePaciente(PacienteId);

            //Assert
            Assert.True(Result);
        }





    }
}
