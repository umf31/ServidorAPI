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
//                   IPaginacionSadim: Creado 13-06-2022
//=======================================================================

#endregion

using ServidorAPI.Dominio.Entidades.Sadim;

namespace ServidorAPI.Dominio.Interfaces.Utils
{
    public interface IPagSadim
    {
        IPaginacion<Detalles> Detalles { get; }
        IPaginacion<Meta> Meta { get; }
        IPaginacion<Periodos> Periodo { get; }
        IPaginacion<Proceso> Proceso { get; }
        IPaginacion<Dm01Unidad> Dm01Unidad { get; }
        IPaginacion<Dm02Unidad> Dm02Unidad { get; }
        IPaginacion<Dm04Unidad> Dm04Unidad { get; }
        IPaginacion<Dm05Unidad> Dm05Unidad { get; }
        IPaginacion<Eh01Unidad> Eh01Unidad { get; }
        IPaginacion<Eh02Unidad> Eh02Unidad { get; }
        IPaginacion<Eh04Unidad> Eh04Unidad { get; }
        IPaginacion<CaMama01Unidad> CaMama01Unidad { get; }
        IPaginacion<CaMama02Unidad> CaMama02Unidad { get; }
        IPaginacion<CaMama03Unidad> CaMama03Unidad { get; }
        IPaginacion<CaCu01Unidad> CaCu01Unidad { get; }
        IPaginacion<Materna01Unidad> Materna01Unidad { get; }
        IPaginacion<Materna02Unidad> Materna02Unidad { get; }
        IPaginacion<Materna03Unidad> Materna03Unidad { get; }
        IPaginacion<Materna04Unidad> Materna04Unidad { get; }
        IPaginacion<SOb01Unidad> SOb01Unidad { get; }
        IPaginacion<Caispn01Unidad> Caispn01Unidad { get; }
        IPaginacion<Caispn02Unidad> Caispn02Unidad { get; }
        IPaginacion<Caispn04Unidad> Caispn04Unidad { get; }
        IPaginacion<Caispn05Unidad> Caispn05Unidad { get; }
        IPaginacion<Caispn08Unidad> Caispn08Unidad { get; }
        IPaginacion<Caispn09Unidad> Caispn09Unidad { get; }
        IPaginacion<Caispn14Unidad> Caispn14Unidad { get; }
    }
}