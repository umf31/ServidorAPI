using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using ServidorAPI.Persistencia.Conectividad.Contexto;
using System;
using System.Data.Common;

namespace ServidorAPI.PruebasIntegracion.Utils
{
    public class SimuladorBaseDatos : IDisposable
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public SimuladorBaseDatos()
        {
            string dbName = "ServidorAPI.PruebasIntegracion.Connection.dll";
            Conexion = new SqliteConnection($"Filename={dbName}");
            Seed();
            Conexion.Open();
        }

        public DbConnection Conexion { get; }

        public ServidorContexto CrearContexto(DbTransaction? transaction = null)
        {
            var db = new ServidorContexto(new DbContextOptionsBuilder<ServidorContexto>().UseSqlite(Conexion).Options);

            if (transaction != null)
            {
                db.Database.UseTransaction(transaction);
            }
            return db;
        }

        private void Seed()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var db = CrearContexto())
                    {
                        db.Database.EnsureDeleted();
                        db.Database.EnsureCreated();
                        Alimentador.InyectarStatus(db);
                        Alimentador.InyectarCategorias(db);
                        Alimentador.InyectarServicios(db);
                        Alimentador.InyectarRoles(db);
                        Alimentador.InyectarPaises(db);
                        Alimentador.InyectarEstados(db);
                        Alimentador.InyectarMunicipios(db);
                        Alimentador.InyectarAsentamientos(db);
                        Alimentador.InyectarColonias(db);
                        Alimentador.InyectarDelegaciones(db);
                        Alimentador.InyectarUnidadesTipo(db);
                        Alimentador.InyectarVialidades(db);
                        Alimentador.InyectarUnidad(db);
                        Alimentador.InyectarCategoriaServicios(db);
                        Alimentador.InyectarEmpleados(db);
                        Alimentador.InyectarEmpleadosRol(db);
                        Alimentador.InyectarProcesos(db);
                        Alimentador.InyectarPeriodos(db);
                        Alimentador.InyectarDetalles(db);
                        Alimentador.InyectarMetas(db);
                    }

                    _databaseInitialized = true;
                }
            }
        }

        public void Dispose()
        {
            DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        public async void DisposeAsync(bool disposing)
        {
            if (disposing)
            {
                if (Conexion != null)
                {
                    await Conexion.DisposeAsync();
                }
            }
        }
    }
}