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
//               CancerMamaMapper: Creado 15-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Sadim
{
    public class CancerMamaMapper : Profile
    {
        public CancerMamaMapper()
        {
            CreateMap<CP03_INCOM_OtrasCob, CaMama01Unidad>()
                .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<CaMama01Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<CaMama01Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<CP02_IMCP_08M, CaMama02Unidad>()
                .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<CaMama02Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<CaMama02Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<CP02_IMCP_08M, CaMama03Unidad>()
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<CaMama03Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<CaMama03Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

        }
    }
}