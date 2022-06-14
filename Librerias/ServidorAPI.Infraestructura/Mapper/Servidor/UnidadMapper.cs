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
//                Mapeo UnidadMapper: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Entidades.Soporte;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Servidor
{
    public class UnidadMapper : Profile
    {
        public UnidadMapper()
        {
            CreateMap<Unidad, UnidadRespuesta>()
               .ForMember(dest => dest.Tipo, opt => opt.Ignore())
               .ForMember(dest => dest.UnidadTipoId, opt => opt.Ignore())
               .ForMember(dest => dest.CodigoPostalId, opt => opt.Ignore())
               .ForMember(dest => dest.Delegacion, opt => opt.MapFrom(origen => origen.Delegacion.Nombre))
               .ForMember(dest => dest.Colonia, opt => opt.MapFrom(origen => origen.Colonia.Nombre))
               .ForMember(dest => dest.CodigoPostal, opt => opt.MapFrom(origen => origen.Colonia.CodigoPostal))
               .ForMember(dest => dest.Municipio, opt => opt.MapFrom(origen => origen.Municipio.Nombre));

            CreateMap<Lista<Unidad>, Metadatos>()
              .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
              .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<UnidadMedicaSoporte, Unidad>()
                .ForMember(dest => dest.Municipio, opt => opt.Ignore())
                .ForMember(dest => dest.Colonia, opt => opt.Ignore())
                .ForMember(dest => dest.Delegacion, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.UnidadTipo, opt => opt.Ignore())
                .ForMember(dest => dest.Vialidad, opt => opt.Ignore())
                .ForMember(dest => dest.Empleados, opt => opt.Ignore());

            CreateMap<UnidadSoporte, UnidadSoporteRespuesta>();
        }
    }
}