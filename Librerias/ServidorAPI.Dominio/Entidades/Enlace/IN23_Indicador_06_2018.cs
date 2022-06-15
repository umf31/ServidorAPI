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
//                  in23INDICADOR_06IP: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class IN23_Indicador_06_2018
    {
        public string? DescripcionTotal { get; set; }
        public int? TotalDiabeticosTipo2Atendidos { get; set; }
        public int? TotalRegistroPeso { get; set; }
        public decimal? PorcentRegPeso { get; set; }
        public int? TotalRegistroTalla { get; set; }
        public decimal? PorcentRegTalla { get; set; }
        public int? TotalRegistroTension { get; set; }
        public decimal? PorcentRegTension { get; set; }
        public int? TotalDiabeticosTipo2Glucosa { get; set; }
        public int? TotalRegGlucosa140 { get; set; }
        public decimal? PorcentRegGlucosa140 { get; set; }
        public int? TotalRegPies { get; set; }
        public decimal? PorcentRegPies { get; set; }
        public int? TotalRegTension13080 { get; set; }
        public decimal? PorcentRegTension13080 { get; set; }
        public int? PacDm2Glucosa130 { get; set; }
        public decimal? PorcentGlucosa130 { get; set; }
        public int? PacDm2Tension13080 { get; set; }
        public decimal? PorcentTension13080 { get; set; }
        public int? PacDm220ymasAtendidos { get; set; }
        public int? PacDm2Glucosa20ymas { get; set; }
        public decimal? PorcentGlucosa20ymas { get; set; }
        public int? PacDm2Tension20ymas { get; set; }
        public decimal? PorcentTension20ymas { get; set; }
        public int? PacDm2Glucosa13020ymas { get; set; }
        public decimal? PorcentGlucosa13020ymas { get; set; }
        public int? PacDm2Tension1308020ymas { get; set; }
        public decimal? PorcentTension1308020ymas { get; set; }
        public string Delegacion { get; set; } = null!;
        public string CvePresup { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public int Turno { get; set; }
        public string PeriodoInicial { get; set; } = null!;
        public string PeriodoFinal { get; set; } = null!;
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public string? Matricula { get; set; }
    }
}