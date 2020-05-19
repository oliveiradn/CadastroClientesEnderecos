# Cadastro de Clientes e Endereços

## Arquitetura:

### Padrões
* SOLID
* Domain Driven Desing
* Test Driven Development
* Api RestFull

### Frameworks
* AspNet Core 3.1
* Entity Framework Core 3
* Swagger Framework
* XUnit

## Projeto:

### Organização

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

### Acesso a Api
[Endereço Localhost]/swagger/index.html


## Base de dados
### Realizar Migration em uma base de dados:
* Add-Migration InitialRelease
* Update-Database
