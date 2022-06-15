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
//
//                LogicaPeriodo: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Logica.Sadim;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Sadim.Consulta;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;

namespace ServidorAPI.Logica.Sadim
{
    public class LogicaPeriodo<Entidad> : ILogicaPeriodo<Periodos>
    {
        private readonly ISadimUT ut;
        private readonly IPagSadim lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaPeriodo(IMapper _mapper, ISadimUT _ut, IPagSadim _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Periodos>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (PeriodoConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;

            var entidad = await ut.AsistentePeriodo.ObtenerTodo();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Periodo != null)
            {
                entidad = entidad.Where(x => x.Periodo == consulta.Periodo);
            }
            if (consulta.Mes != null)
            {
                entidad = entidad.Where(x => x.Mes == consulta.Mes);
            }
            if (consulta.Año != null)
            {
                entidad = entidad.Where(x => x.Año == consulta.Año);
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Periodo.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Periodos> ObtenerPorId(int entidadId)
        {
            var entidad = await ut.AsistentePeriodo.ObtenerPorId(entidadId);
            if (entidad == null)
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            else if (entidad.StatusId != 1)
            {
                throw new Locked(Mensaje.Detalle.Bloqueado);
            }
            return entidad;
        }

        public async Task<Periodos> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (PeriodoInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }

            if (!await ut.AsistentePeriodo.ExistePeriodoPorMesAño(entidadInsertar.Mes, entidadInsertar.Año))
            {
                throw new NotFound(Mensaje.Detalle.PeriodoExiste);
            }
            string fechaInicioPeriodo = await util.CrearFechaInicio(entidadInsertar.Mes, entidadInsertar.Año);
            string fechaTerminoPeriodo = await util.CrearFechaTermino(entidadInsertar.Mes, entidadInsertar.Año);
            var entidad = mapper.Map<Periodos>(entidadInsertar);

            #endregion

            entidad.UsuarioMod = matricula;
            entidad.Periodo = entidad.Año + entidad.Mes;
            entidad.FechaInicio = DateTime.Parse(fechaInicioPeriodo);
            entidad.FechaTermino = DateTime.Parse(fechaTerminoPeriodo);
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;
            entidad.StatusId = 1;

            await ut.AsistentePeriodo.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            return entidad;
        }

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistentePeriodo.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (PeriodoEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistentePeriodo.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            var entidad = await ut.AsistentePeriodo.ObtenerPorId(id);
            string fechaTerminoPeriodo;
            string fechaInicioPeriodo;
            if (entidadEditar.Mes != null && entidadEditar.Año != null)
            {
                fechaInicioPeriodo = await util.CrearFechaInicio(entidadEditar.Mes, entidadEditar.Año);
                fechaTerminoPeriodo = await util.CrearFechaTermino(entidadEditar.Mes, entidadEditar.Año);
            }
            else if (entidadEditar.Mes != null && entidadEditar.Año == null)
            {
                fechaInicioPeriodo = await util.CrearFechaInicio(entidadEditar.Mes, entidad.Año);
                fechaTerminoPeriodo = await util.CrearFechaTermino(entidadEditar.Mes, entidad.Año);
                entidad.Mes = entidadEditar.Mes;
            }
            else if (entidadEditar.Mes == null && entidadEditar.Año == null)
            {
                fechaInicioPeriodo = await util.CrearFechaInicio(entidad.Mes, entidadEditar.Año);
                fechaTerminoPeriodo = await util.CrearFechaTermino(entidad.Mes, entidadEditar.Año);
            }
            else
            {
                fechaInicioPeriodo = await util.CrearFechaInicio(entidad.Mes, entidad.Año);
                fechaTerminoPeriodo = await util.CrearFechaTermino(entidad.Mes, entidad.Año);
            }
            entidad = mapper.Map(entidadEditar, entidad);
            entidad.Periodo = entidad.Año + entidad.Mes;
            entidad.FechaInicio = DateTime.Parse(fechaInicioPeriodo);
            entidad.FechaTermino = DateTime.Parse(fechaTerminoPeriodo);

            #endregion

            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioMod = matricula;

            await ut.AsistentePeriodo.Editar(entidad);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Eliminar(int entidadId, string matricula)
        {
            var empleado = await ut.AsistenteEmpleado.ObtenerPorMatricula(matricula);
            var empleadoRol = empleado.Roles.Where(x => x.Rol.Descripcion == "SadimMaster").FirstOrDefault();
            if (empleado == null)
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            var entidad = await ut.AsistentePeriodo.ObtenerPorId(entidadId);
            if (entidad == null)
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (entidad.StatusId == 2 && empleadoRol == null)
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (empleadoRol != null)
            {
                await ut.AsistentePeriodo.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistentePeriodo.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}