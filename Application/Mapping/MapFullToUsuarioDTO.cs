using Application.Model.DTO;

namespace Application.Mapping
{
    public class MapFullToUsuarioDTO
    {
        public UsuarioDTO Map(FullUsuarioTutorDTO FullUsuarioTutorDTO)
        {
            return new UsuarioDTO
            {
                CUIL = FullUsuarioTutorDTO.CUIL,
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
