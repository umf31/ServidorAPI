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
//          Validacion MetodosValidacion: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Persistencia.Informacion;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils
{
    public static class MetodosValidacion
    {
        public static IRuleBuilderOptions<T, string?> AbrevReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_2, FluentValidate.Max.Valor_6).WithMessage(Mensaje.FluentValidator.CaracterMinMax)
                .Matches(FluentValidate.Regex.NoNumeros).WithMessage(Mensaje.FluentValidator.CaracterInvalido);
        }

        public static IRuleBuilderOptions<T, string?> AñoReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Matches(FluentValidate.Regex.Año).WithMessage(Mensaje.FluentValidator.AñoInvalido);
        }

        public static IRuleBuilderOptions<T, string?> CalleReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(0, FluentValidate.Max.Valor_150).WithMessage(Mensaje.FluentValidator.CaracterMax);
        }

        public static IRuleBuilderOptions<T, string?> ClavePresupuestalReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_12, FluentValidate.Max.Valor_12).WithMessage(Mensaje.FluentValidator.CaracterMax);
        }

        public static IRuleBuilderOptions<T, int?> CodigoSMS<T>(this IRuleBuilderInitial<T, int?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .GreaterThan(99999).WithMessage(Mensaje.FluentValidator.CodigoSMS)
                .LessThan(1000000).WithMessage(Mensaje.FluentValidator.CodigoSMS);
        }

        public static IRuleBuilderOptions<T, string?> DescripcionReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_0, FluentValidate.Max.Valor_750).WithMessage(Mensaje.FluentValidator.CaracterMax)
                .Matches(FluentValidate.Regex.NoNumeros).WithMessage(Mensaje.FluentValidator.CaracterInvalido)
                .Matches(FluentValidate.Regex.Nombre).WithMessage(Mensaje.FluentValidator.CaracterInvalido);
        }

        public static IRuleBuilderOptions<T, string?> EmailReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .EmailAddress().WithMessage(Mensaje.FluentValidator.EmailInvalido);
        }

        public static IRuleBuilderOptions<T, decimal?> Latitud<T>(this IRuleBuilderInitial<T, decimal?> regla)
        {
            return regla
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.CoordenadaNoNulo)
                .ScalePrecision(6, 9).WithMessage(Mensaje.FluentValidator.Precision)
                .LessThanOrEqualTo(90).WithMessage(Mensaje.FluentValidator.Latitud)
                .GreaterThanOrEqualTo(-90).WithMessage(Mensaje.FluentValidator.Latitud);
        }

        public static IRuleBuilderOptions<T, decimal?> Longitud<T>(this IRuleBuilderInitial<T, decimal?> regla)
        {
            return regla
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.CoordenadaNoNulo)
                .ScalePrecision(6, 9).WithMessage(Mensaje.FluentValidator.Precision)
                .LessThanOrEqualTo(180).WithMessage(Mensaje.FluentValidator.Longitud)
                .GreaterThanOrEqualTo(-180).WithMessage(Mensaje.FluentValidator.Longitud);
        }

        public static IRuleBuilderOptions<T, string?> MesReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Matches(FluentValidate.Regex.Mes).WithMessage(Mensaje.FluentValidator.MesInvalido);
        }

        public static IRuleBuilderOptions<T, string?> NombreReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_0, FluentValidate.Max.Valor_50).WithMessage(Mensaje.FluentValidator.CaracterMax)
                .Matches(FluentValidate.Regex.NoNumeros).WithMessage(Mensaje.FluentValidator.CaracterInvalido)
                .Matches(FluentValidate.Regex.Nombre).WithMessage(Mensaje.FluentValidator.CaracterInvalido);
        }

        public static IRuleBuilderOptions<T, string?> NumDomicilioReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_0, FluentValidate.Max.Valor_6).WithMessage(Mensaje.FluentValidator.CaracterMax);
        }

        public static IRuleBuilderOptions<T, string?> PasswordReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .MinimumLength(FluentValidate.Min.Valor_5).WithMessage(Mensaje.FluentValidator.CaracterMin);
        }

        public static IRuleBuilderOptions<T, string?> Requerido<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo);
        }

        public static IRuleBuilderOptions<T, int?> Requerido<T>(this IRuleBuilderInitial<T, int?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .GreaterThan(0).WithMessage(Mensaje.FluentValidator.NoNulo);
        }

        public static IRuleBuilderOptions<T, int> Requerido<T>(this IRuleBuilderInitial<T, int> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .GreaterThan(0).WithMessage(Mensaje.FluentValidator.NoNulo);
        }

        public static IRuleBuilderOptions<T, string?> MatriculaReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Matches(FluentValidate.Regex.Numeros).WithMessage(Mensaje.FluentValidator.MatriculaInvalida);
        }

        public static IRuleBuilderOptions<T, string?> TelefonoReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Matches(FluentValidate.Regex.Telefono).WithMessage(Mensaje.FluentValidator.TelefonoInvalido);
        }

        public static IRuleBuilderOptions<T, string?> TituloReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Length(FluentValidate.Min.Valor_0, FluentValidate.Max.Valor_300).WithMessage(Mensaje.FluentValidator.CaracterMax)
                .Matches(FluentValidate.Regex.NoNumeros).WithMessage(Mensaje.FluentValidator.CaracterInvalido)
                .Matches(FluentValidate.Regex.Nombre).WithMessage(Mensaje.FluentValidator.CaracterInvalido);
        }

        public static IRuleBuilderOptions<T, string?> UrlReq<T>(this IRuleBuilderInitial<T, string?> regla)
        {
            return regla.Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage(Mensaje.FluentValidator.NoNulo)
                .Must(UrlValido).WithMessage(Mensaje.FluentValidator.URLInvalido);
        }

        public static IRuleBuilderOptions<T, decimal?> ValorRefenciaReq<T>(this IRuleBuilderInitial<T, decimal?> regla)
        {
            return regla
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage(Mensaje.FluentValidator.NoNulo)
                .ScalePrecision(2, 5).WithMessage(Mensaje.FluentValidator.ReferenciaPresicion)
                .GreaterThan(-100.01M).WithMessage(Mensaje.FluentValidator.ReferenciaPresicion)
                .LessThan(100.01M).WithMessage(Mensaje.FluentValidator.ReferenciaPresicion);
        }

        public static bool UrlValido(string? arg)
        {
            return Uri.TryCreate(arg, UriKind.Absolute, out _);
        }
    }

    public class ValidacionImagen : AbstractValidator<IFormFile>
    {
        public ValidacionImagen()
        {
            RuleFor(x => x.Length / 1024).LessThanOrEqualTo(1024).WithMessage(Mensaje.FluentValidator.ImagenGrande);
            RuleFor(x => x.ContentType)
                .Must(x => x.Equals(TipoArchivo.Jpeg) || x.Equals(TipoArchivo.Jpg) || x.Equals(TipoArchivo.Png))
                .WithMessage(Mensaje.FluentValidator.ImagenTipo);
        }
    }
}