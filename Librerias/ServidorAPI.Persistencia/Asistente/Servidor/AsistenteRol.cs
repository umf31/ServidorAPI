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
//                   AsistenteRol: Creado 14-06-2022
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
    public class AsistenteRol : IAsistenteRol
    {
        private readonly ServidorContexto db;

        public AsistenteRol(ServidorContexto _db)
        {
            db = _db;
        }

        public async Task<List<EmpleadoRol>> ObtenerTodo(int empleadoId)
        {
            var entidad = await db.EmpleadoRoles.Where(x => x.IdEmpleado == empleadoId).ToListAsync();
            return await Task.FromResult(entidad);
        }

        public async Task<bool> AgregarRol(int empleadoId, int idRol)
        {
            var empleado = new EmpleadoRol
            {
                IdEmpleado = empleadoId,
                IdRol = idRol
            };
            await db.AddAsync(empleado);
            return true;
        }

        public async Task<bool> EliminarRol(int empleadoId, int idRol)
        {
            var empleadoRol = await db.EmpleadoRoles.Where(x => x.IdEmpleado == empleadoId && x.IdRol == idRol).FirstOrDefaultAsync();
            if (empleadoRol != null)
            {
                db.EmpleadoRoles.Remove(empleadoRol);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }

            return true;
        }

        public async Task<bool> AgregarRolInicio(int empleadoId)
        {
            var empleado = new EmpleadoRol
            {
                IdEmpleado = empleadoId,
                IdRol = 0
            };
            await db.AddAsync(empleado);
            return true;
        }
    }
}