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
//              ValidacionDetalleIndicador: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Sadim
{
    public class ValidacionDetalleIndicadorInsertar : AbstractValidator<DetallesInsertar>
    {
        public ValidacionDetalleIndicadorInsertar()
        {
            RuleFor(x => x.ProcesoId).Requerido();
            RuleFor(x => x.Nombre).NombreReq().When(x => x.ProcesoId > 0);
            RuleFor(x => x.Descripcion).DescripcionReq().When(x => x.Nombre != null);
            RuleFor(x => x.DescripcionCorta).TituloReq().When(x => x.Descripcion != null);
            RuleFor(x => x.Objetivo).NombreReq().When(x => x.DescripcionCorta != null);
            RuleFor(x => x.NumeradorDescripcion).DescripcionReq().When(x => x.Objetivo != null);
            RuleFor(x => x.DenominadorDescripcion).DescripcionReq().When(x => x.NumeradorDescripcion != null);
            RuleFor(x => x.Multiplicador).Requerido().When(x => x.DenominadorDescripcion != null);
            RuleFor(x => x.Interpretacion).DescripcionReq().When(x => x.Multiplicador > 0);
            RuleFor(x => x.Periocidad).TituloReq().When(x => x.Interpretacion != null);
        }
    }

    public class ValidacionDetalleIndicadorEditar : AbstractValidator<DetallesEditar>
    {
        public ValidacionDetalleIndicadorEditar()
        {
            RuleFor(x => x.ProcesoId).Requerido().When(x => x.ProcesoId > 0);
            RuleFor(x => x.Nombre).NombreReq().When(x => x.Nombre != null);
            RuleFor(x => x.Descripcion).DescripcionReq().When(x => x.Descripcion != null);
            RuleFor(x => x.DescripcionCorta).TituloReq().When(x => x.DescripcionCorta != null);
            RuleFor(x => x.Objetivo).NombreReq().When(x => x.Objetivo != null);
            RuleFor(x => x.NumeradorDescripcion).DescripcionReq().When(x => x.NumeradorDescripcion != null);
            RuleFor(x => x.DenominadorDescripcion).DescripcionReq().When(x => x.DenominadorDescripcion != null);
            RuleFor(x => x.Multiplicador).Requerido().When(x => x.Multiplicador > 0);
            RuleFor(x => x.Interpretacion).DescripcionReq().When(x => x.Interpretacion != null);
            RuleFor(x => x.Periocidad).TituloReq().When(x => x.Periocidad != null);
        }
    }
}