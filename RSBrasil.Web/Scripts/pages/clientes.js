function Limpar() {
    $("#txtRazaoSocial").val("");
    $("#txtNome").val("");
    $("#txtCNPJ").val("");
    $("#txtContato").val("");
    $("#txtTelefone").val("");
    $("#txtEmail").val("");

    $("#txtRazaoSocial").focus();

}

function ValidarCampos() {

    if ($("#txtRazaoSocial").val() === "") {
        MsgValidacao("Razão Social");
        return false;
    }
    else if ($("#txtNome").val() === "") {
        MsgValidacao("Nome");
        return false;
    }
    else if ($("#txtCNPJ").val() === "") {
        MsgValidacao("CNPJ");
        return false;
    }
    else if ($("#txtContato").val() === "") {
        MsgValidacao("Contato");
        return false;
    }
    else if ($("#txtTelefone").val() === "") {
        MsgValidacao("Telefone");
        return false;
    }
    else if ($("#txtEmail").val() === "") {
        MsgValidacao("E-mail");
        return false;
    }

    return true;
}

function Inserir(event) {

    event.preventDefault();
    if (ValidarCampos()) {
            $("#frmCliente").submit();
    }
}

function MsgValidacao(nomeCampo) {
    swal("Ops!", `O campo ${nomeCampo} deve ser preenchido!`, "warning");
    nomeCampo = "#" + nomeCampo;
    $(nomeCampo).focus();
}

function Desativar(id, nome) {

    nome = "#" + nome;

    Swal({
        title: 'Você deseja excluir o cliente' + $(nome).val() + "?",
        text: "Não será possiver reverter.",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Apagar',
        cancelButtonText: "Cancelar"
    }).then((result) => {
        if (result.value) {

            DesativarBanco();
            
        }
    });
}

function DesativarBanco(idCliente) {

    $.ajax({
        url: "/Clientes/AlgumaCoisa",
        type: "post",
        data: { id: idCliente },
        error: function (data) {
            Swal.fire(
                'Ops!',
                'Ocorreu um erro ao excluir o cliente!.',
                'warning');
            console.log(data.error);
        },
        success: function (data) {
            Swal.fire(
                'Apagado!',
                'Cliente apagado com sucesso!.',
                'success');
        }
    });

}

