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
//                    MetaPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Sadim.Editar;
using ServidorAPI.Infraestructura.Objetos.Sadim.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Sadim.Objetos
{
    public class MetaPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public MetaPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad DetallesId

        [Fact]
        public async Task MetaEditar_DetallesId_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                DetallesId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_DetallesId_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                DetallesId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Detalles Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_DetallesId_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                DetallesId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_DetallesId_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar { DetallesId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Detalles Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad PeriodoId

        [Fact]
        public async Task MetaEditar_PeriodoId_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                PeriodoId = entidadFalsa.Random.Number(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_PeriodoId_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                PeriodoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periodo Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_PeriodoId_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                PeriodoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_PeriodoId_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar { PeriodoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periodo Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad RendimientoEsperado

        [Fact]
        public async void MetaEditar_RendimientoEsperado_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Esperado no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Esperado es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoEsperado_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoEsperado = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Esperado es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad RendimientoBajo

        [Fact]
        public async void MetaEditar_RendimientoBajo_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Bajo no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Bajo es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoBajo_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoBajo = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Bajo es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad RendimientoLimite

        [Fact]
        public async void MetaEditar_RendimientoLimite_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Limite no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Limite es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoLimite_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoLimite = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Limite es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad RendimientoMedio

        [Fact]
        public async void MetaEditar_RendimientoMedio_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Medio no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Medio es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaEditar_RendimientoMedio_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                RendimientoMedio = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Medio es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaEditar propiedad ValorReferencia

        [Fact]
        public async Task MetaEditar_ValorReferencia_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                ValorReferencia = entidadFalsa.Random.String2(3, 7)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_ValorReferencia_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                ValorReferencia = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Valor Referencia no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_ValorReferencia_SuperaPrueba_SiNoEsVacio()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                ValorReferencia = ">=0"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaEditar_ValorReferencia_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<MetaEditar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaEditar
            {
                ValorReferencia = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Valor Referencia no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad DetallesId

        [Fact]
        public async Task MetaInsertar_DetallesId_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                DetallesId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_DetallesId_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                DetallesId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Detalles Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_DetallesId_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                DetallesId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_DetallesId_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.DetallesId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar { DetallesId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Detalles Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad PeriodoId

        [Fact]
        public async Task MetaInsertar_PeriodoId_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                PeriodoId = entidadFalsa.Random.Number(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_PeriodoId_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                PeriodoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periodo Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_PeriodoId_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                PeriodoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_PeriodoId_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.PeriodoId!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar { PeriodoId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periodo Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad RendimientoEsperado

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Esperado no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Esperado es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoEsperado_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoEsperado!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoEsperado = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Esperado es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad RendimientoBajo

        [Fact]
        public async void MetaInsertar_RendimientoBajo_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Bajo no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Bajo es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoBajo_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoBajo!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoBajo = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Bajo es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad RendimientoLimite

        [Fact]
        public async void MetaInsertar_RendimientoLimite_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Limite no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Limite es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoLimite_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoLimite!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoLimite = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Limite es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad RendimientoMedio

        [Fact]
        public async void MetaInsertar_RendimientoMedio_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = 98.25M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = null
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Rendimiento Medio no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_SuperaPruebaSiEsMayorIgual100negativo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = -100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_SuperaPruebaSiEMenor100()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = 100.00M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_NoSuperaPruebaYEnviaMensajeSiRangoEsIncorrecto()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = 180
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Medio es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_SuperaPrueba_SiContiene2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };

            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = 21.71M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void MetaInsertar_RendimientoMedio_NoSuperaPruebaYEnviaMensaje_SicontieneMas2decimales()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.RendimientoMedio!).ValorRefenciaReq()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                RendimientoMedio = -99.3256854M
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El valor del campo Rendimiento Medio es un número de -100.00 a 100.00 con dos decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia MetaInsertar propiedad ValorReferencia

        [Fact]
        public async Task MetaInsertar_ValorReferencia_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                ValorReferencia = entidadFalsa.Random.String2(3, 7)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_ValorReferencia_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                ValorReferencia = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Valor Referencia no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_ValorReferencia_SuperaPrueba_SiNoEsVacio()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                ValorReferencia = ">=0"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task MetaInsertar_ValorReferencia_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<MetaInsertar>
            {
                v => v.RuleFor(x => x.ValorReferencia!).Requerido()
            };
            var resultado = validador.Validate(new MetaInsertar
            {
                ValorReferencia = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Valor Referencia no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion
    }
}