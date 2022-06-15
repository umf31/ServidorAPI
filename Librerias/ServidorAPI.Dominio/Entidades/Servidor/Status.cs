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
        public virtual ICollection<Dm01Unidad> Dm01Unidad { get; set; } = null!;
        public virtual ICollection<Dm02Unidad> Dm02Unidad { get; set; } = null!;
        public virtual ICollection<Dm04Unidad> Dm04Unidad { get; set; } = null!;
        public virtual ICollection<Dm05Unidad> Dm05Unidad { get; set; } = null!;
        public virtual ICollection<Eh01Unidad> Eh01Unidad { get; set; } = null!;
        public virtual ICollection<Eh02Unidad> Eh02Unidad { get; set; } = null!;
        public virtual ICollection<Eh04Unidad> Eh04Unidad { get; set; } = null!;
        public virtual ICollection<CaMama01Unidad> CaMama01Unidad { get; set; } = null!;
        public virtual ICollection<CaMama02Unidad> CaMama02Unidad { get; set; } = null!;
        public virtual ICollection<CaMama03Unidad> CaMama03Unidad { get; set; } = null!;
        public virtual ICollection<CaCu01Unidad> CaCu01Unidad { get; set; } = null!;
        public virtual ICollection<Materna01Unidad> Materna01Unidad { get; set; } = null!;
        public virtual ICollection<Materna02Unidad> Materna02Unidad { get; set; } = null!;
        public virtual ICollection<Materna03Unidad> Materna03Unidad { get; set; } = null!;
        public virtual ICollection<Materna04Unidad> Materna04Unidad { get; set; } = null!;
        public virtual ICollection<SOb01Unidad> SOb01Unidad { get; set; } = null!;
        public virtual ICollection<Caispn01Unidad> Caispn01Unidad { get; set; } = null!;
        public virtual ICollection<Caispn02Unidad> Caispn02Unidad { get; set; } = null!;
        public virtual ICollection<Caispn04Unidad> Caispn04Unidad { get; set; } = null!;
        public virtual ICollection<Caispn05Unidad> Caispn05Unidad { get; set; } = null!;
        public virtual ICollection<Caispn08Unidad> Caispn08Unidad { get; set; } = null!;
        public virtual ICollection<Caispn09Unidad> Caispn09Unidad { get; set; } = null!;
        public virtual ICollection<Caispn14Unidad> Caispn14Unidad { get; set; } = null!;
    }
}