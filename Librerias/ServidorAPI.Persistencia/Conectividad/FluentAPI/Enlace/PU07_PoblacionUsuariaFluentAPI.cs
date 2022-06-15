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
//           PU07_PoblacionUsuariaFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class PU07_PoblacionUsuariaFluentAPI : IEntityTypeConfiguration<PU07_PoblacionUsuaria>
    {
        public void Configure(EntityTypeBuilder<PU07_PoblacionUsuaria> entity)
        {
            entity.HasKey(e => new { e.CvePresup, e.Periodo, e.Consultorio, e.Turno });
            entity.ToTable("tbPoblacion_Sub14");

            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Consultorio).HasMaxLength(4).IsUnicode(false);
            entity.Property(e => e.Adolescentes1019).HasColumnType("numeric(18, 0)").HasColumnName("Adolescentes_10_19").HasDefaultValueSql("(0)");
            entity.Property(e => e.AdultoMayorMas59).HasColumnType("numeric(18, 0)").HasColumnName("AdultoMayor_Mas_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.AdultosH2059).HasColumnType("numeric(18, 0)").HasColumnName("AdultosH_20_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.AdultosM2059).HasColumnType("numeric(18, 0)").HasColumnName("AdultosM_20_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.IdEquipo).HasMaxLength(15).IsUnicode(false).HasColumnName("Id_Equipo");
            entity.Property(e => e.IdUsuario).HasMaxLength(10).IsUnicode(false).HasColumnName("Id_Usuario");
            entity.Property(e => e.IdUsuarioAct).HasMaxLength(10).IsUnicode(false).HasColumnName("Id_Usuario_Act");
            entity.Property(e => e.Menores1).HasColumnType("numeric(18, 0)").HasColumnName("Menores_1").HasDefaultValueSql("(0)");
            entity.Property(e => e.Ninos09).HasColumnType("numeric(18, 0)").HasColumnName("Ninos_0_9").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob1014).HasColumnType("numeric(18, 0)").HasColumnName("Pob_10_14").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob12A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_12_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob13A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_13_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob14).HasColumnType("numeric(18, 0)").HasColumnName("Pob_1_4").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob14A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_14_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob15A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_15_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob1A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_1_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob29).HasColumnType("numeric(18, 0)").HasColumnName("Pob_2_9").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob2A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_2_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob39).HasColumnType("numeric(18, 0)").HasColumnName("Pob_3_9").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob3A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_3_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob4A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_4_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob59).HasColumnType("numeric(18, 0)").HasColumnName("Pob_5_9").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob5A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_5_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob6A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_6_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob7A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_7_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob8A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_8_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.Pob9A).HasColumnType("numeric(18, 0)").HasColumnName("Pob_9_A").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH1014).HasColumnType("numeric(18, 0)").HasColumnName("PobH_10_14").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH1519).HasColumnType("numeric(18, 0)").HasColumnName("PobH_15_19").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH2024).HasColumnType("numeric(18, 0)").HasColumnName("PobH_20_24").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH2044).HasColumnType("numeric(18, 0)").HasColumnName("PobH_20_44").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH2529).HasColumnType("numeric(18, 0)").HasColumnName("PobH_25_29").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH3034).HasColumnType("numeric(18, 0)").HasColumnName("PobH_30_34").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH3059).HasColumnType("numeric(18, 0)").HasColumnName("PobH_30_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH3539).HasColumnType("numeric(18, 0)").HasColumnName("PobH_35_39").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH4044).HasColumnType("numeric(18, 0)").HasColumnName("PobH_40_44").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH4549).HasColumnType("numeric(18, 0)").HasColumnName("PobH_45_49").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH5054).HasColumnType("numeric(18, 0)").HasColumnName("PobH_50_54").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH5559).HasColumnType("numeric(18, 0)").HasColumnName("PobH_55_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH6064).HasColumnType("numeric(18, 0)").HasColumnName("PobH_60_64").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH6569).HasColumnType("numeric(18, 0)").HasColumnName("PobH_65_69").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH7074).HasColumnType("numeric(18, 0)").HasColumnName("PobH_70_74").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH7579).HasColumnType("numeric(18, 0)").HasColumnName("PobH_75_79").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH8084).HasColumnType("numeric(18, 0)").HasColumnName("PobH_80_84").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobH85).HasColumnType("numeric(18, 0)").HasColumnName("PobH_85_").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM1014).HasColumnType("numeric(18, 0)").HasColumnName("PobM_10_14").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM1519).HasColumnType("numeric(18, 0)").HasColumnName("PobM_15_19").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM2024).HasColumnType("numeric(18, 0)").HasColumnName("PobM_20_24").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM2044).HasColumnType("numeric(18, 0)").HasColumnName("PobM_20_44").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM2529).HasColumnType("numeric(18, 0)").HasColumnName("PobM_25_29").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM2559).HasColumnType("numeric(18, 0)").HasColumnName("PobM_25_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM3034).HasColumnType("numeric(18, 0)").HasColumnName("PobM_30_34").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM3059).HasColumnType("numeric(18, 0)").HasColumnName("PobM_30_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM3539).HasColumnType("numeric(18, 0)").HasColumnName("PobM_35_39").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM4044).HasColumnType("numeric(18, 0)").HasColumnName("PobM_40_44").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM4549).HasColumnType("numeric(18, 0)").HasColumnName("PobM_45_49").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM5054).HasColumnType("numeric(18, 0)").HasColumnName("PobM_50_54").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM5559).HasColumnType("numeric(18, 0)").HasColumnName("PobM_55_59").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM6064).HasColumnType("numeric(18, 0)").HasColumnName("PobM_60_64").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM6065).HasColumnType("numeric(18, 0)").HasColumnName("PobM_60_65").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM6069).HasColumnType("numeric(18, 0)").HasColumnName("PobM_60_69").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM6569).HasColumnType("numeric(18, 0)").HasColumnName("PobM_65_69").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM7074).HasColumnType("numeric(18, 0)").HasColumnName("PobM_70_74").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM7579).HasColumnType("numeric(18, 0)").HasColumnName("PobM_75_79").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM8084).HasColumnType("numeric(18, 0)").HasColumnName("PobM_80_84").HasDefaultValueSql("(0)");
            entity.Property(e => e.PobM85).HasColumnType("numeric(18, 0)").HasColumnName("PobM_85_").HasDefaultValueSql("(0)");
            entity.Property(e => e.TotalPob).HasColumnType("numeric(18, 0)").HasColumnName("Total_Pob").HasDefaultValueSql("(0)");
        }
    }
}