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
//               https://github.com/umf31/ServidorAPI
//                Modulo Información: Creado 13-06-2022
//=======================================================================

#endregion

namespace ServidorAPI.Persistencia.Informacion
{
    public static class Configuracion
    {
        public const string LlavePrivada = "asdfghj75643445_sadim_rrfiuetyikfddssSDRDFdssddbnRRUREDFJDLKJF698_77vcgfdsrtftr_uRTGVC543FDhgcvgfx_dg708ctrreSSssSwwsswrrrRRRRWYUIY";
        public const string UrlUnidad = "https://localhost:44337/";
    }

    public static class Controlador
    {
        public static class Nombre
        {
            public const string Asentamiento = "asentamientos";
            public const string Categoria = "categorias";
            public const string Colonia = "colonias";
            public const string Delegacion = "delegaciones";
            public const string Empleado = "empleados";
            public const string Estado = "estados";
            public const string Indicador = "indicadores";
            public const string Vialidad = "vialidades";
            public const string Municipio = "municipios";
            public const string Pais = "paises";
            public const string Servicio = "servicios";
            public const string Status = "status";
            public const string DetalleIndicador = "DetalleIndicador";
            public const string Periodo = "periodos";
            public const string Proceso = "procesos";
            public const string Meta = "metas";
            public const string UnidadTipo = "unidadesTipo";
            public const string Unidad = "unidades";
            public const string Dm01 = "dm01";
            public const string Dm02 = "dm02";
            public const string Dm04 = "dm04";
            public const string Dm05 = "dm05";
            public const string Eh01 = "eh01";
            public const string Eh02 = "eh02";
            public const string Eh04 = "eh04";
            public const string CaMama01 = "caMama01";
            public const string CaMama02 = "caMama02";
            public const string CaMama03 = "caMama03";
            public const string CaCu01 = "cacu01";
            public const string Materna01 = "materna01";
            public const string Materna02 = "materna02";
            public const string Materna03 = "materna03";
            public const string Materna04 = "materna04";
            public const string SOb01 = "sob01";
            public const string Caispn01 = "caispn01";
            public const string Caispn02 = "caispn02";
            public const string Caispn04 = "caispn04";
            public const string Caispn05 = "caispn05";
            public const string Caispn08 = "caispn08";
            public const string Caispn09 = "caispn09";
            public const string Caispn14 = "caispn14";
        }

        public static class Parametro
        {
            public const string Id = "{id:int}";
            public const string Matricula = "{matricula:int}";
            public const string Id_Matricula = "{id:int},{matricula:int}";
        }

        public static class Ruta
        {
            public const string BloquearEmpleado = "bloquearEmpleado";
            public const string CambiarPassword = "cambiarPassword";
            public const string CambiarRol = "cambiarRol";
            public const string CambiarUnidad = "cambiarUnidad";
            public const string DesbloquearEmpleado = "desbloquearEmpleado";
            public const string Login = "login";
            public const string Registro = "registro";
            public const string Recuperacion = "recuperacion";
            public const string ActualizarDm01 = "actualizarDm01/{matricula:int}";
            public const string ActualizarDm02 = "actualizarDm02/{matricula:int}";
            public const string ActualizarDm04 = "actualizarDm04/{matricula:int}";
            public const string ActualizarDm05 = "actualizarDm05/{matricula:int}";
            public const string ActualizarEh01 = "actualizarEh01/{matricula:int}";
            public const string ActualizarEh02 = "actualizarEh02/{matricula:int}";
            public const string ActualizarEh04 = "actualizarEh04/{matricula:int}";
            public const string ActualizarCaMama01 = "actualizarCAMama01/{matricula:int}";
            public const string ActualizarCaMama02 = "actualizarCAMama02/{matricula:int}";
            public const string ActualizarCaMama03 = "actualizarCAMama03/{matricula:int}";
            public const string ActualizarCaCu01 = "actualizarCaCu01/{matricula:int}";
            public const string ActualizarMaterna01 = "actualizarMaterna01/{matricula:int}";
            public const string ActualizarMaterna02 = "actualizarMaterna02/{matricula:int}";
            public const string ActualizarMaterna03 = "actualizarMaterna03/{matricula:int}";
            public const string ActualizarMaterna04 = "actualizarMaterna04/{matricula:int}";
            public const string ActualizarSOb01 = "actualizarSOb01/{matricula:int}";
            public const string ActualizarCaispn01 = "actualizarCaispn01/{matricula:int}";
            public const string ActualizarCaispn02 = "actualizarCaispn02/{matricula:int}";
            public const string ActualizarCaispn04 = "actualizarCaispn04/{matricula:int}";
            public const string ActualizarCaispn05 = "actualizarCaispn05/{matricula:int}";
            public const string ActualizarCaispn06 = "actualizarCaispn06/{matricula:int}";
            public const string ActualizarCaispn08 = "actualizarCaispn08/{matricula:int}";
            public const string ActualizarCaispn09 = "actualizarCaispn09/{matricula:int}";
            public const string ActualizarCaispn11 = "actualizarCaispn11/{matricula:int}";
            public const string ActualizarCaispn14 = "actualizarCaispn14/{matricula:int}";
        }
    }

