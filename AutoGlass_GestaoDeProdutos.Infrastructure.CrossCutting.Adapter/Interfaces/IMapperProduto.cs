using System;
using AutoGlass_GestaoDeProdutos.Domain.Models;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using System.Collections.Generic;

namespace AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Interfaces
{
    public interface IMapperProduto
    {
        #region Interfaces Mappers

        Produto MapperToEntity(ProdutoDTO produtoDTO);

        IEnumerable<ProdutoDTO> MapperListProdutos(IEnumerable<Produto> clientes);

        ProdutoDTO MapperToDTO(Produto produto);

        #endregion

    }
}

