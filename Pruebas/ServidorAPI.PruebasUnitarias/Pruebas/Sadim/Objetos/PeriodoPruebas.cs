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
//               PeriodoPruebas : Creado 14-06-2022
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
    public class PeriodoPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public PeriodoPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia PeriodoEditar propiedad Mes

        [Fact]
        public async void PeriodoEditar_Mes_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };
            var resultado = validador.Validate(new PeriodoEditar
            {
                Mes = entidadFalsa.Random.Number(10, 12).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Mes_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Mes = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Mes no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Mes_NoSuperaPrueba_SiEsVacio()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Mes!).NombreReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Mes = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Mes_SuperaPrueba_SiTiene2Digitos()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Mes = entidadFalsa.Random.Number(10, 12).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Mes_NoSuperaPruebaYEnviaMensaje_SiTieneMas2Digitos()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Mes = entidadFalsa.Random.Number(101, 101).ToString()
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Mes debe tener un formato de 2 digitos y menor a 13 (XX)ͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia PeriodoEditar propiedad Año

        [Fact]
        public async void PeriodoEditar_Año_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };
            var resultado = validador.Validate(new PeriodoEditar
            {
                Año = entidadFalsa.Random.Number(2021, 2022).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Año_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Año = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Año no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Año_NoSuperaPrueba_SiEsVacio()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Año!).NombreReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Año = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Año_SuperaPrueba_SiTiene4Digitos()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Año = entidadFalsa.Random.Number(2021, 2021).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoEditar_Año_NoSuperaPruebaYEnviaMensaje_SiTieneMas4Digitos()
        {
            var validator = new Validacion<PeriodoEditar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoEditar
            {
                Año = entidadFalsa.Random.Number(10101, 10101).ToString()
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Año debe tener un formato de 4 digitos (XXXX)ͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia PeriodoInsertar propiedad Mes

        [Fact]
        public async void PeriodoInsertar_Mes_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };
            var resultado = validador.Validate(new PeriodoInsertar
            {
                Mes = entidadFalsa.Random.Number(10, 12).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Mes_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Mes = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Mes no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Mes_NoSuperaPrueba_SiEsVacio()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Mes!).NombreReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Mes = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Mes_SuperaPrueba_SiTiene2Digitos()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Mes = entidadFalsa.Random.Number(10, 12).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Mes_NoSuperaPruebaYEnviaMensaje_SiTieneMas2Digitos()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Mes!).MesReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Mes = entidadFalsa.Random.Number(101, 101).ToString()
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Mes debe tener un formato de 2 digitos y menor a 13 (XX)ͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia PeriodoInsertar propiedad Año

        [Fact]
        public async void PeriodoInsertar_Año_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };
            var resultado = validador.Validate(new PeriodoInsertar
            {
                Año = entidadFalsa.Random.Number(2021, 2022).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Año_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Año = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Año no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Año_NoSuperaPrueba_SiEsVacio()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Año!).NombreReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Año = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Año_SuperaPrueba_SiTiene4Digitos()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Año = entidadFalsa.Random.Number(2021, 2021).ToString()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task PeriodoInsertar_Año_NoSuperaPruebaYEnviaMensaje_SiTieneMas4Digitos()
        {
            var validator = new Validacion<PeriodoInsertar>
            {
                v => v.RuleFor(x => x.Año!).AñoReq()
            };

            var resultado = validator.Validate(new PeriodoInsertar
            {
                Año = entidadFalsa.Random.Number(10101, 10101).ToString()
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Año debe tener un formato de 4 digitos (XXXX)ͺ");

            await Task.CompletedTask;
        }

        #endregion
    }
}