    public static class FluentValidate
    {
        public static class Min
        {
            public const int Valor_0 = 0;
            public const int Valor_1 = 1;
            public const int Valor_2 = 2;
            public const int Valor_3 = 3;
            public const int Valor_5 = 5;
            public const int Valor_12 = 12;
        }

        public static class Max
        {
            public const int Valor_6 = 6;
            public const int Valor_12 = 12;
            public const int Valor_50 = 50;
            public const int Valor_150 = 150;
            public const int Valor_300 = 300;
            public const int Valor_750 = 750;
            public const int Valor_1500 = 1500;
        }

        public static class Regex
        {
            public const string Año = "^\\d{4}$";
            public const string Mes = "^(0[1-9]|1[0-2])$";
            public const string Nombre = "[a-z0-9\\-]";
            public const string Numeros = "^([0-9]*[1-9][0-9]*(\\.[0-9]+)?|[0]+\\.[0-9]*[1-9][0-9]*)$";
            public const string NoNumeros = "(?!^\\d+$)^.+$";
            public const string Telefono = "^(\\([0-9]{3}\\) |[0-9]{3}-)[0-9]{3}-[0-9]{4}$";
        }
    }

    public static class Indicadores
    {
        public static class Nombre
        {
            public const string DM01 = "DM01";
            public const string DM02 = "DM02";
            public const string DM03 = "DM03";
            public const string DM04 = "DM04";
            public const string DM05 = "DM05";
            public const string EH01 = "EH01";
            public const string EH02 = "EH02";
            public const string EH03 = "EH03";
            public const string EH04 = "EH04";
            public const string CaMama01 = "CA_MAma01";
            public const string CaMama02 = "CA_MAma02";
            public const string CaMama03 = "CA_MAma03";
            public const string CaCu01 = "CA_CU01";
            public const string Materna01 = "Materna01";
            public const string Materna02 = "Materna02";
            public const string Materna03 = "Materna03";
            public const string Materna04 = "Materna04";
            public const string SOb01 = "S_Ob01";
            public const string CAISPN01 = "CAISPN01";
            public const string CAISPN02 = "CAISPN02";
            public const string CAISPN04 = "CAISPN04";
            public const string CAISPN05 = "CAISPN05";
            public const string CAISPN06 = "CAISPN06";
            public const string CAISPN08 = "CAISPN08";
            public const string CAISPN09 = "CAISPN09";
            public const string CAISPN11 = "CAISPN11";
            public const string CAISPN14 = "CAISPN14";
        }
        public static class Periodo
        {
            public const string Inicio = "201901";
            public const string Div = "/";
            public const string DiaInicio = "26/";
            public const string DiaTermino = "25/";
            public const string HoraInicio = " 00:00:00";
            public const string HoraTermino = " 23:59:59.990";
        }
        public static class Prevalencia
        {
            public const decimal DMPrevM45_59 = 0.800M;
            public const decimal DMPrevH45_59 = 0.833M;
            public const decimal DMprevAM = 0.732M;
            public const decimal EHPrevM30_59 = 0.753M;
            public const decimal EHPrevH30_59 = 0.845M;
            public const decimal EHprevAM = 0.543M;
            public const decimal CACUPrev = 0.110M;
        }
        public static class Rend
        {
            public const string Bajo = "Bajo";
            public const string Medio = "Medio";
            public const string Alto = "Alto";
        }

    }

    public static class Google
    {
        public const string Link = "https://maps.google.com/?ll=";
        public const string Link2 = "https://www.google.com/maps/search/?api=1&query=";
        public const string Zoom4 = "&z=4";
        public const string Zoom5 = "&z=5";
        public const string Zoom6 = "&z=6";
        public const string Zoom7 = "&z=7";
        public const string Zoom8 = "&z=8";
        public const string Zoom9 = "&z=9";
        public const string Zoom10 = "&z=10";
        public const string Zoom12 = "&z=12";
        public const string Zoom13 = "&z=13";
        public const string Zoom16 = "&z=16";
        public const string Zoom18 = "&z=18";
        public const string Zoom19 = "&z=19";
        public const string Zoom20 = "&z=20";
        public const string Satelite = "&t=k";
        public const string Cerca = "&q=";
        public const string Div = "%2C";
    }

