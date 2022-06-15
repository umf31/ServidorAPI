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
//              ProcesosController: Creado 15-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServidorAPI.Controladores.Utils;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Infraestructura.Objetos.Sadim.Consulta;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;

namespace ServidorAPI.Controladores.Sadim
{
    [Route(Ruta.Api.Proceso)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Sadim)]
    [ApiController]
    [Authorize]
    public class ProcesosController : BaseController<Proceso, ProcesoEditar, ProcesoInsertar, ProcesoRespuesta, ProcesoConsulta>
    {
        public ProcesosController(IMapper mapper, ILogicaProceso<Proceso> logica, IPaginacion<Proceso> paginacion)
            : base(mapper, logica, paginacion, Controlador.Nombre.Proceso)
        { }

        [AllowAnonymous]
        [HttpGet]
        public override Task<IActionResult> ObtenerTodo(ProcesoConsulta consulta)
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
        public override Task<IActionResult> Insertar(ProcesoInsertar entidadInsertar, string matricula)
        {
            return base.Insertar(entidadInsertar, matricula);
        }

        [HttpPut(Controlador.Parametro.Id_Matricula)]
        [AllowAnonymous]
        public override Task<IActionResult> Editar(string matricula, int id, [FromForm] ProcesoEditar entidadEditar)
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