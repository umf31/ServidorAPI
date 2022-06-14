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
//                 EmpleadoFluentAPI: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ServidorAPI.Dominio.Entidades.Servidor;

namespace ServidorAPI.Persistencia.Conectividad.FluentAPI.Servidor
{
    public class EmpleadoFluentAPI : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleados", "catalogo");
            builder.HasIndex(e => e.UnidadId, "IX_Empleados_UnidadId");
            builder.HasIndex(e => e.CategoriaId, "IX_Empleados_CategoriaId");
            builder.HasIndex(e => e.ServicioId, "IX_Empleados_ServicioId");
            builder.HasIndex(e => e.ColoniaId, "IX_Empleados_ColoniaId");
            builder.HasIndex(e => e.StatusId, "IX_Empleados_StatusId");
            builder.HasIndex(e => e.VialidadId, "IX_Empleados_VialidadId");
            builder.HasOne(d => d.Unidad).WithMany(p => p.Empleados).HasForeignKey(d => d.UnidadId);
            builder.HasOne(d => d.Categoria).WithMany(p => p.Empleados).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.CategoriaId);
            builder.HasOne(d => d.Colonia).WithMany(p => p.Empleados).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.ColoniaId);
            builder.HasOne(d => d.Status).WithMany(p => p.Empleados).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.StatusId);
            builder.HasOne(d => d.Vialidad).WithMany(p => p.Empleados).OnDelete(DeleteBehavior.ClientSetNull).HasForeignKey(d => d.VialidadId);
            builder.HasMany(d => d.Roles).WithOne().HasForeignKey(d => d.IdEmpleado).HasConstraintName("FK_Empleado_Roles");
            builder.HasMany(d => d.Aplicaciones).WithOne().HasForeignKey(d => d.IdEmpleado).HasConstraintName("FK_Empleado_Aplicaciones");

            builder.Property(e => e.Id).HasColumnOrder(0);
            builder.Property(e => e.Matricula).HasColumnOrder(1).IsRequired().IsUnicode(false);
            builder.Property(e => e.Email).HasColumnOrder(2).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(e => e.UnidadId).HasColumnOrder(3).IsRequired();
            builder.Property(e => e.ClavePresupuestal).HasColumnOrder(4).IsRequired().HasMaxLength(12).IsUnicode(false);
            builder.Property(e => e.ApellidoPaterno).HasColumnOrder(5).IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.ApellidoMaterno).HasColumnOrder(6).HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.Nombre).HasColumnOrder(7).IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.CategoriaId).HasColumnOrder(8).IsRequired();
            builder.Property(e => e.ServicioId).HasColumnOrder(9).IsRequired();
            builder.Property(e => e.VialidadId).HasColumnOrder(10).IsRequired();
            builder.Property(e => e.Calle).HasColumnOrder(11).IsRequired().IsUnicode(false);
            builder.Property(e => e.Numero).HasColumnOrder(12).IsRequired().HasMaxLength(10).IsUnicode(false);
            builder.Property(e => e.Telefono).HasColumnOrder(13).IsRequired().HasMaxLength(50).IsUnicode(false);
            builder.Property(e => e.ColoniaId).HasColumnOrder(14).IsRequired().IsUnicode(false);
            builder.Property(e => e.Latitud).HasColumnOrder(15).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Longitud).HasColumnOrder(16).HasColumnType("decimal(9, 6)");
            builder.Property(e => e.Geolocalizacion).HasColumnOrder(17).IsUnicode(false);
            builder.Property(e => e.Imagen).HasColumnOrder(18).IsUnicode(false);
            builder.Property(e => e.CodigoSMS).HasColumnOrder(19).IsUnicode(false);
            builder.Property(e => e.PasswordHash).HasColumnOrder(20).IsRequired();
            builder.Property(e => e.PasswordSalt).HasColumnOrder(21).IsRequired();
            builder.Property(e => e.Bloqueo).HasColumnOrder(22);
            builder.Property(e => e.Recordar).HasColumnOrder(23);
            builder.Property(e => e.Activo).HasColumnOrder(24);
            builder.Property(e => e.FechaCreacion).HasColumnOrder(25).HasColumnType("datetime");
            builder.Property(e => e.FechaModificacion).HasColumnOrder(26).HasColumnType("datetime");
            builder.Property(e => e.UsuarioMod).HasColumnOrder(27).IsUnicode(false);
            builder.Ignore(e => e.Soporte);
        }
    }
}