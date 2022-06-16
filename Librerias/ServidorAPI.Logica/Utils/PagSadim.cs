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
//                   IPagServidor: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Interfaces.Utils;

namespace ServidorAPI.Logica.Utils
{
    public class PagSadim : IPagSadim
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accessor;
        internal readonly IPaginacion<Detalles> detalles = null!;
        internal readonly IPaginacion<Meta> meta = null!;
        internal readonly IPaginacion<Periodos> periodo = null!;
        internal readonly IPaginacion<Proceso> proceso = null!;
        internal readonly IPaginacion<Dm01Unidad> dm01Unidad = null!;
        internal readonly IPaginacion<Dm02Unidad> dm02Unidad = null!;
        internal readonly IPaginacion<Dm04Unidad> dm04Unidad = null!;
        internal readonly IPaginacion<Dm05Unidad> dm05Unidad = null!;
        internal readonly IPaginacion<Eh01Unidad> eh01Unidad = null!;
        internal readonly IPaginacion<Eh02Unidad> eh02Unidad = null!;
        internal readonly IPaginacion<Eh04Unidad> eh04Unidad = null!;
        internal readonly IPaginacion<CaMama01Unidad> caMama01Unidad = null!;
        internal readonly IPaginacion<CaMama02Unidad> caMama02Unidad = null!;
        internal readonly IPaginacion<CaMama03Unidad> caMama03Unidad = null!;
        internal readonly IPaginacion<CaCu01Unidad> caCu01Unidad = null!;
        internal readonly IPaginacion<Materna01Unidad> materna01Unidad = null!;
        internal readonly IPaginacion<Materna02Unidad> materna02Unidad = null!;
        internal readonly IPaginacion<Materna03Unidad> materna03Unidad = null!;
        internal readonly IPaginacion<Materna04Unidad> materna04Unidad = null!;
        internal readonly IPaginacion<SOb01Unidad> sOb01Unidad = null!;
        internal readonly IPaginacion<Caispn01Unidad> caispn01Unidad = null!;
        internal readonly IPaginacion<Caispn02Unidad> caispn02Unidad = null!;
        internal readonly IPaginacion<Caispn04Unidad> caispn04Unidad = null!;
        internal readonly IPaginacion<Caispn05Unidad> caispn05Unidad = null!;
        internal readonly IPaginacion<Caispn08Unidad> caispn08Unidad = null!;
        internal readonly IPaginacion<Caispn09Unidad> caispn09Unidad = null!;
        internal readonly IPaginacion<Caispn14Unidad> caispn14Unidad = null!;

        public PagSadim(IMapper _mapper, IHttpContextAccessor _accessor)
        {
            mapper = _mapper;
            accessor = _accessor;
        }

        public IPaginacion<Detalles> Detalles => detalles ?? new Paginacion<Detalles>(mapper, accessor);
        public IPaginacion<Meta> Meta => meta ?? new Paginacion<Meta>(mapper, accessor);
        public IPaginacion<Periodos> Periodo => periodo ?? new Paginacion<Periodos>(mapper, accessor);
        public IPaginacion<Proceso> Proceso => proceso ?? new Paginacion<Proceso>(mapper, accessor);
        public IPaginacion<Dm01Unidad> Dm01Unidad => dm01Unidad ?? new Paginacion<Dm01Unidad>(mapper, accessor);
        public IPaginacion<Dm02Unidad> Dm02Unidad => dm02Unidad ?? new Paginacion<Dm02Unidad>(mapper, accessor);
        public IPaginacion<Dm04Unidad> Dm04Unidad => dm04Unidad ?? new Paginacion<Dm04Unidad>(mapper, accessor);
        public IPaginacion<Dm05Unidad> Dm05Unidad => dm05Unidad ?? new Paginacion<Dm05Unidad>(mapper, accessor);
        public IPaginacion<Eh01Unidad> Eh01Unidad => eh01Unidad ?? new Paginacion<Eh01Unidad>(mapper, accessor);
        public IPaginacion<Eh02Unidad> Eh02Unidad => eh02Unidad ?? new Paginacion<Eh02Unidad>(mapper, accessor);
        public IPaginacion<Eh04Unidad> Eh04Unidad => eh04Unidad ?? new Paginacion<Eh04Unidad>(mapper, accessor);
        public IPaginacion<CaMama01Unidad> CaMama01Unidad => caMama01Unidad ?? new Paginacion<CaMama01Unidad>(mapper, accessor);
        public IPaginacion<CaMama02Unidad> CaMama02Unidad => caMama02Unidad ?? new Paginacion<CaMama02Unidad>(mapper, accessor);
        public IPaginacion<CaMama03Unidad> CaMama03Unidad => caMama03Unidad ?? new Paginacion<CaMama03Unidad>(mapper, accessor);
        public IPaginacion<CaCu01Unidad> CaCu01Unidad => caCu01Unidad ?? new Paginacion<CaCu01Unidad>(mapper, accessor);
        public IPaginacion<Materna01Unidad> Materna01Unidad => materna01Unidad ?? new Paginacion<Materna01Unidad>(mapper, accessor);
        public IPaginacion<Materna02Unidad> Materna02Unidad => materna02Unidad ?? new Paginacion<Materna02Unidad>(mapper, accessor);
        public IPaginacion<Materna03Unidad> Materna03Unidad => materna03Unidad ?? new Paginacion<Materna03Unidad>(mapper, accessor);
        public IPaginacion<Materna04Unidad> Materna04Unidad => materna04Unidad ?? new Paginacion<Materna04Unidad>(mapper, accessor);
        public IPaginacion<SOb01Unidad> SOb01Unidad => sOb01Unidad ?? new Paginacion<SOb01Unidad>(mapper, accessor);
        public IPaginacion<Caispn01Unidad> Caispn01Unidad => caispn01Unidad ?? new Paginacion<Caispn01Unidad>(mapper, accessor);
        public IPaginacion<Caispn02Unidad> Caispn02Unidad => caispn02Unidad ?? new Paginacion<Caispn02Unidad>(mapper, accessor);
        public IPaginacion<Caispn04Unidad> Caispn04Unidad => caispn04Unidad ?? new Paginacion<Caispn04Unidad>(mapper, accessor);
        public IPaginacion<Caispn05Unidad> Caispn05Unidad => caispn05Unidad ?? new Paginacion<Caispn05Unidad>(mapper, accessor);
        public IPaginacion<Caispn08Unidad> Caispn08Unidad => caispn08Unidad ?? new Paginacion<Caispn08Unidad>(mapper, accessor);
        public IPaginacion<Caispn09Unidad> Caispn09Unidad => caispn09Unidad ?? new Paginacion<Caispn09Unidad>(mapper, accessor);
        public IPaginacion<Caispn14Unidad> Caispn14Unidad => caispn14Unidad ?? new Paginacion<Caispn14Unidad>(mapper, accessor);
    }
}