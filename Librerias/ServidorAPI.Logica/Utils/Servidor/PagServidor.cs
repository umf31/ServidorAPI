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
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Interfaces.Utils.Servidor;

namespace ServidorAPI.Logica.Utils.Servidor
{
    public class PagServidor : IPagServidor
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accessor;
        internal readonly IPaginacion<Asentamiento> asentamiento = null!;
        internal readonly IPaginacion<Categoria> categoria = null!;
        internal readonly IPaginacion<Colonia> colonia = null!;
        internal readonly IPaginacion<Delegacion> delegacion = null!;
        internal readonly IPaginacion<Empleado> empleado = null!;
        internal readonly IPaginacion<Estado> estado = null!;
        internal readonly IPaginacion<Municipio> municipio = null!;
        internal readonly IPaginacion<Pais> pais = null!;
        internal readonly IPaginacion<Servicio> servicio = null!;
        internal readonly IPaginacion<Status> status = null!;
        internal readonly IPaginacion<Unidad> unidad = null!;
        internal readonly IPaginacion<UnidadTipo> unidadTipo = null!;
        internal readonly IPaginacion<Vialidad> vialidad = null!;

        public PagServidor(IMapper _mapper, IHttpContextAccessor _accessor)
        {
            mapper = _mapper;
            accessor = _accessor;
        }

        public IPaginacion<Asentamiento> Asentamiento => asentamiento ?? new Paginacion<Asentamiento>(mapper, accessor);
        public IPaginacion<Categoria> Categoria => categoria ?? new Paginacion<Categoria>(mapper, accessor);
        public IPaginacion<Colonia> Colonia => colonia ?? new Paginacion<Colonia>(mapper, accessor);
        public IPaginacion<Delegacion> Delegacion => delegacion ?? new Paginacion<Delegacion>(mapper, accessor);
        public IPaginacion<Empleado> Empleado => empleado ?? new Paginacion<Empleado>(mapper, accessor);
        public IPaginacion<Estado> Estado => estado ?? new Paginacion<Estado>(mapper, accessor);
        public IPaginacion<Municipio> Municipio => municipio ?? new Paginacion<Municipio>(mapper, accessor);
        public IPaginacion<Pais> Pais => pais ?? new Paginacion<Pais>(mapper, accessor);
        public IPaginacion<Servicio> Servicio => servicio ?? new Paginacion<Servicio>(mapper, accessor);
        public IPaginacion<Status> Status => status ?? new Paginacion<Status>(mapper, accessor);
        public IPaginacion<Unidad> Unidad => unidad ?? new Paginacion<Unidad>(mapper, accessor);
        public IPaginacion<UnidadTipo> UnidadTipo => unidadTipo ?? new Paginacion<UnidadTipo>(mapper, accessor);
        public IPaginacion<Vialidad> Vialidad => vialidad ?? new Paginacion<Vialidad>(mapper, accessor);
    }
}