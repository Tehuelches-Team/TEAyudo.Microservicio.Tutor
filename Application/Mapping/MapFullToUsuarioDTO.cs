using Application.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapping
{
    public class MapFullToUsuarioDTO
    {
        public UsuarioDTO Map(FullUsuarioTutorDTO FullUsuarioTutorDTO) 
        {
            return new UsuarioDTO
            {
                Nombre = FullUsuarioTutorDTO.Nombre,
                Apellido = FullUsuarioTutorDTO.Apellido,
                CorreoElectronico = FullUsuarioTutorDTO.CorreoElectronico,
                Contrasena = FullUsuarioTutorDTO.Contrasena,
                FotoPerfil = FullUsuarioTutorDTO.FotoPerfil,
                Domicilio = FullUsuarioTutorDTO.Domicilio,
                FechaNacimiento = FullUsuarioTutorDTO.FechaNacimiento,
            };
        }
    }
}
