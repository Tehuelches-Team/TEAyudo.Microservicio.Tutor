using Application.Interface;
using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Tutores
{
    public class FiltrarUsuariosTutores : IFiltrarUsuariosTutores
    {
        public List<FullUsuarioResponse> Filtrar(List<TutorResponse> ListaTutores, List<UsuarioResponse> ListaUsuarios)
        {
            FullUsuarioResponse Full;
            List<FullUsuarioResponse> Result = new List<FullUsuarioResponse>();
            foreach (var Tutor in ListaTutores)
            {
                foreach (var Usuario in ListaUsuarios) {
                    if (Tutor.UsuarioId == Usuario.UsuarioId) 
                    {
                        Full = new FullUsuarioResponse
                        {
                            TutorId = Tutor.TutorId,
                            UsuarioId = Tutor.UsuarioId,
                            Nombre = Usuario.Nombre,
                            Apellido = Usuario.Apellido,
                            CorreoElectronico = Usuario.CorreoElectronico,
                            Contrasena = Usuario.Contrasena,
                            FotoPerfil = Usuario.FotoPerfil,
                            Domicilio = Usuario.Domicilio,
                            FechaNacimiento = Usuario.FechaNacimiento,
                            EstadoUsuarioId  = Usuario.EstadoUsuarioId
                        };
                        Result.Add(Full);
                    } 
                }
            }

            return Result;
        }
    }
}
