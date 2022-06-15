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
//                 MaternaMapper: Creado 15-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Sadim
{
    public class MaternaMapper : Profile
    {
        public MaternaMapper()
        {
            CreateMap<MT03_VigilanciaMaterna, Materna01Unidad>()
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Materna01Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Materna01Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());


            CreateMap<MT03_VigilanciaMaterna, Materna02Unidad>()
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Materna02Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Materna02Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<MT03_VigilanciaMaterna, Materna03Unidad>()
              .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Materna03Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Materna03Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<MT01_Materna, Materna04Unidad>()
              .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Materna04Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Materna04Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());
        }
    }
}