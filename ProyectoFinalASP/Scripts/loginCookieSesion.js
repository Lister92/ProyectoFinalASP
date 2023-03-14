
//Variables cookies
var userNameCookie;
var surnameCookie;
var passwordCookie;
var emailCookie;
var fechaNacimientoCookie;
var dniCookie;
var telfCookie;

//Llamar a la funcion register del archivo register.js
function obtenerDatos() {

    v = register()

    //Guardar variables
    userNameCookie = v[0];
    surnameCookie = v[1]
    passwordCookie = v[2];
    emailCookie = v[3];
    fechaNacimientoCookie = v[4];
    dniCookie = v[5];
    telfCookie = v[6];

}

//Crear localStorage
function localStorage() {

    localStorage.setItem("user", userNameCookie)
    localStorage.setItem("surname", surnameCookie)
    localStorage.setItem("password", passwordCookie)
    localStorage.setItem("email", emailCookie)
    localStorage.setItem("fechaNacimiento", fechaNacimientoCookie)
    localStorage.setItem("dni", dniCookie)
    localStorage.setItem("telf", telfCookie)

}

//Elimina localStorage
function cerrarSesion() {

    localStorage.removeItem("cookieSesion");

    location.href = './PaginaPrincipal.aspx.'
}

function detectarCookieSesion() {
    if (localStorage.getItem("cookieSesion") === "true") {
        $('#userLogin').text('' + localStorage.getItem("user"))
    }
    else
        location.href = './PaginaPrincipal.aspx'
}

//Validar el form con el localStorage
function validarLogin() {

    if ($('#password').val() == localStorage.getItem("password") &&
        $('#email').val() == localStorage.getItem("email")) {

        localStorage.setItem("cookieSesion", "true");

        //location.href = './indice.html'

    } else {
        swal("Error", "Credenciales incorretas", "error");
    }
}

/*PRUEBAS*/
function mostrar() {
    alert(localStorage.getItem("user"))
    alert(localStorage.getItem("surname"))
    alert(localStorage.getItem("password"))
    alert(localStorage.getItem("email"))
    alert(localStorage.getItem("fechaNacimiento"))
    alert(localStorage.getItem("dni"))
    alert(localStorage.getItem("telf"))
}
