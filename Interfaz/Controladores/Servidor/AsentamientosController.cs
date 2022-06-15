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
//              AsentamientosController: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServidorAPI.Controladores.Utils;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Interfaces.Logica.Servidor;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Infraestructura.Objetos.Servidor.Consulta;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Controladores.Servidor
{
    [Route(Ruta.Api.Asentamiento)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Servidor)]
    [ApiController]
    [Authorize]
    public class AsentamientosController : BaseController<Asentamiento, AsentamientoEditar, AsentamientoInsertar, AsentamientoRespuesta, AsentamientoConsulta>
    {
        public AsentamientosController(IMapper mapper, ILogicaAsentamiento<Asentamiento> logica, IPaginacion<Asentamiento> paginacion)
            : base(mapper, logica, paginacion, Controlador.Nombre.Asentamiento)
        { }

        [AllowAnonymous]
        [HttpGet]
        public override Task<IActionResult> ObtenerTodo(AsentamientoConsulta consulta)
        {
            return base.ObtenerTodo(consulta);
        }

        [HttpGet(Controlador.Parametro.Id)]
        [AllowAnonymous]
        public override Task<IActionResult> ObtenerPorId(int id)
        {
            return base.ObtenerPorId(id);
        }

        [HttpPost(Controlador.Parametro.Matricula)]
        [AllowAnonymous]
        public override Task<IActionResult> Insertar(AsentamientoInsertar entidadInsertar, string matricula)
        {
            return base.Insertar(entidadInsertar, matricula);
        }

        [HttpPut(Controlador.Parametro.Id_Matricula)]
        [AllowAnonymous]
        public override Task<IActionResult> Editar(string matricula, int id, [FromForm] AsentamientoEditar entidadEditar)
        {
            return base.Editar(matricula, id, entidadEditar);
        }

        [HttpDelete(Controlador.Parametro.Id_Matricula)]
        [AllowAnonymous]
        public override Task<IActionResult> Eliminar(string matricula, int id)
        {
            return base.Eliminar(matricula, id);
        }
    }
}