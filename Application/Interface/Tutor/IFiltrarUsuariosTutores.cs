﻿using Application.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IFiltrarUsuariosTutores
    {
        List<UsuarioResponse> Filtrar(List<TutorResponse> ListaTutores, List<UsuarioResponse> ListaUsuarios);
    }
}
