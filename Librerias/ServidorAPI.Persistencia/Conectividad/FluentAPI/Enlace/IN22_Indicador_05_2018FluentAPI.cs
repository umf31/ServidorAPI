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
//           IN16Indicador_05IPFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class IN22_Indicador_05_2018FluentAPI : IEntityTypeConfiguration<IN22_Indicador_05_2018>
    {
        public void Configure(EntityTypeBuilder<IN22_Indicador_05_2018> entity)
        {
            entity.HasNoKey();
            entity.ToTable("tb_Indicador_05_2018_AtnMedica_UM");

            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Delegacion, e.CvePresup, e.Consultorio, e.Turno }, "IX_tb_Indicador_05_2018_AtnMedica_UM_Indice1");
            entity.HasIndex(e => new { e.PeriodoInicial, e.PeriodoFinal, e.Delegacion, e.CvePresup }, "IX_tb_Indicador_05_2018_AtnMedica_UM_Indice2");
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Delegacion).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.DescripcionTotal).HasMaxLength(250).IsUnicode(false).HasColumnName("Descripcion_Total");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime").HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime").HasColumnName("Fecha_Inicial");
            entity.Property(e => e.Matricula).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.PacHta20ymasAtendidos).HasColumnName("PacHTA_20ymas_Atendidos");
            entity.Property(e => e.PacHtaTension1409020ymas).HasColumnName("PacHTA_Tension14090_20ymas");
            entity.Property(e => e.PacHtaTension20ymas).HasColumnName("PacHTA_Tension_20ymas");
            entity.Property(e => e.PacientesHipertensos).HasColumnName("Pacientes_Hipertensos");
            entity.Property(e => e.PeriodoFinal).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Final");
            entity.Property(e => e.PeriodoInicial).HasMaxLength(6).IsUnicode(false).HasColumnName("Periodo_Inicial");
            entity.Property(e => e.PorcentRegPeso).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Peso");
            entity.Property(e => e.PorcentRegTalla).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Talla");
            entity.Property(e => e.PorcentRegTension).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Tension");
            entity.Property(e => e.PorcentRegTension14090).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Reg_Tension14090");
            entity.Property(e => e.PorcentTension13090).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension13090");
            entity.Property(e => e.PorcentTension1409020ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension14090_20ymas");
            entity.Property(e => e.PorcentTension20ymas).HasColumnType("decimal(10, 2)").HasColumnName("Porcent_Tension_20ymas");
            entity.Property(e => e.TotalRegTension14090).HasColumnName("Total_Reg_Tension14090");
            entity.Property(e => e.TotalRegistroPeso).HasColumnName("Total_Registro_Peso");
            entity.Property(e => e.TotalRegistroTalla).HasColumnName("Total_Registro_Talla");
            entity.Property(e => e.TotalRegistroTension).HasColumnName("Total_Registro_Tension");
            entity.Property(e => e.TotalTension13090).HasColumnName("Total_Tension13090");
        }
    }
}