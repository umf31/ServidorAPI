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
//                 CP03_INComplDMHTA: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class CP03_INCOM_DMHTA
    {
        public string? Prestador { get; set; }
        public decimal? Pob20A44M { get; set; }
        public decimal? Diabetes20A44M { get; set; }
        public decimal? CobDiabetes20A44M { get; set; }
        public decimal? SosDiabetes20A44M { get; set; }
        public decimal? Pob20A44H { get; set; }
        public decimal? Diabetes20A44H { get; set; }
        public decimal? CobDiabetes20A44H { get; set; }
        public decimal? SosDiabetes20A44H { get; set; }
        public decimal? Pob20YMas { get; set; }
        public decimal? Diabetes20YMas { get; set; }
        public decimal? CobDiabetes20YMas { get; set; }
        public decimal? Pob20A29M { get; set; }
        public decimal? Hipertension20A29M { get; set; }
        public decimal? CobHipertension20A29M { get; set; }
        public decimal? SosHipertension20A29M { get; set; }
        public decimal? Pob20A29H { get; set; }
        public decimal? Hipertension20A29H { get; set; }
        public decimal? CobHipertension20A29H { get; set; }
        public decimal? SosHipertension20A29H { get; set; }
        public decimal? Hipertension20YMas { get; set; }
        public decimal? CobHipertension20YMas { get; set; }
        public decimal? Colesterol20A44M { get; set; }
        public decimal? PobM2044 { get; set; }
        public decimal? CobColesterol20A44M { get; set; }
        public decimal? SosColesterol20A44M { get; set; }
        public decimal? PobH2044 { get; set; }
        public decimal? Colesterol20A44H { get; set; }
        public decimal? CobColesterol20A44H { get; set; }
        public decimal? SosColesterol20A44H { get; set; }
        public decimal? Pob45A74 { get; set; }
        public decimal? Colesterol45A74 { get; set; }
        public decimal? CobColesterol45A74 { get; set; }
        public decimal? SosColesterol45A74 { get; set; }
        public decimal? DiabetesMes20A44M { get; set; }
        public decimal? DiabetesMesSospecha20A44M { get; set; }
        public decimal? DiabetesMes20A44H { get; set; }
        public decimal? DiabetesMesSospecha20A44H { get; set; }
        public decimal? HipertensionMes20A29M { get; set; }
        public decimal? HipertensionMesSospecha20A29M { get; set; }
        public decimal? HipertensionMes20A29H { get; set; }
        public decimal? HipertensionMesSospecha20A29H { get; set; }
        public decimal? ColesterolMes20A44M { get; set; }
        public decimal? ColesterolMesSospecha20A44M { get; set; }
        public decimal? ColesterolMes20A44H { get; set; }
        public decimal? ColesterolMesSospecha20A44H { get; set; }
        public decimal? ColesterolMes45A74 { get; set; }
        public decimal? ColesterolMesSospecha45A74 { get; set; }
        public string CvePresup { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public string Periodo { get; set; } = null!;
        public decimal? Diabetes20YMas2 { get; set; }
        public decimal? Hipertension20YMas2 { get; set; }
    }
}