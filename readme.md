# Autenticacao
- Necessário criar um usuário
- endpoint http://localhost:5214/v1/usuarios
- Método: Post
- No body é obrigatório os seguinta campos:
Request
~~~json
{
  "email": "string",
  "password": "string",
  "name": "string"
}
~~~
Response
~~~json
{
  "data": {
    "token": "string",
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "email": "string"
  },
  "message": "string"
}
~~~
 na criação já retorno o token, mas também pode ser o ulizado o endpoint de login para obter o token
- enpoint: http://localhost:5214/v1/usuarios/login
- Método: Post
Request
~~~json
{
  "email": "inacio@mail.com",
  "password": "1234567890"
}
~~~
Response
~~~json
{
  "data": {
    "token": "string",
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "name": "string",
    "email": "string"
  },
  "message": "string"
}
~~~
- Com o token já é possível fazer as operações da api de tarefas

# Tarefas
### Criar
- endpoint: http://localhost:5214/v1/tarefas
- método: Post
- Authorization bearToken
- dataConclusao é um campo opcional, demais obrigatório
Request
~~~json
{
    "titulo": "primeira",
    "descricao": "essa é a 1 tarefa",
    "dataCriacao": "2024-12-22T21:51:01.5659609-03:00",
    "dataConclusao": "2024-12-23T00:49:12.31Z",
    "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
}
~~~
Response
~~~json
{
    "data": {
        "id": 3,
        "titulo": "segund",
        "descricao": "essa é a 2 tarefa",
        "dataCriacao": "2024-12-22T22:20:15.9641955-03:00",
        "dataConclusao": "2024-12-23T00:49:12.31Z",
        "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
    },
    "message": "tarefa criada com sucesso"
}
~~~
### Obter por id
- endpoint: http://localhost:5214/v1/tarefas/{id}
- método: Get
- Authorization bearToken
Response
~~~json
{
    "data": {
        "id": 2,
        "titulo": "primeira",
        "descricao": "essa é a 1 tarefa",
        "dataCriacao": "2024-12-22T22:20:00.7533898",
        "dataConclusao": "2024-12-23T00:49:12.31",
        "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
    },
    "message": null
}
~~~
### Obter todos do usuario
- endpoint: http://localhost:5214/v1/tarefas?pageNumber=1&pageSize=25
- método: Get
- Authorization bearToken
Response
~~~json
{
    "currentPage": 1,
    "totalPages": 1,
    "pageSize": 25,
    "totalCount": 2,
    "data": [
        {
            "id": 2,
            "titulo": "primeira",
            "descricao": "essa é a 1 tarefa",
            "dataCriacao": "2024-12-22T22:20:00.7533898",
            "dataConclusao": "2024-12-23T00:49:12.31",
            "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
        },
        {
            "id": 3,
            "titulo": "segund",
            "descricao": "essa é a 2 tarefa",
            "dataCriacao": "2024-12-22T22:20:15.9641955",
            "dataConclusao": "2024-12-23T00:49:12.31",
            "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
        }
    ],
    "message": null
}
~~~

### Editar
- endpoint: http://localhost:5214/v1/tarefas
- método: Put
- Authorization bearToken
Request
~~~json
{
  "idUsuario": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "titulo": "primeira",
  "descricao": "essa é a 1 tarefa editada",
  "dataConclusao": "2024-12-23T00:49:12.310Z"
}
~~~

Response
~~~json
{
{
    "data": {
        "id": 1,
        "titulo": "primeira",
        "descricao": "essa é a 1 tarefa editada",
        "dataCriacao": "2024-12-22T21:51:01.5659609",
        "dataConclusao": "2024-12-23T00:49:12.31Z",
        "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
    },
    "message": "Tarefa atualizada com sucesso"
}
}
~~~

### Deletar
- endpoint: http://localhost:5214/v1/{id}
- método: Delete
- Authorization bearToken

Response
~~~json
{
    "data": {
        "id": 1,
        "titulo": "primeira",
        "descricao": "essa é a 1 tarefa editada",
        "dataCriacao": "2024-12-22T21:51:01.5659609",
        "dataConclusao": "2024-12-23T00:49:12.31",
        "idUsuario": "3c0fc708-e72c-4d94-b4fe-ce71ce8fd863"
    },
    "message": "Tarefa excluída com sucesso!"
}
~~~