# MotoFácil API 🚀

API RESTful desenvolvida em ASP.NET Core com Entity Framework Core e banco de dados Oracle.  
Essa API realiza o cadastro e login de usuários, utilizando apenas **usuário e senha**, com documentação via Swagger.

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

---

## 🔗 Rotas da API

| Método | Rota                  | Descrição                             |
|--------|-----------------------|---------------------------------------|
| POST   | /api/user             | Cadastrar novo usuário                |
| POST   | /api/auth/login       | Login de usuário                      |
| GET    | /api/user             | Listar todos os usuários              |
| GET    | /api/user/{id}        | Buscar usuário por ID                 |
| GET    | /api/user/search?username={nome} | Buscar usuário por nome         |
| PUT    | /api/user/{id}        | Atualizar usuário                     |
| DELETE | /api/user/{id}        | Deletar usuário                       |

---

## 🛠️ Instalação e Execução

1. Clone o repositório:
   ```bash
   git clone https://github.com/seuusuario/MotoFacilAPI.git
   cd MotoFacilAPI
