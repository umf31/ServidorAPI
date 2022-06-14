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
//                      Status: Creado 13-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Servicios.Servidor;

namespace ServidorAPI.Dominio.Entidades.Servidor
{
    public class Status : EntidadBase
    {
        public virtual ICollection<Asentamiento> Asentamientos { get; set; } = null!;
        public virtual ICollection<Categoria> Categorias { get; set; } = null!;
        public virtual ICollection<Colonia> Colonias { get; set; } = null!;
        public virtual ICollection<Delegacion> Delegaciones { get; set; } = null!;
        public virtual ICollection<Empleado> Empleados { get; set; } = null!;
        public virtual ICollection<Estado> Estados { get; set; } = null!;
        public virtual ICollection<Municipio> Municipios { get; set; } = null!;
        public virtual ICollection<Pais> Paises { get; set; } = null!;
        public virtual ICollection<UnidadTipo> UnidadesTipo { get; set; } = null!;
        public virtual ICollection<Unidad> Unidades { get; set; } = null!;
        public virtual ICollection<Vialidad> Vialidades { get; set; } = null!;
        public virtual ICollection<Periodos> Periodos { get; set; } = null!;
        public virtual ICollection<Proceso> Procesos { get; set; } = null!;
        public virtual ICollection<Detalles> Detalles { get; set; } = null!;
        public virtual ICollection<Meta> Metas { get; set; } = null!;
    }
}