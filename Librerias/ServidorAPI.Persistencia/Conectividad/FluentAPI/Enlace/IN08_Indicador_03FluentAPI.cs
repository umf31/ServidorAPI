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
//            IN08_Indicador_03FluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class IN08_Indicador_03FluentAPI : IEntityTypeConfiguration<IN08_Indicador_03>
    {
        public void Configure(EntityTypeBuilder<IN08_Indicador_03> entity)
        {
            entity.HasNoKey();
            entity.ToTable("tb_Indicador_03_AtnMedica_UM");
            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Orden, e.Delegacion, e.CvePresup, e.Consultorio, e.Turno }, "IX_tb_Indicador_03_AtnMedica_UM_Indice1");
            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Delegacion, e.CvePresup }, "IX_tb_Indicador_03_AtnMedica_UM_Indice2");

            entity.Property(e => e.CategoriaUnidad).HasMaxLength(1).IsUnicode(false).HasColumnName("Categoria_Unidad");
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Delegacion).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.DescripcionTotal).HasMaxLength(145).IsUnicode(false).HasColumnName("Descripcion_Total");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime").HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime").HasColumnName("Fecha_Inicial");
            entity.Property(e => e.Matricula).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.PeriodoFinal).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Final");
            entity.Property(e => e.PeriodoInicial).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Inicial");
            entity.Property(e => e.PorcentDhPases).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_DH_Pases");
            entity.Property(e => e.PorcentDhReferidos).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_DH_Referidos");
            entity.Property(e => e.PorcentTotalConsultas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Total_Consultas");
            entity.Property(e => e.TotalConsultas).HasColumnName("Total_Consultas");
            entity.Property(e => e.TotalDhReferidos).HasColumnName("Total_DH_Referidos");
            entity.Property(e => e.TotalPasesDh).HasColumnName("Total_Pases_DH");
        }
    }
}