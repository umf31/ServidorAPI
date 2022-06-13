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
//                  StatusSoporte: Creado 13-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Dominio.Entidades.Soporte
{
    public class StatusSoporte
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public string UsuarioMod { get; set; } = null!;
        public int StatusId { get; set; }

        public virtual ICollection<AsentamientoSoporte> Asentamientos { get; set; } = null!;
        public virtual ICollection<CategoriaSoporte> Categorias { get; set; } = null!;
        public virtual ICollection<ColoniaSoporte> Colonias { get; set; } = null!;
        public virtual ICollection<DelegacionSoporte> Delegaciones { get; set; } = null!;
        public virtual ICollection<EmpleadoSoporte> Empleados { get; set; } = null!;
        public virtual ICollection<EstadoSoporte> Estados { get; set; } = null!;
        public virtual ICollection<MunicipioSoporte> Municipios { get; set; } = null!;
        public virtual ICollection<PaisSoporte> Paises { get; set; } = null!;
        public virtual ICollection<UnidadTipoSoporte> UnidadesTipo { get; set; } = null!;
        public virtual ICollection<UnidadSoporte> Unidades { get; set; } = null!;
        public virtual ICollection<VialidadSoporte> Vialidades { get; set; } = null!;
        public virtual ICollection<PeriodoSoporte> Periodos { get; set; } = null!;
        public virtual ICollection<ProcesoSoporte> Procesos { get; set; } = null!;
        public virtual ICollection<DetalleIndicadorSoporte> DetalleIndicador { get; set; } = null!;
        public virtual ICollection<MetaSoporte> Metas { get; set; } = null!;
        public virtual ICollection<IndicadorSoporte> Indicadores { get; set; } = null!;
    }
}