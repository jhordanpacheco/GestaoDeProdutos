using System;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Repositorys;
using AutoGlass_GestaoDeProdutos.Domain.Models;

namespace AutoGlass_GestaoDeProdutos.Infrastructure.Repository
{
    public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
    {
        private readonly SqlContext _context;

        public RepositoryProduto(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

    }
}