    public static class Mensaje
    {
        public static class Detalle
        {
            public const string AsentamientoNoExiste = "El asentamiento ingresado no existe.";
            public const string AutoMapper = "Ha ocurrido un error grave en el mapeo de sus entidades, revise las relaciones de sus entidades.";
            public const string Bienvenida = "Bienvenido nuevamente ";
            public const string Bloqueado = "El objeto seleccionado se encuentra temporalmente suspendido.";
            public const string BloquearCorrecto = "Empleado bloqueado satisfactoriamente.";
            public const string BloquearExiste = "El empleado que intenta bloquear ya tiene status bloqueado.";
            public const string BloquearNoExiste = "El empleado que intenta desbloquear ya tiene status desbloqueado.";
            public const string CategoriaNoExiste = "La categoría ingresada no existe.";
            public const string ClavePresupuestalExiste = "La clave presupuestal ingresada pertenece a otra unidad médica.";
            public const string CodigoPostalNoExiste = "El códigoPostal ingresado no existe.";
            public const string ColoniaNoExiste = "La colonia ingresada no existe.";
            public const string DelegacionNoExiste = "La delegación ingresada no existe.";
            public const string DesbloquearCorrecto = "Empleado desbloqueado satisfactoriamente.";
            public const string DesbloquearError = "Favor de verificar sus credenciales, password incorrecto.";
            public const string EditarError = "No se ha modificado la base de datos, ya que no ha ingresado ningún cambio.";
            public const string EditarExito = "Registro modificado satisfactoriamente.";
            public const string EditarOk = "Registro modificado satisfactoriamente.";
            public const string EliminarConflicto = "No es posible eliminar un objeto si esta realcionado con otro.";
            public const string EliminarOk = "Registro eliminado satisfactoriamente.";
            public const string EmpleadoExiste = "Ya existe un empleado registrado con esos datos.";
            public const string EmpleadoNoExiste = "El empleado ingresado no existe.";
            public const string ErrorDependencia = "Ha ocurrido un error grave no se han encontrado las dependencias necesarias para acceder a este servicio: ";
            public const string ErrorNulo = "No es posible insertar un valor NULL en el campo: ";
            public const string EstadoNoExiste = "El estado ingresado no existe.";
            public const string IndicadorNoExiste = "No existe ningún indicador con esos datos.";
            public const string InsertarOk = "Registro insertado satisfactoriamente en la base de datos.";
            public const string LoginError = "Favor de verificar sus credenciales, usuario o password incorrecto.";
            public const string LoginSoporte = "Ha iniciado sesión con el usuario de soporte, debe registrar usuarios y asignar roles o de lo contrario se inhabilitara el sistema.";
            public const string MunicipioNoExiste = "El municipio ingresado no existe.";
            public const string NoAceptable = "Necesita ser un usuario registrado para insertar o editar este objeto";
            public const string NoAutorizado = "No se cuenta con el nivel de acceso necesario para acceder a este servicio.";
            public const string NoEncontrado = "No se han encontrado registros en la base de datos.";
            public const string NumPaginaNoExiste = "La página del recurso que solicita no existe.";
            public const string OK = "Su solicitud se ha realizado correctamente.";
            public const string PasswordError = "Las contraseñas no coinciden.";
            public const string PasswordRecoveryError = "No fue posible validar su código, reliace nuevamente el proceso de recuperación.";
            public const string ProcesoNoExiste = "El proceso de salud ingresado no existe.";
            public const string PeriodoExiste = "Ya existe un periodo registrado con esos datos.";
            public const string PeriodoNoExiste = "No existe ningun periodo registrado con esos datos.";
            public const string Prohibido = "No se cuenta con el nivel de acceso necesario para insertar o modificar este recurso.";
            public const string RecuperacionEnviado = "Mensaje de recuperación de contraseña enviado correctamente.";
            public const string RegistroExito = "Registro de usuario completado stasfactoriamente, Pendiente Autorizacion.";
            public const string ServicioNoExiste = "El servicio ingresado no existe.";
            public const string SolicitudInvalida = "Ya existe un objeto registrado con ese nombre.";
            public const string UnidadNoExiste = "La unidad médica ingresada no existe.";
            public const string UnidadTipoNoExiste = "El tipo de unidad médica ingresado no existe.";
            public const string VialidadNoExiste = "La vialidad ingresada no existe.";

