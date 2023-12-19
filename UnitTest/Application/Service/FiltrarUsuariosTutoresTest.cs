using Application.Model.Response;
using Application.Service.Tutores;
using Domain.Entities;
using FluentAssertions;
using Xunit;

namespace UnitTest.Application.Service
{
    public class FiltrarUsuariosTutoresTest
    {

        [Fact]
        public async Task Filtrar_ListaFullUsuarioResponse()
        {
            //Arrange
            List<Tutor> ListaTutores = new List<Tutor>
            {
                new Tutor
                {
                    TutorId = 1,
                    UsuarioId = 1,
                    Pacientes = new List<Paciente>(),
                }
            };
            List<UsuarioResponse> ListaUsuarios = new List<UsuarioResponse>
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
            FiltrarUsuariosTutores FiltrarUsuariosTutores = new FiltrarUsuariosTutores();


            //Act
            List<FullUsuarioResponse> ListaFullUsuarioResponse = FiltrarUsuariosTutores.Filtrar(ListaTutores, ListaUsuarios);

            //Assert
            ListaFullUsuarioResponse.Should().NotBeNull();


        }



        [Fact]
        public async Task Filtrar_FullUsuarioResponse()
        {
            //Arrange
            Tutor Tutor = new Tutor
            {
                TutorId = 1,
                UsuarioId = 1,
                Pacientes = new List<Paciente>(),
            };
            UsuarioResponse UsuarioRespo = new UsuarioResponse
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

            FiltrarUsuariosTutores FiltrarUsuariosTutores = new FiltrarUsuariosTutores();


            //Act
            FullUsuarioResponse Result = FiltrarUsuariosTutores.Filtrar(Tutor, UsuarioRespo);

            //Assert
            Result.Should().NotBeNull();
            Result.TutorId.Should().Be(FullUsuarioResponse.TutorId);
            Result.CUIL.Should().Be(FullUsuarioResponse.CUIL);
            Result.UsuarioId.Should().Be(FullUsuarioResponse.UsuarioId);
            Result.Nombre.Should().Be(FullUsuarioResponse.Nombre);
            Result.Apellido.Should().Be(FullUsuarioResponse.Apellido);
            Result.CorreoElectronico.Should().Be(FullUsuarioResponse.CorreoElectronico);
            Result.Contrasena.Should().Be(FullUsuarioResponse.Contrasena);
            Result.FotoPerfil.Should().Be(FullUsuarioResponse.FotoPerfil);
            Result.Domicilio.Should().Be(FullUsuarioResponse.Domicilio);
            Result.FechaNacimiento.Should().Be(FullUsuarioResponse.FechaNacimiento);
            Result.EstadoUsuarioId.Should().Be(FullUsuarioResponse.EstadoUsuarioId);



        }


    }
}
