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
//                 EmpleadoPruebas : Creado 14-06-2022
//=======================================================================

#endregion

using Bogus;
using Microsoft.AspNetCore.Http;
using ServidorAPI.Infraestructura.Filtros.FluentValidator.Utils;
using ServidorAPI.Infraestructura.Objetos.Servidor.Editar;
using ServidorAPI.Infraestructura.Objetos.Servidor.Insertar;
using ServidorAPI.PruebasUnitarias.Utils;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ServidorAPI.PruebasUnitarias.Pruebas.Servidor.Objetos
{
    public class EmpleadoPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public EmpleadoPruebas()
        { }

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Matricula

        [Fact]
        public async void EmpleadoEditar_Matricula_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Matricula = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_DistintoVacio()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_EnviaExcepcionVacio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Matricula = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_ValorNumerico()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_EnviaExcepcionDistintoNumerico()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Matricula = "simon"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula debe ser númerica dígitos de 0-9ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Matricula_SuperaPrueba_EnviaExcepcionMenorIgual0()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Matricula = "-1"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula debe ser númerica dígitos de 0-9ͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Email

        [Fact]
        public async Task EmpleadoEditar_Email_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Email = "sadim@imss.com"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void EmpleadoEditar_Email_SuperaPrueba_DistintoVacio()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Email_SuperaPrueba_EnviaExcepcionVacio()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validador.Validate(new EmpleadoEditar
            {
                Email = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async void EmpleadoEditar_Email_SuperaPrueba_FormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Email_SuperaPrueba_EnviaExcepcionFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validador.Validate(new EmpleadoEditar
            {
                Email = entidadFalsa.Person.FullName
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email tiene un formato de correo electronico invalidoͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad ApellidoPaterno

        [Fact]
        public async void EmpleadoEditar_ApellidoPaterno_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { ApellidoPaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { ApellidoPaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoPaterno = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad ApellidoMaterno

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoMaterno = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoMaterno = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { ApellidoMaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoMaterno = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { ApellidoMaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                ApellidoMaterno = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Nombre

        [Fact]
        public async void EmpleadoEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoEditar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoEditar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad CategoriaId

        [Fact]
        public async Task EmpleadoEditar_CategoriaId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                CategoriaId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_CategoriaId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                CategoriaId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Categoria Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_CategoriaId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                CategoriaId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_CategoriaId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar { CategoriaId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Categoria Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad ServicioId

        [Fact]
        public async Task EmpleadoEditar_ServicioId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ServicioId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ServicioId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ServicioId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Servicio Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ServicioId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ServicioId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ServicioId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar { ServicioId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Servicio Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad ColoniaId

        [Fact]
        public async Task EmpleadoEditar_ColoniaId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ColoniaId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ColoniaId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ColoniaId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Colonia Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ColoniaId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                ColoniaId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_ColoniaId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar { ColoniaId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Colonia Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad VialidadId

        [Fact]
        public async Task EmpleadoEditar_VialidadId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                VialidadId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_VialidadId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                VialidadId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Vialidad Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_VialidadId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                VialidadId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_VialidadId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoEditar { VialidadId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Vialidad Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad Calle

        [Fact]
        public async Task EmpleadoEditar_Calle_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Calle = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Calle_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Calle = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Calle no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Calle_SuperaPrueba_Menos150Caracteres()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };

            var resultado = validador.Validate(new EmpleadoEditar
            {
                Calle = entidadFalsa.Random.String2(25, 25)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Calle_SuperaPrueba_EnviaExcepcionMayor150Caracteres()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Calle = entidadFalsa.Random.String2(151, 151)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Calle solo debe tener 150 caracteres, y ha ingresado un total de 151 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad Numero

        [Fact]
        public async Task EmpleadoEditar_Numero_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Numero = "125"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Numero_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Numero = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numero no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Numero_SuperaPrueba_Menor6Caracteres()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };

            var resultado = validador.Validate(new EmpleadoEditar
            {
                Numero = entidadFalsa.Random.String2(3, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Numero_SuperaPrueba_EnviaExcepcionMayor6Caracteres()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Numero = entidadFalsa.Random.String2(7, 7)
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numero solo debe tener 6 caracteres, y ha ingresado un total de 7 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoEditar propiedad Telefono

        [Fact]
        public async Task EmpleadoEditar_TelefonoEditar_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("(###) ###-####")
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_TelefonoEditar_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Telefono = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Telefono no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_TelefonoEditar_SuperaPrueba_FormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("(###) ###-####")
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_TelefonoEditar_SuperaPrueba_LanzaExcepcionFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("#########")
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Telefono debe tener un formato (XXX) XXX-XXXX donde X es un dígito de 0-9ͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Latitud

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new EmpleadoEditar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Longitud

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new EmpleadoEditar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoEditar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoEditar propiedad Foto

        [Fact]
        public async Task EmpleadoEditar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoEditar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<EmpleadoEditar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoEditar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Matricula

        [Fact]
        public async void EmpleadoInsertar_Matricula_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Matricula = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_DistintoVacio()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_EnviaExcepcionVacio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Matricula = ""
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_ValorNumerico()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Matricula = "10716076"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_EnviaExcepcionDistintoNumerico()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Matricula = "simon"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula debe ser númerica dígitos de 0-9ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Matricula_SuperaPrueba_EnviaExcepcionMenorIgual0()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Matricula!).MatriculaReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Matricula = "-1"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Matricula debe ser númerica dígitos de 0-9ͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Email

        [Fact]
        public async Task EmpleadoInsertar_Email_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Email = "sadim@imss.com"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async void EmpleadoInsertar_Email_SuperaPrueba_DistintoVacio()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Email_SuperaPrueba_EnviaExcepcionVacio()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Email = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async void EmpleadoInsertar_Email_SuperaPrueba_FormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Email = entidadFalsa.Person.Email
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Email_SuperaPrueba_EnviaExcepcionFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Email!).EmailReq()
            };

            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Email = entidadFalsa.Person.FullName
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Email tiene un formato de correo electronico invalidoͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad ApellidoPaterno

        [Fact]
        public async void EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { ApellidoPaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { ApellidoPaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoPaterno_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoPaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoPaterno = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Paterno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad ApellidoMaterno

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoMaterno = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoMaterno = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { ApellidoMaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoMaterno = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { ApellidoMaterno = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ApellidoMaterno_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ApellidoMaterno!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                ApellidoMaterno = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Apellido Materno contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Nombre

        [Fact]
        public async void EmpleadoInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Nombre = entidadFalsa.Address.City()
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_DistintoVacio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_Limite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionLimite50Caracteres()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneCaracteresInvalidos()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_NoContieneCaracteresNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var result = validator.Validate(new EmpleadoInsertar { Nombre = "calle" });
            result.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Nombre_SuperaPrueba_LanzaExcepcionContieneNumerosInicio()
        {
            var validator = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validator.Validate(new EmpleadoInsertar
            {
                Nombre = "587"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad CategoriaId

        [Fact]
        public async Task EmpleadoInsertar_CategoriaId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                CategoriaId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_CategoriaId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                CategoriaId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Categoria Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_CategoriaId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                CategoriaId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_CategoriaId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.CategoriaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { CategoriaId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Categoria Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad ServicioId

        [Fact]
        public async Task EmpleadoInsertar_ServicioId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ServicioId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ServicioId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ServicioId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Servicio Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ServicioId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ServicioId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ServicioId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ServicioId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { ServicioId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Servicio Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad VialidadId

        [Fact]
        public async Task EmpleadoInsertar_VialidadId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                VialidadId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_VialidadId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                VialidadId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Vialidad Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_VialidadId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                VialidadId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_VialidadId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.VialidadId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { VialidadId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Vialidad Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad Calle

        [Fact]
        public async Task EmpleadoInsertar_Calle_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Calle = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Calle_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Calle = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Calle no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Calle_SuperaPrueba_Menos150Caracteres()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };

            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Calle = entidadFalsa.Random.String2(25, 25)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Calle_SuperaPrueba_EnviaExcepcionMayor150Caracteres()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Calle!).CalleReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Calle = entidadFalsa.Random.String2(151, 151)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Calle solo debe tener 150 caracteres, y ha ingresado un total de 151 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad Numero

        [Fact]
        public async Task EmpleadoInsertar_Numero_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Numero = "125"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Numero_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Numero = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numero no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Numero_SuperaPrueba_Menor6Caracteres()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };

            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Numero = entidadFalsa.Random.String2(3, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Numero_SuperaPrueba_EnviaExcepcionMayor6Caracteres()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Numero!).NumDomicilioReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Numero = entidadFalsa.Random.String2(7, 7)
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numero solo debe tener 6 caracteres, y ha ingresado un total de 7 caracteresͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad ColoniaId

        [Fact]
        public async Task EmpleadoInsertar_ColoniaId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ColoniaId = 1
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ColoniaId_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ColoniaId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Colonia Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ColoniaId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                ColoniaId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_ColoniaId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.ColoniaId!).Requerido()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { ColoniaId = -5 });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Colonia Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia EmpleadoInsertar propiedad Telefono

        [Fact]
        public async Task EmpleadoInsertar_TelefonoInsertar_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("(###) ###-####")
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_TelefonoInsertar_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Telefono = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Telefono no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_TelefonoInsertar_SuperaPrueba_FormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("(###) ###-####")
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_TelefonoInsertar_SuperaPrueba_LanzaExcepcionFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Telefono!).TelefonoReq()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Telefono = entidadFalsa.Phone.PhoneNumber("#########")
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Telefono debe tener un formato (XXX) XXX-XXXX donde X es un dígito de 0-9ͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Latitud

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = null, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_ValorEntre90yMenos90Grados()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = 25.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = -99.325685M, Longitud = -102.358061M });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe estar entre -90 <-> 90 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };

            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Latitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Latitud!).Latitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Latitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Latitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Longitud

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Latitud = 23.125463M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionNulo()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Latitud = 23.325874M,
                Longitud = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_ValorEntre180yMenos180Grados()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Latitud = 25.325685M,
                Longitud = -102.358061M
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionValorInvalido()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Latitud = 29.325685M,
                Longitud = -230.358061M
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe estar entre -180 <-> 180 gradosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_Contiene6Decimales()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };

            var resultado = validador.Validate(new EmpleadoInsertar { Longitud = 21.711213M });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionDistinto6Decimales()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Longitud_SuperaPrueba_LanzaExcepcionObligatorio2Coordenadas()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                v => v.RuleFor(x => x.Longitud!).Longitud()
            };
            var resultado = validador.Validate(new EmpleadoInsertar { Longitud = -99.3256854M });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Longitud debe contener maximo 3 enteros entre -180 y 180 y 6 decimalesͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al objeto de transferencia EmpleadoInsertar propiedad Foto

        [Fact]
        public async Task EmpleadoInsertar_Foto_SuperaPrueba_FotoFormatoCorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Foto_SuperaPrueba_LanzaExcepcionFotoFormatoIncorrecto()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.json");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.json"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/json",
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Foto_SuperaPrueba_ArchivoMenor2Mb()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Foto = archivo
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task EmpleadoInsertar_Foto_SuperaPrueba_LanzaExepcionArchivoMayor2Mb()
        {
            var validador = new Validacion<EmpleadoInsertar>
            {
                 v => v.RuleFor(x => x.Foto!).SetValidator(new ValidacionImagen())
            };
            using var stream = File.OpenRead(@"./no-disponible2.png");
            var archivo = new FormFile(stream, 0, stream.Length, null!, Path.GetFileName(@"./no-disponible2.png"))
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/png",
            };
            var resultado = validador.Validate(new EmpleadoInsertar
            {
                Foto = archivo
            });
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ");
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        #endregion
    }
}