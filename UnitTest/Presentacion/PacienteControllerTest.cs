using Application.DTO;
using Application.Interface.Pacientes;
using Application.Model.Response;
using Application.Service;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEAyudo_Tutores.Controllers;
using Xunit;

namespace UnitTest.Presentacion
{
    public class PacienteControllerTest
    {
        [Fact]
        public async Task GetPacientes_Ok()
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            List<PacienteResponse> ListaResponse = new List<PacienteResponse>
            {
                new PacienteResponse
                {
                    PacienteId = 1,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    TutorId = 1,
                    CertUniDisc = "eee",
                }
            };

            MockPacienteService.Setup(q => q.GetPacientes()).ReturnsAsync(ListaResponse);

            //Act
            var Result = await PacienteController.GetPacientes() as OkObjectResult;


            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(200);
            Result.Value.Should().Be(ListaResponse);
        }






        [Fact]
        public async Task GetPacientes_NotFound()
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            List<PacienteResponse> ListaResponse = new List<PacienteResponse>();

            MockPacienteService.Setup(q => q.GetPacientes()).ReturnsAsync(ListaResponse);

            //Act
            var Result = await PacienteController.GetPacientes() as NotFoundObjectResult;


            //Assert
            Result.Should().NotBeNull();
            Result.StatusCode.Should().Be(404);
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task GetPaciente_OkOrNotFound(int PacienteId)
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            if (PacienteId > 0)
            {
                PacienteResponse PacienteResponse = new PacienteResponse
                {
                    PacienteId = 1,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    TutorId = 1,
                    CertUniDisc = "eee",
                };

                MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.GetPaciente(PacienteId) as OkObjectResult;

                //Arrange
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(200);
            }
            else
            {
                PacienteResponse PacienteResponse = null;

                MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.GetPaciente(PacienteId) as NotFoundObjectResult;

                //Arrange
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }



        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public async Task PostPaciente_CreatedOrConflict(int TutorId)
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            PacienteDTO PacienteDTO = new PacienteDTO
            {
                TutorId = TutorId,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
            };
            if (TutorId > 0) 
            {
                PacienteResponse PacienteResponse = new PacienteResponse
                {
                    PacienteId = 1,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    TutorId = 1,
                    CertUniDisc = "eee",
                };
                MockPacienteService.Setup(q => q.PostPaciente(It.IsAny<PacienteDTO>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.PostPaciente(PacienteDTO) as JsonResult;


                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(201);
            }
            else 
            {
                PacienteResponse PacienteResponse = null;
                MockPacienteService.Setup(q => q.PostPaciente(It.IsAny<PacienteDTO>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.PostPaciente(PacienteDTO) as ConflictObjectResult;


                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(409);
            }

        }









        [Theory]
        [InlineData(1, 0)]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        public async Task PutPaciente_CreatedOrConflictOrNotFound(int TutorId, int PacienteId) 
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            PacienteDTO PacienteDTO = new PacienteDTO
            {
                TutorId = TutorId,
                Nombre = "roko",
                Apellido = "Duarte",
                FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                DiagnosticoTEA = "eee",
                Sexo = "eee",
                CertUniDisc = "eee",
            };
            if (PacienteId > 0) 
            {
                PacienteResponse PacienteResponse = new PacienteResponse
                {
                    PacienteId = PacienteId,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    TutorId = TutorId,
                    CertUniDisc = "eee",
                };
                if (TutorId > 0) 
                {
                    MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);
                    MockPacienteService.Setup(q => q.PutPaciente(It.IsAny<int>(), It.IsAny<PacienteDTO>())).ReturnsAsync(PacienteResponse);

                    //Act
                    var Result = await PacienteController.PutPaciente(PacienteId, PacienteDTO) as JsonResult;

                    //Assert
                    Result.Should().NotBeNull();
                    Result.StatusCode.Should().Be(201);
                }
                else 
                {
                    PacienteResponse PacienteResponse2 = null;
                    MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);
                    MockPacienteService.Setup(q => q.PutPaciente(It.IsAny<int>(), It.IsAny<PacienteDTO>())).ReturnsAsync(PacienteResponse2);

                    //Act
                    var Result = await PacienteController.PutPaciente(PacienteId, PacienteDTO) as ConflictObjectResult;

                    //Assert
                    Result.Should().NotBeNull();
                    Result.StatusCode.Should().Be(409);
                };
            }
            else 
            {
                PacienteResponse PacienteResponse = null;
                MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.PutPaciente(PacienteId, PacienteDTO) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            };
        }



        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        public async Task DeletePaciente_OkOrNotFound(int PacienteId) 
        {
            //Arrange
            var MockPacienteService = new Mock<IPacienteService>();
            PacienteController PacienteController = new PacienteController(MockPacienteService.Object);

            if (PacienteId > 0) 
            {
                PacienteResponse PacienteResponse = new PacienteResponse
                {
                    PacienteId = PacienteId,
                    Nombre = "roko",
                    Apellido = "Duarte",
                    FechaNacimiento = DateTime.Parse("2021 - 11 - 27T00: 00:00"),
                    DiagnosticoTEA = "eee",
                    Sexo = "eee",
                    TutorId = 1,
                    CertUniDisc = "eee",
                };

                MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.DeletePaciente(PacienteId) as OkObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(200);
            }
            else
            {
                PacienteResponse PacienteResponse = null;

                MockPacienteService.Setup(q => q.GetPacienteById(It.IsAny<int>())).ReturnsAsync(PacienteResponse);

                //Act
                var Result = await PacienteController.DeletePaciente(PacienteId) as NotFoundObjectResult;

                //Assert
                Result.Should().NotBeNull();
                Result.StatusCode.Should().Be(404);
            }
        }




    }
}
