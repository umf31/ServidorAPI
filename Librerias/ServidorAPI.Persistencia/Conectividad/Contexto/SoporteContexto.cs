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
//                  SoporteContexto: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Soporte;
using ServidorAPI.Persistencia.Conectividad.FluentAPI.Soporte;

namespace ServidorAPI.Persistencia.Conectividad.Contexto
{
    public class SoporteContexto : DbContext
    {
        public SoporteContexto()
        { }

        public SoporteContexto(DbContextOptions<SoporteContexto> options) : base(options)
        { }

        public DbSet<StatusSoporte> Status { get; set; } = null!;
        public DbSet<CategoriaSoporte> Categorias { get; set; } = null!;
        public DbSet<ServicioSoporte> Servicios { get; set; } = null!;
        public DbSet<AplicacionesSoporte> Aplicaciones { get; set; } = null!;
        public DbSet<RolesSoporte> Roles { get; set; } = null!;
        public DbSet<PaisSoporte> Paises { get; set; } = null!;
        public DbSet<EstadoSoporte> Estados { get; set; } = null!;
        public DbSet<MunicipioSoporte> Municipios { get; set; } = null!;
        public DbSet<AsentamientoSoporte> Asentamientos { get; set; } = null!;
        public DbSet<ColoniaSoporte> Colonias { get; set; } = null!;
        public DbSet<DelegacionSoporte> Delegaciones { get; set; } = null!;
        public DbSet<UnidadTipoSoporte> UnidadesTipo { get; set; } = null!;
        public DbSet<VialidadSoporte> Vialidades { get; set; } = null!;
        public DbSet<UnidadMedicaSoporte> UnidadesMedicas { get; set; } = null!;
        public DbSet<UnidadSoporte> Unidades { get; set; } = null!;
        public DbSet<EmpleadoSoporte> Empleados { get; set; } = null!;
        public DbSet<EmpleadoAplicacionSoporte> EmpleadoAplicaciones { get; set; } = null!;
        public DbSet<EmpleadoRolSoporte> EmpleadoRoles { get; set; } = null!;
        public DbSet<CategoriaServicioSoporte> CategoriaServicios { get; set; } = null!;
        public DbSet<ProcesoSoporte> Procesos { get; set; } = null!;
        public DbSet<PeriodoSoporte> Periodos { get; set; } = null!;
        public DbSet<DetallesSoporte> Detalles { get; set; } = null!;
        public DbSet<MetaSoporte> Metas { get; set; } = null!;
        public DbSet<MensajeriaSoporte> Mensajeria { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Filename=.\\bin\\Debug\\net6.0\\ServidorAPI.Soporte.dll");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StatusFluentAPI());
            modelBuilder.ApplyConfiguration(new CategoriaFluentAPI());
            modelBuilder.ApplyConfiguration(new ServicioFluentAPI());
            modelBuilder.ApplyConfiguration(new AplicacionesFluentAPI());
            modelBuilder.ApplyConfiguration(new RolesFluentAPI());
            modelBuilder.ApplyConfiguration(new PaisFluentAPI());
            modelBuilder.ApplyConfiguration(new EstadoFluentAPI());
            modelBuilder.ApplyConfiguration(new MunicipioFluentAPI());
            modelBuilder.ApplyConfiguration(new AsentamientoFluentAPI());
            modelBuilder.ApplyConfiguration(new ColoniaFluentAPI());
            modelBuilder.ApplyConfiguration(new DelegacionFluentAPI());
            modelBuilder.ApplyConfiguration(new UnidadTipoFluentAPI());
            modelBuilder.ApplyConfiguration(new VialidadFluentAPI());
            modelBuilder.ApplyConfiguration(new UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new UnidadMedicaFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoAplicacionFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoRolFluentAPI());
            modelBuilder.ApplyConfiguration(new CategoriaServicioFluentAPI());
            modelBuilder.ApplyConfiguration(new ProcesoFluentAPI());
            modelBuilder.ApplyConfiguration(new PeriodoFluentAPI());
            modelBuilder.ApplyConfiguration(new DetallesFluentAPI());
            modelBuilder.ApplyConfiguration(new MetaFluentAPI());
            modelBuilder.ApplyConfiguration(new MensajeriaFluentAPI());
        }
    }
}