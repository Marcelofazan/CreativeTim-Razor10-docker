## 🌐 Argon-RazorPages10-docker
Exemplo de renderização Argon Dashboard em C# ASP.NET Core 10 EF com banco de dados Postgres.

#### 🎨 Aqui está uma demonstração do projeto
<img width="800" height="350" alt="image" src="https://github.com/user-attachments/assets/82458208-621e-444d-bbaf-71feeb5fb4c3" />

#### 📋 O que voçê vai ver nesse Projeto
| Tecnologia | Descrição |
|-----------|-----------|
| **Argon** | Painéis administrativos, sistemas de CRM, controle de dados e interfaces de gerenciamento |
| **BootStrap4** | Serviços de autenticação, autorização e gerenciamento de acessos,  garantindo que apenas as pessoas e entidades autorizadas acessem recursos e dados |
| **Identity** | Serviços de autenticação, autorização e gerenciamento de acessos,  garantindo que apenas as pessoas e entidades autorizadas acessem recursos e dados |

#### 💬 Requisitos do Projeto
- Necessário **Docker** instalado.
- Certificado válido **SSL/TLS**

#### ⚠️ String de conexão do banco 
Alterar em todos arquivos **YML** e **appsettings** o campo **[SUA_SENHA]** colocar sua senha localhost do Postgres.

-Nos arquivos **appsettings** 
```bash
 "PostgresConnection": "Host=localhost;Port=5432;Database=creativeTim;User Id=postgres;Password=[SUA_SENHA]"
```
-Nos arquivos **YML**  
```bash
POSTGRES_PASSWORD: '[SUA_SENHA]'
```
```bash
 CONNECTIONSTRINGS__POSTGRESCONNECTION=Server=db;Port=5432;Database=creativeTim;User Id=postgres;Password=[SUA_SENHA]
```
No arquivo **ApplicationDbContextFactory.cs**  
```bash
 optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=creativeTim;User Id=postgres;Password=[SUA_SENHA]");
```

#### 🔄 Executar a aplicação Docker
VSCode Terminal [1]

- Criar Container
```bash
docker-compose up --build
```

VSCode Terminal [2]
- Fechar Container
```bash
docker compose down 
```

#### 🔄 Executar a aplicação Desenvolvimento Local
VSCode Terminal [1.1]
- Necessário verificar se em Serviços o Postgres está iniciado.
```bash
cd CreativeTim.Argon.DotNetCore.Free
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update 
```

A aplicação ficará disponivel em **https://localhost:44308/**

Para primeiro acesso usuario: **admin@argon.com** senha: **Secret1+**

#### 🔍 Docker no Postgres 
Para verificar se a database **creativeTim** está no docker acesse o banco com os commandos, para verificar as tabelas. 


**Observação:** Para manipular os dados do **Postgres** no **Docker** alterar **appsettings**, após configurado o banco de dados.
- Deve se trocar **Server=localhost** por **Host=db** nos arquivos **appsettings** , os Postgres aceita o dialeto tanto a palavra **Server** como a palavra **Host** para distinguir o Servidor. 

| Host | Conexão |
|-----------|-----------|
| **Local** | Server=localhost |
| **Docker** | Host=db ou Server=db |

VSCode Terminal [3]
```bash 
docker exec -it argon-dashboard-asp-net-master-db-1 psql -U postgres
\l
\c creativeTim
\dt
```
- Caso houver falhas de Erro nos comandos Digite  ; ( ponto e virgula ) e aperte **Enter**.
- Se você já digitou texto errado na linha anterior, use o atalho **Ctrl + C** para cancelar o comando atual e limpar a linha. Digite o comando completo novamente em uma única linha e finalize com  ; ( ponto e virgula )

- Os Select(s) das tabelas do **Identity Microsoft** podem ser usados no terminal

VSCode Terminal [4]
```bash 
	SELECT * FROM "AspNetRoles";
	SELECT * FROM "AspNetUsers";
	SELECT * FROM "AspNetUserRoles";
	SELECT * FROM "AspNetRoleClaims";
	SELECT * FROM "AspNetUserClaims";
	SELECT * FROM "AspNetUserLogins";
	SELECT * FROM "AspNetUserTokens";
	SELECT * FROM "DataProtectionKeys";
```
- Verificar o Health do banco
 ```bash  
docker inspect --format='{{json .State.Health}}' argon-dashboard-asp-net-master-db-1
```
- Verificar **TCP/IP** da aplicação 
```bash  
docker inspect -f '{{range.NetworkSettings.Networks}}{{.IPAddress}}{{end}}' argon-dashboard-asp-net-master-db-1
```
- Caso precise Recriar o banco de dados
```bash  
SELECT pg_terminate_backend(pid) FROM pg_stat_activity WHERE datname = 'creativeTim'
;
DROP DATABASE "creativeTim";
```

#### Identity ASPNET relação de tabelas
| Tabela | Descrição |
|-----------|-----------|
| **AspNetRoles** |  Armazena os papéis/perfis de acesso (ex: Admin, Usuário). |
| **AspNetUsers** |  Armazena os dados dos usuários cadastrados. |
| **AspNetUserRoles** |  Tabela de associação (muitos-para-muitos) que vincula quais usuários possuem quais papéis. |
| **AspNetRoleClaims** |  Permissões ou reivindicações específicas atreladas a um papel. |
| **AspNetUserClaims** |  Permissões específicas atribuídas diretamente a um usuário. |
| **AspNetUserLogins** |  Usado para logins externos (como Google, Facebook, Microsoft). |
| **AspNetUserTokens** |  Armazena tokens de autenticação do usuário. |


 #### ⚙️ Instalar Certificado válido **SSL/TLS
- Garante que a pasta existe no seu Windows
```bash
mkdir -Force "$env:USERPROFILE\.aspnet\https"
```
- Limpa resquícios de certificados antigos
```bash
dotnet dev-certs https --clean
```
- Cria um novo certificado confiável no Windows
```bash
dotnet dev-certs https --trust
```
- Exporta o arquivo PFX com uma senha padrão para a pasta correta
```bash
dotnet dev-certs https -ep "$env:USERPROFILE\.aspnet\https\argonapp.pfx" -p "CrypticPassword99!"
```

