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
//                Mapeo StatusMapper: Creado 13-06-2022
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
    public class StatusMapper : Profile
    {
        public StatusMapper()
        {
            CreateMap<Status, StatusRespuesta>();

            CreateMap<Lista<Status>, Metadatos>()
               .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
               .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<StatusSoporte, Status>()
                .ForMember(dest => dest.Asentamientos, opt => opt.Ignore())
                .ForMember(dest => dest.Categorias, opt => opt.Ignore())
                .ForMember(dest => dest.Colonias, opt => opt.Ignore())
                .ForMember(dest => dest.Delegaciones, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Estados, opt => opt.Ignore())
                .ForMember(dest => dest.Municipios, opt => opt.Ignore())
                .ForMember(dest => dest.Paises, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadesTipo, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore())
                .ForMember(dest => dest.Vialidades, opt => opt.Ignore())
                .ForMember(dest => dest.Periodos, opt => opt.Ignore())
                .ForMember(dest => dest.Procesos, opt => opt.Ignore())
                .ForMember(dest => dest.Detalles, opt => opt.Ignore())
                .ForMember(dest => dest.Metas, opt => opt.Ignore());

            CreateMap<StatusInsertar, Status>()
                .ForMember(dest => dest.Asentamientos, opt => opt.Ignore())
                .ForMember(dest => dest.Categorias, opt => opt.Ignore())
                .ForMember(dest => dest.Colonias, opt => opt.Ignore())
                .ForMember(dest => dest.Delegaciones, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Estados, opt => opt.Ignore())
                .ForMember(dest => dest.Municipios, opt => opt.Ignore())
                .ForMember(dest => dest.Paises, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadesTipo, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore())
                .ForMember(dest => dest.Vialidades, opt => opt.Ignore())
                .ForMember(dest => dest.Periodos, opt => opt.Ignore())
                .ForMember(dest => dest.Procesos, opt => opt.Ignore())
                .ForMember(dest => dest.Detalles, opt => opt.Ignore())
                .ForMember(dest => dest.Metas, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<StatusEditar, Status>()
                .ForMember(dest => dest.Asentamientos, opt => opt.Ignore())
                .ForMember(dest => dest.Categorias, opt => opt.Ignore())
                .ForMember(dest => dest.Colonias, opt => opt.Ignore())
                .ForMember(dest => dest.Delegaciones, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Estados, opt => opt.Ignore())
                .ForMember(dest => dest.Municipios, opt => opt.Ignore())
                .ForMember(dest => dest.Paises, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadesTipo, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore())
                .ForMember(dest => dest.Vialidades, opt => opt.Ignore())
                .ForMember(dest => dest.Periodos, opt => opt.Ignore())
                .ForMember(dest => dest.Procesos, opt => opt.Ignore())
                .ForMember(dest => dest.Detalles, opt => opt.Ignore())
                .ForMember(dest => dest.Metas, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => resultado != null));
        }
    }
}