function ValidacaoCampo(tituloCampo, nomeCampo) {
    swal({
        title: 'Ops!',
        text: 'O campo ' + tituloCampo + ' está em branco!',
        type: 'warning',
    });

    document.querySelector(nomeCampo).focus();
}
     
function ValidacaoLogin() {
    swal({
        title: 'Ops!',
        text: 'Não foi possivel efetuar o login!',
        type: 'error',
        confirmButtonText: ' Ok '
    });
}

function MensagemErro(msg) {
    swal({
        title: 'Ops!',
        text: 'Não foi possivel efetuar o login!\n' + msg + '\nEntre em contato com administrador do sistema!',
        type: 'error',
        confirmButtonText: ' Ok '
    });
}
 
function Logar()
{
    var login = false;

    if (document.querySelector("#txtUsuario").value == "") {
        ValidacaoCampo("Usuário", "#txtUsuario");
        return false;
    }

    if (document.querySelector("#txtSenha").value == "") {
        ValidacaoCampo("Senha", "#txtSenha");
        return false;
    }

    if (login) {

        /*
        $.ajax({
            type: "POST",
            url: "Home/alguma coisa",
            data: { someParameter: "some value" },
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                
            },
            error: function (err) {
                MensagemErro(err.Message);
            },
            fail: function (err) {
                MensagemErro(err.Message);
            }
        });*/
    }
    else
    {
        ValidacaoLogin();
        return false;
    }
}
