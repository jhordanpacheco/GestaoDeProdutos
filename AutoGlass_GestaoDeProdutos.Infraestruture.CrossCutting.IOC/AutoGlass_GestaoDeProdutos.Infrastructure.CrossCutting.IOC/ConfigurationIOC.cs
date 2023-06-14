using System;
using Autofac;
using AutoGlass_GestaoDeProdutos.Application.Interfaces;
using AutoGlass_GestaoDeProdutos.Application.Service;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Repositorys;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Services;
using AutoGlass_GestaoDeProdutos.Domain.Services.Services;
using AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Interfaces;
using AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Map;
using AutoGlass_GestaoDeProdutos.Infrastructure.Repository;

namespace AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceProduto>().As<IServiceProduto>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryProduto>().As<IRepositoryProduto>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperProduto>().As<IMapperProduto>();
            #endregion

            #endregion

        }
    }
}

