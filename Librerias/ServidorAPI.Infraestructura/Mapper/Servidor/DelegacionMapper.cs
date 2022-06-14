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
//              Mapeo DelegacionMapper: Creado 13-06-2022
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
    public class DelegacionMapper : Profile
    {
        public DelegacionMapper()
        {
            CreateMap<Delegacion, DelegacionRespuesta>()
               .ForMember(dest => dest.Estado, opt => opt.MapFrom(origen => origen.Estado.Nombre));

            CreateMap<Lista<Delegacion>, Metadatos>()
               .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
               .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<DelegacionSoporte, Delegacion>()
                .ForMember(dest => dest.Estado, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore());

            CreateMap<DelegacionInsertar, Delegacion>()
               .ForMember(dest => dest.Estado, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Unidades, opt => opt.Ignore())
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<DelegacionEditar, Delegacion>()
               .ForMember(dest => dest.Estado, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Unidades, opt => opt.Ignore())
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));

            CreateMap<DelegacionInsertar, UtileriasRespuesta>();

            CreateMap<DelegacionEditar, UtileriasRespuesta>();
        }
    }
}