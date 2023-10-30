using Application.Model.Response;
using Domain.Entities;

namespace Application.Interface
{
    public interface IFiltrarUsuariosTutores
    {
        List<FullUsuarioResponse> Filtrar(List<Tutor> ListaTutores, List<UsuarioResponse> ListaUsuarios);
        FullUsuarioResponse Filtrar(Tutor Tutor, UsuarioResponse Usuario);
    }
}
