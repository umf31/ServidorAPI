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
//               Mapeo VialidadMapper: Creado 13-06-2022
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
    public class VialidadMapper : Profile
    {
        public VialidadMapper()
        {
            CreateMap<Vialidad, VialidadRespuesta>();

            CreateMap<Lista<Vialidad>, Metadatos>()
               .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
               .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<VialidadSoporte, Vialidad>()
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore());

            CreateMap<VialidadInsertar, Vialidad>()
              .ForMember(dest => dest.Status, opt => opt.Ignore())
              .ForMember(dest => dest.Empleados, opt => opt.Ignore())
              .ForMember(dest => dest.Unidades, opt => opt.Ignore())
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
              .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
              .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
              .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<VialidadEditar, Vialidad>()
              .ForMember(dest => dest.Status, opt => opt.Ignore())
              .ForMember(dest => dest.Empleados, opt => opt.Ignore())
              .ForMember(dest => dest.Unidades, opt => opt.Ignore())
              .ForMember(dest => dest.Id, opt => opt.Ignore())
              .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
              .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
              .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
              .ForMember(dest => dest.StatusId, opt => opt.Ignore())
              .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));
        }
    }
}