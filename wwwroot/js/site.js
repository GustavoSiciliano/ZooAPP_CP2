
var modal = document.getElementById("modal");
var modalTitulo = document.getElementById("modalTitulo");
var modalTexto = document.getElementById("modalTexto");
var modalConfirmarTexto = document.getElementById("modalConfirmarTexto");
var botaoConfirmar = document.getElementById("modalConfirmar");
var botaoCancelar = document.getElementById("modalCancelar");

// Função que será executada quando o usuário clicar em confirmar
var aoConfirmar = null;

function abrirModal(titulo, texto, textoBotao, funcao) {
    modalTitulo.textContent = titulo;
    modalTexto.textContent = texto;
    modalConfirmarTexto.textContent = textoBotao;
    aoConfirmar = funcao;
    modal.showModal();
}

botaoConfirmar.addEventListener("click", function () {
    modal.close();
    if (aoConfirmar != null) {
        aoConfirmar();
    }
});

botaoCancelar.addEventListener("click", function () {
    modal.close();
});

// Formulários de cadastrar e editar 

var formularios = document.querySelectorAll("form[data-confirmar]");

formularios.forEach(function (form) {
    form.addEventListener("submit", function (evento) {

        if (form.getAttribute("data-ok") == "sim") {
            return;
        }

        evento.preventDefault();
        abrirModal(
            form.getAttribute("data-titulo"),
            form.getAttribute("data-confirmar"),
            "Confirmar",
            function () {
                form.setAttribute("data-ok", "sim");
                form.submit();
            }
        );
    });
});

//Botões de excluir
var botoesExcluir = document.querySelectorAll(".botao-excluir");
var formExcluir = document.getElementById("formExcluir");

botoesExcluir.forEach(function (botao) {
    botao.addEventListener("click", function () {
        var nome = botao.getAttribute("data-nome");
        var url = botao.getAttribute("data-url");

        abrirModal(
            "Confirmar exclusão",
            "Deseja excluir o animal " + nome + "? Esta ação não pode ser desfeita.",
            "Sim, excluir",
            function () {
                formExcluir.setAttribute("action", url);
                formExcluir.submit();
            }
        );
    });
});
