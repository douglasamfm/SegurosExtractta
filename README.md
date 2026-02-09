# Seguros API

API REST para cadastro e consulta de seguros, com cálculo do valor do seguro,
persistência em banco relacional (SQLite) e relatório em JSON com média aritmética.

## Tecnologias
- .NET 8
- ASP.NET Core Web API
- EF Core + SQLite
- xUnit (testes unitários)
- Swagger / OpenAPI

## Arquitetura
Projeto organizado seguindo separação de responsabilidades (Clean Architecture):

- **Seguros.Domain**
  - Entidades e regras de negócio
  - Cálculo do valor do seguro
- **Seguros.Application**
  - Casos de uso
  - DTOs (Requests / Responses)
  - Interfaces de repositório
- **Seguros.Infrastructure**
  - Persistência de dados (EF Core + SQLite)
  - Implementações de repositórios
- **Seguros (API)**
  - Controllers
  - Configuração de DI, Swagger e banco
- **Seguros.Tests**
  - Testes unitários do domínio

## Como executar
1. Abra a solução `Seguros.sln`
2. Defina o projeto **Seguros** como Startup Project
3. Execute a aplicação (F5) ou via terminal:

```bash
dotnet run --project Seguros
