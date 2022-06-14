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
//               DetallesPruebas : Creado 14-06-2022
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
    public class DetallesPruebas
    {
        private readonly Faker entidadFalsa = new("es_MX");

        public DetallesPruebas()
        { }

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad ProcesoId

        [Fact]
        public async Task DetallesEditar_ProcesoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                ProcesoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_ProcesoId_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                ProcesoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Proceso Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_ProcesoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                ProcesoId = entidadFalsa.Random.Number(1, 1)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_ProcesoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                ProcesoId = -5
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Proceso Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Nombre

        [Fact]
        public async Task DetallesEditar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_SuperaPrueba_EnviaExcepcionDistintoVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_SuperaPrueba_SiTieneMenos50Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_NoSuperaPruebaYEnviaMensaje_SiTieneMas50Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar { Nombre = "//*" });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_NoSuperaPrueba_SiInciaConNumeros()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = "553"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Nombre_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Descripcion

        [Fact]
        public async Task DetallesEditar_Descripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcion_SuperaPrueba_EnviaExcepcionSiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcion_SuperaPrueba_EnviaExcepcionSiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcio_SuperaPrueba_EnviaExcepcionMayor750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Descripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad DescripcionCorta

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_SuperaPrueba_SiContieneMenos300Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiContieneMas300Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = entidadFalsa.Random.String2(301, 301)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta solo debe tener 300 caracteres, y ha ingresado un total de 301 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                DescripcionCorta = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Objetivo

        [Fact]
        public async Task DetallesEditar_Objetivo_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Objetivo = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad NumeradorDescripcion

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                NumeradorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad DenominadorDescripcion

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                DenominadorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Multiplicador

        [Fact]
        public async Task DetallesEditar_Multiplicador_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Multiplicador = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Multiplicador_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Multiplicador = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Multiplicador no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Multiplicador_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Multiplicador = entidadFalsa.Random.Number(1, 1)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Multiplicador_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Multiplicador = -5
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Multiplicador no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Interpretacion

        [Fact]
        public async Task DetallesEditar_Interpretacion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Interpretacion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesEditar propiedad Periocidad

        [Fact]
        public async Task DetallesEditar_Periocidad_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_SuperaPrueba_SiContieneMenos300Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiContieneMas300Caracteres()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = entidadFalsa.Random.String2(301, 301)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad solo debe tener 300 caracteres, y ha ingresado un total de 301 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesEditar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesEditar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesEditar
            {
                Periocidad = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad ProcesoId

        [Fact]
        public async Task DetallesInsertar_ProcesoId_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                ProcesoId = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_ProcesoId_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                ProcesoId = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Proceso Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_ProcesoId_SuperaPrueba_Mayor0()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                ProcesoId = entidadFalsa.Random.Number(1, 1)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_ProcesoId_SuperaPrueba_LanzaExcepcionMenorIgual0()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.ProcesoId!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                ProcesoId = -5
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Proceso Id no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Nombre

        [Fact]
        public async Task DetallesInsertar_Nombre_SuperaPrueba_DistintoNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_SuperaPrueba_EnviaExcepcionNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_SuperaPrueba_EnviaExcepcionDistintoVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_SuperaPrueba_SiTieneMenos50Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = entidadFalsa.Random.String2(1, 10)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_NoSuperaPruebaYEnviaMensaje_SiTieneMas50Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = entidadFalsa.Random.String2(51, 51)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre solo debe tener 50 caracteres, y ha ingresado un total de 51 caracteresͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar { Nombre = "//*" });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_NoSuperaPrueba_SiInciaConNumeros()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = "553"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Nombre_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Nombre!).NombreReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Nombre = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Nombre contiene caracteres no validosͺ");

            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Descripcion

        [Fact]
        public async Task DetallesInsertar_Descripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcion_SuperaPrueba_EnviaExcepcionSiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcion_SuperaPrueba_EnviaExcepcionSiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcio_SuperaPrueba_EnviaExcepcionMayor750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Descripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Descripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Descripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad DescripcionCorta

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_SuperaPrueba_SiContieneMenos300Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiContieneMas300Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = entidadFalsa.Random.String2(301, 301)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta solo debe tener 300 caracteres, y ha ingresado un total de 301 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DescripcionCorta_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DescripcionCorta!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                DescripcionCorta = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Descripcion Corta contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Objetivo

        [Fact]
        public async Task DetallesInsertar_Objetivo_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Objetivo_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Objetivo!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Objetivo = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Objetivo contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad NumeradorDescripcion

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_NumeradorDescripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.NumeradorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                NumeradorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Numerador Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad DenominadorDescripcion

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_DenominadorDescripcion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.DenominadorDescripcion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                DenominadorDescripcion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Denominador Descripcion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Multiplicador

        [Fact]
        public async Task DetallesInsertar_Multiplicador_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Multiplicador = entidadFalsa.Random.Number(1, 5)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Multiplicador_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Multiplicador = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Multiplicador no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Multiplicador_SuperaPrueba_SiEsMayor0()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Multiplicador = entidadFalsa.Random.Number(1, 1)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Multiplicador_NoSuperaPruebaYEnviaMensaje_SiEsMenorIgual0()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Multiplicador!).Requerido()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Multiplicador = -5
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Multiplicador no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Interpretacion

        [Fact]
        public async Task DetallesInsertar_Interpretacion_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_SuperaPrueba_SiContieneMenos750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiContieneMas750Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = entidadFalsa.Random.String2(751, 751)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion solo debe tener 750 caracteres, y ha ingresado un total de 751 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Interpretacion_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Interpretacion!).DescripcionReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Interpretacion = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Interpretacion contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion

        #region => Pruebas Unitarias al Objeto de Transferencia DetallesInsertar propiedad Periocidad

        [Fact]
        public async Task DetallesInsertar_Periocidad_SuperaPrueba_SiNoEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = "Sadim"
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiEsNulo()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = null
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad no acepta valores nulos o vaciosͺ");

            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiEsVacio()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = " "
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad no acepta valores nulos o vaciosͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_SuperaPrueba_SiContieneMenos300Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = entidadFalsa.Random.String2(1, 20)
            });
            resultado.IsValid.DeberiaSerVerdadero();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiContieneMas300Caracteres()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = entidadFalsa.Random.String2(301, 301)
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad solo debe tener 300 caracteres, y ha ingresado un total de 301 caracteresͺ");
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_NoSuperaPrueba_SiInciaConCaracteresInvalidos()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };

            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            await Task.CompletedTask;
        }

        [Fact]
        public async Task DetallesInsertar_Periocidad_NoSuperaPruebaYEnviaMensaje_SiIniciaConCaracterInvalido()
        {
            var validador = new Validacion<DetallesInsertar>
            {
                v => v.RuleFor(x => x.Periocidad!).TituloReq()
            };
            var resultado = validador.Validate(new DetallesInsertar
            {
                Periocidad = "//*"
            });
            resultado.IsValid.DeberiaSerFalso();
            resultado.Errors.Single().ErrorMessage.DebeSerIgual("El campo Periocidad contiene caracteres no validosͺ");
            await Task.CompletedTask;
        }

        #endregion
    }
}