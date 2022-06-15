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
//               Controlador Autorizacion: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Interfaces.Logica.Servidor;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Controladores.Servidor
{
    [Route(Ruta.Api.Autorizacion)]
    [Produces(TipoArchivo.ApplicationJson)]
    [ApiExplorerSettings(GroupName = Plataforma.Servidor)]
    [ApiController]
    [Authorize]
    public class AutorizacionController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ILogicaAutorizacion logica;
        private readonly ILogicaEmpleado<Empleado> registro;
        private readonly IPagServidor paginacion;

        public AutorizacionController(IMapper _mapper, ILogicaAutorizacion _logica, ILogicaEmpleado<Empleado> _registro, IPagServidor _paginacion)
        {
            mapper = _mapper;
            logica = _logica;
            paginacion = _paginacion;
            registro = _registro;
        }

        [HttpPost(Controlador.Ruta.Login)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromQuery] LoginInsertar login)
        {
            var autentificar = await logica.Login(login);
            string mensaje;
            if (autentificar.Soporte != true)
            {
                mensaje = Mensaje.Detalle.Bienvenida + autentificar.NombreCompleto;
            }
            else
            {
                mensaje = Mensaje.Detalle.LoginSoporte;
            }
            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = mensaje,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var oReply = new Reply<Autentificacion>(autentificar)
            {
                Detalles = detalleRespuesta
            };
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.Registro)]
        [AllowAnonymous]
        public async Task<IActionResult> Registro([FromForm] EmpleadoInsertar entidadInsertar)
        {
            var empleado = await registro.Insertar(entidadInsertar, entidadInsertar.Matricula!);
            var informacionRegistro = await paginacion.Empleado.Informacion(Controlador.Nombre.Empleado, empleado.Id);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode201,
                Detalle = Mensaje.Detalle.RegistroExito,
                StatusCode = Mensaje.Excepcion.StatusCode201,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito,
                InfromacionRegistro = informacionRegistro
            };
            var oReply = new CodigoRespuesta
            {
                Detalles = detalleRespuesta
            };
            return Created(detalleRespuesta.InfromacionRegistro, oReply);
        }

        [HttpPost(Controlador.Ruta.Recuperacion)]
        [AllowAnonymous]
        public async Task<IActionResult> Recuperacion([FromForm] RecuperacionInsertar recovery)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.Recuperacion(recovery))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.RecuperacionEnviado,
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

        [HttpPost(Controlador.Ruta.CambiarPassword)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> CambiarPasswordRecovery([FromForm] CambiarPasswordInsertar pass)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.CambiarPasswordRecuperacion(pass))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta
                };
            }
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.CambiarUnidad)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> CambiarUnidadActiva(int unidadId, string matricula, [FromForm] UnidadActivaInsertar unidadActiva)
        {
            var unidad = await logica.CambiarUnidad(unidadActiva, unidadId, matricula);
            var unidadRespuesta = mapper.Map<Unidad>(unidad);

            var detalleRespuesta = new DetalleRespuesta
            {
                Resultado = true,
                Encabezado = Mensaje.Encabezado.StatusCode200,
                Detalle = Mensaje.Detalle.EditarExito,
                StatusCode = Mensaje.Excepcion.StatusCode200,
                TipoRespuesta = Mensaje.TipoRespuesta.Exito
            };
            var oReply = new Reply<Unidad>(unidadRespuesta)
            {
                Detalles = detalleRespuesta,
            };
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.BloquearEmpleado)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> BloquearEmpleado(int empleadoId)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.BloquearEmpleado(empleadoId))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.BloquearCorrecto,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta
                };
            }
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.DesbloquearEmpleado)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> DesbloquearEmpleado(int empleadoId, string password)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.DesbloquearEmpleado(empleadoId, password))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    Detalle = Mensaje.Detalle.DesbloquearCorrecto,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta
                };
            }
            return Ok(oReply);
        }

        [HttpPost(Controlador.Ruta.CambiarRol)]
        [AllowAnonymous]
        public virtual async Task<IActionResult> CambiarRolEmpleado(string matricula, int empleadoId, [FromForm] AgregarRolInsertar rol)
        {
            var oReply = new CodigoRespuesta();
            if (await logica.CambiarRol(rol, empleadoId, matricula))
            {
                var detalleRespuesta = new DetalleRespuesta
                {
                    Resultado = true,
                    Encabezado = Mensaje.Encabezado.StatusCode200,
                    StatusCode = Mensaje.Excepcion.StatusCode200,
                    TipoRespuesta = Mensaje.TipoRespuesta.Exito
                };
                oReply = new CodigoRespuesta
                {
                    Detalles = detalleRespuesta
                };
            }
            return Ok(oReply);
        }
    }
}