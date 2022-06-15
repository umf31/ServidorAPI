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
//                  CP02_IMCP_10Y: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class CP02_IMCP_10Y
    {
        public string CvePresup { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Prestador { get; set; } = null!;
        public decimal? Adultos60 { get; set; }
        public int? Cartilla60 { get; set; }
        public decimal? CobCartilla60 { get; set; }
        public int? PesoYtalla60 { get; set; }
        public decimal? CobPesoYtalla60 { get; set; }
        public decimal? CobDesnutricion60 { get; set; }
        public decimal? CobSobrePeso60 { get; set; }
        public decimal? CobObesidad60 { get; set; }
        public decimal? CobObesidadCentral60 { get; set; }
        public int? Neumo60 { get; set; }
        public decimal? CobNeumo60 { get; set; }
        public int? Influenza60 { get; set; }
        public decimal? CobInfluenza60 { get; set; }
        public int? DetDiabetes60 { get; set; }
        public decimal? CobDetDiabetes60 { get; set; }
        public decimal? IndSosDiabetes60 { get; set; }
        public int? DetHipertension60 { get; set; }
        public decimal? CobDetHipertension60 { get; set; }
        public decimal? IndSosHipertension60 { get; set; }
        public int? DetTb60H { get; set; }
        public decimal? CobDetTb60H { get; set; }
        public decimal? IndSosTb60 { get; set; }
        public int? DetColesterol60 { get; set; }
        public decimal? CobDetColesterol60 { get; set; }
        public decimal? IndSosColesterol60 { get; set; }
        public int? Desnutricion60 { get; set; }
        public int? SobrePeso60 { get; set; }
        public int? Obesidad60 { get; set; }
        public int? MedicionCintura60 { get; set; }
        public int? ObesidadCentral60 { get; set; }
        public int? DiabetesMesSospecha60 { get; set; }
        public int? DiabetesMes60 { get; set; }
        public int? HipertensionMesSospecha60 { get; set; }
        public int? HipertensionMes60 { get; set; }
        public int? TbMesSospecha60 { get; set; }
        public int? TbMes60 { get; set; }
        public int? ColesterolMesSospecha60 { get; set; }
        public int? ColesterolMes60 { get; set; }
    }
}