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
//                Mapeo PeriodoMapper: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Entidades.Soporte;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Sadim
{
    public class PeriodoMapper : Profile
    {
        public PeriodoMapper()
        {
            CreateMap<Periodos, PeriodoRespuesta>();

            CreateMap<Lista<Periodos>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<PeriodoSoporte, Periodos>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Metas, opt => opt.Ignore());

            CreateMap<PeriodoInsertar, Periodos>()
               .ForMember(dest => dest.Periodo, opt => opt.Ignore())
               .ForMember(dest => dest.Nombre, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.MesAbrev, opt => opt.Ignore())
               .ForMember(dest => dest.FechaInicio, opt => opt.Ignore())
               .ForMember(dest => dest.FechaTermino, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Metas, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<PeriodoEditar, Periodos>()
               .ForMember(dest => dest.Periodo, opt => opt.Ignore())
               .ForMember(dest => dest.Nombre, opt => opt.Ignore())
               .ForMember(dest => dest.Id, opt => opt.Ignore())
               .ForMember(dest => dest.MesAbrev, opt => opt.Ignore())
               .ForMember(dest => dest.FechaInicio, opt => opt.Ignore())
               .ForMember(dest => dest.FechaTermino, opt => opt.Ignore())
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Metas, opt => opt.Ignore())
               .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
               .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
               .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
               .ForMember(dest => dest.StatusId, opt => opt.Ignore())
               .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));
        }
    }
}