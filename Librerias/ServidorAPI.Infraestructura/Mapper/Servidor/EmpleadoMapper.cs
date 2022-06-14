#region ==> Licencia

//=======================================================================
//
//                 ░▒▓▓▓██▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓█▓▓▓▓▒░
//               █████▓░▒▓███████████████████▓▒░▓████▓
//              █████       ▒████████████▓▒       ████▓
//              █████          ▒▓█████▓░          ▓████
//             ░██▓██  ░▒▒▒▒▒▒░░▓██▓░  ▒▒         ▓████
//             ▒████████▓▒▒▒▒▓███▒   ▓█▓          ▓████
//             ▒██▓█▒░▒▒             ██▓          █████░
//             ▒████▓▓▓▓█████▓▒▒░     ▒█▓         █████░
//             ▒██▓███      ░███████▒   █▓       ▓██▓██░
//             ▒███▓██▒       ▓▒▒▒▓▓▓█▓  █░      ██▓███░
//             ▒██▓▓███       ▓░   ▓▒ ▓█░▒█     ▒███▓██░
//             ▒███▓███▓      ▓█▒░  ▓▓ ▓█▒▓     ███▓███░
//             ░██▓█▓███░    ▒▓░    ▒█  ██░    ███▓▓▓██
//              ███▓█▓███    ░ ▒▒  ░█▓  ██    ▓██▓█████
//              ▓█████████▒   ▒▒████▒  ██░   █████████▒
//               ▒██████████▓▒░ ░▒▒░░▓██▓░▓██████████▒
//                   ░░░░░▒▓▓▓▓▓▒▒▒▒▓▓▒░▒▓▒▒░░
//              ▒██▓   ▓▓        ░▓▓  ░▓▓▓▓█▒  ▓▓▓███
//              ▒██▓   ███▒     ▒███ ███   ▓▒▓██   ░▓
//              ▒██▓  ▒████▒   ▒████░███▓▒   ▓███▒░
//              ░██▓  ██ ███▒ ▒█ ▒██▒ ▓█████▓ ░██████▒
//              ░██▓  █▓  ███▓█▒  ███     ▓███    ▒███▒
//              ▒███ ▒█▓   ███▒   ████▓░  ▓████▒  ░███░
//               ▒▒░ ░▓     ▒     ▒▒▒░▒▓▓▓▓▒  ░▓▓▓▓▒░
//
//               INSITUTO MEXICANO DEL SEGURO SOCIAL
//                 DELEGACION REGIONAL NUEVO LEON
// © TODOS LOS DERECHOS RESERVADOS 2021 REVELADO DE INVENCION R1-123-2020
//            Información y actualizaciones del proyecto en
//                https://github.com/umf31/ServidorAPI
//              Mapeo EmpleadoMapper: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Entidades.Soporte;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Servidor
{
    public class EmpleadoMapper : Profile
    {
        public EmpleadoMapper()
        {
            CreateMap<Empleado, EmpleadoRespuesta>()
                .ForMember(dest => dest.Categoria, opt => opt.MapFrom(origen => origen.Categoria.Nombre))
                .ForMember(dest => dest.Colonia, opt => opt.MapFrom(origen => origen.Colonia.Nombre))
                .ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(origen => origen.Colonia.CodigoPostal))
                .ForMember(dest => dest.UnidadId, opt => opt.Ignore());

            CreateMap<Lista<Empleado>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<EmpleadoSoporte, Empleado>()
                .ForMember(dest => dest.Aplicaciones, opt => opt.Ignore())
                .ForMember(dest => dest.Soporte, opt => opt.Ignore())
                .ForMember(dest => dest.Categoria, opt => opt.Ignore())
                .ForMember(dest => dest.Servicio, opt => opt.Ignore())
                .ForMember(dest => dest.Colonia, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Unidad, opt => opt.Ignore())
                .ForMember(dest => dest.Vialidad, opt => opt.Ignore())
                .ForMember(dest => dest.Roles, opt => opt.Ignore());

            CreateMap<EmpleadoInsertar, Empleado>()
               .ForMember(dest => dest.Aplicaciones, opt => opt.Ignore())
               .ForMember(dest => dest.UnidadId, opt => opt.Ignore())
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
               .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
               .ForMember(dest => dest.CodigoSMS, opt => opt.Ignore())
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Bloqueo, opt => opt.Ignore())
               .ForMember(dest => dest.Recordar, opt => opt.Ignore())
               .ForMember(dest => dest.Activo, opt => opt.Ignore())
               .ForMember(dest => dest.Categoria, opt => opt.Ignore())
               .ForMember(dest => dest.Servicio, opt => opt.Ignore())
               .ForMember(dest => dest.Colonia, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Unidad, opt => opt.Ignore())
               .ForMember(dest => dest.Vialidad, opt => opt.Ignore())
               .ForMember(dest => dest.Roles, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.Soporte, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<EmpleadoEditar, Empleado>()
               .ForMember(dest => dest.Aplicaciones, opt => opt.Ignore())
               .ForMember(dest => dest.UnidadId, opt => opt.Ignore())
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
               .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
               .ForMember(dest => dest.CodigoSMS, opt => opt.Ignore())
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Bloqueo, opt => opt.Ignore())
               .ForMember(dest => dest.Recordar, opt => opt.Ignore())
               .ForMember(dest => dest.Activo, opt => opt.Ignore())
               .ForMember(dest => dest.Categoria, opt => opt.Ignore())
               .ForMember(dest => dest.Servicio, opt => opt.Ignore())
               .ForMember(dest => dest.Colonia, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Unidad, opt => opt.Ignore())
               .ForMember(dest => dest.Vialidad, opt => opt.Ignore())
               .ForMember(dest => dest.Roles, opt => opt.Ignore())
               .ForMember(dest => dest.Soporte, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));

            CreateMap<EmpleadoInsertar, UtileriasRespuesta>();

            CreateMap<EmpleadoEditar, UtileriasRespuesta>();
        }
    }
}