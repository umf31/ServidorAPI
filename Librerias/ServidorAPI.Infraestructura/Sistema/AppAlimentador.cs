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
//            Sistema AgregarAlimentador: Creado 13-06-2022
//=======================================================================

#endregion

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ServidorAPI.Dominio.Interfaces.Utils;

namespace ServidorAPI.Infraestructura.Sistema
{
    public static class AppAlimentador
    {
        public static IApplicationBuilder UseAlimentador(this IApplicationBuilder app)
        {
            IServiceScopeFactory? scopedFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
            using (var scope = scopedFactory!.CreateScope())
            {
                var alimentador = scope.ServiceProvider.GetService<IAlimentador>();
                alimentador!.CrearSadimDb().Wait();
                alimentador!.InyectarStatus().Wait();
                alimentador!.InyectarCategorias().Wait();
                alimentador!.InyectarServicios().Wait();
                alimentador!.InyectarRoles().Wait();
                alimentador!.InyectarPaises().Wait();
                alimentador!.InyectarEstados().Wait();
                alimentador!.InyectarMunicipios().Wait();
                alimentador!.InyectarAsentamientos().Wait();
                alimentador!.InyectarColonias().Wait();
                alimentador!.InyectarDelegaciones().Wait();
                alimentador!.InyectarUnidadesTipo().Wait();
                alimentador!.InyectarVialidades().Wait();
                alimentador!.InyectarUnidades().Wait();
                alimentador!.InyectarCategoriaServicios().Wait();
                alimentador!.InyectarProcesos().Wait();
                alimentador!.InyectarPeriodos().Wait();
                alimentador!.InyectarDetalles().Wait();
                alimentador!.InyectarMetas().Wait();
            }
            return app;
        }
    }
}