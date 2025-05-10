# API de Autenticação

Esta API é responsável por intermediar a comunicação entre a aplicação [LoginService](https://github.com/LucasSousaDev/LoginService) e o banco de dados, fornecendo endpoints seguros para autenticação e gerenciamento de usuários.

## 🚀 Funcionalidades

- Registro de usuários
- Login com autenticação JWT
- Logout
- Validação de tokens
- Gerenciamento de sessões

## 🛠️ Tecnologias Utilizadas

- .NET 7.0
- Entity Framework Core
- JWT (JSON Web Tokens)
- SQL Server

## 📋 Pré-requisitos

- .NET 7.0 SDK
- SQL Server
- Visual Studio 2022 ou VS Code

## 🔧 Configuração

1. Clone o repositório
```bash
git clone https://github.com/LucasSousaDev/LoginSystem.git
```

2. Configure a string de conexão no arquivo `appsettings.json`

3. Execute as migrações do banco de dados
```bash
dotnet ef database update
```

4. Execute o projeto
```bash
dotnet run
```

## 📝 Endpoints

### Registro de Usuário
```
POST /api/Auth/register
```

### Login
```
POST /api/Auth/login
```

### Logout
```
POST /api/Auth/logout
```

## 🔒 Segurança

- Autenticação via JWT
- Senhas criptografadas
- Proteção contra ataques comuns
- Validação de dados

## 🤝 Integração com LoginService

Esta API foi desenvolvida especificamente para atender às necessidades do [LoginService](https://github.com/LucasSousaDev/LoginService), fornecendo uma camada segura e eficiente para:

- Autenticação de usuários
- Gerenciamento de sessões
- Validação de credenciais
- Armazenamento seguro de dados


