# GestaoDeProdutos

**Endpoints**

- Recuperar um registro por código
- Listar registros
    - Filtrando a partir de parâmetros e paginando a resposta
- Inserir
    - Criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade
- Editar
    - Criar validação para o campo data de fabricação que não poderá ser maior ou igual a data de validade
- Excluir
    - A exclusão deverá ser lógica, atualizando o campo situação com o valor Inativo

**Requisitos**

- Construir a Web-api em dotnet core ou dotnet 5.
- Construir a estrutura em camadas e em DDD.
- Utilizar ORM
- Utilizar a biblioteca Automapper para fazer o mapeamento entity-DTO.
- Fazer teste unitários

**BD**

create table produto 
(  
    codigo_produto                 serial. 
        constraint produto_pk  
            primary key,  
      descricao_produto              varchar(500) not null,  
      situacao_produto               boolean      not null,  
      fabricacao_produto             date,  
      validade_produto               date         not null,  
      codigo_fornecedor_produto      integer      not null,  
      descricacao_fornecedor_produto varchar(500),  
      cnpj_fornecedor_produto        varchar(15)  
);  
