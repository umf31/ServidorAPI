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
//                LogicaEmpleado: Creado 14-06-2022
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
    public class LogicaEmpleado<Entidad> : ILogicaEmpleado<Empleado>
    {
        private readonly IServidorUT ut;
        private readonly IPagServidor lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaEmpleado(IMapper _mapper, IServidorUT _ut, IPagServidor _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Empleado>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (EmpleadoConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;
            var unidadActual = await ut.AsistenteUnidad.ObtenerUnidadActiva();
            var entidad = await ut.AsistenteEmpleado.ObtenerTodoFiltros(unidadActual.Id);
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Nombre != null)
            {
                entidad = entidad.Where(x => x.Nombre.ToLower().Contains(consulta.Nombre.ToLower()));
            }
            if (consulta.Matricula != null)
            {
                entidad = entidad.Where(x => x.Matricula == consulta.Matricula);
            }
            if (consulta.Email != null)
            {
                entidad = entidad.Where(x => x.Email.ToLower().Contains(consulta.Email.ToLower()));
            }
            if (consulta.ColoniaId != null)
            {
                entidad = entidad.Where(x => x.ColoniaId == consulta.ColoniaId);
            }
            if (consulta.Colonia != null)
            {
                entidad = entidad.Where(x => x.Colonia.Nombre.ToLower().Contains(consulta.Colonia.ToLower()));
            }
            if (consulta.CategoriaId != null)
            {
                entidad = entidad.Where(x => x.CategoriaId == consulta.CategoriaId);
            }
            if (consulta.Categoria != null)
            {
                entidad = entidad.Where(x => x.Categoria.Nombre.ToLower().Contains(consulta.Categoria.ToLower()));
            }
            if (consulta.ServicioId != null)
            {
                entidad = entidad.Where(x => x.ServicioId == consulta.ServicioId);
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Empleado.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);
            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Empleado> ObtenerPorId(int entidadId)
        {
            var unidad = await ut.AsistenteUnidad.ObtenerUnidadActiva();
            var entidad = await ut.AsistenteEmpleado.ObtenerPorIdPorUnidad(entidadId, unidad.Id);
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

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistenteEmpleado.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<Empleado> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (EmpleadoInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (entidadInsertar.Matricula != matricula)
            {
                if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
                {
                    if (!await ut.AsistenteSoporte.ExisteEmpleadoPorMatricula(matricula))
                    {
                        throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
                    }
                }
            }
            if (await ut.AsistenteEmpleado.ExisteEmpleado(entidadInsertar.Matricula, entidadInsertar.Email))
            {
                throw new NotAcceptable(Mensaje.Detalle.EmpleadoExiste);
            }
            if (!await ut.AsistenteCategoria.ExisteEntidadPorId(entidadInsertar.CategoriaId))
            {
                throw new NotAcceptable(Mensaje.Detalle.CategoriaNoExiste);
            }
            if (!await ut.AsistenteServicio.ExisteEntidadPorId(entidadInsertar.ServicioId))
            {
                throw new NotAcceptable(Mensaje.Detalle.ServicioNoExiste);
            }
            if (!await ut.AsistenteVialidad.ExisteEntidadPorId(entidadInsertar.VialidadId))
            {
                throw new NotAcceptable(Mensaje.Detalle.VialidadNoExiste);
            }
            if (!await ut.AsistenteColonia.ExisteEntidadPorId(entidadInsertar.ColoniaId))
            {
                throw new NotAcceptable(Mensaje.Detalle.ColoniaNoExiste);
            }
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadInsertar);
            var entidad = mapper.Map<Empleado>(entidadInsertar);
            if (entidad.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(entidad.Latitud, entidad.Longitud, Controlador.Nombre.Empleado, entidad.Nombre);
            }
            if (entidadInsertar.Foto != null)
            {
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Empleado);
            }
            else
            {
                entidad.Imagen = await util.CrearLinkImagenPredeterminada();
            }
            var encriptarPassword = await util.CrearHash(entidadInsertar.Password);
            var unidad = await ut.AsistenteUnidad.ObtenerUnidadActiva();

            #endregion

            entidad.PasswordHash = encriptarPassword.ItemHash;
            entidad.PasswordSalt = encriptarPassword.ItemSalt;
            entidad.ClavePresupuestal = unidad.ClavePresupuestal;
            entidad.UnidadId = unidad.Id;
            entidad.UsuarioMod = matricula;
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;
            entidad.StatusId = 1;

            await ut.AsistenteEmpleado.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            await ut.AsistenteRol.AgregarRolInicio(entidad.Id);
            return entidad;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (EmpleadoEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistenteEmpleado.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (entidadEditar.Email != null)
            {
                if (await ut.AsistenteEmpleado.ExisteEmpleadoPorEmail(entidadEditar.Email))
                {
                    throw new NotAcceptable(Mensaje.Detalle.EmpleadoExiste);
                }
            }
            if (entidadEditar.Matricula != null)
            {
                if (await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(entidadEditar.Matricula))
                {
                    throw new NotAcceptable(Mensaje.Detalle.EmpleadoExiste);
                }
            }
            if (entidadEditar.CategoriaId != null)
            {
                if (!await ut.AsistenteCategoria.ExisteEntidadPorId(entidadEditar.CategoriaId))
                {
                    throw new NotAcceptable(Mensaje.Detalle.CategoriaNoExiste);
                }
            }
            if (entidadEditar.ServicioId != null)
            {
                if (!await ut.AsistenteServicio.ExisteEntidadPorId(entidadEditar.ServicioId))
                {
                    throw new NotAcceptable(Mensaje.Detalle.ServicioNoExiste);
                }
            }
            if (entidadEditar.VialidadId != null)
            {
                if (!await ut.AsistenteVialidad.ExisteEntidadPorId(entidadEditar.VialidadId))
                {
                    throw new NotAcceptable(Mensaje.Detalle.VialidadNoExiste);
                }
            }
            if (entidadEditar.ColoniaId != null)
            {
                if (!await ut.AsistenteColonia.ExisteEntidadPorId(entidadEditar.ColoniaId))
                {
                    throw new NotAcceptable(Mensaje.Detalle.CategoriaNoExiste);
                }
            }
            var entidad = await ut.AsistenteEmpleado.ObtenerPorId(id);
            var utilerias = mapper.Map<UtileriasRespuesta>(entidadEditar);
            if (entidadEditar.Latitud != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Empleado, entidad.Nombre);
            }
            if (entidadEditar.Nombre != null)
            {
                entidad.Geolocalizacion = await util.CrearLinkGeolocalizacion(utilerias, entidad.Latitud, entidad.Longitud, Controlador.Nombre.Empleado, entidad.Nombre);
            }
            if (entidadEditar.Foto != null)
            {
                if (entidad.Imagen != null && !entidad.Imagen.Contains(Ruta.Imagen.RutaDefault))
                {
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Empleado);
                }
                entidad.Imagen = await util.CrearLinkImagen(utilerias, Controlador.Nombre.Empleado, entidad.Nombre);
            }
            else
            {
                if (entidad.Imagen == null)
                {
                    entidad.Imagen = await util.CrearLinkImagenPredeterminada();
                }
            }
            entidad = mapper.Map(entidadEditar, entidad);

            #endregion

            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioMod = matricula;

            await ut.AsistenteEmpleado.Editar(entidad);
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
            var entidad = await ut.AsistenteEmpleado.ObtenerPorId(entidadId);
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
                    await util.EliminarImagen(entidad.Imagen, Controlador.Nombre.Empleado);
                }
                await ut.AsistenteEmpleado.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistenteEmpleado.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}