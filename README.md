# MotoFácil API 🚀

API RESTful desenvolvida em ASP.NET Core, utilizando Entity Framework Core e banco de dados Oracle.
Esta API permite o cadastro e login de usuários, utilizando apenas usuário e senha, e também a gestão de motos no sistema.

Conta com documentação interativa via Swagger para facilitar testes e integração.

---

## 📌 Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- Oracle Database
- EF Core Migrations
- Swagger (OpenAPI)
- C#

---

## ⚙️ Funcionalidades da API

- ✅ Cadastro de usuários
- ✅ Login de usuários
- ✅ Consulta de usuários por ID
- ✅ Busca de usuário por nome
- ✅ Atualização de usuários
- ✅ Exclusão de usuários
- ✅ Cadastro de motos
- ✅ Consulta de todas as motos
- ✅ Consulta de moto por ID
- ✅ Atualização de motos
- ✅ Exclusão de motos



---

## 🔗 Rotas da API

| Método | Rota                  | Descrição                             |
|--------|-----------------------|---------------------------------------|
| POST   | /api/user             | Cadastrar novo usuário                |
| POST   | /api/auth/login       | Login de usuário                      |
| GET    | /api/user             | Listar todos os usuários              |
| GET    | /api/user/{id}        | Buscar usuário por ID                 |
| GET    | /api/user/search?username={nome} | Buscar usuário por nome    |
| PUT    | /api/user/{id}        | Atualizar usuário                     |
| DELETE | /api/user/{id}        | Deletar usuário                       |

| Método | Rota        | Descrição                                  |
| ------ | ----------- | ------------------------------------------ |
| GET    | /motos      | Lista todas as motos cadastradas           |
| GET    | /motos/{id} | Retorna os detalhes de uma moto específica |
| POST   | /motos      | Adiciona uma nova moto ao sistema          |
| PUT    | /motos/{id} | Atualiza as informações de uma moto        |
| DELETE | /motos/{id} | Remove uma moto do sistema                 |



---

## 🛠️ Instalação e Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/MotoFacilAPI.git
   cd MotoFacilAPI
