﻿#region ==> Licencia

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
//                LogicaAsentamiento: Creado 14-06-2022
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

namespace ServidorAPI.Logica.Servidor
{
    public class LogicaAsentamiento<Entidad> : ILogicaAsentamiento<Asentamiento>
    {
        private readonly IServidorUT ut;
        private readonly IPagServidor lista;
        private readonly IUtilerias util;
        private readonly IMapper mapper;

        public LogicaAsentamiento(IMapper _mapper, IServidorUT _ut, IPagServidor _lista, IUtilerias _util)
        {
            mapper = _mapper;
            ut = _ut;
            lista = _lista;
            util = _util;
        }

        public async Task<Lista<Asentamiento>> ObtenerTodo(dynamic dynConsulta)
        {
            var consulta = (AsentamientoConsulta)dynConsulta;
            consulta.NumeroPagina = consulta.NumeroPagina == 0 ? Paginacion.DefaultNumeroPagina : consulta.NumeroPagina;
            consulta.NumeroRegistros = consulta.NumeroRegistros == 0 ? Paginacion.DefaultNumeroRegistros : consulta.NumeroRegistros;

            var entidad = await ut.AsistenteAsentamiento.ObtenerTodo();
            if (consulta.Id != null)
            {
                entidad = entidad.Where(x => x.Id == consulta.Id);
            }
            if (consulta.Nombre != null)
            {
                entidad = entidad.Where(x => x.Nombre.ToLower().Contains(consulta.Nombre.ToLower()));
            }
            if (!entidad.Any())
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            var entidadPaginada = await lista.Asentamiento.CrearLista(entidad, consulta.NumeroPagina, consulta.NumeroRegistros);

            if (!entidadPaginada.Any())
            {
                throw new NotFound(Mensaje.Detalle.NumPaginaNoExiste);
            }
            return entidadPaginada;
        }

        public async Task<Asentamiento> ObtenerPorId(int entidadId)
        {
            var entidad = await ut.AsistenteAsentamiento.ObtenerPorId(entidadId);
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

        public async Task<Asentamiento> Insertar(dynamic dynEntidadInsertar, string matricula)
        {
            var entidadInsertar = (AsentamientoInsertar)dynEntidadInsertar;

            #region => Logica validación de entidad

            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (await ut.AsistenteAsentamiento.ExisteEntidadPorNombre(entidadInsertar.Nombre))
            {
                throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
            }
            var entidad = mapper.Map<Asentamiento>(entidadInsertar);

            #endregion

            entidad.UsuarioMod = matricula;
            entidad.FechaCreacion = DateTime.Now;
            entidad.FechaModificacion = DateTime.Now;
            entidad.StatusId = 1;

            await ut.AsistenteAsentamiento.Insertar(entidad);
            await ut.GuardarServidorAPI();
            entidad.Id = entidad.Id;
            return entidad;
        }

        public async Task<bool> Actualizar(int entidadId, string matricula)
        {
            await ut.AsistenteAsentamiento.Actualizar(entidadId, matricula);
            await ut.GuardarServidorAPI();
            return true;
        }

        public async Task<bool> Editar(dynamic dynEntidadEditar, string matricula, int id)
        {
            var entidadEditar = (AsentamientoEditar)dynEntidadEditar;

            #region => Logica validación de entidad

            if (await util.VerificaEntidadNula(entidadEditar))
            {
                throw new NotFound(Mensaje.Detalle.EditarError);
            }
            if (!await ut.AsistenteEmpleado.ExisteEmpleadoPorMatricula(matricula))
            {
                throw new NotAcceptable(Mensaje.Detalle.NoAceptable);
            }
            if (!await ut.AsistenteAsentamiento.ExisteEntidadPorId(id))
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
            if (await ut.AsistenteAsentamiento.ExisteEntidadPorNombre(entidadEditar.Nombre))
            {
                throw new BadRequest(Mensaje.Detalle.SolicitudInvalida);
            }
            var entidad = await ut.AsistenteAsentamiento.ObtenerPorId(id);
            entidad = mapper.Map(entidadEditar, entidad);

            #endregion

            entidad.FechaModificacion = DateTime.Now;
            entidad.UsuarioMod = matricula;

            await ut.AsistenteAsentamiento.Editar(entidad);
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
            var entidad = await ut.AsistenteAsentamiento.ObtenerPorId(entidadId);
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
                await ut.AsistenteAsentamiento.Eliminar(entidadId);
            }
            else
            {
                await ut.AsistenteAsentamiento.Actualizar(entidadId, matricula);
            }
            await ut.GuardarServidorAPI();
            return true;
        }
    }
}