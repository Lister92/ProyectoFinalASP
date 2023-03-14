//Variables JQuery
var userName;
var surname;
var password;
var email;
var fechaNacimiento;
var telf;

//Variables regex
var regExpPassword = /[aA-zZ|\d]{6,}/;
var regExpTel = /^[6|7](\d){8}$/;
var regExpEmail = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/;

//Programa
function programa() {

    if (validarCampos()) {
        obtenerDatos()
        limpiarForm()
    }
}

//Registrarse
function register() {
    userName = $('#userName').val();
    surname = $('#surname').val()
    password = $('#passwordBox').val();
    email = $('#emailBox').val();
    telf = $('#telf').val();
}

//Validar Campos
function validarCampos() {
    var bool = true

    borrarInput()

    if (regExpPassword.test($('#passwordBox').val()) == false) {
        $('#errorPassword').text('Mínimo 6 carateres (a-z,A-Z,0-9)');
        bool = false
    }

    if (regExpPassword.test($('#passwordV2').val()) == false) {
        $('#errorPasswordV2').text('Mínimo 6 carateres (a-z,A-Z,0-9)');
        bool = false
    }

    if ($('#passwordBox').val() != $('#passwordV2').val()) {
        $('#errorPasswordV2').text('Las contraseñas no coinciden');
        bool = false
    }

    if (regExpEmail.test($('#emailBox').val()) == false) {
        $('#errorEmail').text('Email obligatorio ejm: user@user.com');
        bool = false
    }

    }
    if (regExpTel.test($('#telf').val()) == false) {
        $('#errorTelf').text('Telf obligatorio ejm: 661778995');
        bool = false
    }
    if (!bool) {
        swal("Error", "Por favor complete los campos", "error");
        return false
    }
    else {
        swal("Usuario Creado", "¡Ya puedes iniciar sesión!", "success");
        return true
    }

//Borra el contenido de los input
function borrarInput() {

    $('#errorPassword').text('')
    $('#errorPasswordV2').text('')
    $('#errorEmail').text('');
    $('#errorDNI').text('');
    $('#errorTelf').text('');

}