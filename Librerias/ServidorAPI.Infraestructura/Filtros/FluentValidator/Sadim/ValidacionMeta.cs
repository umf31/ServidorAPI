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
//               ValidacionRendimiento: Creado 13-06-2022
//=======================================================================

#endregion

using FluentValidation;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;

namespace ServidorAPI.Infraestructura.Filtros.FluentValidator.Sadim
{
    public class ValidacionMetaInsertar : AbstractValidator<MetaInsertar>
    {
        public ValidacionMetaInsertar()
        {
            RuleFor(x => x.DetallesId).Requerido();
            RuleFor(x => x.PeriodoId).Requerido().When(x => x.DetallesId > 0);
            RuleFor(x => x.RendimientoEsperado).ValorRefenciaReq().When(x => x.PeriodoId > 0);
            RuleFor(x => x.RendimientoBajo).ValorRefenciaReq().When(x => x.RendimientoEsperado != null);
            RuleFor(x => x.RendimientoLimite).ValorRefenciaReq().When(x => x.RendimientoBajo != null);
            RuleFor(x => x.RendimientoMedio).ValorRefenciaReq().When(x => x.RendimientoLimite != null);
            RuleFor(x => x.ValorReferencia).Requerido().When(x => x.RendimientoMedio != null);
        }
    }

    public class ValidacionMetaEditar : AbstractValidator<MetaEditar>
    {
        public ValidacionMetaEditar()
        {
            RuleFor(x => x.DetallesId).Requerido().When(x => x.DetallesId > 0);
            RuleFor(x => x.PeriodoId).Requerido().When(x => x.PeriodoId > 0);
            RuleFor(x => x.RendimientoEsperado).ValorRefenciaReq().When(x => x.RendimientoEsperado > 0);
            RuleFor(x => x.RendimientoBajo).ValorRefenciaReq().When(x => x.RendimientoBajo > 0);
            RuleFor(x => x.RendimientoLimite).ValorRefenciaReq().When(x => x.RendimientoLimite > 0);
            RuleFor(x => x.RendimientoMedio).ValorRefenciaReq().When(x => x.RendimientoMedio > 0);
            RuleFor(x => x.ValorReferencia).Requerido().When(x => x.ValorReferencia != null);
        }
    }
}