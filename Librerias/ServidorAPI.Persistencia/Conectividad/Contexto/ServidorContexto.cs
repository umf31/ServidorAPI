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
//                  ServidorContexto: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Persistencia.Conectividad.FluentAPI.Servidor;
using ServidorAPI.Persistencia.Conectividad.FluentAPI.Sadim;

namespace ServidorAPI.Persistencia.Conectividad.Contexto
{
    public class ServidorContexto : DbContext
    {
        private readonly SoporteContexto dba = null!;
        public ServidorContexto(SoporteContexto _dba)
        { dba = _dba; }

        public ServidorContexto(DbContextOptions<ServidorContexto> options) : base(options)
        { }

        #region => Servidor
        public DbSet<Status> Status { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<Servicio> Servicios { get; set; } = null!;
        public DbSet<Aplicaciones> Aplicaciones { get; set; } = null!;
        public DbSet<Roles> Roles { get; set; } = null!;
        public DbSet<Pais> Paises { get; set; } = null!;
        public DbSet<Estado> Estados { get; set; } = null!;
        public DbSet<Municipio> Municipios { get; set; } = null!;
        public DbSet<Asentamiento> Asentamientos { get; set; } = null!;
        public DbSet<Colonia> Colonias { get; set; } = null!;
        public DbSet<Delegacion> Delegaciones { get; set; } = null!;
        public DbSet<Vialidad> Vialidades { get; set; } = null!;
        public DbSet<Empleado> Empleados { get; set; } = null!;
        public DbSet<EmpleadoAplicacion> EmpleadoAplicaciones { get; set; } = null!;
        public DbSet<EmpleadoRol> EmpleadoRoles { get; set; } = null!;
        public DbSet<CategoriaServicio> CategoriaServicios { get; set; } = null!;        
        public DbSet<Unidad> Unidades { get; set; } = null!;
        public DbSet<UnidadTipo> UnidadesTipo { get; set; } = null!;

        #endregion

        #region => Sadim

        public DbSet<Proceso> Procesos { get; set; } = null!;
        public DbSet<Periodos> Periodos { get; set; } = null!;
        public DbSet<Detalles> Detalles { get; set; } = null!;
        public DbSet<Meta> Metas { get; set; } = null!;
        public DbSet<Dm01Unidad> Dm01Unidad { get; set; } = null!;
        public DbSet<Dm02Unidad> Dm02Unidad { get; set; } = null!;
        public DbSet<Dm04Unidad> Dm04Unidad { get; set; } = null!;
        public DbSet<Dm05Unidad> Dm05Unidad { get; set; } = null!;
        public DbSet<Eh01Unidad> Eh01Unidad { get; set; } = null!;
        public DbSet<Eh02Unidad> Eh02Unidad { get; set; } = null!;
        public DbSet<Eh04Unidad> Eh04Unidad { get; set; } = null!;
        public DbSet<CaMama01Unidad> CaMama01Unidad { get; set; } = null!;
        public DbSet<CaMama02Unidad> CaMama02Unidad { get; set; } = null!;
        public DbSet<CaMama03Unidad> CaMama03Unidad { get; set; } = null!;
        public DbSet<CaCu01Unidad> CaCu01Unidad { get; set; } = null!;
        public DbSet<Materna01Unidad> Materna01Unidad { get; set; } = null!;
        public DbSet<Materna02Unidad> Materna02Unidad { get; set; } = null!;
        public DbSet<Materna03Unidad> Materna03Unidad { get; set; } = null!;
        public DbSet<Materna04Unidad> Materna04Unidad { get; set; } = null!;
        public DbSet<SOb01Unidad> SOb01Unidad { get; set; } = null!;
        public DbSet<Caispn01Unidad> Caispn01Unidad { get; set; } = null!;
        public DbSet<Caispn02Unidad> Caispn02Unidad { get; set; } = null!;
        public DbSet<Caispn04Unidad> Caispn04Unidad { get; set; } = null!;
        public DbSet<Caispn05Unidad> Caispn05Unidad { get; set; } = null!;
        public DbSet<Caispn08Unidad> Caispn08Unidad { get; set; } = null!;
        public DbSet<Caispn09Unidad> Caispn09Unidad { get; set; } = null!;
        public DbSet<Caispn14Unidad> Caispn14Unidad { get; set; } = null!;

        #endregion

        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuracion = await dba.Unidades.Where(x => x.StatusId == 4).FirstOrDefaultAsync();
            if (configuracion != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server="+configuracion.ServidorAPI+"; Database=DBSadim; User="+configuracion.Usuario+"; Password="+configuracion.Password+";");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region => Servidor

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
            modelBuilder.ApplyConfiguration(new VialidadFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoAplicacionFluentAPI());
            modelBuilder.ApplyConfiguration(new EmpleadoRolFluentAPI());
            modelBuilder.ApplyConfiguration(new CategoriaServicioFluentAPI());
            modelBuilder.ApplyConfiguration(new UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new UnidadTipoFluentAPI());

            #endregion

            #region => Sadim

            modelBuilder.ApplyConfiguration(new DetallesFluentAPI());
            modelBuilder.ApplyConfiguration(new ProcesoFluentAPI());
            modelBuilder.ApplyConfiguration(new PeriodoFluentAPI());
            modelBuilder.ApplyConfiguration(new MetaFluentAPI());
            modelBuilder.ApplyConfiguration(new Dm01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Dm02UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Dm04UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Dm05UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Eh01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Eh02UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Eh04UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new CaMama01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new CaMama02UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new CaMama03UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new CaCu01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Materna01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Materna02UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Materna03UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Materna04UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new SOb01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn01UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn02UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn04UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn05UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn08UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn09UnidadFluentAPI());
            modelBuilder.ApplyConfiguration(new Caispn14UnidadFluentAPI());

            #endregion
        }
    }
}