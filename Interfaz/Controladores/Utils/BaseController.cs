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
//                  ControladorBase: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Controladores.Utils
{
    public class BaseController<Entidad, oEditar, oInsertar, oRespuesta, oConsulta> : ControllerBase where Entidad : EntidadBase
    {
        private readonly IMapper mapper;
        private readonly IServidorLogica<Entidad> logica;
        private readonly IPaginacion<Entidad> paginacion;
        private readonly string control;

        public BaseController(IMapper _mapper, IServidorLogica<Entidad> _logica, IPaginacion<Entidad> _paginacion, string _control)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
            control = _control;
        }

        public virtual async Task<IActionResult> ObtenerTodo([FromQuery] oConsulta consulta)
        {
            var entidad = await logica.ObtenerTodo(consulta!);
            var metadatos = paginacion.CrearMetadatos(entidad, control);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var entidadRespuesta = mapper.Map<IEnumerable<oRespuesta>>(entidad);
            var oReply = new Reply<IEnumerable<oRespuesta>>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
                Meta = metadatos.Result
            };
            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadatos.Result));
            return Ok(oReply);
        }

        public virtual async Task<IActionResult> ObtenerPorId(int Id)
        {
            var entidad = await logica.ObtenerPorId(Id);
            var entidadRespuesta = mapper.Map<oRespuesta>(entidad);
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.OK,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };

            var oReply = new Reply<oRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Ok(oReply);
        }

        public virtual async Task<IActionResult> Insertar([FromForm] oInsertar entidadInsertar, string matricula)
        {
            var entidad = mapper.Map<Entidad>(entidadInsertar);
            entidad.UsuarioMod = matricula;

            entidad = await logica.Insertar(entidadInsertar!, matricula);

            var entidadRespuesta = mapper.Map<oRespuesta>(entidad);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode201,
                Detalle = Mensaje.Detalle.InsertarOk,
                StatusCode = Mensaje.Excepcion.StatusCode201,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito,
                InfromacionRegistro = await paginacion.Informacion(control, entidad.Id)
            };

            var oReply = new Reply<oRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Created(detalleRespuesta.InfromacionRegistro, oReply);
        }

        public virtual async Task<IActionResult> Editar(string matricula, int id, [FromForm] oEditar entidadEditar)
        {
            await logica.Editar(entidadEditar!, matricula, id);
            var entidadEditada = await logica.ObtenerPorId(id);
            var entidadRespuesta = mapper.Map<oRespuesta>(entidadEditada);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.EditarOk,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var oReply = new Reply<oRespuesta>(entidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Ok(oReply);
        }

        public virtual async Task<IActionResult> Eliminar(string matricula, int Id)
        {
            await logica.Eliminar(Id, matricula);
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