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
//                   IUtilerias: Creado 13-06-2022
//=======================================================================

#endregion


using ServidorAPI.Dominio.Servicios.Servidor;

namespace ServidorAPI.Dominio.Interfaces.Utils.Servidor
{
    public interface IUtilerias
    {
        Task<string> CrearFechaInicio(string? mes, string? año);

        Task<string> CrearFechaTermino(string? mes, string? año);

        Task<EncriptacionHash> CrearHash(string? item);

        Task<string> CrearLinkImagen(dynamic dynImagen, string entidad, string? nombre = null);

        Task<string> CrearLinkImagenNoDisponible();

        Task<string> CrearLinkImagenNoDisponibleC();

        Task<string> CrearLinkImagenPredeterminada();

        Task<string> CrearLinkGeolocalizacion(decimal? latitud, decimal? longitud, string entidad, string? entidadNombre = null);

        Task<string> CrearLinkGeolocalizacion(dynamic dynEntidadEditar, decimal? latitud, decimal? longitud, string entidad, string? entidadNombre = null);

        Task<string> CrearNombreUnidad(dynamic editar, string? tipoUnidad, int? numUnidad, string? localidad);

        Task<string> CrearNombreUnidad(string? tipoUnidad, int? numUnidad, string? localidad);

        Task<string> CrearTokenJWTBearer(dynamic dynEmpleado);

        Task EliminarImagen(string ruta, string contenedor);

        Task<bool> VerificaHash(string item, byte[] itemHash, byte[] itemSalt);

        Task<bool> VerificaEntidadNula(object objEntidad);

        Task<bool> VerificaEsNumero(string? item);
    }
}