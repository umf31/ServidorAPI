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
//                ServidorAsistente: Creado 14-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Persistencia.Conectividad.Contexto;

namespace ServidorAPI.Persistencia.Utils
{
    public class ServidorAsistente<Entidad> : IServidorAsistente<Entidad> where Entidad : EntidadBase
    {
        private readonly ServidorContexto db;
        protected readonly DbSet<Entidad> entidades;

        public ServidorAsistente(ServidorContexto _db)
        {
            db = _db;
            entidades = db.Set<Entidad>();
        }

        public async Task<IEnumerable<Entidad>> ObtenerTodo()
        {
            var entidad = entidades.Where(x => x.StatusId == 1).AsEnumerable();
            return await Task.FromResult(entidad);
        }

        public async Task<Entidad> ObtenerPorId(int? id)
        {
            var entidad = await entidades.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task Insertar(Entidad entidad)
        {
            await entidades.AddAsync(entidad);
        }

        public async Task Actualizar(int id, string matricula)
        {
            var entidadActualizada = await ObtenerPorId(id);
            entidadActualizada.UsuarioMod = matricula;
            entidadActualizada.StatusId = 2;
            await Task.FromResult(entidades.Update(entidadActualizada));
        }

        public async Task Editar(Entidad entidad)
        {
            await Task.FromResult(entidades.Update(entidad));
        }

        public async Task Eliminar(int id)
        {
            Entidad? entidad = await ObtenerPorId(id);
            if (entidad != null)
            {
                entidades.Remove(entidad);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteEntidadPorId(int? entidadId)
        {
            var existe = await entidades.Where(x => x.Id == entidadId && x.StatusId == 1).FirstOrDefaultAsync();
            if (existe == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ExisteEntidadPorNombre(string? nombre)
        {
            if (nombre != null)
            {
                var existe = await entidades.Where(x => x.Nombre.ToLower() == nombre.ToLower() && x.StatusId == 1).FirstOrDefaultAsync();
                if (existe == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }
    }
}