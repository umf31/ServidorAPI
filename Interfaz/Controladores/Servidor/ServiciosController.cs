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
//               Controlador Servicios: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
    [Route(Ruta.Api.Servicio)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Servidor)]
    [ApiController]
    [Authorize]
    public class ServiciosController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogicaServicio logica;
        private readonly IPagServidor paginacion;

        public ServiciosController(IMapper _mapper, ILogicaServicio _logica, IPagServidor _paginacion)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
        }

        [AllowAnonymous]
        [HttpGet]
        public virtual async Task<IActionResult> ObtenerTodoAsync([FromQuery] ServicioConsulta consulta)
        {
            var entidad = await logica.ObtenerTodo(consulta!);
            var metadatos = paginacion.Servicio.CrearMetadatos(entidad, Controlador.Nombre.Servicio);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var entidadRespuesta = mapper.Map<IEnumerable<ServicioRespuesta>>(entidad);
            var oReply = new Reply<IEnumerable<ServicioRespuesta>>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
                Meta = metadatos.Result
            };
            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadatos.Result));
            return Ok(oReply);
        }

        [HttpGet(Controlador.Parametro.Id)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> ObtenerPorId(int id)
        {
            var entidad = await logica.ObtenerPorId(id);
            var entidadRespuesta = mapper.Map<ServicioRespuesta>(entidad);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };

            var oReply = new Reply<ServicioRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Ok(oReply);
        }

        [HttpPost(Controlador.Parametro.Matricula)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> InsertarAsync([FromForm] ServicioInsertar entidadInsertar, string matricula)
        {
            var entidad = mapper.Map<Servicio>(entidadInsertar);
            entidad.UsuarioMod = matricula;

            entidad = await logica.Insertar(entidadInsertar!, matricula);

            var entidadRespuesta = mapper.Map<ServicioRespuesta>(entidad);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode201,
                Detalle = Mensaje.Detalle.InsertarOk,
                StatusCode = Mensaje.Excepcion.StatusCode201,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito,
                InfromacionRegistro = await paginacion.Servicio.Informacion(Controlador.Nombre.Servicio, entidad.IdServicio)
            };

            var oReply = new Reply<ServicioRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Created(detalleRespuesta.InfromacionRegistro, oReply);
        }

        [HttpPut(Controlador.Parametro.Id_Matricula)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> EditarAsync(string matricula, int id, [FromForm] ServicioEditar entidadEditar)
        {
            await logica.Editar(entidadEditar!, matricula, id);
            var entidadEditada = await logica.ObtenerPorId(id);
            var entidadRespuesta = mapper.Map<ServicioRespuesta>(entidadEditada);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.EditarExito,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var oReply = new Reply<ServicioRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Ok(oReply);
        }

        [HttpDelete(Controlador.Parametro.Id_Matricula)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> EliminarAsync(string matricula, int id)
        {
            await logica.Eliminar(id, matricula);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.EliminarOk,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var oReply = new CodigoRespuesta
            {
                Detalles = detalleRespuesta
            };
            return Ok(oReply);
        }
    }
}