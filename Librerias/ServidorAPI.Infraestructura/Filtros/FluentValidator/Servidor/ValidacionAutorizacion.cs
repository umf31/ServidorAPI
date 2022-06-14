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
//              ValidacionAutorizacion: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Persistencia.Informacion;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Servidor
{
    public class ValidacionAutorizacionLogin : AbstractValidator<LoginInsertar>
    {
        public ValidacionAutorizacionLogin()
        {
            RuleFor(x => x.Usuario).Requerido();
            RuleFor(x => x.Password).PasswordReq();
        }
    }

    public class ValidacionAutorizacionRecuperacion : AbstractValidator<RecuperacionInsertar>
    {
        public ValidacionAutorizacionRecuperacion()
        {
            RuleFor(x => x.Email).EmailReq();
            RuleFor(x => x.Telefono).TelefonoReq();
        }
    }

    public class ValidacionAutorizacionCambiarPassword : AbstractValidator<CambiarPasswordInsertar>
    {
        public ValidacionAutorizacionCambiarPassword()
        {
            RuleFor(x => x.CodigoSMS).CodigoSMS();
            RuleFor(x => x.Password).PasswordReq();
            RuleFor(x => x.ConfirmarPassword).PasswordReq().Equal(e => e.Password).WithMessage(Mensaje.FluentValidator.PasswordNoCoincide);
        }
    }

    public class ValidacionAutorizacionUnidad : AbstractValidator<UnidadActivaInsertar>
    {
        public ValidacionAutorizacionUnidad()
        {
            RuleFor(x => x.UrlUnidad).UrlReq();
            RuleFor(x => x.EmailUnidad).EmailReq();
            RuleFor(x => x.PasswordMail).PasswordReq();
        }
    }
}