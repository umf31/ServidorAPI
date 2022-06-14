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
//                ValidacionEmpleado: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Persistencia.Informacion;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Servidor
{
    public class ValidacionEmpleadoInsertar : AbstractValidator<EmpleadoInsertar>
    {
        public ValidacionEmpleadoInsertar()
        {
            RuleFor(x => x.Matricula).MatriculaReq();
            RuleFor(x => x.Email).EmailReq().When(x => x.Matricula != null);
            RuleFor(x => x.ApellidoPaterno).NombreReq().When(x => x.Email != null);
            RuleFor(x => x.ApellidoMaterno).NombreReq().When(x => x.ApellidoPaterno != null);
            RuleFor(x => x.Nombre).NombreReq().When(x => x.ApellidoMaterno != null);
            RuleFor(x => x.CategoriaId).Requerido().When(x => x.Nombre != null);
            RuleFor(x => x.ServicioId).Requerido().When(x => x.CategoriaId > 0);
            RuleFor(x => x.VialidadId).Requerido().When(x => x.ServicioId > 0);
            RuleFor(c => c.Calle).CalleReq().When(x => x.VialidadId > 0);
            RuleFor(x => x.Numero).NumDomicilioReq().When(x => x.Calle != null);
            RuleFor(x => x.ColoniaId).Requerido().When(x => x.Numero != null);
            RuleFor(x => x.Telefono).TelefonoReq().When(x => x.ColoniaId > 0);
            RuleFor(x => x.Password).PasswordReq().When(x => x.Telefono != null);
            RuleFor(x => x.ConfirmarPassword).PasswordReq().Equal(e => e.Password).WithMessage(Mensaje.FluentValidator.PasswordNoCoincide).When(x => x.Password != null);
            RuleFor(x => x.Latitud).Latitud().When(x => x.Longitud != null && x.ConfirmarPassword != null);
            RuleFor(x => x.Longitud).Longitud().When(x => x.Latitud != null);
            RuleFor(e => e.Foto!).SetValidator(new ValidacionImagen());
        }
    }

    public class ValidacionEmpleadoEditar : AbstractValidator<EmpleadoEditar>
    {
        public ValidacionEmpleadoEditar()
        {
            RuleFor(x => x.Matricula).MatriculaReq().When(x => x.Matricula != null);
            RuleFor(x => x.Email).EmailReq().When(x => x.Email != null);
            RuleFor(x => x.ApellidoPaterno).NombreReq().When(x => x.ApellidoPaterno != null);
            RuleFor(x => x.ApellidoMaterno).NombreReq().When(x => x.ApellidoMaterno != null);
            RuleFor(x => x.Nombre).NombreReq().When(x => x.Nombre != null);
            RuleFor(x => x.CategoriaId).Requerido().When(x => x.CategoriaId > 0);
            RuleFor(x => x.ServicioId).Requerido().When(x => x.ServicioId > 0);
            RuleFor(x => x.VialidadId).Requerido().When(x => x.VialidadId > 0);
            RuleFor(c => c.Calle).CalleReq().When(x => x.Calle != null);
            RuleFor(x => x.Numero).NumDomicilioReq().When(x => x.Numero != null);
            RuleFor(x => x.ColoniaId).Requerido().When(x => x.ColoniaId > 0);
            RuleFor(x => x.Telefono).TelefonoReq().When(x => x.Telefono != null);
            RuleFor(x => x.Latitud).Latitud().When(x => x.Longitud != null);
            RuleFor(x => x.Longitud).Longitud().When(x => x.Latitud != null);
            RuleFor(e => e.Foto!).SetValidator(new ValidacionImagen());
        }
    }
}