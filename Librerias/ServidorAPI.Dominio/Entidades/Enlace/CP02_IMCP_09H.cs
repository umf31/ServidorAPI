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
//                  CP02_IMCP_09H: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class CP02_IMCP_09H
    {
        public string CvePresup { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Prestador { get; set; } = null!;
        public decimal? AdultosH2059 { get; set; }
        public int? Cartilla2059H { get; set; }
        public decimal? CobCartilla2059H { get; set; }
        public int? PesoYtalla2059H { get; set; }
        public decimal? CobPesoYtalla2059H { get; set; }
        public decimal? CobSobrePeso2059H { get; set; }
        public decimal? CobObesidad2059H { get; set; }
        public decimal? CobObesidadCentral2059H { get; set; }
        public decimal? PobH2039 { get; set; }
        public int? Sr2039H { get; set; }
        public decimal? CobSr2039H { get; set; }
        public decimal? PobH5059 { get; set; }
        public int? Neumo5059H { get; set; }
        public decimal? CobNeumo5059H { get; set; }
        public int? Influenza5059H { get; set; }
        public decimal? CobInfluenza5059H { get; set; }
        public decimal? PobH4559 { get; set; }
        public int? DetDiabetes4559H { get; set; }
        public decimal? CobDetDiabetes4559H { get; set; }
        public decimal? IndSosDiabetes4559H { get; set; }
        public decimal? PobH3059 { get; set; }
        public int? DetHipertension3059H { get; set; }
        public decimal? CobDetHipertension3059H { get; set; }
        public decimal? IndSosHipertension3059H { get; set; }
        public int? DetTb2059H { get; set; }
        public decimal? CobDetTb2059H { get; set; }
        public decimal? IndSosTb2059H { get; set; }
        public int? DetColesterol4559H { get; set; }
        public decimal? CobDetColesterol4559H { get; set; }
        public decimal? IndSosColesterol4559H { get; set; }
        public int? SobrePeso2059H { get; set; }
        public int? Obesidad2059H { get; set; }
        public int? MedicionCintura2059H { get; set; }
        public int? ObesidadCentral2059H { get; set; }
        public int? DiabetesMesSospecha4559H { get; set; }
        public int? DiabetesMes4559H { get; set; }
        public int? HipertensionMesSospecha3059H { get; set; }
        public int? HipertensionMes3059H { get; set; }
        public int? TbMesSospecha2059H { get; set; }
        public int? TbMes2059H { get; set; }
        public int? ColesterolMesSospecha3059H { get; set; }
        public int? ColesterolMes3059H { get; set; }
    }
}