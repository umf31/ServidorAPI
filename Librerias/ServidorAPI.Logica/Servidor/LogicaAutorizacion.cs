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
//                LogicaAutorizacion: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.DataProtection;
using MimeKit;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Logica.Servidor;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace ServidorAPI.Logica.Servidor
{
    public class LogicaAutorizacion : ILogicaAutorizacion
    {
        private readonly IMapper mapper;
        private readonly IServidorUT ut;
        private readonly IUtilerias util;
        private readonly IDataProtector protector;

        public LogicaAutorizacion(IMapper _mapper, IServidorUT _ut, IUtilerias _util, IDataProtectionProvider _protector)
        {
            mapper = _mapper;
            ut = _ut;
            util = _util;
            protector = _protector.CreateProtector(Configuracion.LlavePrivada);
        }

        public async Task<Autentificacion> Login(dynamic dynLogin)
        {
            var login = (LoginInsertar)dynLogin;
            Empleado empleado;
            if (await util.VerificaEsNumero(login.Usuario))
            {
                var matricula = login.Usuario;
                empleado = await ut.AsistenteEmpleado.ObtenerPorMatricula(matricula);
            }
            else
            {
                empleado = await ut.AsistenteEmpleado.ObtenerPorEmail(login.Usuario);
            }
            if (empleado == null)
            {
                var matricula = login.Usuario;
                var empleadoSoporte = await ut.AsistenteSoporte.ObtenerEmpleadoPorMatricula(matricula);
                if (empleadoSoporte != null)
                {
                    empleado = mapper.Map<Empleado>(empleadoSoporte);
                    empleado.Soporte = true;

                    if (!await util.VerificaHash(login.Password, empleado.PasswordHash, empleado.PasswordSalt))
                    {
                        throw new BadRequest(Mensaje.Detalle.LoginError);
                    }
                }
                else
                {
                    throw new BadRequest(Mensaje.Detalle.LoginError);
                }
            }
            else
            {
                var unidad = await ut.AsistenteUnidad.ObtenerUnidadActiva();
                if (empleado.UnidadId != unidad.Id)
                {
                    throw new BadRequest(Mensaje.Detalle.LoginError);
                }
                if (!await util.VerificaHash(login.Password, empleado.PasswordHash, empleado.PasswordSalt))
                {
                    throw new BadRequest(Mensaje.Detalle.LoginError);
                }
                empleado.Soporte = null;
                await ut.AsistenteEmpleado.DesbloquearEmpleado(empleado.Id);
                await ut.GuardarServidorAPI();
            }
            empleado.Recordar = login.Recordar;
            var token = await util.CrearTokenJWTBearer(empleado);
            var roles = new List<Roles>();
            foreach (EmpleadoRol item in empleado.Roles)
            {
                Roles rol = item.Rol;
                roles.Add(rol);
            }
            var autentificar = new Autentificacion()
            {
                Id = empleado.Id,
                NombreCompleto = empleado.NombreCompleto,
                Email = empleado.Email,
                Matricula = empleado.Matricula,
                ServicioId = empleado.ServicioId,
                Recordar = empleado.Recordar,
                Imagen = empleado.Imagen,
                Roles = roles,
                Token = token,
                Soporte = empleado.Soporte
            };

            return autentificar;
        }

        public async Task<Unidad> CambiarUnidad(dynamic dynUnidadActiva, int unidadId, string matricula)
        {
            var unidadActiva = (UnidadActivaInsertar)dynUnidadActiva;

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.Prohibido);
            }
            if (!await ut.AsistenteUnidad.ExisteEntidadPorId(unidadId))
            {
                throw new NotFound(Mensaje.Detalle.UnidadNoExiste);
            }

            var unidadActual = await ut.AsistenteSoporte.ObtenerUnidadActiva();
            await ut.AsistenteSoporte.CambiarStatusUnidadAnterior(unidadActual.Id, matricula);
            await ut.GuardarSoporte();

            var unidadNueva = await ut.AsistenteSoporte.ObtenerUnidadPorId(unidadId);
            unidadNueva.UrlUnidad = unidadActiva.UrlUnidad;
            unidadNueva.EmailUnidad = unidadActiva.EmailUnidad;
            unidadNueva.PasswordMail = unidadActiva.PasswordMail;
            unidadNueva.UsuarioMod = matricula;
            unidadNueva.FechaModificacion = DateTime.Now;
            unidadNueva.StatusId = 4;
            await ut.AsistenteSoporte.CambiarUnidadSoporte(unidadNueva);
            await ut.GuardarSoporte();

            await ut.AsistenteUnidad.CambiarStatusUnidadAnterior(unidadActual.Id, matricula);
            await ut.GuardarServidorAPI();
            var unidad = await ut.AsistenteUnidad.ObtenerPorId(unidadId);
            unidad.UsuarioMod = matricula;
            unidad.FechaModificacion = DateTime.Now;
            unidad.StatusId = 4;
            await ut.AsistenteUnidad.CambiarUnidadActiva(unidad);
            await ut.GuardarServidorAPI();
            unidad.Id = unidad.Id;
            return unidad;
        }

        public async Task<bool> Recuperacion(dynamic dynRecovery)
        {
            var recuperacion = (RecuperacionInsertar)dynRecovery;
            Random random = new Random();
            recuperacion.Email = recuperacion.Email.ToLower();
            var entidad = await ut.AsistenteEmpleado.ObtenerPorEmail(recuperacion.Email);
            var codigo = random.Next(100000, 999999);
            var codigoSMS = protector.Protect(codigo.ToString());
            entidad.CodigoSMS = codigoSMS;
            var unidad = await ut.AsistenteSoporte.ObtenerUnidadActiva();

            var mensaje = new MimeMessage();
            mensaje.From.Add(new MailboxAddress(unidad.Nombre, unidad.EmailUnidad));
            mensaje.To.Add(new MailboxAddress(entidad.NombreCompleto, entidad.Email));
            mensaje.Subject = Ruta.Email.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = Ruta.Email.Body + codigo;
            mensaje.Body = bodyBuilder.ToMessageBody();
            using (var cliente = new SmtpClient())
            {
                cliente.CheckCertificateRevocation = false;
                await cliente.ConnectAsync(unidad.ServidorMail, unidad.PuertoMail, MailKit.Security.SecureSocketOptions.StartTls);
                await cliente.AuthenticateAsync(unidad.EmailUnidad, unidad.PasswordMail);
                await cliente.SendAsync(mensaje);
                await cliente.DisconnectAsync(true);
            }

            if (recuperacion.Telefono != null)
            {
                var telefono = Regex.Replace(recuperacion.Telefono, @"[^0-9]", "", RegexOptions.None);
                var sms = await ut.AsistenteSoporte.ObtenerOpcionesSMS();

                TwilioClient.Init(sms.TwilioCuenta, sms.TwilioToken);
                MessageResource.Create(
                    from: new PhoneNumber(sms.TwilioTelefono),
                    to: new PhoneNumber("+52" + telefono),
                    body: Ruta.Email.Subject + codigo
                    );
            }
            await ut.AsistenteEmpleado.Editar(entidad);
            await ut.GuardarServidorAPI();

            return true;
        }

        public async Task<bool> BloquearEmpleado(int empleadoId)
        {
            var entidad = await ut.AsistenteEmpleado.ObtenerPorId(empleadoId);
            if (entidad == null)
            {
                throw new BadRequest(Mensaje.Detalle.EmpleadoNoExiste);
            }
            if (entidad.Bloqueo == true)
            {
                throw new BadRequest(Mensaje.Detalle.BloquearExiste);
            }
            entidad.Bloqueo = true;
            await ut.AsistenteEmpleado.Editar(entidad);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> DesbloquearEmpleado(int empleadoId, string password)
        {
            var entidad = await ut.AsistenteEmpleado.ObtenerPorId(empleadoId);
            if (entidad == null)
            {
                throw new NotFound(Mensaje.Detalle.EmpleadoNoExiste);
            }
            if (!await util.VerificaHash(password, entidad.PasswordHash, entidad.PasswordSalt))
            {
                throw new NotFound(Mensaje.Detalle.DesbloquearError);
            }
            if (entidad.Bloqueo == false)
            {
                throw new BadRequest(Mensaje.Detalle.BloquearNoExiste);
            }

            entidad.Bloqueo = false;
            await ut.AsistenteEmpleado.Editar(entidad);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> CambiarPasswordRecuperacion(dynamic dynCambiarContraseña)
        {
            var cambiarContraseña = (CambiarPasswordInsertar)dynCambiarContraseña;
            Empleado empleado;
            if (await util.VerificaEsNumero(cambiarContraseña.Usuario))
            {
                var matricula = cambiarContraseña.Usuario;
                empleado = await ut.AsistenteEmpleado.ObtenerPorMatricula(matricula);
            }
            else
            {
                empleado = await ut.AsistenteEmpleado.ObtenerPorEmail(cambiarContraseña.Usuario);
            }
            var codigoSMS = protector.Unprotect(empleado.CodigoSMS!);
            if (Convert.ToInt32(codigoSMS) != cambiarContraseña.CodigoSMS)
            {
                throw new InternalServerError(Mensaje.Detalle.PasswordRecoveryError);
            }

            var crearPassword = await util.CrearHash(cambiarContraseña.Password);
            empleado.PasswordHash = crearPassword.ItemHash;
            empleado.PasswordSalt = crearPassword.ItemSalt;
            empleado.CodigoSMS = null;
            await ut.AsistenteEmpleado.Editar(empleado);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> CambiarRol(dynamic dynRol, int empleadoId, string matricula)
        {
            var rol = (AgregarRolInsertar)dynRol;

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.Prohibido);
            }
            if (!await ut.AsistenteEmpleado.ExisteEntidadPorId(empleadoId))
            {
                throw new NotFound(Mensaje.Detalle.EmpleadoNoExiste);
            }
            var empleado = await ut.AsistenteEmpleado.ObtenerPorMatricula(matricula);
            if (empleado.Roles.Where(x => x.Rol.IdRol >= 2).FirstOrDefault() != null)
            {
                var roles = await ut.AsistenteRol.ObtenerTodo(empleadoId);
                if (roles != null)
                {
                    if (rol.EsUsuario == true)
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.Usuario))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.Usuario);
                        }
                        await ut.AsistenteRol.AgregarRol(empleadoId, RolServidor.Usuario);
                    }
                    else
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.Usuario))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.Usuario);
                        }
                    }
                    if (rol.EsJefeServicio == true)
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.JefeServicio))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.JefeServicio);
                        }
                        await ut.AsistenteRol.AgregarRol(empleadoId, RolServidor.JefeServicio);
                    }
                    else
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.JefeServicio))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.JefeServicio);
                        }
                    }
                    if (rol.EsDirectivo == true)
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.Directivo))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.Directivo);
                        }
                        await ut.AsistenteRol.AgregarRol(empleadoId, RolServidor.Directivo);
                    }
                    else
                    {
                        if (roles.Any(x => x.IdRol == RolServidor.Directivo))
                        {
                            await ut.AsistenteRol.EliminarRol(empleadoId, RolServidor.Directivo);
                        }
                    }
                    if (roles.Any(x => x.IdRol == 0))
                    {
                        await ut.AsistenteRol.EliminarRol(empleadoId, 0);
                    }
                    await ut.GuardarServidorAPI();
                    return true;
                }
            }
            return true;
        }

        public async Task<bool> Logout(int empleadoId)
        {
            var entidad = await ut.AsistenteEmpleado.ObtenerPorId(empleadoId);
            if (entidad == null)
            {
                throw new BadRequest(Mensaje.Detalle.EmpleadoNoExiste);
            }
            if (entidad.Bloqueo == true)
            {
                throw new BadRequest(Mensaje.Detalle.BloquearExiste);
            }
            entidad.Bloqueo = false;
            entidad.Activo = false;
            await ut.AsistenteEmpleado.Editar(entidad);
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}