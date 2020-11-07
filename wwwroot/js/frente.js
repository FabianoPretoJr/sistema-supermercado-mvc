
// DECLARAÇÃO DE VARIAVEIS

var enderecoProduto = "https://localhost:5001/Produtos/Produto/";
var produto;
var compra = [];
var __totalvenda__ = 0.0;

$("#posvenda").hide();

atualizarTotal();

// FUNÇÕES

function atualizarTotal() {
    $("#totalVenda").html(__totalvenda__);
}

function preencherFormulario(dadosProduto) {
    $("#campoNome").val(dadosProduto.nome);
    $("#campoCategoria").val(dadosProduto.categoria.nome);
    $("#campoFornecedor").val(dadosProduto.fornecedor.nome);
    $("#campoPreco").val(dadosProduto.precoDeVenda);
}

function zerarFormulario() {
    $("#campoNome").val("");
    $("#campoCategoria").val("");
    $("#campoFornecedor").val("");
    $("#campoPreco").val("");
    $("#campoQuantidade").val("");
}

function adicionarNaTabela(p, q) {
    var produtoTemp = {};
    Object.assign(produtoTemp,produto);

    var listaCompras = {produto: produtoTemp, quantidade: q, subtotal: produtoTemp.precoDeVenda * q};

    __totalvenda__ += listaCompras.subtotal;

    atualizarTotal();

    compra.push(listaCompras);

    $("#compras").append(`<tr>
        <td>${p.id}</td>
        <td>${p.nome}</td>
        <td>${q}</td>
        <td>R$ ${p.precoDeVenda}</td>
        <td>${p.medicao}</td>
        <td>R$ ${p.precoDeVenda * q}</td>
        <td><button class='btn btn-danger'>Remover</button></td>
    </tr>`);
}

// AJAX

$("#produtoForm").on("submit", function(event) {
    event.preventDefault();
    var produtoParaTabela = produto;
    var qtd = parseInt($("#campoQuantidade").val());

    adicionarNaTabela(produtoParaTabela, qtd);

    zerarFormulario();
});

$("#pesquisar").click(function() {
    var codProduto = $("#codProduto").val();
    var enderecoTemporario = enderecoProduto + codProduto;

    $.post(enderecoTemporario, function(dados, status) {
        produto = dados;

        var med = "";

        switch(produto.medicao) {
            case 0:
                med = "Litro";
                break;
            case 1:
                med = "Kilo";
                break;
            case 2:
                med = "Unidade";
                break;
            default:
                med = "-";
                break;
        }

        produto.medicao = med;

        preencherFormulario(produto);
    }).fail(function() {
        alert("Produto inválido!");
    });
});

// Fechar venda

$("#finalizarVendaBtn").click(function() {
    if (__totalvenda__ <= 0) {
        alert("Compra inválida nenhum produto adicionado!");
        return;
    }

    var valorPago = $("#valorPago").val();
    console.log(typeof valorPago);
    if (!isNaN(valorPago)) {
        valorPago = parseFloat(valorPago);
        if (valorPago >= __totalvenda__) {
            $("#posvenda").show();
            $("#prevenda").hide();
            $("#valorPago").prop("disabled", true);

            var troco = valorPago - __totalvenda__;
            $("#troco").val(troco);
        }
        else {
            alert("Valor pago abaixo do total da compra!");
            return;
        }
    }
    else {
        alert("Valor pago, inválido!");
        return;
    }
});

function restaurarModal() {
    $("#posvenda").hide();
    $("#prevenda").show();
    $("#valorPago").prop("disabled", false);
    $("#troco").val("");
    $("#valorPago").val("");
}

$("#fecharModal").click(function(){
    restaurarModal();
});