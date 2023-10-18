using Application.Model.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFiltrarUsuariosTutores
    {
        List<FullUsuarioResponse> Filtrar(List<Tutor> ListaTutores, List<UsuarioResponse> ListaUsuarios);
        FullUsuarioResponse Filtrar(Tutor Tutor, UsuarioResponse Usuario);
    }
}
