### Conteinerizando uma aplicação .NET Core

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

O objetivo é criar uma aplicação para gerenciar aluguel de motos e entregadores. Quando um entregador estiver registrado e com uma locação ativa poderá também efetuar entregas de pedidos disponíveis na plataforma.

A ideia central é **_conteinerizar_** um aplicativo .NET Core para desenvolvimento com o Docker Compose. Neste caso, trata-se de uma aplicação para cadastro de motos, entregadores, controle de aluguéis e delivery.

> Todo processo está configurado num arquivo de manifesto (**docker-compose.yaml**) que está na raiz da solução.

### 🔥 Para baixar:

```bash
$ git clone https://github.com/fabioborges-ti/AppGroup-api-net6
```

### 📋 Pré-requisitos
Antes de começar, você vai precisar ter instalado as seguintes ferramentas: [Git]([https://git-scm.com](https://git-scm.com/)) e o [Docker]([https://docs.docker.com/desktop/](https://docs.docker.com/desktop/)). Além disto, sugiro que você também utilize um bom editor de código, como o [VSCode]([https://code.visualstudio.com/]  (https://code.visualstudio.com/)). Este vai te oferecer _muitas_ extensões que farão toda diferença.

### 📦 Dependências do projeto
Abra seu terminal na pasta da solução e execute o seguinte comando: 

```bash
$ dotnet restore
```

### 🤞 Vamos testar?
Agora que você já tem tudo... chegou a hora de testar. Novamente, abra seu terminal na pasta **_raiz_** da solução, digite o comando abaixo e aguarde o fim do processo ☕

```bash
$ docker-compose up -d 
```
O **_Docker_** vai baixar do seu repositório https://hub.docker.com todas as imagens mencionadas no arquivo do _compose_ (**_yaml_**). Depois, inicia a geração da imagem e por fim a geração do container. Em poucos instantes nosso container estará de pé 😲

Quando esse processo encerrar, você pode conferir usando o comando abaixo:

```bash
$ docker-compose ps  
```
Atente para os seguintes containers:

```bash
webapi-1
pgadmin
postgresdb
rabbitmq
portainer
```

Se estes foram listados, sucesso! 🤗 Já podemos fazer nossa primeira chamada da API. 👋🏼

### 🧭 Para acessar esses recursos 

| Recursos          | Portas        | Urls                                      |
| ----------------- | ------------- | ----------------------------------------- |
| healthchecks      | 8081          | https://localhost:8081/health             |
| webapi-1          | 8081          | https://localhost:8081/swagger/index.html |
| portainer         | 9000          | http://localhost:9000                     |
| rabbitmq          | 15672         | http://localhost:15672                    |
| pgadmin           | 6002          | http://localhost:6002                     |

### 🛟 Importante

Antes que você inicie os testes, pedimos que você crie em seu disco local (conforme abaixo) que servirá como local para armazenamento dos dados da API (volumes) de alguns recursos, como Postgres; desse jeito você não irá perder nenhuma informação salva no seu banco de dados, conforme abaixo:

```bash
C:/Dados/Infraestrutura
```
Também é recomendado que você acesse a url do Portainer [mencionada acima](http://localhost:9000), crie uma conta de administrador para conseguir acessar e conferir se todos os recursos estão funcionando adequadamente. 

Trata-se de uma ótima alternativa para controle de logs da API e conferir um monte de outras coisas, como redes, volumes, imagens, eventos e uma série de coisas. Vale a pena testar e conhecer!

Vale ressaltar que essa API atende dois públicos distintos: os adminstradores do sistema e os entregadores (aqueles que querem alugar uma moto para trabalhar). Isso você vai poder conferir no link do Swagger, em https://localhost:8081/swagger/index.html

No topo da página, você verá as versões disponíveis (v1 e v2) para administradores e entregadores, respectivamente. Agora vamos ao que interessa... os recursos da API😜

### 💼 Versão administrador

| Recursos                      | Endpoints             | Finalidade                           |
| ----------------------------- | --------------------- | ------------------------------------ |
| Motodriver                    | /api/v1/Motodriver    | Listar entregadores                  |
| Motorcycle                    | /api/v1/Motorcycle    | Manter cadastro de motos             |
| Notification                  | /api/v1/Notification  | Listar notificações                  |
| Order                         | /api/v1/Order         | Criar pedidos                        |
| Rent                          | /api/v1/Rent          | Manter contratos de aluguel          |

> **Nota:** O administrador tem o papel de manter o cadastro das motos atualizado, gerar pedidos de entrega e controlar as notificações.

> - Na controller Rent, tomei a liberdade de incluir um endpoint que faz uso de uma **API pública** para pesquisa completa do CNPJ do entregador.

### 📱 Versão entregador

| Recursos                      | Endpoints             | Finalidade                               |
| ----------------------------- | --------------------- | ---------------------------------------- |
| Delivery                      | /api/v2/Delivery      | Manter entregas de pedidos               |
| Motodriver                    | /api/v2/Motodriver    | Manter cadastro de entregadores          |
| Rent                          | /api/v2/Rent          | Manter contratos de aluguel              |

> **Nota:** Os entregadores podem checar se há motos disponíveis para aluguel, conferir os diferentes planos e valores de aluguel e mais... se possuir a CNH com a categoria A (motos) ainda poderão conferir se há pedidos disponpiveis para entrega e sair trabalhando... 

> - Apenas os motoristas habilitados com CNH do tipo **A** serão notificados das entregas.

### 📑 Regras gerais 

O sistema foi desenvolvido para testar as seguintes situações:

- O CNPJ do entregador é único (não pode se repetir) e deve ser válido;
- O número da CNH é único e não pode se repetir;
- Quando um entregador estiver registrado e com uma locação ativa poderá também efetuar entregas de pedidos disponíveis na plataforma;
- Quando o pedido entrar na plataforma a aplicação deverá notificar os entregadores sobre a existencia desse pedido;
- A notificação deverá ser publicada por mensageria;
  - Somente entregadores que tenham sido notificados podem aceitar o pedido.
  - Somente entregadores com locação ativa e que não estejam com um pedido já aceito deverão ser notificados;
- Um entregador pode publicar uma foto de perfil, apenas nos formatos BMP e PNG;
- Um entregador não pode gerar novo contrato de aluguel estando com um contrato ativo;
- Um entregador não pode encerrar um contrato de aluguel com pedido de entrega pendente;
- O administrador quer consultar todos entregadoeres que foram notificados de um pedido;

### 📢 Notas importantes 

> - Anexei um arquivo PDF (notas técnicas) no repositório que ajudará na utilização do sistema.

### 💾 Principais tecnologias envolvidas 

Principais tecnologias e padrões envolvidos;

- Netcore 6;
- MediatR;
- Postgres;
- RabbitMQ;
- MassTransit;
- EntityFrameWorkCore e Dapper;
- FluentValidation;
- Serilog;
- RestSharp;
- HealthChecks;
- Princípios SOLID;
- Clean Architecture e Clean Code;
- Padrões de projeto
  - CQRS;
  - Chain of responsibility;
- Arquitetura e modelagem de dados;
- Versionamento de APIs;
- xUnit;
  - Moq;
  - Unit tests;
  - Integration tests;

### ✈️ Para mais informações:
Se você não conhece sobre docker ou docker-compose e quer mais detalhes, consulte em:

https://docs.docker.com/compose/

E bons estudos! 🚀
