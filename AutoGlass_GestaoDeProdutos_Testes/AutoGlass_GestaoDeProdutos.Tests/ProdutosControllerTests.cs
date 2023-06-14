using System.Net;
using System.Text;
using System.Text.Json;
using AutoGlass_GestaoDeProdutos.Application.DTO;
using AutoGlass_GestaoDeProdutos.Application.Interfaces;
using AutoGlass_GestaoDeProdutos.Controllers;
using AutoGlass_GestaoDeProdutos.Domain.Core.Interfaces.Services;
using AutoGlass_GestaoDeProdutos.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AutoGlass_GestaoDeProdutos.Tests;

public class ProdutosControllerTests
{
    ProdutosController _controller;
    IApplicationServiceProduto _service;

    public ProdutosControllerTests()
    {
        _service = new ServiceProdutoFake();
        _controller = new ProdutosController(_service);
    }

    [Fact]
    public void Get_WhenCalled_ReturnsById()
    {
        // Act
        var okResult = _controller.Get(4);

        // Assert
        Assert.IsType<OkObjectResult>(okResult.Result);
    }

    [Fact]
    public void Post_WhenCalled_Post()
    {
        var novoProduto = new ProdutoDTO()
        {
            CodigoProduto = 5,
            DescricaoProduto = "teste 2",
            SituacaoProduto = true,
            FabricacaoProduto = DateTime.Now,
            ValidadeProduto = DateTime.Now,
            CodigoFornecedorProduto = 1,
            DescricacaoFornecedorProduto = "teste 2",
            CnpjFornecedorProduto = "74.704.008/0001-00"
        };

        // Act
        var response = _controller.Post(novoProduto) as ObjectResult;

        // Assert
        Assert.Equal(((int)HttpStatusCode.Created).ToString(), response.StatusCode.ToString());
    }
    
}
