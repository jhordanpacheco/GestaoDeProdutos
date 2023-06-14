using System;
using System.Collections.Generic;
using AutoGlass_GestaoDeProdutos.Application.DTO;

namespace AutoGlass_GestaoDeProdutos.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Add(ProdutoDTO obj);

        ProdutoDTO GetById(int id);

        IEnumerable<ProdutoDTO> GetAll();

        void Update(ProdutoDTO obj);

        void Remove(ProdutoDTO obj);

        void Dispose();
    }
}
