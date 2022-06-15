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
//                  CP03_INCOM_CobVac: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public partial class CP03_INCOM_CobVac
    {
        public string Prestador { get; set; } = null!;
        public decimal? OfiMenor1 { get; set; }
        public decimal? Menorde1 { get; set; }
        public decimal? CobMenor1 { get; set; }
        public decimal? Ofide1año { get; set; }
        public decimal? De1año { get; set; }
        public decimal? Cobde1año { get; set; }
        public decimal? Ofide1a4 { get; set; }
        public decimal? De1a4años { get; set; }
        public decimal? Cobde1a4años { get; set; }
        public decimal? Ofide6años { get; set; }
        public decimal? De6años { get; set; }
        public decimal? Cobde6años { get; set; }
        public decimal? Rotavirusde2a11mes { get; set; }
        public decimal? CobRotavirus { get; set; }
        public decimal? Pob5oPrim { get; set; }
        public decimal? DeVph { get; set; }
        public decimal? CobVph { get; set; }
        public decimal? De0a1mes { get; set; }
        public decimal? De2a3mes { get; set; }
        public decimal? De4a5mes { get; set; }
        public decimal? De6a8mes { get; set; }
        public decimal? De9a11mes { get; set; }
        public decimal? De14meses { get; set; }
        public decimal? De23meses { get; set; }
        public decimal? De2años { get; set; }
        public decimal? De3años { get; set; }
        public decimal? De4años { get; set; }
        public string CvePresup { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Periodo { get; set; } = null!;
    }
}