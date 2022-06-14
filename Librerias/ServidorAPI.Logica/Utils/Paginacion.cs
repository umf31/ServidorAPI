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
//               Paginacion<Entidad>: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;

namespace ServidorAPI.Logica.Utils
{
    public class Paginacion<Entidad> : IPaginacion<Entidad>
    {
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor accessor;

        public Paginacion(IMapper _mapper, IHttpContextAccessor _accessor)
        {
            mapper = _mapper;
            accessor = _accessor;
        }

        public async Task<Lista<Entidad>> CrearLista(IEnumerable<Entidad> reg, int numPag, int regPag)
        {
            var totalRegistros = reg.Count();
            var items = reg.Skip((numPag - 1) * regPag).Take(regPag).ToList();
            var lista = new Lista<Entidad>(items, totalRegistros, numPag, regPag);
            return await Task.FromResult(lista);
        }

        public async Task<Metadatos> CrearMetadatos(Lista<Entidad> entidad, string control)
        {
            var metadatos = mapper.Map<Metadatos>(entidad);
            if (metadatos.ExistePaginaSiguiente == true && metadatos.ExistePaginaAnterior == true)
            {
                metadatos.PaginaSiguiente = await PaginaSiguiente(control, metadatos.PaginaActual, metadatos.RegistrosPagina);
                metadatos.PaginaAnterior = await PaginaAnterior(control, metadatos.PaginaActual, metadatos.RegistrosPagina);
            }
            else if (metadatos.ExistePaginaSiguiente == true && metadatos.ExistePaginaAnterior == false)
            {
                metadatos.PaginaSiguiente = await PaginaSiguiente(control, metadatos.PaginaActual, metadatos.RegistrosPagina);
            }
            else if (metadatos.ExistePaginaSiguiente == false && metadatos.ExistePaginaAnterior == true)
            {
                metadatos.PaginaAnterior = await PaginaAnterior(control, metadatos.PaginaActual, metadatos.RegistrosPagina);
            }
            return await Task.FromResult(metadatos);
        }

        public async Task<string> Informacion(string control, int? Id)
        {
            string UrlActual = $"{accessor?.HttpContext?.Request.Scheme}://{accessor?.HttpContext?.Request.Host}";
            var controlador = Ruta.Api.Base + control + "/" + Id;
            string Url = Path.Combine(UrlActual, controlador).Replace("\\", "/");
            return await Task.FromResult(Url);
        }

        public async Task<string> PaginaAnterior(string control, int pagAct, int regPag)
        {
            string anterior = Convert.ToString(pagAct - 1);
            string UrlActual = $"{accessor?.HttpContext?.Request.Scheme}://{accessor?.HttpContext?.Request.Host}";
            var controlador = Ruta.Api.Base + control + Paginacion.NumPag + anterior + Paginacion.NumReg + regPag;
            string Url = Path.Combine(UrlActual, controlador).Replace("\\", "/");
            return await Task.FromResult(Url);
        }

        public async Task<string> PaginaSiguiente(string control, int pagAct, int regPag)
        {
            string anterior = Convert.ToString(pagAct + 1);
            string UrlActual = $"{accessor?.HttpContext?.Request.Scheme}://{accessor?.HttpContext?.Request.Host}";
            var controlador = Ruta.Api.Base + control + Paginacion.NumPag + anterior + Paginacion.NumReg + regPag;
            string Url = Path.Combine(UrlActual, controlador).Replace("\\", "/");
            return await Task.FromResult(Url);
        }
    }
}