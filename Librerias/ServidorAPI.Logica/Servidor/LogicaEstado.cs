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
//                  LogicaEstado: Creado 05-06-2022
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
    public class LogicaEstado<Entidad> : ILogicaEstado<Estado>
    {
        private readonly IServidorUT ut;
        private readonly IPagServidor lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaEstado(IMapper _mapper, IServidorUT _ut, IPagServidor _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Estado>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (EstadoConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;
            var entidad = await ut.AsistenteEstado.ObtenerTodoFiltros();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Nombre != null)
            {
                entidad = entidad.Where(x => x.Nombre.ToLower().Contains(consulta.Nombre.ToLower()));
            }
            if (consulta.PaisId != null)
            {
                entidad = entidad.Where(x => x.PaisId == consulta.PaisId);
            }
            if (consulta.Pais != null)
            {
                entidad = entidad.Where(x => x.Pais.Nombre.ToLower().Contains(consulta.Pais.ToLower()));
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Estado.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Estado> ObtenerPorId(int entidadId)
        {
            var entidad = await ut.AsistenteEstado.ObtenerPorId(entidadId);
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

        public async Task<Estado> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (EstadoInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (!await ut.AsistentePais.ExisteEntidadPorId(entidadInsertar.PaisId))
            {
                throw new NotFound(Mensaje.Detalle.EstadoNoExiste);
            }
            if (await ut.AsistenteEstado.ExisteEntidadPorNombre(entidadInsertar.Nombre))
            {
                throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
            }
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadInsertar);
            var entidad = mapper.Map<Estado>(entidadInsertar);
            if (entidad.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(entidad.Latitud, entidad.Longitud, Controlador.Nombre.Estado, entidad.Nombre);
            }
            if (entidadInsertar.Foto != null)
            {
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Estado);
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

            await ut.AsistenteEstado.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            return entidad;
        }

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistenteEstado.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (EstadoEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistenteEstado.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (entidadEditar.Nombre != null)
            {
                if (await ut.AsistenteEstado.ExisteEntidadPorNombre(entidadEditar.Nombre))
                {
                    throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
                }
            }
            if (entidadEditar.PaisId != null)
            {
                if (!await ut.AsistentePais.ExisteEntidadPorId(entidadEditar.PaisId))
                {
                    throw new NotFound(Mensaje.Detalle.EstadoNoExiste);
                }
            }
            var entidad = await ut.AsistenteEstado.ObtenerPorId(id);
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadEditar);
            if (entidadEditar.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Estado, entidad.Nombre);
            }
            if (entidadEditar.Nombre != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Estado, entidadEditar.Nombre);
            }
            if (entidadEditar.Foto != null)
            {
                if (entidad.Imagen != null && !entidad.Imagen.Contains(Ruta.Imagen.RutaDefault))
                {
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Estado);
                }
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Estado, entidad.Nombre);
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

            await ut.AsistenteEstado.Editar(entidad);
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
            var entidad = await ut.AsistenteEstado.ObtenerPorId(entidadId);
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
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Estado);
                }
                await ut.AsistenteEstado.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistenteEstado.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}