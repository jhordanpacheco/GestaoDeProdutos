using System;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using AutoGlass_GestaoDeProdutos.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using AutoGlass_GestaoDeProdutos.Application.Service;
using System.Linq;

namespace AutoGlass_GestaoDeProdutos.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;

        public ProdutosController(IApplicationServiceProduto ApplicationServiceProduto)
        {
            _applicationServiceProduto = ApplicationServiceProduto;
        }

        //GET: produtos 
        /// <summary>
        /// Listar produtos
        /// </summary>
        [HttpGet]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        public ActionResult<IEnumerable<ProdutoDTO>> Get(
            [FromQuery] int? codigoProduto,
            [FromQuery] string descricaoProduto,
            [FromQuery] bool? situacaoProduto,
            [FromQuery] DateTime? dataFabricacao,
            [FromQuery] DateTime? dataValidade,
            [FromQuery] int? codigoFornecedor,
            [FromQuery] string descricaoFornecedor,
            [FromQuery] string cnpjFornecedor,
            [FromQuery] int pagina = 1,
            [FromQuery] int tamanhoPagina = 10)
        {
            var produtos = _applicationServiceProduto.GetAll();

            if (codigoProduto != null)
            {
                produtos = produtos.Where(p => p.CodigoProduto == codigoProduto);
            }

            if (!string.IsNullOrEmpty(descricaoProduto))
            {
                produtos = produtos.Where(p => p.DescricaoProduto.Contains(descricaoProduto));
            }

            if (situacaoProduto != null)
            {
                produtos = produtos.Where(p => p.SituacaoProduto == situacaoProduto);
            }

            if (dataFabricacao.HasValue)
            {
                produtos = produtos.Where(p => p.FabricacaoProduto == dataFabricacao.Value);
            }

            if (dataValidade.HasValue)
            {
                produtos = produtos.Where(p => p.ValidadeProduto == dataValidade.Value);
            }

            if (codigoFornecedor != null)
            {
                produtos = produtos.Where(p => p.CodigoFornecedorProduto == codigoFornecedor);
            }

            if (!string.IsNullOrEmpty(descricaoFornecedor))
            {
                produtos = produtos.Where(p => p.DescricacaoFornecedorProduto.Contains(descricaoFornecedor));
            }

            if (!string.IsNullOrEmpty(cnpjFornecedor))
            {
                produtos = produtos.Where(p => p.CnpjFornecedorProduto == cnpjFornecedor);
            }

            var produtosPaginados = produtos.Skip((pagina - 1) * tamanhoPagina)
                                .Take(tamanhoPagina)
                                .ToList();
            return Ok(produtosPaginados);
        }

        //GET: produtos/id
        /// <summary>
        /// Obter produto
        /// </summary>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProdutoDTO))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ProdutoDTO> Get([FromRoute] int id)
        {
            ProdutoDTO produtoDTO = _applicationServiceProduto.GetById(id);
            if (produtoDTO == null)
                return NotFound(String.Format("Produto com o id: {0} não foi encontrado.", id.ToString()));

            return Ok(_applicationServiceProduto.GetById(id));
        }

        //POST: produtos
        /// <summary>
        /// Inserir produto
        /// </summary>
        [HttpPost]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Post([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();


                _applicationServiceProduto.Add(produtoDTO);

                return StatusCode(201, "O produto foi cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Ocorreu um erro. Tente novamente mais tarde. {0}", ex.Message.ToString()));
            }
        }

        //PUT: produtos
        /// <summary>
        /// Atualizar produto
        /// </summary>
        [HttpPut]
        [Route("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Put([FromBody] ProdutoDTO produtoDTO)
        {
            try
            {
                if (produtoDTO == null)
                    return NotFound();

                _applicationServiceProduto.Update(produtoDTO);

                return Ok("O produto foi atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Ocorreu um erro. Tente novamente mais tarde. {0}", ex.Message.ToString()));
            }
        }

        //DELETE: produtos/id
        /// <summary>
        /// Deletar produto
        /// </summary>
        [HttpDelete]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Delete([FromRoute] int id)
        {
            try
            {
                ProdutoDTO produtoDTO = _applicationServiceProduto.GetById(id);
                if (produtoDTO == null)
                    return NotFound();

                produtoDTO.SituacaoProduto = false;
                _applicationServiceProduto.Update(produtoDTO);

                return Ok("O produto foi removido com sucesso!");

            }
            catch (Exception ex)
            {
                return StatusCode(500, String.Format("Ocorreu um erro. Tente novamente mais tarde. {0}", ex.Message.ToString()));
            }
        }
    }
}