            public const string IndicadorActualizado = "Se ha actualizado correctamente la base de datos.";
        }

        public static class Encabezado
        {
            public const string StatusCode200 = "Servidor UMF 31: Solcitud exitosa Codigo 200 (OK)";
            public const string StatusCode201 = "Servidor UMF 31: Solcitud exitosa Codigo 201 (Creado)";
            public const string StatusCode400 = "Servidor UMF 31: Error Codigo 400 (Solicitud Invalida)";
            public const string StatusCode401 = "Servidor UMF 31: Error Codigo 401 (No Autorizado)";
            public const string StatusCode403 = "Servidor UMF 31: Error Codigo 403 (Prohibido)";
            public const string StatusCode404 = "Servidor UMF 31: Error Codigo 404 (No Encontrado)";
            public const string StatusCode406 = "Servidor UMF 31: Error Codigo 406 (No Aceptable)";
            public const string StatusCode409 = "Servidor UMF 31: Error Codigo 409 (Conflicto)";
            public const string StatusCode423 = "Servidor UMF 31: Error Codigo 423 (Bloqueado)";
            public const string StatusCode500 = "Servidor UMF 31: Error Codigo 500 (Error interno del servidor)";
        }

        public static class Excepcion
        {
            public const int StatusCode200 = 200;
            public const int StatusCode201 = 201;
            public const int StatusCode400 = 400;
            public const int StatusCode401 = 401;
            public const int StatusCode403 = 403;
            public const int StatusCode404 = 404;
            public const int StatusCode406 = 406;
            public const int StatusCode409 = 409;
            public const int StatusCode423 = 423;
            public const int StatusCode500 = 500;
        }

        public static class TipoRespuesta
        {
            public const string Error = "danger";
            public const string Exito = "success";
            public const string Alerta = "warning";
            public const string Info = "info";
            public const string Azul = "primary";
            public const string Rosa = "rose";
        }

        public static class FluentValidator
        {
            public const string AñoInvalido = "El campo {PropertyName} debe tener un formato de 4 digitos (XXXX)ͺ";
            public const string CaracterInvalido = "El campo {PropertyName} contiene caracteres no validosͺ";
            public const string CaracterMax = "El campo {PropertyName} solo debe tener {MaxLength} caracteres, y ha ingresado un total de {TotalLength} caracteresͺ";
            public const string CaracterMin = "El campo {PropertyName} debe tener al menos {MinLength} caracteresͺ";
            public const string CaracterMinMax = "El campo {PropertyName} debe tener entre {MinLength} y {MaxLength} caracteresͺ";
            public const string CodigoSMS = "El campo {PropertyName} se conforma obligatoriamente de 6 digitosͺ";
            public const string CoordenadaNoNulo = "El campo {PropertyName} necesita que se registren ambas coordenadas (Latitud y Longitud)ͺ";
            public const string EmailInvalido = "El campo {PropertyName} tiene un formato de correo electronico invalidoͺ";
            public const string ImagenGrande = "El archivo de imágen seleccionado supera los 2 Mb.permitidosͺ";
            public const string ImagenTipo = "Típo de archivo no validoͺ los tipos permitidos son image/jpeg, image/jpg, image/pngͺ";
            public const string Latitud = "El campo {PropertyName} debe estar entre -90 <-> 90 gradosͺ";
            public const string Longitud = "El campo {PropertyName} debe estar entre -180 <-> 180 gradosͺ";
            public const string NoNulo = "El campo {PropertyName} no acepta valores nulos o vaciosͺ";
            public const string Mayor0 = "El campo {PropertyName} debe tener un valor entero mayor a 0ͺ";
            public const string MesInvalido = "El campo {PropertyName} debe tener un formato de 2 digitos y menor a 13 (XX)ͺ";
            public const string PasswordNoCoincide = "El campo {PropertyName} debe ser igual al campo passwordͺ";
            public const string Precision = "El campo {PropertyName} debe contener maximo 3 enteros entre -180 y 180 y {ExpectedScale} decimalesͺ";
            public const string ReferenciaPresicion = "El valor del campo {PropertyName} es un número de -100.00 a 100.00 con dos decimalesͺ";
            public const string TelefonoInvalido = "El campo {PropertyName} debe tener un formato (XXX) XXX-XXXX donde X es un dígito de 0-9ͺ";
            public const string MatriculaInvalida = "El campo {PropertyName} debe ser númerica dígitos de 0-9ͺ";
            public const string URLInvalido = "El campo {PropertyName} tiene un formato URL incorrectoͺ";
        }
    }

