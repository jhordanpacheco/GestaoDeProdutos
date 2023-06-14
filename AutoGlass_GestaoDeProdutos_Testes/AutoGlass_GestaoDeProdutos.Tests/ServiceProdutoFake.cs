using System;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using AutoGlass_GestaoDeProdutos.Application.Interfaces;

namespace AutoGlass_GestaoDeProdutos.Tests
{
	public class ServiceProdutoFake : IApplicationServiceProduto
    {
        private readonly List<ProdutoDTO> _produto;

        public ServiceProdutoFake()
        {
            _produto = new List<ProdutoDTO>()
            {
                new ProdutoDTO() {
                    CodigoProduto = 4,
                    DescricaoProduto = "teste",
                    SituacaoProduto = true,
                    FabricacaoProduto = DateTime.Now,
                    ValidadeProduto = DateTime.Now,
                    CodigoFornecedorProduto = 1,
                    DescricacaoFornecedorProduto = "teste",
                    CnpjFornecedorProduto = "74.704.008/0001-00"
                }
            };
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            return _produto;
        }

        public void Add(ProdutoDTO novoItem)
        {
            _produto.Add(novoItem);

        }

        public ProdutoDTO GetById(int id)
        {
            return _produto.Where(a => a.CodigoProduto == id)
                .FirstOrDefault();
        }

        public void Update(ProdutoDTO produtoDTO)
        {

        }

        public void Remove(ProdutoDTO produtoDTO)
        {
            _produto.Remove(produtoDTO);
        }

        public void Dispose()
        {

        }
    }
}

