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
//                CancerMamaController: Creado 30-05-2022
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
    [Route(Ruta.Sadim.CancerMama)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Sadim)]
    [ApiController]
    [Authorize]
    public class CancerMamaController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogicaCaMama logica;
        private readonly IPagSadim paginacion;
        public CancerMamaController(IMapper _mapper, ILogicaCaMama _logica, IPagSadim _paginacion)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
        }

        [HttpGet(Controlador.Nombre.CaMama01)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoCaMama01([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaCaMama01Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.CaMama01Unidad.CrearMetadatos(entidad, Controlador.Nombre.CaMama01);
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

        [HttpPost(Controlador.Ruta.ActualizarCaMama01)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarCaMama01(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaCaMama01Unidad.Actualizar(matricula))
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

        [HttpGet(Controlador.Nombre.CaMama02)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoCaMama02([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaCaMama02Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.CaMama02Unidad.CrearMetadatos(entidad, Controlador.Nombre.CaMama02);
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

        [HttpPost(Controlador.Ruta.ActualizarCaMama02)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarCaMama02(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaCaMama02Unidad.Actualizar(matricula))
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

        [HttpGet(Controlador.Nombre.CaMama03)]
        [AllowAnonymous]
        public async Task<IActionResult> ObtenerTodoCaMama03([FromQuery] IndicadorConsulta consulta)
        {
            var entidad = await logica.LogicaCaMama03Unidad.ObtenerTodo(consulta!);
            var metadatos = paginacion.CaMama03Unidad.CrearMetadatos(entidad, Controlador.Nombre.CaMama03);
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

        [HttpPost(Controlador.Ruta.ActualizarCaMama03)]
        [AllowAnonymous]
        public async Task<IActionResult> ActualizarCaMama03(string matricula)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.LogicaCaMama03Unidad.Actualizar(matricula))
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