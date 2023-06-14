using System;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using AutoGlass_GestaoDeProdutos.Application.Interfaces;
using System.Collections.Generic;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Services;
using AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Interfaces;
using AutoGlass_GestaoDeProdutos.Infrastructure.CrossCutting.Adapter.Map;

namespace AutoGlass_GestaoDeProdutos.Application.Service
{
    public class ApplicationServiceProduto : IDisposable, IApplicationServiceProduto
    {
        private readonly IServiceProduto _serviceProduto;
        private readonly IMapperProduto _mapperProduto;

        public ApplicationServiceProduto(IServiceProduto ServiceProduto
                                         , IMapperProduto MapperProduto)
        {
            _serviceProduto = ServiceProduto;
            _mapperProduto = MapperProduto;
        }

        public void Add(ProdutoDTO obj)
        {
            if(!obj.DataDeFabricacaoValida(obj))
            {
                throw new ApplicationException("A data de fabricação do produto é inválida.");
            }

            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Add(objProduto);
        }

        public void Dispose()
        {
            _serviceProduto.Dispose();
        }

        public IEnumerable<ProdutoDTO> GetAll()
        {
            var objProdutos = _serviceProduto.GetAll();
            return _mapperProduto.MapperListProdutos(objProdutos);
        }

        public ProdutoDTO GetById(int id)
        {
            var objProduto = _serviceProduto.GetById(id);
            return _mapperProduto.MapperToDTO(objProduto);
        }

        public void Remove(ProdutoDTO obj)
        {
            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Remove(objProduto);
        }

        public void Update(ProdutoDTO obj)
        {
            if (!obj.DataDeFabricacaoValida(obj))
            {
                throw new ApplicationException("A data de fabricação do produto é inválida.");
            }

            var objProduto = _mapperProduto.MapperToEntity(obj);
            _serviceProduto.Update(objProduto);
        }

    }
}
