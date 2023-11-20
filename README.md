# CondoApp

# Introdução ao projeto
Projeto para aplicativo de condomínio

# Integrantes

-Larissa Moura Basso

-Felipe de Souza Modesto

-Gabriel Lima Silva

-Daniel Cardoso Costa

-Éder Cardoso Fernandes

-Davi de Oliveira

## Protótipo Figma
https://www.figma.com/file/FfpZ2n1bgwumlAev4L9mnj/CondoApp?type=design&node-id=0-1&mode=design&t=8p1uT439DdX8Y6px-0

## *_Tecnologias Utilizadas_*

FRONTEND
 - React (Utilizado como framework base)

## Fluxo de Funcionamento Frontend
- Instalar o Node.js v6.14.13
- Baixar pasta CondoAppFrontend/condo-app
- Abrir VSCode (ter instalado)
- Abrir terminal no diretório do projeto "CondoAppFrontend/condo-app"
- Executar o comando "npm install"
- Executar o comando "npm start"

### Fluxo do Projeto (Navegação entre telas)
- Fazer login com os dados   "email": "pi@exemplo.com.br", "password": "projetointegrador".
- Na tela inicial, clicar em reservar.
- Inserir dados e "adicionar".

BACKEND
 - .Net6.0 (Utilizado como framework base)
 - EntityFramework 7.0 (Utilizado para acesso a banco de dados full ORM)
 - Microsoft SQL Server Management Studio 18.12.1

### Fluxo do Projeto (Endpoints da API)
	# Atualmente o projeto conta com os endpoints:
		##User
			- Login (POST - https://localhost:7133/User/logins)
		
		##Reservation
			- Busca por todas as reservas (GET - https://localhost:7133/Reservation/{userId}) *
			- Cria nova reserva (POST - https://localhost:7133/Reservation/{userId}) *
			
* - Os endpoints com * necessitam de autorização de acesso via JWT, fornecido após login de um usuário pré-cadastrado.

### Usuário default 
email: pi@exemplo.com.br
senha: projetointegrador

## Fluxo para funcionamento da API

- Ter instalado o VSCode com as extensões (.NET runtime install tool, C# e C# extensions).
- Ter instalado o Microsoft SQL Server Management Studio 18.12.1.
- Ter instalado o POSTMAN (para fazer as requisições para a API como teste).
- Abrir o SQL Server e rodar os scripts no final das instruções.
- Abrir o VSCode, em seguida ir em "Abrir Pasta" e selecionar a pasta CondoAppAPI.
- Em Data -> Contexts -> CondoAppContext.cs, alterar o nome do "Server" da connectionString de acordo com o da sua máquina.
- Usar Cntrl+S para salvar.
- Caso apareça uma mensagem no canto direito do VSCode pedindo para usar a extensão do C#, clicar em "sim" (pode aparecer a qualquer momento).
- No terminal, digitar dotnet run (é necessário estar apontando o diretório para a pasta CondoAppAPI\CondoAppAPI).
- Ir no POSTMAN e fazer as requisições necessárias.

  ### POSTMAN

- JSON para login de User (POST - https://localhost:7133/User/logins)
  Obs: na aba Body (clicar na opção "raw" e mudar texto para JSON)
{
  "email": "pi@exemplo.com.br",
  "password": "projetointegrador"
}

- Buscar reservas (GET - https://localhost:7133/Reservation/{userId})
  Obs1: Passar o campo Id que retornou do user default.
  Obs2: Na aba Authorization, clicar na opção "type", mudar para "Bearer Token" e colar campo token retornado do login do user default.


- Criar reserva (POST - https://localhost:7133/Reservation/{userId})
  Obs1: Passar o campo Id que retornou do user default.
  Obs2: Na aba Authorization, clicar na opção "type", mudar para "Bearer Token" e colar campo token retornado do login do user default.
  Obs3: Na aba Body (clicar na opção "raw" e mudar texto para JSON) e passar os seguintes parâmetros:
  {
  "title": "título da reserva",
  "leisureSpace": "espaços de lazer reservados",
  "dateTime": "data desejada para reserva do evento"
  }
  Obs4: Os dois primeiros campos são do tipo string e a data é do tipo datetime.

  # Scripts SQL

  ## Script 1:

  CREATE DATABASE CondoApp;

  ## Script 2:

  USE [CondoApp];

IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL BEGIN CREATE TABLE [__EFMigrationsHistory] ( [MigrationId] nvarchar(150) NOT NULL, [ProductVersion] nvarchar(32) NOT NULL, CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId]) ); END; 

BEGIN TRANSACTION; 

CREATE TABLE [Users] ( [Id] uniqueidentifier NOT NULL, [Name] nvarchar(max) NOT NULL, [Email] nvarchar(max) NOT NULL, [Document] nvarchar(max) NOT NULL, [Password] nvarchar(max) NOT NULL, [BirthDate] datetime2 NOT NULL, [Type] int NOT NULL, [CreateAt] datetime2 NOT NULL, CONSTRAINT [PK_Users] PRIMARY KEY ([Id]) ); 

CREATE TABLE [Messages] ( [Id] uniqueidentifier NOT NULL, [UserId] uniqueidentifier NOT NULL, [Title] nvarchar(max) NOT NULL, [Description] nvarchar(max) NOT NULL, [HasBeenReaded] bit NOT NULL, [DateTime] datetime2 NOT NULL, [Type] int NOT NULL, [CreateAt] datetime2 NOT NULL, CONSTRAINT [PK_Messages] PRIMARY KEY ([Id]), CONSTRAINT [FK_Messages_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE ); 

CREATE TABLE [Reservations] ( [Id] uniqueidentifier NOT NULL, [UserId] uniqueidentifier NOT NULL, [Title] nvarchar(max) NOT NULL, [LeisureSpace] nvarchar(max) NOT NULL, [DateTime] datetime2 NOT NULL, [CreateAt] datetime2 NOT NULL, CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id]), CONSTRAINT [FK_Reservations_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE ); 

CREATE TABLE [Services] ( [Id] uniqueidentifier NOT NULL, [UserId] uniqueidentifier NOT NULL, [Title] nvarchar(max) NOT NULL, [Description] nvarchar(max) NOT NULL, [Value] decimal(18,2) NOT NULL, [Phone] nvarchar(max) NOT NULL, [Address] nvarchar(max) NOT NULL, [CreateAt] datetime2 NOT NULL, CONSTRAINT [PK_Services] PRIMARY KEY ([Id]), CONSTRAINT [FK_Services_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE ); 

CREATE INDEX [IX_Messages_UserId] ON [Messages] ([UserId]); 

CREATE INDEX [IX_Reservations_UserId] ON [Reservations] ([UserId]); 

CREATE INDEX [IX_Services_UserId] ON [Services] ([UserId]); 

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231024152353_Initial', N'7.0.12'); 

COMMIT; 

INSERT Users VALUES(NEWID(), 'Master', 'pi@exemplo.com.br', '12345678910', 'projetointegrador',GETDATE(), 1, GETDATE());








