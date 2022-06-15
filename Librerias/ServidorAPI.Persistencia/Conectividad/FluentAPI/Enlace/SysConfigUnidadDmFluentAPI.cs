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
//            SysConfigUnidadDmFluentAPI: Creado 15-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Enlace;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Enlace
{
    public class SysConfigUnidadDmFluentAPI : IEntityTypeConfiguration<SysConfigUnidadDm>
    {
        public void Configure(EntityTypeBuilder<SysConfigUnidadDm> entity)
        {
            entity.HasNoKey();
            entity.ToTable("sysconfigunidadm");

            entity.Property(e => e.AsociadoServicio).HasMaxLength(1).IsUnicode(false).HasColumnName("Asociado_Servicio");
            entity.Property(e => e.CentroCostos).HasMaxLength(250).IsUnicode(false).HasColumnName("Centro_Costos");
            entity.Property(e => e.ControlAutorizacion1).HasMaxLength(100).IsUnicode(false).HasColumnName("Control_Autorizacion1");
            entity.Property(e => e.ControlAutorizacion2).HasMaxLength(100).IsUnicode(false).HasColumnName("Control_Autorizacion2");
            entity.Property(e => e.CveConcepto).HasMaxLength(50).IsUnicode(false).HasColumnName("Cve_Concepto");
            entity.Property(e => e.CvePresup).HasMaxLength(12).IsUnicode(false);
            entity.Property(e => e.DescripcionConcepto).HasMaxLength(250).IsUnicode(false).HasColumnName("Descripcion_Concepto");
            entity.Property(e => e.DescripcionTipoConcepto).HasMaxLength(250).IsUnicode(false).HasColumnName("Descripcion_Tipo_Concepto");
            entity.Property(e => e.Estatus).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime").HasColumnName("Fecha_Actualizacion");
            entity.Property(e => e.FechaAutorizacion).HasColumnType("datetime").HasColumnName("Fecha_Autorizacion");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime").HasColumnName("Fecha_Baja");
            entity.Property(e => e.FechaFinal).HasColumnType("datetime").HasColumnName("Fecha_Final");
            entity.Property(e => e.FechaInicial).HasColumnType("datetime").HasColumnName("Fecha_Inicial");
            entity.Property(e => e.FechaInicioVig).HasColumnType("datetime").HasColumnName("Fecha_Inicio_Vig");
            entity.Property(e => e.FechaMovSistema).HasColumnType("datetime").HasColumnName("Fecha_Mov_Sistema");
            entity.Property(e => e.FechaTerminoVig).HasColumnType("datetime").HasColumnName("Fecha_Termino_Vig");
            entity.Property(e => e.Idestatus).HasMaxLength(2).IsUnicode(false).HasColumnName("IDEstatus");
            entity.Property(e => e.MovimientoAplicado).HasMaxLength(50).IsUnicode(false).HasColumnName("Movimiento_Aplicado");
            entity.Property(e => e.Periodo).HasMaxLength(6).IsUnicode(false);
            entity.Property(e => e.Servicio).HasMaxLength(2).IsUnicode(false);
            entity.Property(e => e.TipoConcepto).HasColumnName("Tipo_Concepto");
            entity.Property(e => e.TotalAtenciones).HasColumnName("Total_Atenciones");
            entity.Property(e => e.ValidacionMovimiento).HasMaxLength(100).IsUnicode(false).HasColumnName("Validacion_Movimiento");
        }
    }
}