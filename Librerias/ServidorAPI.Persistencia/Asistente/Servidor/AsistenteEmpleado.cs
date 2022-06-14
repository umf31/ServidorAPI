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
//                 AsistenteEmpleado: Creado 14-06-2022
//=======================================================================

#endregion

using Microsoft.EntityFrameworkCore;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Excepciones;
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;
using ServidorAPI.Dominio.Servicios.Informacion;
using ServidorAPI.Persistencia.Conectividad.Contexto;
using ServidorAPI.Persistencia.Utils;

namespace ServidorAPI.Persistencia.Asistente.Servidor
{
    public class AsistenteEmpleado : ServidorAsistente<Empleado>, IAsistenteEmpleado
    {
        public AsistenteEmpleado(ServidorContexto db) : base(db)
        { }

        public async Task<IEnumerable<Empleado>> ObtenerTodoFiltros(int? unidadId)
        {
            var entidad = entidades.Where(x => x.StatusId != 2 && x.UnidadId == unidadId).Include("Roles.Rol").Include(x => x.Colonia).Include(c => c.Categoria).AsEnumerable();

            return await Task.FromResult(entidad);
        }

        public async Task<Empleado> ObtenerPorMatricula(string? matricula)
        {
            var entidad = await entidades.Include("Roles.Rol").Include(c => c.Categoria).FirstOrDefaultAsync(x => x.Matricula == matricula);
            return entidad!;
        }

        public async Task<Empleado> ObtenerPorEmail(string email)
        {
            var entidad = await entidades.Include("Roles.Rol").Include(c => c.Categoria).FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            return entidad!;
        }

        public async Task<Empleado> ObtenerPorIdPorUnidad(int? empleadoId, int? unidadId)
        {
            var entidad = await entidades.Where(x => x.Id == empleadoId && x.StatusId != 2 && x.UnidadId == unidadId).Include("Roles.Rol").FirstOrDefaultAsync();
            if (entidad != null)
            {
                return await Task.FromResult(entidad);
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<Empleado> ObtenerPorIdRoles(int id)
        {
            var entidad = await entidades.Where(x => x.Id == id).Include("Roles.Rol").FirstOrDefaultAsync();
            if (entidad != null)
            {
                return entidad;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> BloquearEmpleado(int empleadoId)
        {
            var empleado = await entidades.FirstOrDefaultAsync(u => u.Id == empleadoId && u.StatusId == 1);
            if (empleado != null)
            {
                empleado.Bloqueo = true;
                entidades.Update(empleado);
                return true;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> DesbloquearEmpleado(int empleadoId)
        {
            var empleado = await entidades.FirstOrDefaultAsync(u => u.Id == empleadoId && u.StatusId != 2);
            if (empleado != null)
            {
                empleado.Bloqueo = false;
                entidades.Update(empleado);
                return true;
            }
            else
            {
                throw new NotFound(Mensaje.Detalle.NoEncontrado);
            }
        }

        public async Task<bool> ExisteEmpleado(string? matricula, string? email)
        {
            var empleado = await entidades.FirstOrDefaultAsync(x => x.Email.ToLower() == email!.ToLower() || x.Matricula == matricula);
            if (empleado != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> ExisteEmpleadoPorMatricula(string? matricula)
        {
            var empleado = await entidades.FirstOrDefaultAsync(x => x.Matricula == matricula);
            if (empleado != null) { return true; }
            return false;
        }

        public async Task<bool> ExisteEmpleadoPorEmail(string email)
        {
            var empleado = await entidades.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
            if (empleado != null) { return true; }
            return false;
        }
    }
}