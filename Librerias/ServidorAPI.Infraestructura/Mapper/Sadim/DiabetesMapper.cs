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
//                 DiabetesMapper: Creado 15-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;

namespace ServidorAPI.Infraestructura.Mapper.Sadim
{
    public class DiabetesMapper : Profile
    {
        public DiabetesMapper()
        {
            CreateMap<CP04_IMCP20, Dm01Unidad>()
                .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Dm01Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Dm01Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<CP04_IMCP20, Dm02Unidad>()
                .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup));

            CreateMap<Dm02Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Dm02Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<IN23_Indicador_06_2018, Dm04Unidad>()
               .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup))
               .ForMember(dest => dest.Periodo, opt => opt.MapFrom(origen => origen.PeriodoInicial));

            CreateMap<Dm04Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Dm04Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

            CreateMap<IN23_Indicador_06_2018, Dm05Unidad>()
              .ForMember(dest => dest.ClavePresupuestal, opt => opt.MapFrom(origen => origen.CvePresup))
              .ForMember(dest => dest.Periodo, opt => opt.MapFrom(origen => origen.PeriodoInicial));

            CreateMap<Dm05Unidad, IndicadorRespuesta>()
                .ForMember(dest => dest.MesAbrev, opt => opt.MapFrom(origen => origen.Periodos.MesAbrev));

            CreateMap<Lista<Dm05Unidad>, Metadatos>()
                .ForMember(dest => dest.PaginaSiguiente, opt => opt.Ignore())
                .ForMember(dest => dest.PaginaAnterior, opt => opt.Ignore());

        }
    }
}