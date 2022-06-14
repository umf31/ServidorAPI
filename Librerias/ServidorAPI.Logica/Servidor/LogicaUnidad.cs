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
//                LogicaUnidad: Creado 05-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Logica.Base;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Servidor.Consulta;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;

namespace ServidorAPI.Logica.Servidor
{
    public class LogicaUnidad<Entidad> : ILogicaUnidad<Unidad>
    {
        private readonly IServidorUT ut;
        private readonly IPagServidor lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaUnidad(IMapper _mapper, IServidorUT _ut, IPagServidor _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Unidad>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (UnidadConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;
            var entidad = await ut.AsistenteUnidad.ObtenerTodoFiltros();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Nombre != null)
            {
                entidad = entidad.Where(x => x.Nombre.ToLower().Contains(consulta.Nombre.ToLower()));
            }
            if (consulta.ClavePresupuestal != null)
            {
                entidad = entidad.Where(x => x.ClavePresupuestal.ToLower().Contains(consulta.ClavePresupuestal.ToLower()));
            }
            if (consulta.DelegacionId != null)
            {
                entidad = entidad.Where(x => x.DelegacionId == consulta.DelegacionId);
            }
            if (consulta.Delegacion != null)
            {
                entidad = entidad.Where(x => x.Delegacion.Nombre.ToLower().Contains(consulta.Delegacion.ToLower()));
            }
            if (consulta.NumUnidad != null)
            {
                entidad = entidad.Where(x => x.NumUnidad == consulta.NumUnidad);
            }
            if (consulta.ColoniaId != null)
            {
                entidad = entidad.Where(x => x.ColoniaId == consulta.ColoniaId);
            }
            if (consulta.Colonia != null)
            {
                entidad = entidad.Where(x => x.Colonia.Nombre.ToLower().Contains(consulta.Colonia.ToLower()));
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Unidad.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Unidad> ObtenerPorId(int entidadId)
        {
            var entidad = await ut.AsistenteUnidad.ObtenerPorId(entidadId);
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

        public async Task<Unidad> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (UnidadInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (await ut.AsistenteUnidad.ExisteUnidadPorClavePresupuestal(entidadInsertar.ClavePresupuestal))
            {
                throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
            }
            if (await ut.AsistenteUnidad.ExistePorNumeroUnidad(entidadInsertar.NumUnidad, entidadInsertar.DelegacionId))
            {
                throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
            }
            if (!await ut.AsistenteDelegacion.ExisteEntidadPorId(entidadInsertar.DelegacionId))
            {
                throw new NotAcceptable(Mensaje.Detalle.DelegacionNoExiste);
            }
            if (!await ut.AsistenteVialidad.ExisteEntidadPorId(entidadInsertar.VialidadId))
            {
                throw new NotAcceptable(Mensaje.Detalle.VialidadNoExiste);
            }
            if (!await ut.AsistenteMunicipio.ExisteEntidadPorId(entidadInsertar.MunicipioId))
            {
                throw new NotAcceptable(Mensaje.Detalle.MunicipioNoExiste);
            }
            if (!await ut.AsistenteUnidadTipo.ExisteEntidadPorId(entidadInsertar.UnidadTipoId))
            {
                throw new NotAcceptable(Mensaje.Detalle.UnidadTipoNoExiste);
            }
            if (!await ut.AsistenteMunicipio.ExisteEntidadPorId(entidadInsertar.MunicipioId))
            {
                throw new NotAcceptable(Mensaje.Detalle.MunicipioNoExiste);
            }

            var utilerias = mapper.Map<UtileriasRespuesta>(entidadInsertar);
            var entidad = mapper.Map<Unidad>(entidadInsertar);
            if (entidad.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(entidad.Latitud, entidad.Longitud, Controlador.Nombre.Unidad, entidad.Nombre);
            }
            if (entidadInsertar.Foto != null)
            {
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Unidad);
            }
            else
            {
                entidad.Imagen = await util.CrearLinkImagenNoDisponible();
            }
            var unidadTipo = await ut.AsistenteUnidadTipo.ObtenerPorId(entidadInsertar.UnidadTipoId);
            entidad.Nombre = await util.CrearNombreUnidad(unidadTipo.Abrev, entidad.NumUnidad, entidad.Localidad);
            entidad.MunicipioId = (int)entidadInsertar.MunicipioId!;

            #endregion

            entidad.UsuarioMod = matricula;
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;
            entidad.StatusId = 1;

            await ut.AsistenteUnidad.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            return entidad;
        }

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistenteUnidad.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (UnidadEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistenteUnidad.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (entidadEditar.DelegacionId != null)
            {
                if (!await ut.AsistenteDelegacion.ExisteEntidadPorId(entidadEditar.DelegacionId))
                {
                    throw new NotAcceptable(Mensaje.Detalle.DelegacionNoExiste);
                }
            }
            if (entidadEditar.ClavePresupuestal != null)
            {
                if (await ut.AsistenteUnidad.ExisteUnidadPorClavePresupuestal(entidadEditar.ClavePresupuestal))
                {
                    throw new BadRequest(Mensaje.Detalle.ClavePresupuestalExiste);
                }
            }
            if (entidadEditar.UnidadTipoId != null)
            {
                if (!await ut.AsistenteUnidadTipo.ExisteEntidadPorId(entidadEditar.UnidadTipoId))
                {
                    throw new BadRequest(Mensaje.Detalle.UnidadTipoNoExiste);
                }
            }
            if (entidadEditar.VialidadId != null)
            {
                if (!await ut.AsistenteVialidad.ExisteEntidadPorId(entidadEditar.VialidadId))
                {
                    throw new BadRequest(Mensaje.Detalle.VialidadNoExiste);
                }
            }
            if (entidadEditar.ColoniaId != null)
            {
                if (!await ut.AsistenteColonia.ExisteEntidadPorId(entidadEditar.ColoniaId))
                {
                    throw new BadRequest(Mensaje.Detalle.ColoniaNoExiste);
                }
            }
            if (entidadEditar.UnidadTipoId != null)
            {
                if (!await ut.AsistenteUnidadTipo.ExisteEntidadPorId(entidadEditar.UnidadTipoId))
                {
                    throw new BadRequest(Mensaje.Detalle.UnidadTipoNoExiste);
                }
            }

            var entidad = await ut.AsistenteUnidad.ObtenerPorId(id);
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadEditar);
            if (entidadEditar.MunicipioId != null)
            {
                if (!await ut.AsistenteMunicipio.ExisteEntidadPorId(entidadEditar.MunicipioId))
                {
                    throw new BadRequest(Mensaje.Detalle.MunicipioNoExiste);
                }
                entidad.Nombre = await util.CrearNombreUnidad(utilerias, entidad.UnidadTipo.Abrev, entidad.NumUnidad, entidad.Localidad);
            }
            if (entidadEditar.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Unidad, entidad.Nombre);
            }
            if (entidadEditar.NumUnidad != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Unidad, entidad.Nombre);
            }
            if (entidadEditar.Foto != null)
            {
                if (entidad.Imagen != null && !entidad.Imagen.Contains(Ruta.Imagen.RutaDefault))
                {
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Unidad);
                }
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Unidad, entidad.Nombre);
            }
            else
            {
                if (entidad.Imagen == null)
                {
                    entidad.Imagen = await util.CrearLinkImagenNoDisponible();
                }
            }
            entidad = mapper.Map(entidadEditar, entidad);

            #endregion

            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioMod = matricula;

            await ut.AsistenteUnidad.Editar(entidad);
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
            var entidad = await ut.AsistenteUnidad.ObtenerPorId(entidadId);
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
                if (entidad.Imagen != null)
                {
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Unidad);
                }
                await ut.AsistenteUnidad.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistenteUnidad.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}