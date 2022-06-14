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
//                   ExcepcionBase: Creado 05-06-2022
//=======================================================================

#endregion

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;
using ServidorAPI.Persistencia.Informacion;
using System.Net;

namespace ServidorAPI.Infraestructura.Filtros.ControlExcepciones
{
    public class ExcepcionBase : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.Message.Contains("Unable to resolve service for type"))
            {
                string origen = context.Exception.Message;
                string primeraPalabra = "type '";
                string segundaPalabra = "`";
                string resultado = EncontrarEntre(origen, primeraPalabra, segundaPalabra);

                var validacion = new DetalleRespuesta
                {
                    Resultado = false,
                    Encabezado = Mensaje.Encabezado.StatusCode500,
                    Detalle = Mensaje.Detalle.ErrorDependencia + resultado,
                    StatusCode = Mensaje.Excepcion.StatusCode500,
                    TipoRespuesta = Mensaje.TipoRespuesta.Error
                };
                var json = new
                {
                    Detalles = validacion
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
            if (context.Exception.Message.Contains("Error mapping types"))
            {
                var validacion = new DetalleRespuesta
                {
                    Resultado = false,
                    Encabezado = Mensaje.Encabezado.StatusCode500,
                    Detalle = Mensaje.Detalle.AutoMapper,
                    StatusCode = Mensaje.Excepcion.StatusCode500,
                    TipoRespuesta = Mensaje.TipoRespuesta.Error
                };
                var json = new
                {
                    Detalles = validacion
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
            if (context.Exception.Message.Contains("Missing type map configuration or unsupported mapping"))
            {
                var validacion = new DetalleRespuesta
                {
                    Resultado = false,
                    Encabezado = Mensaje.Encabezado.StatusCode500,
                    Detalle = Mensaje.Detalle.AutoMapper,
                    StatusCode = Mensaje.Excepcion.StatusCode500,
                    TipoRespuesta = Mensaje.TipoRespuesta.Error
                };
                var json = new
                {
                    Detalles = validacion
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
            if (context.Exception.Message.Contains("Instrucción DELETE en conflicto"))
            {
                var validacion = new DetalleRespuesta
                {
                    Resultado = false,
                    Encabezado = Mensaje.Encabezado.StatusCode500,
                    Detalle = Mensaje.Detalle.EliminarConflicto,
                    StatusCode = Mensaje.Excepcion.StatusCode500,
                    TipoRespuesta = Mensaje.TipoRespuesta.Error
                };
                var json = new
                {
                    Detalles = validacion
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
            if (context.Exception.Message.Contains("No se puede insertar el valor NULL en la columna"))
            {
                string origen = context.Exception.Message;
                string primeraPalabra = "columna '";
                string segundaPalabra = "`";
                string resultado = EncontrarEntre(origen, primeraPalabra, segundaPalabra);

                var validacion = new DetalleRespuesta
                {
                    Resultado = false,
                    Encabezado = Mensaje.Encabezado.StatusCode500,
                    Detalle = Mensaje.Detalle.ErrorNulo + resultado,
                    StatusCode = Mensaje.Excepcion.StatusCode500,
                    TipoRespuesta = Mensaje.TipoRespuesta.Error
                };
                var json = new
                {
                    Detalles = validacion
                };
                context.Result = new ObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.ExceptionHandled = true;
            }
        }

        public static string EncontrarEntre(string Origen, string PrimeraPalabra, string SegundaPalabra)
        {
            string result = "";
            if (Origen.Contains(PrimeraPalabra) && Origen.Contains(SegundaPalabra))
            {
                int StartIndex = Origen.IndexOf(PrimeraPalabra, 0) + PrimeraPalabra.Length;
                int EndIndex = Origen.IndexOf(SegundaPalabra, StartIndex);
                result = Origen[StartIndex..EndIndex];
                return result;
            }
            return result;
        }
    }
}