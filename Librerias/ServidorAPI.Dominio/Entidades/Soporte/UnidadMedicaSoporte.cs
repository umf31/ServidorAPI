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
//               https://github.com/umf31/ServidorAPI
//                UnidadMedicaSoporte: Creado 13-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Soporte
{
    public partial class UnidadMedicaSoporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int DelegacionId { get; set; }
        public int NumUnidad { get; set; }
        public string Localidad { get; set; } = null!;
        public string ClavePresupuestal { get; set; } = null!;
        public int UnidadTipoId { get; set; }
        public int VialidadId { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Telefono { get; set; }
        public int ColoniaId { get; set; }
        public int MunicipioId { get; set; }
        public string? Imagen { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string? Geolocalizacion { get; set; }
        public string? UrlUnidad { get; set; }
        public string? EmailUnidad { get; set; }
        public string? ServidorMail { get; set; }
        public int PuertoMail { get; set; }
        public string? PasswordMail { get; set; }
        public string? ServidorAPI { get; set; }
        public string DireccionIP { get; set; } = null!;
        public string Usuario { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string LlavePrivada { get; set; } = null!;
        public int? Poblacion { get; set; }
        public int? ConsultoriosMF { get; set; }
        public int? ConsultoriosEG { get; set; }
        public int? ConsultoriosEE { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioMod { get; set; } = null!;
        public int StatusId { get; set; }
    }
}