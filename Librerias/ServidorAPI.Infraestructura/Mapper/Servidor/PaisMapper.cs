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
//                 Mapeo PaisMapper: Creado 13-06-2022
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
    public class PaisMapper : Profile
    {
        public PaisMapper()
        {
            CreateMap<Pais, PaisRespuesta>();

            CreateMap<Lista<Pais>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<PaisSoporte, Pais>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Estados, opt => opt.Ignore());

            CreateMap<PaisInsertar, Pais>()
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Estados, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<PaisEditar, Pais>()
               .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
               .ForMember(dest => dest.Imagen, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Estados, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));

            CreateMap<PaisInsertar, UtileriasRespuesta>();

            CreateMap<PaisEditar, UtileriasRespuesta>();
        }
    }
}