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
//                  EmpleadoSoporte: Creado 13-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Soporte
{
    public partial class EmpleadoSoporte
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Matricula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int UnidadId { get; set; }
        public string ClavePresupuestal { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public int CategoriaId { get; set; }
        public int ServicioId { get; set; }
        public string? Imagen { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string? CodigoSMS { get; set; }
        public string? Telefono { get; set; }
        public int VialidadId { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public int ColoniaId { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string? Geolocalizacion { get; set; }
        public bool Bloqueo { get; set; }
        public bool Recordar { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioMod { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual CategoriaSoporte Categoria { get; set; } = null!;
        public virtual ServicioSoporte Servicio { get; set; } = null!;
        public virtual ColoniaSoporte Colonia { get; set; } = null!;
        public virtual StatusSoporte Status { get; set; } = null!;
        public virtual UnidadSoporte Unidad { get; set; } = null!;
        public virtual VialidadSoporte Vialidad { get; set; } = null!;
        public virtual List<EmpleadoRolSoporte> Roles { get; set; } = null!;
        public virtual List<EmpleadoAplicacionSoporte> Aplicaciones { get; set; } = null!;
    }
}