# Cadastro de Clientes e Endereços

## Arquitetura:

* AspNet Core 3.1
* Swagger Framework
* Domain Driven Desing
* Test Driven Development
* Api RestFull
* SOLID

## Projeto:

* Cadastro.Api
  * Controllers
    * Get()
    * Get([FromRoute] long id)
    * Post([FromBody] Entidade entidade)
    * Put([FromRoute]long id, [FromBody] Entidade entidade)
    * Delete([FromRoute]long id)
  * Startup
  * Program
* Cadastro.Dominio
  * Abstracoes
  * Entidades
    * Entidade
    * Modelo
    * Repositorio
    * Servico
  * Contexto
    * Mapeamento de Entidades
    * Provedor de Acesso
* Cadastro.Infraestrutura
  * Conexoes
  * Extensoes
* Cadastro.Teste
  * Teste de Entidades
