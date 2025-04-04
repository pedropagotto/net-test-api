## Objetivo:

Teste técnico para forlogic

## Descrição:

Essa api será basicamente um cadastro e gestão de usuarios conforme descrito no pdf do desafio da 4logic.

## Techs:

- .NET 8 Web Api
- Postgres
- Docker e docker compose

### Packages:

- Ef core 8
- JWT
- Fluent Validator
- Xunit
- NSubstitute
- AutoFixture

## Como rodar o projeto:

Clone o repositorio e na sequencia realize os comandos:

``` shell
dotnet restore

dotnet build

dotnet run

```

```
docker compose up -d
```

## Compartilhando contexto de decisões do projeto:

Porque foi utilizado .NET 8?

R: Por ser uma versão LTS.

Como foi estruturado o projeto quais arquiteturas foram baseadas?

Por que foi escolhido postgresSQL?

Por que foi determinado o uso do JWT ao invés de um provider de autenticação?


