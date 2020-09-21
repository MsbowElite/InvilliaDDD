# DDD project
crqs, repository, dependency injection, clean, solid.

#Database Sql Server EntityFramework Commands
Projeto seguiu metodologia de DATABASE FIRST
dotnet ef dbcontext scaffold "Server=localhost;Database=GameManager;Uid=sa;Pwd=Insecure!12345" Microsoft.EntityFrameworkCore.SqlServer

#Sql Create Script 
File in solution, "Create.sql"

#Planos
Adicionar EventSourcing com storage em SqlServer
RabbitMQ
Refazer toda estrutura de autenticação
Http actions filter
Http throttling
