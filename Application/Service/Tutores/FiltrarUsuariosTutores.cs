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
        public List<UsuarioResponse> Filtrar(List<TutorResponse> ListaTutores, List<UsuarioResponse> ListaUsuarios)
        {
            List<UsuarioResponse> Result = new List<UsuarioResponse>();
            foreach (var Tutor in ListaTutores)
            {
                foreach (var Usuario in ListaUsuarios) {
                    if (Tutor.UsuarioId == Usuario.UsuarioId) Result.Add(Usuario);
                }
            }

            return Result;
        }
    }
}
