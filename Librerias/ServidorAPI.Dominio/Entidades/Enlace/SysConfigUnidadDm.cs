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
//                 SysConfigUnidad: Creado 20-05-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class SysConfigUnidadDm
    {
        public string CvePresup { get; set; } = null!;
        public string? Periodo { get; set; }
        public DateTime? FechaInicial { get; set; }
        public DateTime? FechaFinal { get; set; }
        public short Division { get; set; }
        public string Servicio { get; set; } = null!;
        public long? TotalAtenciones { get; set; }
        public string? CveConcepto { get; set; }
        public string? DescripcionConcepto { get; set; }
        public int? TipoConcepto { get; set; }
        public string? DescripcionTipoConcepto { get; set; }
        public string? AsociadoServicio { get; set; }
        public DateTime? FechaAutorizacion { get; set; }
        public DateTime? FechaInicioVig { get; set; }
        public DateTime? FechaTerminoVig { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string? Estatus { get; set; }
        public string? MovimientoAplicado { get; set; }
        public string? CentroCostos { get; set; }
        public DateTime? FechaMovSistema { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? ControlAutorizacion1 { get; set; }
        public string? ControlAutorizacion2 { get; set; }
        public string? Idestatus { get; set; }
        public string? ValidacionMovimiento { get; set; }
    }
}