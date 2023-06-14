using System;
namespace AutoGlass_GestaoDeProdutos.Application.DTO
{
	public class ProdutoDTO
	{
        public int? CodigoProduto { get; set; }

        public string? DescricaoProduto { get; set; }

        public bool? SituacaoProduto { get; set; }

        public DateTime? FabricacaoProduto { get; set; }

        public DateTime ValidadeProduto { get; set; }

        public int? CodigoFornecedorProduto { get; set; }

        public string? DescricacaoFornecedorProduto { get; set; }

        public string? CnpjFornecedorProduto { get; set; }


        public bool DataDeFabricacaoValida(ProdutoDTO obj)
        {
            if (obj.FabricacaoProduto >= obj.ValidadeProduto)
                return false;

            return true;
        }
    }
}
