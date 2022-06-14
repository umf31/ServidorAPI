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
//                    Utilerias: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using ServidorAPI.Dominio.Entidades.Servidor;
using ServidorAPI.Dominio.Interfaces.Utils.Servidor;
using ServidorAPI.Dominio.Servicios.Servidor;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Respuesta;
using ServidorAPI.Persistencia.Informacion;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServidorAPI.Logica.Utils.Servidor
{
    public class Utilerias : IUtilerias
    {
        private readonly IAlmacenamiento sa;
        private readonly IHttpContextAccessor httpContextAccessor;

        public Utilerias(IAlmacenamiento _sa, IHttpContextAccessor _httpContextAccessor)
        {
            sa = _sa;
            httpContextAccessor = _httpContextAccessor;
        }

        public async Task<string> CrearFechaInicio(string? mes, string? año)
        {
            string fechaInicial = null!;
            if (Convert.ToInt32(mes) == 1)
            {
                fechaInicial = Indicadores.Periodo.DiaInicio + (Convert.ToInt32(mes) + 11) + "/" + (Convert.ToInt32(año) - 1) + Indicadores.Periodo.HoraInicio;
            }
            else
            {
                fechaInicial = Indicadores.Periodo.DiaInicio + mes + Indicadores.Periodo.Div + año + Indicadores.Periodo.HoraInicio;
            }
            return await Task.FromResult(fechaInicial);
        }

        public async Task<string> CrearFechaTermino(string? mes, string? año)
        {
            string fechaTermino;
            if (Convert.ToInt32(mes) == 12)
            {
                fechaTermino = Indicadores.Periodo.DiaTermino + (Convert.ToInt32(mes) - 11) + "/" + (Convert.ToInt32(año) + 1) + Indicadores.Periodo.HoraTermino;
            }
            else
            {
                fechaTermino = Indicadores.Periodo.DiaTermino + mes + Indicadores.Periodo.Div + año + Indicadores.Periodo.HoraTermino;
            }
            return await Task.FromResult(fechaTermino);
        }

        public async Task<EncriptacionHash> CrearHash(string? item)
        {
            var encriptar = new EncriptacionHash();
            await Task.Run(() =>
            {
                if (item != null)
                {
                    using var hmac = new HMACSHA512();
                    encriptar.ItemSalt = hmac.Key;
                    encriptar.ItemHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(item));
                }
            });
            return encriptar;
        }

        public async Task<string> CrearLinkGeolocalizacion(decimal? latitud, decimal? longitud, string entidad, string? entidadNombre = null)
        {
            string geolocalizacion;

            if (entidad == Controlador.Nombre.Pais)
            {
                geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom5 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
            }
            else if (entidad == Controlador.Nombre.Estado)
            {
                geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom7 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
            }
            else if (entidad == Controlador.Nombre.Municipio)
            {
                geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom12 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
            }
            else if (entidad == Controlador.Nombre.Colonia)
            {
                geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom13 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
            }
            else
            {
                geolocalizacion = Google.Link2 + latitud + Google.Div + longitud;
            }

            return await Task.FromResult(geolocalizacion);
        }

        public async Task<string> CrearLinkGeolocalizacion(dynamic dynEntidadEditar, decimal? latitud, decimal? longitud, string entidad, string? entidadNombre = null)
        {
            var entidadEditar = (UtileriasRespuesta)dynEntidadEditar;
            string geolocalizacion;

            if (entidad == Controlador.Nombre.Pais)
            {
                if (entidadEditar.Latitud != null)
                {
                    geolocalizacion = Google.Link + entidadEditar.Latitud + "," + entidadEditar.Longitud + Google.Zoom5 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
                else
                {
                    geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom5 + Google.Satelite + Google.Cerca + latitud + entidadNombre!.Replace(" ", "+");
                }
            }
            else if (entidad == Controlador.Nombre.Estado)
            {
                if (entidadEditar.Latitud != null)
                {
                    geolocalizacion = Google.Link + entidadEditar.Latitud + "," + entidadEditar.Longitud + Google.Zoom7 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
                else
                {
                    geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom7 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
            }
            else if (entidad == Controlador.Nombre.Municipio)
            {
                if (entidadEditar.Latitud != null)
                {
                    geolocalizacion = Google.Link + entidadEditar.Latitud + "," + entidadEditar.Longitud + Google.Zoom12 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
                else
                {
                    geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom12 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
            }
            else if (entidad == Controlador.Nombre.Colonia)
            {
                if (entidadEditar.Latitud != null)
                {
                    geolocalizacion = Google.Link + entidadEditar.Latitud + "," + entidadEditar.Longitud + Google.Zoom13 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
                else
                {
                    geolocalizacion = Google.Link + latitud + "," + longitud + Google.Zoom13 + Google.Satelite + Google.Cerca + entidadNombre!.Replace(" ", "+");
                }
            }
            else
            {
                geolocalizacion = Google.Link2 + entidadEditar.Latitud + Google.Div  + entidadEditar.Longitud;
            }

            return await Task.FromResult(geolocalizacion);
        }

        public async Task<string> CrearLinkImagen(dynamic dynEntidadEditar, string entidad, string? entidadNombre = null)
        {
            var entidadEditar = (UtileriasRespuesta)dynEntidadEditar;
            string imagen;
            using var stream = new MemoryStream();

            await entidadEditar.Foto.CopyToAsync(stream);
            var archivoBytes = stream.ToArray();
            string nombreArchivo = Guid.NewGuid().ToString();
            imagen = await sa.GuardarImagen(archivoBytes, entidadEditar.Foto.ContentType, Path.GetExtension(entidadEditar.Foto.FileName), entidad, nombreArchivo);

            return await Task.FromResult(imagen);
        }

        public async Task<string> CrearLinkImagenNoDisponible()
        {
            string nombreArchivo = Ruta.Imagen.NoDisponible;
            string contenedor = Ruta.Imagen.ContenedorDefault;
            var configuracion = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host}";

            string Url = Path.Combine(configuracion, contenedor, nombreArchivo).Replace("\\", "/");
            return await Task.FromResult(Url);
        }

        public async Task<string> CrearLinkImagenNoDisponibleC()
        {
            string nombreArchivo = Ruta.Imagen.NoDisponibleC;
            string contenedor = Ruta.Imagen.ContenedorDefault;
            var configuracion = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host}";

            string Url = Path.Combine(configuracion, contenedor, nombreArchivo).Replace("\\", "/");
            return await Task.FromResult(Url);
        }

        public async Task<string> CrearLinkImagenPredeterminada()
        {
            string nombreArchivo = Ruta.Imagen.UsuarioDefault;
            string contenedor = Ruta.Imagen.ContenedorDefault;
            var configuracion = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host}";
            string Url = Path.Combine(configuracion, contenedor, nombreArchivo).Replace("\\", "/");

            return await Task.FromResult(Url);
        }

        public async Task<string> CrearNombreUnidad(dynamic editar, string? tipoUnidad, int? numUnidad, string? localidad)
        {
            var entidadEditar = (UnidadEditar)editar;
            string? nombreUnidad;

            if (entidadEditar.NumUnidad != null && entidadEditar.Localidad != null)
            {
                nombreUnidad = tipoUnidad + " " + "No." + entidadEditar.NumUnidad + " " + entidadEditar.Localidad;
            }
            else if (entidadEditar.NumUnidad != null && entidadEditar.Localidad == null)
            {
                nombreUnidad = tipoUnidad + " " + "No." + entidadEditar.NumUnidad + " " + localidad;
            }
            else if (entidadEditar.NumUnidad == null && entidadEditar.Localidad != null)
            {
                nombreUnidad = tipoUnidad + " " + "No." + numUnidad + " " + entidadEditar.Localidad;
            }
            else
            {
                nombreUnidad = tipoUnidad + " " + "No." + numUnidad + " " + localidad;
            }
            return await Task.FromResult(nombreUnidad);
        }

        public async Task<string> CrearNombreUnidad(string? tipoUnidad, int? numUnidad, string? localidad)
        {
            var nombreUnidad = tipoUnidad + " " + "No. " + numUnidad + " " + localidad;
            return await Task.FromResult(nombreUnidad);
        }

        public async Task<string> CrearTokenJWTBearer(dynamic dynEmpleado)
        {
            var empleado = (Empleado)dynEmpleado;
            var llavePrivada = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuracion.LlavePrivada));
            var credenciales = new SigningCredentials(llavePrivada, SecurityAlgorithms.HmacSha512Signature);
            var header = new JwtHeader(credenciales);
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, empleado.Id.ToString()),
                new Claim(ClaimTypes.Name, empleado.NombreCompleto),
                new Claim(ClaimTypes.Email, empleado.Email),
                new Claim(ClaimTypes.Sid, empleado.Matricula.ToString()),
                new Claim(ClaimTypes.Spn, empleado.ServicioId.ToString()),
            };
            if (empleado.Imagen != null)
            {
                Claim claim = new(ClaimTypes.Uri, empleado.Imagen.ToString());
                claims.Add(claim);
            }
            foreach (var roles in empleado.Roles)
            {
                Claim claim = new(ClaimTypes.Role, roles.Rol.Descripcion);
                claims.Add(claim);
            }
            var payload = new JwtPayload
            (
                Configuracion.UrlUnidad,
                Configuracion.UrlUnidad,
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );
            var unir = new JwtSecurityToken(header, payload);
            var token = new JwtSecurityTokenHandler().WriteToken(unir);

            return await Task.FromResult(token);
        }

        public async Task EliminarImagen(string ruta, string contenedor)
        {
            await sa.Eliminar(ruta, contenedor);
        }

        public async Task<bool> VerificaEntidadNula(object objEntidad)
        {
            bool esNulo = objEntidad.GetType().GetProperties().All(p => p.GetValue(objEntidad) == null);
            return await Task.FromResult(esNulo);
        }

        public async Task<bool> VerificaEsNumero(string? item)
        {
            bool esNumero = int.TryParse(item, out _);
            if (esNumero)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> VerificaHash(string item, byte[] itemHash, byte[] itemSalt)
        {
            using (var hmac = new HMACSHA512(itemSalt))
            {
                var hashComputado = hmac.ComputeHash(Encoding.UTF8.GetBytes(item));

                for (int i = 0; i < hashComputado.Length; i++)
                {
                    if (hashComputado[i] != itemHash[i])
                    {
                        return await Task.FromResult(false);
                    }
                }
            }
            return await Task.FromResult(true);
        }
    }
}