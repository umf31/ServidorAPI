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
//                  SadimContexto: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Enlace;
using ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.Contexto
{
    public class SadimContexto : DbContext
    {
        private readonly SoporteContexto dba = null!;

        public SadimContexto(SoporteContexto _dba)
        {
            dba = _dba;
        }

        public SadimContexto(DbContextOptions<SadimContexto> options) : base(options)
        { }
        public DbSet<CIP01_PrevenIMSS> CIP01_PrevenIMSS { get; set; } = null!;
        public DbSet<CP02_IMCP_08M> CP02_IMCP_08M { get; set; } = null!;
        public DbSet<CP02_IMCP_09H> CP02_IMCP_09H { get; set; } = null!;
        public DbSet<CP02_IMCP_10Y> CP02_IMCP_10Y { get; set; } = null!;
        public DbSet<CP03_INCOM_CobVac> CP03_INCOM_CobVac { get; set; } = null!;
        public DbSet<CP03_INCOM_DMHTA> CP03_INCOM_DMHTA { get; set; } = null!;
        public DbSet<CP03_INCOM_OtrasCob> CP03_INCOM_OtrasCob { get; set; } = null!;
        public DbSet<CP04_IMCP20> CP04_IMCP20 { get; set; } = null!;
        public DbSet<IAP01_ProductividadAPI> IAP01_ProductividadAPI { get; set; } = null!;
        public DbSet<IAP01_ProductividadAPI_EEMF> IAP01_ProductividadAPI_EEMF { get; set; } = null!;
        public DbSet<IN08_Indicador_03> IN08_Indicador_03 { get; set; } = null!;
        public DbSet<IN22_Indicador_05_2018> IN22_Indicador_05_2018 { get; set; } = null!;
        public DbSet<IN23_Indicador_06_2018> IN23_Indicador_06_2018 { get; set; } = null!;
        public DbSet<MT01_Materna> MT01_Materna { get; set; } = null!;
        public DbSet<MT03_VigilanciaMaterna> MT03_VigilanciaMaterna { get; set; } = null!;
        public DbSet<PU01_ParteUno> PU01_ParteUno { get; set; } = null!;
        public DbSet<PU07_PoblacionUsuaria> PU07_PoblacionUsuaria { get; set; } = null!;
        public DbSet<SysConfigUnidadDm> SysConfigUnidadDm { get; set; } = null!;

        protected override async void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuracion = await dba.Unidades.Where(x => x.StatusId == 4).FirstOrDefaultAsync();
            if (configuracion != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Server="+configuracion.DireccionIP+"; Database=DBSIAIS; User="+configuracion.Usuario+"; Password="+configuracion.Password+";");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CIP01_PrevenIMSSFluentAPI());
            modelBuilder.ApplyConfiguration(new CP02_IMCP_08MFluentAPI());
            modelBuilder.ApplyConfiguration(new CP02_IMCP_09HFluentAPI());
            modelBuilder.ApplyConfiguration(new CP02_IMCP_10YFluentAPI());
            modelBuilder.ApplyConfiguration(new CP03_INCOM_CobVacFluentAPI());
            modelBuilder.ApplyConfiguration(new CP03_INCOM_DMHTAFluentAPI());
            modelBuilder.ApplyConfiguration(new CP03_INCOM_OtrasCobFluentAPI());
            modelBuilder.ApplyConfiguration(new CP04_IMCP20FluentAPI());
            modelBuilder.ApplyConfiguration(new IAP01_ProductividadAPIFluentAPI());
            modelBuilder.ApplyConfiguration(new IAP01_ProductividadAPI_EEMFFluentAPI());
            modelBuilder.ApplyConfiguration(new IN08_Indicador_03FluentAPI());
            modelBuilder.ApplyConfiguration(new IN22_Indicador_05_2018FluentAPI());
            modelBuilder.ApplyConfiguration(new IN23_Indicador_06_2018FluentAPI());
            modelBuilder.ApplyConfiguration(new MT01_MaternaFluentAPI());
            modelBuilder.ApplyConfiguration(new MT03_VigilanciaMaternaFluentAPI());
            modelBuilder.ApplyConfiguration(new PU01_ParteUnoFluentAPI());
            modelBuilder.ApplyConfiguration(new PU07_PoblacionUsuariaFluentAPI());
            modelBuilder.ApplyConfiguration(new SysConfigUnidadDmFluentAPI());
        }
    }
}