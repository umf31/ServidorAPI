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
//                https://github.com/umf31/ServidorSadim
//                HipertensionController: Creado 30-05-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Infraestructura.Objetos.Sadim.Consulta;
using ServidorAPI.Infraestructura.Objetos.Sadim.Respuesta;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Controladores.Sadim
{
    [Route(Ruta.Sadim.Hipertension)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Sadim)]
    [ApiController]
    [Authorize]
    public class HipertensionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogicaEh logica;
        private readonly IPagSadim paginacion;
        public HipertensionController(IMapper _mapper, ILogicaEh _logica, IPagSadim _paginacion)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
        }

        [HttpGet(Controlador.Nombre.Eh01)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoEh01([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaEh01Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Eh01Unidad.CrearMetadatos(entidad, Controlador.Nombre.Eh01);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var entidadRespuesta = mapper.Map<IEnumerable<IndicadorRespuesta>>(entidad);
            var oReply = new Reply<IEnumerable<IndicadorRespuesta>>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
                Meta = metadatos.Result
            };
            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadatos.Result));
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.ActualizarEh01)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarEh01(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaEh01Unidad.Actualizar(matricula))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.IndicadorActualizado,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta,
                };
            }
            return Ok(oReply);
        }

        [HttpGet(Controlador.Nombre.Eh02)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoEh02([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaEh02Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Eh02Unidad.CrearMetadatos(entidad, Controlador.Nombre.Eh02);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var entidadRespuesta = mapper.Map<IEnumerable<IndicadorRespuesta>>(entidad);
            var oReply = new Reply<IEnumerable<IndicadorRespuesta>>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
                Meta = metadatos.Result
            };
            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadatos.Result));
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.ActualizarEh02)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarEh02(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaEh02Unidad.Actualizar(matricula))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.IndicadorActualizado,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta,
                };
            }
            return Ok(oReply);
        }

        [HttpGet(Controlador.Nombre.Eh04)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoEh04([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaEh04Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Eh04Unidad.CrearMetadatos(entidad, Controlador.Nombre.Eh04);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var entidadRespuesta = mapper.Map<IEnumerable<IndicadorRespuesta>>(entidad);
            var oReply = new Reply<IEnumerable<IndicadorRespuesta>>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
                Meta = metadatos.Result
            };
            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadatos.Result));
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.ActualizarEh04)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarEh04(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaEh04Unidad.Actualizar(matricula))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.IndicadorActualizado,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta,
                };
            }
            return Ok(oReply);
        }

    }
}