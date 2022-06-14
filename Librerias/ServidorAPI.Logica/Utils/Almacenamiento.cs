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
//                  Almacenamiento: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Dominio.Interfaces.Utils;

namespace ServidorAPI.Logica.Utils
{
    public class Almacenamiento : IAlmacenamiento
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment wwwroot;

        public Almacenamiento(IHttpContextAccessor _httpContextAccessor, IWebHostEnvironment _wwwroot)
        {
            httpContextAccessor = _httpContextAccessor;
            wwwroot = _wwwroot;
        }

        public async Task<string> GuardarImagen(byte[] archivo, string contentType, string extension, string contenedor, string? nombre)
        {
            string rutaServidorAPI = wwwroot.WebRootPath;
            string carpetaImagen = Path.Combine(rutaServidorAPI, $"img", contenedor);
            if (!Directory.Exists(carpetaImagen))
            {
                Directory.CreateDirectory(carpetaImagen);
            }

            string nombreArchivo = $"{nombre}{extension}";
            string rutaFinal = Path.Combine(carpetaImagen, nombreArchivo);
            await File.WriteAllBytesAsync(rutaFinal, archivo);

            string UrlActual = $"{httpContextAccessor.HttpContext?.Request.Scheme}://{httpContextAccessor.HttpContext?.Request.Host}";
            string Url = Path.Combine(UrlActual, $"img", contenedor, nombreArchivo).Replace("\\", "/");

            return await Task.FromResult(Url);
        }

        public async Task Eliminar(string ruta, string contenedor)
        {
            string rutaServidorAPI = wwwroot.WebRootPath;
            var nombreArchivo = Path.GetFileName(ruta);
            string rutaFinal = Path.Combine(rutaServidorAPI, $"img", contenedor, nombreArchivo);
            if (File.Exists(rutaFinal))
            {
                File.Delete(rutaFinal);
            }
            await Task.CompletedTask;
        }
    }
}