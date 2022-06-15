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
//                  CP02_IMCP_08M: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class CP02_IMCP_08M
    {
        public string CvePresup { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Prestador { get; set; } = null!;
        public decimal? AdultosM2059 { get; set; }
        public int? Cartilla2059M { get; set; }
        public decimal? CobCartilla2059M { get; set; }
        public int? PesoYtalla2059M { get; set; }
        public decimal? CobPesoYtalla2059M { get; set; }
        public decimal? CobSobrePeso2059M { get; set; }
        public decimal? CobObesidad2059M { get; set; }
        public decimal? CobObesidadCentral2059M { get; set; }
        public decimal? PobM2039 { get; set; }
        public int? Sr2039M { get; set; }
        public decimal? CobSr2039M { get; set; }
        public decimal? PobM5059 { get; set; }
        public int? Neumo5059M { get; set; }
        public decimal? CobNeumo5059M { get; set; }
        public int? Influenza5059M { get; set; }
        public decimal? CobInfluenza5059M { get; set; }
        public decimal? PobM2564 { get; set; }
        public int? DetCaCu2564 { get; set; }
        public decimal? CobDetCaCu2564 { get; set; }
        public decimal? IndSosCaCu2564 { get; set; }
        public decimal? PobM2569 { get; set; }
        public int? DetCaMama2569 { get; set; }
        public decimal? CobDetCaMama2569 { get; set; }
        public decimal? IndSosCaMama2569 { get; set; }
        public decimal? PobM5069 { get; set; }
        public int? DetMastografia5069 { get; set; }
        public decimal? CobDetMastografia5069 { get; set; }
        public decimal? IndSosMastografia5069 { get; set; }
        public decimal? PobM4559 { get; set; }
        public int? DetDiabetes4559M { get; set; }
        public decimal? CobDetDiabetes4559M { get; set; }
        public decimal? IndSosDiabetes4559M { get; set; }
        public decimal? PobM3059 { get; set; }
        public int? DetHipertension3059M { get; set; }
        public decimal? CobDetHipertension3059M { get; set; }
        public decimal? IndSosHipertension3059M { get; set; }
        public int? DetTb2059M { get; set; }
        public decimal? CobDetTb2059M { get; set; }
        public decimal? IndSosTb2059M { get; set; }
        public int? DetColesterol4559M { get; set; }
        public decimal? CobDetColesterol4559M { get; set; }
        public decimal? IndSosColesterol4559M { get; set; }
        public int? SobrePeso2059M { get; set; }
        public int? Obesidad2059M { get; set; }
        public int? MedicionCintura2059M { get; set; }
        public int? ObesidadCentral2059M { get; set; }
        public int? CaCuMesSospecha2564 { get; set; }
        public int? CaCuMes2564 { get; set; }
        public int? CaMamaMesSospecha2569 { get; set; }
        public int? CaMamaMes2569 { get; set; }
        public int? MastografiaMesSospecha5069 { get; set; }
        public int? MastografiaMes5069 { get; set; }
        public int? DiabetesMesSospecha4559M { get; set; }
        public int? DiabetesMes4559M { get; set; }
        public int? HipertensionMesSospecha3059M { get; set; }
        public int? HipertensionMes3059M { get; set; }
        public int? TbMesSospecha2059M { get; set; }
        public int? TbMes2059M { get; set; }
        public int? ColesterolMesSospecha3059M { get; set; }
        public int? ColesterolMes3059M { get; set; }
    }
}