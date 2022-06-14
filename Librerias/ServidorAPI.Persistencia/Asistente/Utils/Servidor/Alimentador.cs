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
//               AsistenteAlimentador: Creado 13-06-2022
//=======================================================================

#endregion

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Interfaces.Utils.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Utils.Servidor
{
    public class Alimentador : IAlimentador
    {
        private readonly IMapper mapper;
        private readonly ServidorContexto db;
        private readonly SoporteContexto dba;

        public Alimentador(IMapper _mapper, ServidorContexto _db, SoporteContexto _dba)
        {
            mapper = _mapper;
            db = _db;
            dba = _dba;
        }

        public async Task CrearSadimDb()
        {
            await db.Database.EnsureCreatedAsync();
        }

        #region => Inyectar Base de Datos

        public async Task InyectarAsentamientos()
        {
            if (!db.Asentamientos.Any())
            {
                var entidad = dba.Asentamientos.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Asentamiento>>(entidad));
            }
        }

        public async Task InyectarCategorias()
        {
            if (!db.Categorias.Any())
            {
                var entidad = dba.Categorias.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Categoria>>(entidad));
            }
        }

        public async Task InyectarCategoriaServicios()
        {
            if (!db.CategoriaServicios.Any())
            {
                var entidad = dba.CategoriaServicios.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<CategoriaServicio>>(entidad));
            }
        }

        public async Task InyectarColonias()
        {
            if (!db.Colonias.Any())
            {
                var entidad = dba.Colonias.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Colonia>>(entidad));
            }
        }

        public async Task InyectarDelegaciones()
        {
            if (!db.Delegaciones.Any())
            {
                var entidad = dba.Delegaciones.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Delegacion>>(entidad));
            }
        }

        public async Task InyectarEstados()
        {
            if (!db.Estados.Any())
            {
                var entidad = dba.Estados.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Estado>>(entidad));
            }
        }

        public async Task InyectarDetalles()
        {
            if (!db.Detalles.Any())
            {
                var entidad = dba.Detalles.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Detalles>>(entidad));
            }
        }

        public async Task InyectarMunicipios()
        {
            if (!db.Municipios.Any())
            {
                var entidad = dba.Municipios.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Municipio>>(entidad));
            }
        }

        public async Task InyectarPaises()
        {
            if (!db.Paises.Any())
            {
                var entidad = dba.Paises.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Pais>>(entidad));
            }
        }

        public async Task InyectarPeriodos()
        {
            if (!db.Periodos.Any())
            {
                var entidad = dba.Periodos.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Periodos>>(entidad));
            }
        }

        public async Task InyectarProcesos()
        {
            if (!db.Procesos.Any())
            {
                var entidad = dba.Procesos.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Proceso>>(entidad));
            }
        }

        public async Task InyectarMetas()
        {
            if (!db.Metas.Any())
            {
                var entidad = dba.Metas.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Meta>>(entidad));
            }
        }

        public async Task InyectarRoles()
        {
            if (!db.Roles.Any())
            {
                var entidad = dba.Roles.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Roles>>(entidad));
            }
        }

        public async Task InyectarServicios()
        {
            if (!db.Servicios.Any())
            {
                var entidad = dba.Servicios.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Servicio>>(entidad));
            }
        }

        public async Task InyectarStatus()
        {
            if (!db.Status.Any())
            {
                var entidad = dba.Status.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Status>>(entidad));
            }
        }

        public async Task InyectarUnidadesTipo()
        {
            if (!db.UnidadesTipo.Any())
            {
                var entidad = dba.UnidadesTipo.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<UnidadTipo>>(entidad));
            }
        }

        public async Task InyectarUnidades()
        {
            if (!db.Unidades.Any())
            {
                var entidad = dba.UnidadesMedicas.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Unidad>>(entidad));
            }
        }

        public async Task InyectarVialidades()
        {
            if (!db.Vialidades.Any())
            {
                var entidad = dba.Vialidades.AsNoTracking().AsEnumerable();
                await db.BulkInsertAsync(mapper.Map<IEnumerable<Vialidad>>(entidad));
            }
        }

        #endregion
    }
}