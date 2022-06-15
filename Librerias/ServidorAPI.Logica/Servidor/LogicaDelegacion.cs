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
//                LogicaDelegacion: Creado 14-06-2022
//=======================================================================

#endregion

using AutoMapper;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Logica.Servidor;
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
    public class LogicaDelegacion<Entidad> : ILogicaDelegacion<Delegacion>
    {
        private readonly IServidorUT ut;
        private readonly IPagServidor lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaDelegacion(IMapper _mapper, IServidorUT _ut, IPagServidor _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Delegacion>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (DelegacionConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;
            var entidad = await ut.AsistenteDelegacion.ObtenerTodoFiltros();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Nombre != null)
            {
                entidad = entidad.Where(x => x.Nombre.ToLower().Contains(consulta.Nombre.ToLower()));
            }
            if (consulta.EstadoId != null)
            {
                entidad = entidad.Where(x => x.EstadoId == consulta.EstadoId);
            }
            if (consulta.Estado != null)
            {
                entidad = entidad.Where(x => x.Estado.Nombre.ToLower().Contains(consulta.Estado.ToLower()));
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Delegacion.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Delegacion> ObtenerPorId(int entidadId)
        {
            var entidad = await ut.AsistenteDelegacion.ObtenerPorId(entidadId);
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

        public async Task<Delegacion> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (DelegacionInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (!await ut.AsistenteEstado.ExisteEntidadPorId(entidadInsertar.EstadoId))
            {
                throw new NotFound(Mensaje.Detalle.EstadoNoExiste);
            }

            var utilerias = mapper.Map<UtileriasRespuesta>(entidadInsertar);
            var entidad = mapper.Map<Delegacion>(entidadInsertar);
            if (entidad.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(entidad.Latitud, entidad.Longitud, Controlador.Nombre.Delegacion, entidad.Nombre);
            }
            if (entidadInsertar.Foto != null)
            {
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Delegacion);
            }
            else
            {
                entidad.Imagen = await util.CrearLinkImagenNoDisponible();
            }

            #endregion

            entidad.UsuarioMod = matricula;
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;
            entidad.StatusId = 1;

            await ut.AsistenteDelegacion.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            return entidad;
        }

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistenteDelegacion.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (DelegacionEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistenteDelegacion.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (entidadEditar.EstadoId != null)
            {
                if (!await ut.AsistenteEstado.ExisteEntidadPorId(entidadEditar.EstadoId))
                {
                    throw new NotFound(Mensaje.Detalle.EstadoNoExiste);
                }
            }

            var entidad = await ut.AsistenteDelegacion.ObtenerPorId(id);
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadEditar);
            if (entidadEditar.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Delegacion, entidad.Nombre);
            }
            if (entidadEditar.Nombre != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Delegacion, entidad.Nombre);
            }
            if (entidadEditar.Foto != null)
            {
                if (entidad.Imagen != null && !entidad.Imagen.Contains(Ruta.Imagen.RutaDefault))
                {
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Delegacion);
                }
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Delegacion, entidad.Nombre);
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

            await ut.AsistenteDelegacion.Editar(entidad);
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
            var entidad = await ut.AsistenteDelegacion.ObtenerPorId(entidadId);
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
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Delegacion);
                }
                await ut.AsistenteDelegacion.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistenteDelegacion.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}