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
//                DiabetesController: Creado 30-05-2022
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
    [Route(Ruta.Sadim.Diabetes)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Sadim)]
    [ApiController]
    [Authorize]
    public class DiabetesController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogicaDiabetes logica;
        private readonly IPagSadim paginacion;
        public DiabetesController(IMapper _mapper, ILogicaDiabetes _logica, IPagSadim _paginacion)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
        }

        [HttpGet(Controlador.Nombre.Dm01)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoDm01([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaDm01Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Dm01Unidad.CrearMetadatos(entidad, Controlador.Nombre.Dm01);
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

        [HttpPost(Controlador.Ruta.ActualizarDm01)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarDm01(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaDm01Unidad.Actualizar(matricula))
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

        [HttpGet(Controlador.Nombre.Dm02)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoDm02([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaDm02Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Dm02Unidad.CrearMetadatos(entidad, Controlador.Nombre.Dm02);
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

        [HttpPost(Controlador.Ruta.ActualizarDm02)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarDm02(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaDm02Unidad.Actualizar(matricula))
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

        [HttpGet(Controlador.Nombre.Dm04)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoDm04([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaDm04Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Dm04Unidad.CrearMetadatos(entidad, Controlador.Nombre.Dm04);
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

        [HttpPost(Controlador.Ruta.ActualizarDm04)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarDm04(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaDm04Unidad.Actualizar(matricula))
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

        [HttpGet(Controlador.Nombre.Dm05)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoDm05([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaDm05Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.Dm05Unidad.CrearMetadatos(entidad, Controlador.Nombre.Dm05);
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

        [HttpPost(Controlador.Ruta.ActualizarDm05)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarDm05(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaDm05Unidad.Actualizar(matricula))
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