    public static class Paginacion
    {
        public const string NumPag = "?NumeroPagina=";
        public const string NumReg = "&NumeroRegistros=";
        public const int DefaultNumeroRegistros = 20;
        public const int DefaultNumeroPagina = 1;
    }

    public static class Plataforma
    {
        public const string Servidor = "ServidorAPI";
        public const string Sadim = "SADIM";
    }

    public static class RolServidor
    {
        public const int NoActivo = 0;
        public const int SadimMaster = 1;
        public const int Usuario = 2;
        public const int JefeServicio = 3;
        public const int Directivo = 4;
        public const int Soporte = 5;
    }

    public static class Ruta
    {
        public static class Api
        {
            public const string Base = "api/";
            public const string Asentamiento = "api/asentamientos";
            public const string Autorizacion = "api/autorizacion";
            public const string Categoria = "api/categorias";
            public const string Colonia = "api/colonias";
            public const string Delegacion = "api/delegaciones";
            public const string Empleado = "api/empleados";
            public const string Estado = "api/estados";
            public const string Vialidad = "api/vialidades";
            public const string Municipio = "api/municipios";
            public const string Pais = "api/paises";
            public const string Servicio = "api/servicios";
            public const string Status = "api/status";
            public const string DetalleIndicador = "api/detalleIndicador";
            public const string Periodo = "api/periodos";
            public const string Proceso = "api/procesos";
            public const string Meta = "api/metas";
            public const string UnidadTipo = "api/unidadesTipo";
            public const string Unidad = "api/unidades";
        }

        public static class Email
        {
            public const string Subject = "Código de recuperación de contraseña.";
            public const string Body = "<p>Este el el código para la recuperación de su contraseña</p><br>";
            public const string LinkAbrir = "<a href = '";
            public const string LinkCerrar = "'>Click aqui para recuperar";
        }

        public static class Imagen
        {
            public const string Contenedor = $"img\\";
            public const string ContenedorDefault = $"img\\default";
            public const string UsuarioDefault = "usr-default.png";
            public const string AdministradorDefault = "usr-admin.png";
            public const string NoDisponible = "no-disponible.png";
            public const string NoDisponibleC = "no-disponible-circulo.png";
            public const string RutaDefault = "/img/default/";
        }

        public static class Sadim
        {
            public const string Base = "api/sadim";       
            public const string Diabetes = "api/sadim/diabetes";
            public const string Hipertension = "api/sadim/hipertension";
            public const string CancerMama = "api/sadim/cancerMama";
            public const string CervicoUterino = "api/sadim/cervicoUterino";
            public const string Materna = "api/sadim/materna";
            public const string Obesidad = "api/sadim/obesidad";
            public const string Caispn = "api/sadim/caispn";
            public const string DM01 = "api/sadim/dm01";
            public const string DM02 = "api/sadim/dm02";
            public const string DM04 = "api/sadim/dm04";
            public const string DM05 = "api/sadim/dm05";
            public const string EH01 = "api/sadim/eh01";
            public const string EH02 = "api/sadim/eh02";
            public const string EH04 = "api/sadim/eh04";
            public const string CAMAma01 = "api/sadim/cama01";
            public const string CAMAma02 = "api/sadim/cama02";
            public const string CAMAma03 = "api/sadim/cama03";
            public const string CACU01 = "api/sadim/cacu01";
            public const string Materna01 = "api/sadim/materna01";
            public const string Materna02 = "api/sadim/materna02";
            public const string Materna03 = "api/sadim/materna03";
            public const string Materna04 = "api/sadim/materna04";
            public const string SOb01 = "api/sadim/sob01";
            public const string CAISPN01 = "api/sadim/caispn01";
            public const string CAISPN02 = "api/sadim/caispn02";
            public const string CAISPN04 = "api/sadim/caispn04";
            public const string CAISPN05 = "api/sadim/caispn05";
            public const string CAISPN06 = "api/sadim/caispn06";
            public const string CAISPN08 = "api/sadim/caispn08";
            public const string CAISPN09 = "api/sadim/caispn09";
            public const string CAISPN11 = "api/sadim/caispn11";
            public const string CAISPN14 = "api/sadim/caispn14";

        }
    }

    public static class TipoArchivo
    {
        public const string ApplicationJson = "application/json";
        public const string Jpeg = "image/jpeg";
        public const string Jpg = "image/jpg";
        public const string Png = "image/png";
    }
}