
// DECLARAÇÃO DE VARIAVEIS

var enderecoProduto = "https://localhost:5001/Produtos/Produto/";
var produto;
var compra = [];

// FUNÇÕES

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

function adicionarNaTabela(p,q) {
    var produtoTemp = {};
    Object.assign(produtoTemp,produto);
    var listaCompras = {produto: produtoTemp, quantidade: q};
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
    var qtd = $("#campoQuantidade").val();

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