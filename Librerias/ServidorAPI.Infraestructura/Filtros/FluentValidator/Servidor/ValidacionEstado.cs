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
//                 ValidacionEstado: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Servidor
{
    public class ValidacionEstadoInsertar : AbstractValidator<EstadoInsertar>
    {
        public ValidacionEstadoInsertar()
        {
            RuleFor(x => x.PaisId).Requerido();
            RuleFor(x => x.Nombre).NombreReq().When(x => x.PaisId > 0);
            RuleFor(x => x.Abrev).AbrevReq().When(x => x.Nombre != null);
            RuleFor(x => x.Latitud).Latitud().When(x => x.Longitud != null && x.Abrev != null);
            RuleFor(x => x.Longitud).Longitud().When(x => x.Latitud != null);
            RuleFor(x => x.Descripcion).DescripcionReq().When(x => x.Longitud != null);
            RuleFor(e => e.Foto!).SetValidator(new ValidacionImagen());
        }
    }

    public class ValidacionEstadoEditar : AbstractValidator<EstadoEditar>
    {
        public ValidacionEstadoEditar()
        {
            RuleFor(x => x.PaisId).Requerido().When(x => x.PaisId > 0);
            RuleFor(x => x.Nombre).NombreReq().When(x => x.Nombre != null);
            RuleFor(x => x.Abrev).AbrevReq().When(x => x.Abrev != null);
            RuleFor(x => x.Latitud).Latitud().When(x => x.Longitud != null);
            RuleFor(x => x.Longitud).Longitud().When(x => x.Latitud != null);
            RuleFor(x => x.Descripcion).DescripcionReq().When(x => x.Descripcion != null);
            RuleFor(e => e.Foto!).SetValidator(new ValidacionImagen());
        }
    }
}