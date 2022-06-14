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
//                     Empleado: Creado 13-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Servicios.Servidor;

namespace ServidorAPI.Dominio.Entidades.Servidor
{
    public partial class Empleado : EntidadBase
    {
        public string NombreCompleto => $"{Nombre} {ApellidoPaterno}";
        public string Matricula { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int UnidadId { get; set; }
        public string ClavePresupuestal { get; set; } = null!;
        public string ApellidoPaterno { get; set; } = null!;
        public string? ApellidoMaterno { get; set; }
        public int CategoriaId { get; set; }
        public int ServicioId { get; set; }
        public int VialidadId { get; set; }
        public string Calle { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public int ColoniaId { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string? Geolocalizacion { get; set; }
        public string? Imagen { get; set; }
        public string? CodigoSMS { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public bool Bloqueo { get; set; }
        public bool Recordar { get; set; }
        public bool Activo { get; set; }
        public bool? Soporte { get; set; }

        public virtual Categoria Categoria { get; set; } = null!;
        public virtual Servicio Servicio { get; set; } = null!;
        public virtual Colonia Colonia { get; set; } = null!;
        public virtual Status Status { get; set; } = null!;
        public virtual Unidad Unidad { get; set; } = null!;
        public virtual Vialidad Vialidad { get; set; } = null!;
        public virtual List<EmpleadoRol> Roles { get; set; } = null!;
        public virtual List<EmpleadoAplicacion> Aplicaciones { get; set; } = null!;
    }
}