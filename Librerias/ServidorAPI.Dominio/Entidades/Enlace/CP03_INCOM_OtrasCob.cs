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
//                  CP03_INCOM_OtrasCob: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public partial class CP03_INCOM_OtrasCob
    {
        public string? Prestador { get; set; }
        public decimal? Menores1 { get; set; }
        public decimal? TamizNenoatal { get; set; }
        public decimal? CobTamizNenoatal { get; set; }
        public decimal? SosHipo { get; set; }
        public decimal? SosHiper { get; set; }
        public decimal? SosDefi { get; set; }
        public decimal? SosFenil { get; set; }
        public decimal? SosGalacto { get; set; }
        public decimal? Pob40A49M { get; set; }
        public decimal? Masto40A49 { get; set; }
        public decimal? CobMasto40A49 { get; set; }
        public decimal? SosMasto40A49 { get; set; }
        public decimal? Pob70YMas { get; set; }
        public decimal? Geriatrimss70YMas { get; set; }
        public decimal? CobGeriatrimss70YMas { get; set; }
        public decimal? SosCaidas { get; set; }
        public decimal? SosInmovil { get; set; }
        public decimal? SosCogniti { get; set; }
        public decimal? SosUrinari { get; set; }
        public decimal? TamizNenoatalMes { get; set; }
        public decimal? SosHipoValor { get; set; }
        public decimal? SosHiperValor { get; set; }
        public decimal? SosDefiValor { get; set; }
        public decimal? SosFenilValor { get; set; }
        public decimal? SosGalactoValor { get; set; }
        public decimal? MastoMes40A49 { get; set; }
        public decimal? SosMastoValor40A49 { get; set; }
        public decimal? GeriatrimssMes70YMas { get; set; }
        public decimal? SosCaidasValor { get; set; }
        public decimal? SosInmovilValor { get; set; }
        public decimal? SosCognitiValor { get; set; }
        public decimal? SosUrinariValor { get; set; }
        public string CvePresup { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Periodo { get; set; } = null!;
    }
}