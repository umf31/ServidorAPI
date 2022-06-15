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
//                IN16Indicador_05IP: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public class IN22_Indicador_05_2018
    {
        public string? DescripcionTotal { get; set; }
        public int? PacientesHipertensos { get; set; }
        public int? TotalRegistroPeso { get; set; }
        public decimal? PorcentRegPeso { get; set; }
        public int? TotalRegistroTalla { get; set; }
        public decimal? PorcentRegTalla { get; set; }
        public int? TotalRegistroTension { get; set; }
        public decimal? PorcentRegTension { get; set; }
        public int? TotalRegTension14090 { get; set; }
        public decimal? PorcentRegTension14090 { get; set; }
        public int? TotalTension13090 { get; set; }
        public decimal? PorcentTension13090 { get; set; }
        public int? PacHta20ymasAtendidos { get; set; }
        public int? PacHtaTension20ymas { get; set; }
        public decimal? PorcentTension20ymas { get; set; }
        public int? PacHtaTension1409020ymas { get; set; }
        public decimal? PorcentTension1409020ymas { get; set; }
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