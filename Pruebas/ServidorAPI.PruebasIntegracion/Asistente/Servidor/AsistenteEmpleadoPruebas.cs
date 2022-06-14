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
//              AsistenteEmpleadoPruebas: Creado 14-06-2022
//=======================================================================
#endregion

using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Persistencia.Asistente.Servidor;
using ServidorAPI.PruebasIntegracion.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasIntegracion.Asistente.Servidor
{
    public class AsistenteEmpleadoPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistenteEmpleadoPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region => Pruebas de Integración Empleado AsistenteBase

        [Fact]
        public async Task ObtenerTodo_EmpleadoBase_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ObtenerTodo();
            Assert.Equal(51, entidad.Count());
        }

        [Fact]
        public async Task ObtenerPorId_EmpleadoBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ObtenerPorId(id);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorId_EmpleadoBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(id));
        }

        [Fact]
        public async Task Insertar_EmpleadoBase_SuperaPrueba_InsertaEntidad()
        {
            using (var transaction = Simulador.Conexion.BeginTransaction())
            {
                string password = "sadim";

                Alimentador.CrearPasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                var entidadId = 0;
                var entidadInsertar = new Empleado
                {
                    Nombre = "Empleado 101",
                    Matricula = "10716076",
                    Email = "emailprueba@sadim.com",
                    UnidadId = 1,
                    ClavePresupuestal = "201707215110",
                    ApellidoPaterno = "ApellidoPaterno101",
                    ApellidoMaterno = "ApellidoMaterno101",
                    CategoriaId = 1,
                    ServicioId = 1,
                    Imagen = "",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CodigoSMS = null,
                    Telefono = "(812) 902-5870",
                    VialidadId = 1,
                    Calle = "CallePrueba",
                    Numero = "101",
                    ColoniaId = 1,
                    Latitud = 23.986525M,
                    Longitud = -108.986525M,
                    Geolocalizacion = "",
                    Bloqueo = false,
                    Recordar = false,
                    Activo = false,
                    Soporte = false,
                    FechaCreacion = DateTime.Now,
                    FechaModificacion = DateTime.Now,
                    UsuarioMod = "10716076",
                    StatusId = 1
                };
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteEmpleado(db);

                    await asistente.Insertar(entidadInsertar);
                    await db.SaveChangesAsync();
                    entidadId = entidadInsertar.Id;
                }
                using (var db = Simulador.CrearContexto(transaction))
                {
                    var asistente = new AsistenteEmpleado(db);

                    var entidad = await asistente.ObtenerPorId(entidadId);

                    Assert.NotNull(entidad);
                    Assert.Equal(entidadInsertar.Nombre, entidad.Nombre);
                    Assert.Equal(entidadInsertar.Matricula, entidad.Matricula);
                    Assert.Equal(entidadInsertar.Email, entidad.Email);
                    Assert.Equal(entidadInsertar.UnidadId, entidad.UnidadId);
                    Assert.Equal(entidadInsertar.ClavePresupuestal, entidad.ClavePresupuestal);
                    Assert.Equal(entidadInsertar.ApellidoPaterno, entidad.ApellidoPaterno);
                    Assert.Equal(entidadInsertar.ApellidoMaterno, entidad.ApellidoMaterno);
                    Assert.Equal(entidadInsertar.CategoriaId, entidad.CategoriaId);
                    Assert.Equal(entidadInsertar.ServicioId, entidad.ServicioId);
                    Assert.Equal(entidadInsertar.Imagen, entidad.Imagen);
                    Assert.Equal(entidadInsertar.CodigoSMS, entidad.CodigoSMS);
                    Assert.Equal(entidadInsertar.Telefono, entidad.Telefono);
                    Assert.Equal(entidadInsertar.VialidadId, entidad.VialidadId);
                    Assert.Equal(entidadInsertar.Calle, entidad.Calle);
                    Assert.Equal(entidadInsertar.Numero, entidad.Numero);
                    Assert.Equal(entidadInsertar.ColoniaId, entidad.ColoniaId);
                    Assert.Equal(entidadInsertar.Latitud, entidad.Latitud);
                    Assert.Equal(entidadInsertar.Longitud, entidad.Longitud);
                    Assert.Equal(entidadInsertar.Geolocalizacion, entidad.Geolocalizacion);
                    Assert.Equal(entidadInsertar.FechaCreacion, entidad.FechaCreacion);
                    Assert.Equal(entidadInsertar.FechaModificacion, entidad.FechaModificacion);
                    Assert.Equal(entidadInsertar.UsuarioMod, entidad.UsuarioMod);
                    Assert.Equal(entidadInsertar.StatusId, entidad.StatusId);
                }
            }
        }

        [Fact]
        public async Task Actualizar_EmpleadoBase_SuperaPrueba_ActualizaEstado()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var matricula = "10716076";

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);

                await asistente.Actualizar(entidadId, matricula);
                await db.SaveChangesAsync();
                entidadId = 1;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(2, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Editar_EmpleadoBase_SuperaPrueba_EditaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var entidadEditar = new Empleado();
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);

                entidadEditar = await asistente.ObtenerPorId(entidadId);
                entidadEditar.Nombre = "Editar 101";
                db.Update(entidadEditar);
                await db.SaveChangesAsync();
            }

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadEditar.Nombre, entidad.Nombre);
            }
        }

        [Fact]
        public async Task Eliminar_EmpleadoBase_SuperaPrueba_EliminaCuentaMaestra()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "SadimMaster";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);
                if (empleadoRol == "SadimMaster")
                {
                    await asistente.Eliminar(entidadId);
                    await db.SaveChangesAsync();
                }
                else
                {
                    await asistente.Actualizar(entidadId, matricula);
                    await db.SaveChangesAsync();
                    entidadId = 1;
                }
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_EmpleadoBase_SuperaPrueba_ActualizaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 51;
            var matricula = "10716076";
            var empleadoRol = "Directivo";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);
                if (empleadoRol == "Directivo")
                {
                    await asistente.Eliminar(entidadId);
                    await db.SaveChangesAsync();
                }
                else
                {
                    await asistente.Actualizar(entidadId, matricula);
                    await db.SaveChangesAsync();
                    entidadId = 1;
                }
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistenteEmpleado(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_EmpleadoBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.Eliminar(id));
        }

        [Fact]
        public async Task ExisteEntidadPorId_EmpleadoBase_SuperaPrueba_SiExisteEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ExisteEntidadPorId(entidadId);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteEntidadPorNombre_EmpleadoBase_SuperaPrueba_SiExisteEntidad()
        {
            var nombre = "Empleado 1";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ExisteEntidadPorNombre(nombre);
            Assert.True(entidad != false);
        }

        #endregion

        #region=> Pruebas de Integración AsistenteEmpleado

        [Fact]
        public async Task ObtenerTodoFiltros_AsistenteEmpleado_SuperaPrueba_SiRetornaDatosFiltrados()
        {
            int unidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ObtenerTodoFiltros(unidadId);
            foreach (var items in entidad)
            {
                Assert.True(items.Colonia != null);
                Assert.True(items.Categoria != null);
                Assert.True(items.Roles != null);
            }
        }

        [Fact]
        public async Task ObtenerPorMatricula_AsistenteEmpleado_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            string matricula = "10716076";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ObtenerPorMatricula(matricula);
            Assert.Equal(entidad.Matricula, matricula);
        }

        [Fact]
        public async Task ObtenerPorEmail_AsistenteEmpleado_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            string matricula = "10716076";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);
            var email = await asistente.ObtenerPorMatricula(matricula);
            var entidad = await asistente.ObtenerPorEmail(email.Email);

            Assert.Equal(entidad.Email, email.Email);
        }

        [Fact]
        public async Task ObtenerPorIdPorUnidad_AsistenteEmpleado_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            int empleadoId = 1;
            int unidadId = 1;
            var asistente = new AsistenteEmpleado(db);
            var entidad = await asistente.ObtenerPorIdPorUnidad(empleadoId, unidadId);

            Assert.Equal(entidad.Id, empleadoId);
            Assert.Equal(entidad.UnidadId, unidadId);
        }

        [Fact]
        public async Task ObtenerPorIdPorUnidad_AsistenteEmpleado_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var empleadoId = 52;
            int unidadId = 61;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorIdPorUnidad(empleadoId, unidadId));
        }

        [Fact]
        public async Task ObtenerPorIdRoles_AsistenteEmpleado_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.ObtenerPorIdRoles(id);

            Assert.True(entidad.Roles != null);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorIdRoles_AsistenteEmpleado_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var empleadoId = 52;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorIdRoles(empleadoId));
        }

        [Fact]
        public async Task BloquearEmpleado_AsistenteEmpleado_SuperaPrueba_SiBloqueaEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.BloquearEmpleado(entidadId);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task BloquearEmpleado_AsistenteEmpleado_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var empleadoId = 52;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.BloquearEmpleado(empleadoId));
        }

        [Fact]
        public async Task DesbloquearEmpleado_AsistenteEmpleado_SuperaPrueba_SiBloqueaEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);

            var entidad = await asistente.DesbloquearEmpleado(entidadId);
            Assert.True(entidad != false);
        }

        [Fact]
        public async Task DesbloquearEmpleado_AsistenteEmpleado_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var empleadoId = 52;
            var asistente = new AsistenteEmpleado(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.DesbloquearEmpleado(empleadoId));
        }

        [Fact]
        public async Task ExisteEmpleado_AsistenteEmpleado_SuperaPrueba_SiExisteEntidad()
        {
            string matricula = "10716076";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);
            var usuario = await asistente.ObtenerPorMatricula(matricula);
            var entidad = await asistente.ExisteEmpleado(matricula, usuario.Email);

            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteEmpleadoPorMatricula_AsistenteEmpleado_SuperaPrueba_SiExisteEntidad()
        {
            string matricula = "10716076";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);
            var entidad = await asistente.ExisteEmpleadoPorMatricula(matricula);

            Assert.True(entidad != false);
        }

        [Fact]
        public async Task ExisteEmpleadoPorEmail_AsistenteEmpleado_SuperaPrueba_SiExisteEntidad()
        {
            string matricula = "10716076";
            using var db = Simulador.CrearContexto();
            var asistente = new AsistenteEmpleado(db);
            var usuario = await asistente.ObtenerPorMatricula(matricula);
            var entidad = await asistente.ExisteEmpleadoPorEmail(usuario.Email);

            Assert.True(entidad != false);
        }

        #endregion
    }
}