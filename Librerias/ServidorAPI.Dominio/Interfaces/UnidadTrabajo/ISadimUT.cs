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
//                     ISadimUT: Creado 14-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Interfaces.Asistente.Sadim;
using ServidorAPI.Dominio.Interfaces.Asistente.Servidor;

namespace ServidorAPI.Dominio.Interfaces.UnidadTrabajo
{
    public interface ISadimUT : IDisposable
    {
        IAsistenteEmpleado AsistenteEmpleado { get; }
        IAsistenteProceso AsistenteProceso { get; }
        IAsistentePeriodo AsistentePeriodo { get; }
        IAsistenteDetalle AsistenteDetalle { get; }
        IAsistenteMeta AsistenteMeta { get; }
        IAsistenteDm01Unidad AsistenteDm01Unidad { get; }
        IAsistenteDm02Unidad AsistenteDm02Unidad { get; }
        IAsistenteDm04Unidad AsistenteDm04Unidad { get; }
        IAsistenteDm05Unidad AsistenteDm05Unidad { get; }
        IAsistenteEh01Unidad AsistenteEh01Unidad { get; }
        IAsistenteEh02Unidad AsistenteEh02Unidad { get; }
        IAsistenteEh04Unidad AsistenteEh04Unidad { get; }
        IAsistenteCaMama01Unidad AsistenteCaMama01Unidad { get; }
        IAsistenteCaMama02Unidad AsistenteCaMama02Unidad { get; }
        IAsistenteCaMama03Unidad AsistenteCaMama03Unidad { get; }
        IAsistenteCaCu01Unidad AsistenteCaCu01Unidad { get; }
        IAsistenteMaterna01Unidad AsistenteMaterna01Unidad { get; }
        IAsistenteMaterna02Unidad AsistenteMaterna02Unidad { get; }
        IAsistenteMaterna03Unidad AsistenteMaterna03Unidad { get; }
        IAsistenteMaterna04Unidad AsistenteMaterna04Unidad { get; }
        IAsistenteSOb01Unidad AsistenteSOb01Unidad { get; }
        IAsistenteCaispn01Unidad AsistenteCaispn01Unidad { get; }
        IAsistenteCaispn02Unidad AsistenteCaispn02Unidad { get; }
        IAsistenteCaispn04Unidad AsistenteCaispn04Unidad { get; }
        IAsistenteCaispn05Unidad AsistenteCaispn05Unidad { get; }
        IAsistenteCaispn08Unidad AsistenteCaispn08Unidad { get; }
        IAsistenteCaispn09Unidad AsistenteCaispn09Unidad { get; }
        IAsistenteCaispn14Unidad AsistenteCaispn14Unidad { get; }

        Task GuardarServidorAPI();
    }
}