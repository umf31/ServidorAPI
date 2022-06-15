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
//              PU07_PoblacionUsuaria: Creado 15-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Enlace
{
    public partial class PU07_PoblacionUsuaria
    {
        public string CvePresup { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public string Consultorio { get; set; } = null!;
        public short Turno { get; set; }
        public decimal? Ninos09 { get; set; }
        public decimal? Adolescentes1019 { get; set; }
        public decimal? AdultosH2059 { get; set; }
        public decimal? AdultosM2059 { get; set; }
        public decimal? AdultoMayorMas59 { get; set; }
        public decimal? Menores1 { get; set; }
        public decimal? Pob1A { get; set; }
        public decimal? Pob2A { get; set; }
        public decimal? Pob3A { get; set; }
        public decimal? Pob4A { get; set; }
        public decimal? Pob14 { get; set; }
        public decimal? Pob5A { get; set; }
        public decimal? Pob6A { get; set; }
        public decimal? Pob7A { get; set; }
        public decimal? Pob8A { get; set; }
        public decimal? Pob9A { get; set; }
        public decimal? Pob29 { get; set; }
        public decimal? Pob39 { get; set; }
        public decimal? Pob59 { get; set; }
        public decimal? Pob1014 { get; set; }
        public decimal? Pob12A { get; set; }
        public decimal? Pob13A { get; set; }
        public decimal? Pob14A { get; set; }
        public decimal? Pob15A { get; set; }
        public decimal? PobM1519 { get; set; }
        public decimal? PobH1519 { get; set; }
        public decimal? PobM2024 { get; set; }
        public decimal? PobH2024 { get; set; }
        public decimal? PobM2529 { get; set; }
        public decimal? PobH2529 { get; set; }
        public decimal? PobM3034 { get; set; }
        public decimal? PobH3034 { get; set; }
        public decimal? PobM3539 { get; set; }
        public decimal? PobH3539 { get; set; }
        public decimal? PobM4044 { get; set; }
        public decimal? PobH4044 { get; set; }
        public decimal? PobM4549 { get; set; }
        public decimal? PobH4549 { get; set; }
        public decimal? PobM5054 { get; set; }
        public decimal? PobH5054 { get; set; }
        public decimal? PobM5559 { get; set; }
        public decimal? PobH5559 { get; set; }
        public decimal? PobM6064 { get; set; }
        public decimal? PobH6064 { get; set; }
        public decimal? PobM6569 { get; set; }
        public decimal? PobH6569 { get; set; }
        public decimal? PobM7074 { get; set; }
        public decimal? PobH7074 { get; set; }
        public decimal? PobM7579 { get; set; }
        public decimal? PobH7579 { get; set; }
        public decimal? PobM8084 { get; set; }
        public decimal? PobH8084 { get; set; }
        public decimal? PobM85 { get; set; }
        public decimal? PobH85 { get; set; }
        public decimal? PobH2044 { get; set; }
        public decimal? PobM2044 { get; set; }
        public decimal? PobM2559 { get; set; }
        public decimal? PobH3059 { get; set; }
        public decimal? PobM3059 { get; set; }
        public decimal? PobM6065 { get; set; }
        public decimal? PobM6069 { get; set; }
        public decimal? TotalPob { get; set; }
        public string? IdEquipo { get; set; }
        public string? IdUsuario { get; set; }
        public string? IdUsuarioAct { get; set; }
        public decimal? PobM1014 { get; set; }
        public decimal? PobH1014 { get; set; }
    }
}