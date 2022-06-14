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
//                 AsistenteServicio: Creado 14-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Asistente.Servidor
{
    public class AsistenteServicio : IAsistenteServicio
    {
        private readonly ServidorContexto db;

        public AsistenteServicio(ServidorContexto _db)
        {
            db = _db;
        }

        public async Task<IEnumerable<Servicio>> ObtenerTodo()
        {
            var entidad = db.Servicios.Where(x => x.StatusId == 1).AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<Servicio> ObtenerPorId(int? id)
        {
            var entidad = await db.Servicios.Where(x => x.IdServicio == id).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task Insertar(Servicio entidad)
        {
            await db.Servicios.AddAsync(entidad);
        }

        public async Task Actualizar(int id, string matricula)
        {
            var entidadActualizada = await ObtenerPorId(id);
            entidadActualizada.UsuarioMod = matricula;
            entidadActualizada.StatusId = 2;
            db.Servicios.Update(entidadActualizada);
        }

        public async Task Editar(Servicio entidad)
        {
            await Task.FromResult(db.Servicios.Update(entidad));
        }

        public async Task Eliminar(int id)
        {
            var entidad = await ObtenerPorId(id);
            if (entidad != null)
            {
                db.Servicios.Remove(entidad);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteEntidadPorId(int? entidadId)
        {
            var existe = await db.Servicios.Where(x => x.IdServicio == entidadId).FirstOrDefaultAsync();
            if (existe == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> ExisteEntidadPorNombre(string? nombre)
        {
            var existe = await db.Servicios.Where(x => x.Nombre == nombre).FirstOrDefaultAsync();
            if (existe == null) { return false; }
            return true;
        }
    }
}