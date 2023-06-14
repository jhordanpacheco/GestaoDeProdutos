using System;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using AutoGlass_GestaoDeProdutos.Domain.Models;
using AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Interfaces;
using System.Collections.Generic;

namespace AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Map
{
    public class MapperProduto : IMapperProduto
    {

        List<ProdutoDTO> produtoDTOs = new List<ProdutoDTO>();

        public Produto MapperToEntity(ProdutoDTO produtoDTO)
        {
            if (produtoDTO != null)
            {
                Produto produto = new Produto
                {
                    CodigoProduto = (int)produtoDTO.CodigoProduto,
                    DescricaoProduto = produtoDTO.DescricaoProduto,
                    SituacaoProduto = (bool)produtoDTO.SituacaoProduto,
                    FabricacaoProduto = produtoDTO.FabricacaoProduto,
                    ValidadeProduto = produtoDTO.ValidadeProduto,
                    CodigoFornecedorProduto = (int)produtoDTO.CodigoFornecedorProduto,
                    DescricacaoFornecedorProduto = produtoDTO.DescricacaoFornecedorProduto,
                    CnpjFornecedorProduto = produtoDTO.CnpjFornecedorProduto
                };

                return produto;
            }
            else
                return null;

        }

        public IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> produtos)
        {
            if (produtos != null)
            {
                foreach (var item in produtos)
                {
                    if (item != null)
                    {
                        ProdutoDTO produtoDTO = new ProdutoDTO
                        {
                            CodigoProduto = item.CodigoProduto,
                            DescricaoProduto = item.DescricaoProduto,
                            SituacaoProduto = item.SituacaoProduto,
                            FabricacaoProduto = item.FabricacaoProduto,
                            ValidadeProduto = item.ValidadeProduto,
                            CodigoFornecedorProduto = item.CodigoFornecedorProduto,
                            DescricacaoFornecedorProduto = item.DescricacaoFornecedorProduto,
                            CnpjFornecedorProduto = item.CnpjFornecedorProduto
                        };

                        produtoDTOs.Add(produtoDTO);
                    }
                }
            }


            return produtoDTOs;

        }

        public ProdutoDTO MapperToDTO(Produto produto)
        {
            if (produto != null)
            {
                ProdutoDTO produtoDTO = new ProdutoDTO
                {
                    CodigoProduto = produto.CodigoProduto,
                    DescricaoProduto = produto.DescricaoProduto,
                    SituacaoProduto = produto.SituacaoProduto,
                    FabricacaoProduto = produto.FabricacaoProduto,
                    ValidadeProduto = produto.ValidadeProduto,
                    CodigoFornecedorProduto = produto.CodigoFornecedorProduto,
                    DescricacaoFornecedorProduto = produto.DescricacaoFornecedorProduto,
                    CnpjFornecedorProduto = produto.CnpjFornecedorProduto
                };

                return produtoDTO;
            }
            else
                return null;

        }
    }
}

