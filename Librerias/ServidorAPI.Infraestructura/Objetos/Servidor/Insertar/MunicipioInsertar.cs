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
//                 MunicipioInsertar: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.AspNetCore.Http;

namespace ServidorAPI.Infraestructura.Objetos.Servidor.Insertar
{
    public partial class MunicipioInsertar
    {
        public int? EstadoId { get; set; }
        public string? Nombre { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public string? Descripcion { get; set; }
        public IFormFile? Foto { get; set; }
    }
}