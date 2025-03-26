# Sistema de Login com JWT

Um sistema de autenticação simples usando ASP.NET Core Web API com JWT (JSON Web Tokens).

## Funcionalidades

- Registro de usuários
- Login com JWT
- Logout
- Proteção de rotas com autenticação

## Requisitos

- .NET 9.0 SDK
- SQL Server
- Visual Studio 2022 ou VS Code

## Configuração

1. Clone o repositório
2. Configure a string de conexão no arquivo `appsettings.json`
3. Execute as migrações do banco de dados:
   ```bash
   dotnet ef database update
   ```
4. Execute o projeto:
   ```bash
   dotnet run
   ```

## Endpoints

### Registro
- POST `/api/auth/register`
- Body:
  ```json
  {
      "username": "seu_usuario",
      "email": "seu_email@email.com",
      "password": "sua_senha"
  }
  ```

### Login
- POST `/api/auth/login`
- Body:
  ```json
  {
      "email": "seu_email@email.com",
      "password": "sua_senha"
  }
  ```

### Logout
- POST `/api/auth/logout`
- Header:
  ```
  Authorization: Bearer seu_token_jwt
  ```

## Tecnologias Utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- JWT Authentication
- SQL Server
- BCrypt para hash de senhas 