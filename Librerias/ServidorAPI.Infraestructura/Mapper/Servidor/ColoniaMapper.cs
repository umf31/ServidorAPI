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
//               Mapeo ColoniaMapper: Creado 13-06-2022
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
    public class ColoniaMapper : Profile
    {
        public ColoniaMapper()
        {
            CreateMap<Colonia, ColoniaRespuesta>()
               .ForMember(dest => dest.Municipio, opt => opt.MapFrom(origen => origen.Municipio.Nombre));

            CreateMap<Lista<Colonia>, Metadatos>()
              .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
              .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<ColoniaSoporte, Colonia>()
                .ForMember(dest => dest.Asentamiento, opt => opt.Ignore())
                .ForMember(dest => dest.Municipio, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore());

            CreateMap<ColoniaInsertar, Colonia>()
                .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
                .ForMember(dest => dest.Imagen, opt => opt.Ignore())
                .ForMember(dest => dest.Asentamiento, opt => opt.Ignore())
                .ForMember(dest => dest.Municipio, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore());

            CreateMap<ColoniaEditar, Colonia>()
                .ForMember(dest => dest.Asentamiento, opt => opt.Ignore())
                .ForMember(dest => dest.Municipio, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore())
                .ForMember(dest => dest.Unidades, opt => opt.Ignore())
                .ForMember(dest => dest.Imagen, opt => opt.Ignore())
                .ForMember(dest => dest.Geolocalizacion, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaModificacion, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioMod, opt => opt.Ignore())
                .ForMember(dest => dest.StatusId, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((origen, destino, resultado) => { return resultado != null; }));

            CreateMap<ColoniaInsertar, UtileriasRespuesta>();

            CreateMap<ColoniaEditar, UtileriasRespuesta>();
        }
    }
}