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
//                  CrearIndicador: Creado 16-06-2022
//=======================================================================

#endregion


using ServidorAPI.Dominio.Entidades.Sadim;
using ServidorAPI.Dominio.Interfaces.UnidadTrabajo;
using ServidorAPI.Dominio.Interfaces.Utils;
using ServidorAPI.Dominio.Servicios.Informacion;

namespace ServidorAPI.Logica.Utils
{
    public class CrearIndicador : ICrearIndicador
    {
        private readonly ISadimUT uts;
        public CrearIndicador(ISadimUT _uts)
        {
            uts = _uts;
        }

        public async Task<List<Dm01Unidad>> CrearDM01(List<Dm01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.DM01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteDm01Unidad.ObtenerFechaCorte();
            var prevM45_59 = Indicadores.Prevalencia.DMPrevM45_59;
            var prevH45_59 = Indicadores.Prevalencia.DMPrevH45_59;
            var prevAM = Indicadores.Prevalencia.DMprevAM;

            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteDm01Unidad.ObtenerCP02_IMCP_08M(periodo);
                var cp02_09h = await uts.AsistenteDm01Unidad.ObtenerCP02_IMCP_09H(periodo);
                var cp02_10y = await uts.AsistenteDm01Unidad.ObtenerCP02_IMCP_10Y(periodo);
                var cp03Incon_DmHta = await uts.AsistenteDm01Unidad.ObtenerCP03_INCOM_DMHTA(periodo);
                var numerador = cp03Incon_DmHta.Diabetes20A44M + cp03Incon_DmHta.Diabetes20A44H + cp02_08m.DetDiabetes4559M + cp02_09h.DetDiabetes4559H + cp02_10y.DetDiabetes60;
                var denominador = cp03Incon_DmHta.Pob20A44M + cp03Incon_DmHta.Pob20A44H + cp02_08m.PobM4559 * prevM45_59 + cp02_09h.PobH4559 * prevH45_59 + cp02_10y.Adultos60 * prevAM;
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.Poblacion = Convert.ToDecimal(cp03Incon_DmHta.Pob20A44M + cp03Incon_DmHta.Pob20A44H + cp02_08m.PobM4559  + cp02_09h.PobH4559 + cp02_10y.Adultos60);
                item.Prevalencia = item.Poblacion - Convert.ToDecimal(denominador);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Dm02Unidad>> CrearDM02(List<Dm02Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.DM02;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteDm02Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp04Imcp20 = await uts.AsistenteDm02Unidad.ObtenerCP04_IMCP20(periodo);
                var numerador = Convert.ToDecimal(cp04Imcp20.DmSospechaConfirmados20);
                var denominador = Convert.ToDecimal(cp04Imcp20.DiabetesMesSospecha20);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Dm04Unidad>> CrearDM04(List<Dm04Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.DM04;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteDm04Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var in23 = await uts.AsistenteDm04Unidad.ObtenerIN23(periodo);
                var numerador = Convert.ToDecimal(in23.PacDm2Glucosa13020ymas);
                var denominador = Convert.ToDecimal(in23.PacDm220ymasAtendidos);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Dm05Unidad>> CrearDM05(List<Dm05Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.DM05;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteDm05Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var in23 = await uts.AsistenteDm05Unidad.ObtenerIN23(periodo);
                var numerador = Convert.ToDecimal(in23.PacDm2Tension1308020ymas);
                var denominador = Convert.ToDecimal(in23.PacDm220ymasAtendidos);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Eh01Unidad>> CrearEH01(List<Eh01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.EH01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var prevMujeres = Indicadores.Prevalencia.EHPrevM30_59;
            var prevHombres = Indicadores.Prevalencia.EHPrevH30_59;
            var prevAdultos = Indicadores.Prevalencia.EHprevAM;
            var fechaCorte = await uts.AsistenteEh01Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteEh01Unidad.ObtenerCP02_IMCP_08M(periodo);
                var cp02_09h = await uts.AsistenteEh01Unidad.ObtenerCP02_IMCP_09H(periodo);
                var cp02_10y = await uts.AsistenteEh01Unidad.ObtenerCP02_IMCP_10Y(periodo);
                var cp03Incon_DmHta = await uts.AsistenteEh01Unidad.ObtenerCP03_INCOM_DMHTA(periodo);
                var numerador = cp03Incon_DmHta.Hipertension20A29M + cp03Incon_DmHta.Hipertension20A29H + cp02_08m.DetHipertension3059M + cp02_09h.DetHipertension3059H + cp02_10y.DetHipertension60;
                var denominador = cp03Incon_DmHta.Pob20A29M + cp03Incon_DmHta.Pob20A29H + cp02_08m.PobM3059 * prevMujeres + cp02_09h.PobH3059 * prevHombres + cp02_10y.Adultos60 * prevAdultos;
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.Poblacion = Convert.ToDecimal(cp03Incon_DmHta.Pob20A29M + cp03Incon_DmHta.Pob20A29M + cp02_08m.PobM3059  + cp02_09h.PobH3059 + cp02_10y.Adultos60);
                item.Prevalencia = item.Poblacion - Convert.ToDecimal(denominador);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Eh02Unidad>> CrearEH02(List<Eh02Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.EH02;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteEh02Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp04Imcp20 = await uts.AsistenteEh02Unidad.ObtenerCP04_IMCP20(periodo);
                var numerador = Convert.ToDecimal(cp04Imcp20.HtaSospechaConfirmados20);
                var denominador = Convert.ToDecimal(cp04Imcp20.HipertensionMesSospecha20);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Eh04Unidad>> CrearEH04(List<Eh04Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.EH04;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteEh04Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var in22 = await uts.AsistenteEh04Unidad.ObtenerIN16(periodo);
                var numerador = Convert.ToDecimal(in22.PacHtaTension1409020ymas);
                var denominador = Convert.ToDecimal(in22.PacHta20ymasAtendidos);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<CaMama01Unidad>> CrearCAMA01(List<CaMama01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CaMama01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaMama01Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp03_OtrasCob = await uts.AsistenteCaMama01Unidad.ObtenerCP03_INCOM_OtrasCob(periodo);
                var numerador = Convert.ToDecimal(cp03_OtrasCob.Masto40A49);
                var denominador = Convert.ToDecimal(cp03_OtrasCob.Pob40A49M);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.Poblacion = Convert.ToDecimal(denominador);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = item.Poblacion;
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<CaMama02Unidad>> CrearCAMA02(List<CaMama02Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CaMama02;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaMama02Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteCaMama02Unidad.ObtenerCP02_IMCP_08M(periodo);
                var numerador = Convert.ToDecimal(cp02_08m.DetMastografia5069);
                var denominador = Convert.ToDecimal(cp02_08m.PobM5069);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<CaMama03Unidad>> CrearCAMA03(List<CaMama03Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CaMama03;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaMama03Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteCaMama03Unidad.ObtenerCP02_IMCP_08M(periodo);
                var numerador = Convert.ToDecimal(cp02_08m.MastografiaMesSospecha5069);
                var denominador = Convert.ToDecimal(cp02_08m.MastografiaMes5069);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<CaCu01Unidad>> CrearCACU01(List<CaCu01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CaCu01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaCu01Unidad.ObtenerFechaCorte();
            var cacuPrev = Indicadores.Prevalencia.CACUPrev;
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteCaCu01Unidad.ObtenerCP02_IMCP_08M(periodo);


                var numerador = Convert.ToDecimal(cp02_08m.DetCaCu2564);

                var denominador = Convert.ToDecimal(cp02_08m.PobM2564 * cacuPrev);


                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Poblacion = Convert.ToDecimal(cp02_08m.PobM2564);
                item.Prevalencia = Convert.ToDecimal(cp02_08m.PobM2564 * cacuPrev);
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador =item.Poblacion - denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Materna01Unidad>> CrearMaterna01(List<Materna01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.Materna01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteMaterna01Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var mt03_vigmat = await uts.AsistenteMaterna01Unidad.ObtenerMT03_ProporcionEmbarazadas(periodo);
                var numerador = Convert.ToDecimal(mt03_vigmat.Gpo1014acum) + Convert.ToDecimal(mt03_vigmat.Gpo1519acum);
                var denominador = Convert.ToDecimal(mt03_vigmat.TotalAcum);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total <= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total < metas.RendimientoBajo && item.Total > metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Materna02Unidad>> CrearMaterna02(List<Materna02Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.Materna02;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteMaterna02Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var mt03_vigmatOportunidad = await uts.AsistenteMaterna02Unidad.ObtenerMT03_OportunidadVigilanciaPrenatal(periodo);
                var mt03_vigmatProporcion = await uts.AsistenteMaterna02Unidad.ObtenerMT03_ProporcionEmbarazadas(periodo);
                var numerador = Convert.ToDecimal(mt03_vigmatOportunidad.TotalAcum);
                var denominador = Convert.ToDecimal(mt03_vigmatProporcion.TotalAcum);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Materna03Unidad>> CrearMaterna03(List<Materna03Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.Materna03;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteMaterna03Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var mt03_vigmatOportunidad = await uts.AsistenteMaterna03Unidad.ObtenerMT03_AtencionesEmbarazadas(periodo);
                var mt03_vigmatProporcion = await uts.AsistenteMaterna03Unidad.ObtenerMT03_ProporcionEmbarazadas(periodo);
                var numerador = Convert.ToDecimal(mt03_vigmatOportunidad.TotalAcum);
                var denominador = Convert.ToDecimal(mt03_vigmatProporcion.TotalAcum);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100; }
                else { item.Total = item.Numerador / item.Denominador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador  * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Materna04Unidad>> CrearMaterna04(List<Materna04Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.Materna04;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteMaterna04Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var mt01_embGenUri = await uts.AsistenteMaterna04Unidad.ObtenerMT01_EmabarzadasInfeccionGen(periodo);
                var mt01_embConsPrimera = await uts.AsistenteMaterna04Unidad.ObtenerMT01_ConsultasPrimeraVez(periodo);
                var numerador = Convert.ToDecimal(mt01_embGenUri.Total);
                var denominador = Convert.ToDecimal(mt01_embConsPrimera.Total);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100 * item.Multiplicador; }
                else { item.Total = item.Numerador / item.Denominador * item.Multiplicador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado && item.Total < metas.RendimientoMedio) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else if (item.Total >= metas.RendimientoMedio && item.Total < metas.RendimientoLimite) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<SOb01Unidad>> CrearSOb01(List<SOb01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.SOb01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteSOb01Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp02_08m = await uts.AsistenteSOb01Unidad.ObtenerCP02_IMCP_08M(periodo);
                var cp02_09h = await uts.AsistenteSOb01Unidad.ObtenerCP02_IMCP_09H(periodo);
                var cp02_10y = await uts.AsistenteSOb01Unidad.ObtenerCP02_IMCP_10Y(periodo);
                var numerador = cp02_08m.PesoYtalla2059M + cp02_09h.PesoYtalla2059H + cp02_10y.PesoYtalla60;
                var denominador = cp02_08m.AdultosM2059 + cp02_09h.AdultosH2059 + cp02_10y.Adultos60;
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.Poblacion = Convert.ToDecimal(denominador);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = Convert.ToDecimal(numerador);
                item.Denominador = Convert.ToDecimal(denominador);
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn01Unidad>> CrearCAISPN01(List<Caispn01Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN01;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn01Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cipPrevenIMSS = await uts.AsistenteCaispn01Unidad.ObtenerCIP01_PrevenIMSS(periodo);
                var numerador = Convert.ToDecimal(cipPrevenIMSS.DhAip);
                var denominador = Convert.ToDecimal(cipPrevenIMSS.TotalPob);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn02Unidad>> CrearCAISPN02(List<Caispn02Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN02;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn02Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var iap_01Api = await uts.AsistenteCaispn02Unidad.ObtenerIAP01_ProductividadAPI(periodo);
                var numerador = Convert.ToDecimal(iap_01Api.Api);
                var denominador = Convert.ToDecimal(iap_01Api.DiasTrab);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100; }
                else { item.Total = item.Numerador / item.Denominador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador  * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn04Unidad>> CrearCAISPN04(List<Caispn04Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN04;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn04Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var cp03_cobvac = await uts.AsistenteCaispn04Unidad.ObtenerCP03_INCOM_CobVac(periodo);
                var numerador = Convert.ToDecimal(cp03_cobvac.De1año);
                var denominador = Convert.ToDecimal(cp03_cobvac.Ofide1año);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                if (item.Total > 100.00M) { item.Total = 100.00M; }
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn05Unidad>> CrearCAISPN05(List<Caispn05Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN05;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn05Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var iap_01Api = await uts.AsistenteCaispn05Unidad.ObtenerIAP01_ProductividadAPI_EEMF(periodo);
                var numerador = Convert.ToDecimal(iap_01Api.Api);
                var denominador = Convert.ToDecimal(iap_01Api.DiasTrab);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100; }
                else { item.Total = item.Numerador / item.Denominador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador  * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn08Unidad>> CrearCAISPN08(List<Caispn08Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN08;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn08Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var in08 = await uts.AsistenteCaispn08Unidad.ObtenerIN08_Indicador_03(periodo);
                var numerador = Convert.ToDecimal(in08.TotalDhReferidos);
                var denominador = Convert.ToDecimal(in08.TotalConsultas);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                item.Multiplicador = indicadorTipo.Multiplicador;
                item.Total = item.Numerador / item.Denominador * item.Multiplicador;
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador / item.Multiplicador * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                if (item.Total > 100.00M) { item.Total = 100.00M; }
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn09Unidad>> CrearCAISPN09(List<Caispn09Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN09;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn09Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var pu01_ParteUno = await uts.AsistenteCaispn09Unidad.ObtenerPU01_ParteUno(periodo);
                var numerador = Convert.ToDecimal(pu01_ParteUno.TotalConsul);
                var denominador = Convert.ToDecimal(pu01_ParteUno.HorasTrab);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100; }
                else { item.Total = item.Numerador / item.Denominador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador  * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }

        public async Task<List<Caispn14Unidad>> CrearCAISPN14(List<Caispn14Unidad> indicador, string matricula)
        {
            var indicadorNombre = Indicadores.Nombre.CAISPN14;
            var indicadorTipo = await uts.AsistenteDetalle.ObtenerPorNombre(indicadorNombre);
            var fechaCorte = await uts.AsistenteCaispn14Unidad.ObtenerFechaCorte();
            foreach (var item in indicador)
            {
                string periodo = item.Periodo;
                var periodoEntidad = await uts.AsistentePeriodo.ObtenerPorPeriodo(periodo);
                var pu01_ParteUno = await uts.AsistenteCaispn14Unidad.ObtenerPU01_ParteUno(periodo);
                var numerador = Convert.ToDecimal(pu01_ParteUno.TotalConsul);
                var denominador = Convert.ToDecimal(pu01_ParteUno.HorasTrab);
                var metas = await uts.AsistenteMeta.ObtenerPorPeriodoId(indicadorTipo.Id, periodoEntidad.Id);
                item.PeriodoId = periodoEntidad.Id;
                item.Nombre = indicadorNombre;
                item.FechaInicio = periodoEntidad.FechaInicio;
                item.FechaTermino = periodoEntidad.FechaTermino;
                item.Numerador = numerador;
                item.Denominador = denominador;
                if (numerador == 0 || denominador == 0) { item.Total = 0 / 100; }
                else { item.Total = item.Numerador / item.Denominador; }
                item.FechaCorte = Convert.ToDateTime(fechaCorte.FechaInicial);
                item.ValorReferencia = metas.RendimientoEsperado;
                if (item.Total >= metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Alto; }
                else if (item.Total > metas.RendimientoBajo && item.Total < metas.RendimientoEsperado) { item.Rendimiento = Indicadores.Rend.Medio; }
                else { item.Rendimiento = Indicadores.Rend.Bajo; }
                item.Meta = item.Denominador  * metas.RendimientoEsperado;
                item.DiferenciaMeta = item.Numerador - item.Meta;
                item.FechaCreacion = DateTime.Now;
                item.FechaModificacion = DateTime.Now;
                item.UsuarioMod = matricula;
                item.StatusId = 1;
            }
            return indicador;
        }
    }
}
