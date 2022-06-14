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
//              AsistentePeriodoPruebas: Creado 14-06-2022
//=======================================================================
#endregion

using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Persistencia.Asistente.Sadim;
using ServidorAPI.PruebasIntegracion.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasIntegracion.Asistente.Sadim
{
    public class AsistentePeriodoPruebas : IClassFixture<SimuladorBaseDatos>
    {
        private SimuladorBaseDatos Simulador { get; }

        public AsistentePeriodoPruebas(SimuladorBaseDatos simulador)
        {
            Simulador = simulador;
        }

        #region => Pruebas de Integración Periodo AsistenteBase

        [Fact]
        public async Task ObtenerTodo_PeriodoBase_SuperaPrueba_SiRetornaTodosLosDatos()
        {
            using var db = Simulador.CrearContexto();
            var asistente = new AsistentePeriodo(db);

            var entidad = await asistente.ObtenerTodo();
            Assert.Equal(3, entidad.Count());
        }

        [Fact]
        public async Task ObtenerPorId_PeriodoBase_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            var id = 1;
            var asistente = new AsistentePeriodo(db);

            var entidad = await asistente.ObtenerPorId(id);
            Assert.Equal(entidad.Id, id);
        }

        [Fact]
        public async Task ObtenerPorId_PeriodoBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 52;
            var asistente = new AsistentePeriodo(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(id));
        }

        [Fact]
        public async Task Insertar_PeriodoBase_SuperaPrueba_InsertaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 0;
            var entidadInsertar = new Periodos
            {
                Periodo = "202212",
                Año = "2022",
                Mes = "12",
                MesAbrev = "Dic",
                Nombre = "Dic22",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "10716076",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                await asistente.Insertar(entidadInsertar);
                await db.SaveChangesAsync();
                entidadId = entidadInsertar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadInsertar.Periodo, entidad.Periodo);
                Assert.Equal(entidadInsertar.Mes, entidad.Mes);
                Assert.Equal(entidadInsertar.Año, entidad.Año);
                Assert.Equal(entidadInsertar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadInsertar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadInsertar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadInsertar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Actualizar_PeriodoBase_SuperaPrueba_ActualizaEstado()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var matricula = "10716076";

            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                await asistente.Actualizar(entidadId, matricula);
                await db.SaveChangesAsync();
                entidadId = 1;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(2, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Editar_PeriodoBase_SuperaPrueba_EditaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 1;
            var entidadEditar = new Periodos
            {
                Periodo = "202211",
                Año = "2022",
                Mes = "11",
                MesAbrev = "Nov",
                Nombre = "Nov22",
                FechaCreacion = DateTime.Now,
                FechaModificacion = DateTime.Now,
                UsuarioMod = "10716076",
                StatusId = 1
            };
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                await asistente.Editar(entidadEditar);
                await db.SaveChangesAsync();
                entidadId = entidadEditar.Id;
            }
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);

                var entidad = await asistente.ObtenerPorId(entidadId);

                Assert.NotNull(entidad);
                Assert.Equal(entidadEditar.Periodo, entidad.Periodo);
                Assert.Equal(entidadEditar.Mes, entidad.Mes);
                Assert.Equal(entidadEditar.Año, entidad.Año);
                Assert.Equal(entidadEditar.FechaCreacion, entidad.FechaCreacion);
                Assert.Equal(entidadEditar.FechaModificacion, entidad.FechaModificacion);
                Assert.Equal(entidadEditar.UsuarioMod, entidad.UsuarioMod);
                Assert.Equal(entidadEditar.StatusId, entidad.StatusId);
            }
        }

        [Fact]
        public async Task Eliminar_PeriodoBase_SuperaPrueba_EliminaCuentaMaestra()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 3;
            var matricula = "10716076";
            var empleadoRol = "SadimMaster";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);
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
                var asistente = new AsistentePeriodo(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_PeriodoBase_SuperaPrueba_ActualizaEntidad()
        {
            using var transaction = Simulador.Conexion.BeginTransaction();
            var entidadId = 3;
            var matricula = "10716076";
            var empleadoRol = "Directivo";
            using (var db = Simulador.CrearContexto(transaction))
            {
                var asistente = new AsistentePeriodo(db);
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
                var asistente = new AsistentePeriodo(db);
                await Assert.ThrowsAsync<NotFound>(() => asistente.ObtenerPorId(entidadId));
            }
        }

        [Fact]
        public async Task Eliminar_PeriodoBase_SuperaPrueba_LanzaExcepcionNotFound()
        {
            using var db = Simulador.CrearContexto();
            var id = 150;
            var asistente = new AsistentePeriodo(db);
            await Assert.ThrowsAsync<NotFound>(() => asistente.Eliminar(id));
        }

        [Fact]
        public async Task ExisteEntidadPorId_PeriodoBase_SuperaPrueba_SiExisteEntidad()
        {
            var entidadId = 1;
            using var db = Simulador.CrearContexto();
            var asistente = new AsistentePeriodo(db);

            var entidad = await asistente.ExisteEntidadPorId(entidadId);
            Assert.True(entidad != false);
        }

        #endregion

        #region=> Pruebas de Integración AsistentePeriodo

        [Fact]
        public async Task ObtenerPeriodo_AsistentePeriodo_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            string Mes = "10";
            string Año = "2021";

            var asistente = new AsistentePeriodo(db);

            var entidad = await asistente.ObtenerPeriodo(Mes, Año);
            Assert.Equal(entidad.Año, Año);
            Assert.Equal(entidad.Mes, Mes);
        }

        [Fact]
        public async Task ObtenerPorPeriodo_AsistentePeriodo_SuperaPrueba_SiRetornaElementoSeleccionado()
        {
            using var db = Simulador.CrearContexto();
            string Periodo = "202110";

            var asistente = new AsistentePeriodo(db);

            var entidad = await asistente.ObtenerPorPeriodo(Periodo);
            Assert.Equal(entidad.Periodo, Periodo);
        }

        [Fact]
        public async Task ExistePeriodoPorMesAño_AsistentPeriodo_SuperaPrueba_SiExisteEntidad()
        {
            using var db = Simulador.CrearContexto();
            string Mes = "10";
            string Año = "2021";
            var asistente = new AsistentePeriodo(db);
            var entidad = await asistente.ExistePeriodoPorMesAño(Mes, Año);

            Assert.True(entidad != false);
        }

        #endregion
    }
}