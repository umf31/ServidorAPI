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
//           in23INDICADOR_06IPFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class IN23_Indicador_06_2018FluentAPI : IEntityTypeConfiguration<IN23_Indicador_06_2018>
    {
        public void Configure(EntityTypeBuilder<IN23_Indicador_06_2018> entity)
        {
            entity.HasNoKey();

            entity.ToTable("tb_Indicador_06_2018_AtnMedica_UM");
            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Delegacion, e.CvePresup, e.Consultorio, e.Turno }, "IX_tb_Indicador_06_2018_AtnMedica_UM_Indice1");
            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Delegacion, e.CvePresup }, "IX_tb_Indicador_06_2018_AtnMedica_UM_Indice2");

            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Delegacion).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.DescripcionTotal).HasMaxLength(250).IsUnicode(false).HasColumnName("Descripcion_Total");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime").HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime").HasColumnName("Fecha_Inicial");
            entity.Property(e => e.Matricula).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.PacDm220ymasAtendidos).HasColumnName("PacDM2_20ymas_Atendidos");
            entity.Property(e => e.PacDm2Glucosa130).HasColumnName("PacDM2_Glucosa130");
            entity.Property(e => e.PacDm2Glucosa13020ymas).HasColumnName("PacDM2_Glucosa130_20ymas");
            entity.Property(e => e.PacDm2Glucosa20ymas).HasColumnName("PacDM2_Glucosa_20ymas");
            entity.Property(e => e.PacDm2Tension13080).HasColumnName("PacDM2_Tension13080");
            entity.Property(e => e.PacDm2Tension1308020ymas).HasColumnName("PacDM2_Tension13080_20ymas");
            entity.Property(e => e.PacDm2Tension20ymas).HasColumnName("PacDM2_Tension_20ymas");
            entity.Property(e => e.PeriodoFinal).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Final");
            entity.Property(e => e.PeriodoInicial).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Inicial");
            entity.Property(e => e.PorcentGlucosa130).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Glucosa130");
            entity.Property(e => e.PorcentGlucosa13020ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Glucosa130_20ymas");
            entity.Property(e => e.PorcentGlucosa20ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Glucosa_20ymas");
            entity.Property(e => e.PorcentRegGlucosa140).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Glucosa140");
            entity.Property(e => e.PorcentRegPeso).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Peso");
            entity.Property(e => e.PorcentRegPies).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Pies");
            entity.Property(e => e.PorcentRegTalla).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Talla");
            entity.Property(e => e.PorcentRegTension).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Tension");
            entity.Property(e => e.PorcentRegTension13080).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Tension13080");
            entity.Property(e => e.PorcentTension13080).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension13080");
            entity.Property(e => e.PorcentTension1308020ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension13080_20ymas");
            entity.Property(e => e.PorcentTension20ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension_20ymas");
            entity.Property(e => e.TotalDiabeticosTipo2Atendidos).HasColumnName("Total_DiabeticosTipo2_Atendidos");
            entity.Property(e => e.TotalDiabeticosTipo2Glucosa).HasColumnName("Total_DiabeticosTipo2_Glucosa");
            entity.Property(e => e.TotalRegGlucosa140).HasColumnName("Total_Reg_Glucosa140");
            entity.Property(e => e.TotalRegPies).HasColumnName("Total_Reg_Pies");
            entity.Property(e => e.TotalRegTension13080).HasColumnName("Total_Reg_Tension13080");
            entity.Property(e => e.TotalRegistroPeso).HasColumnName("Total_Registro_Peso");
            entity.Property(e => e.TotalRegistroTalla).HasColumnName("Total_Registro_Talla");
            entity.Property(e => e.TotalRegistroTension).HasColumnName("Total_Registro_Tension");
        }
    }
}