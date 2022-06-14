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
//               AsentamientoPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Servidor.Objetos
{
    public class AsentamientoPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public AsentamientoPruebas()
        { }

        #region => Pruebas Unitarias al objeto de transferencia AsentamientoEditar propiedad Nombre

        [Fact]
        public async void AsentamientoEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new AsentamientoEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new AsentamientoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new AsentamientoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<AsentamientoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia AsentamientoInsertar propiedad Nombre

        [Fact]
        public async void AsentamientoInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new AsentamientoInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new AsentamientoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new AsentamientoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task AsentamientoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<AsentamientoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new AsentamientoInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion
    }
}