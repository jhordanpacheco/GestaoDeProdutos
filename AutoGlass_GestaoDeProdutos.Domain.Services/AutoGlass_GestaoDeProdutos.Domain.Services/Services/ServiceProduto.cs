using System;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Repositorys;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Services;
using AutoGlass_GestaoDeProdutos.Domain.Models;

namespace AutoGlass_GestaoDeProdutos.Domain.Services.Services
{
    public class ServiceProduto : ServiceBase<Produto>, IServiceProduto
    {
        private readonly IRepositoryProduto _repositoryProduto;

        public ServiceProduto(IRepositoryProduto RepositoryProduto)
            : base(RepositoryProduto)
        {
            _repositoryProduto = RepositoryProduto;
        }
    }
}
