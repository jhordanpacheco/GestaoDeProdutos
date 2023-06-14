using System;
using System.Collections.Generic;

#nullable disable

namespace AutoGlass_GestaoDeProdutos.Domain.Models
{
    public partial class Produto
    {
        public int CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public bool SituacaoProduto { get; set; }
        public DateTime? FabricacaoProduto { get; set; }
        public DateTime ValidadeProduto { get; set; }
        public int CodigoFornecedorProduto { get; set; }
        public string DescricacaoFornecedorProduto { get; set; }
        public string CnpjFornecedorProduto { get; set; }
    }
}
