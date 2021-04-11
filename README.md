# DDD project
	crqs, repository, dependency injection, clean, solid, docker compose.

# Front-End(Em desenvolvimento)

	Autenticação\
	Criação de telas

# Database Sql Server EntityFramework Commands
	Projeto seguiu metodologia de DATABASE FIRST

		dotnet ef dbcontext scaffold "Server=localhost;Database=GameManager;Uid=sa;Pwd=Insecure!12345" Microsoft.EntityFrameworkCore.SqlServer

# Sql Create Script
	Arquivo na base da solution, "Create.sql"

# Planos
	Adicionar EventSourcing com storage em SqlServer\
	RabbitMQ\
	Refazer toda estrutura de autenticação\
	Http actions filter\
	Http throttling\
	Encapsular BaseRepository para o CORE\
	Tratamento de mensagens de erro\
	Tratar erros adversos
	Adicinar FK User para Friends e Games, assim podendo ser um sistema multi-usuario\
	  sendo que cada um terá acesso limitado ao que o próprio criou

# Comandos avulsos

  docker run -e "ACCEPT_EULA=Y" -e "Insecure!12345" `
   -p 1433:1433 --name companyMSQL -h companyMSQL `
   -d microsoft/mssql-server-linux

   docker container commit 016e5c9cbbf5 companyMSQL
   docker image tag company-msql msbowelite/company-msql
   docker push msbowelite/company-msql
