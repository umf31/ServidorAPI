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
//               CategoriaPruebas : Creado 14-06-2022
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
    public class CategoriaPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public CategoriaPruebas()
        { }

        #region => Pruebas Unitarias al objeto de transferencia CategoriaEditar propiedad Nombre

        [Fact]
        public async void CategoriaEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new CategoriaEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new CategoriaEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new CategoriaEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<CategoriaEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia CategoriaInsertar propiedad Nombre

        [Fact]
        public async void CategoriaInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new CategoriaInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new CategoriaInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new CategoriaInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task CategoriaInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<CategoriaInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new CategoriaInsertar
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