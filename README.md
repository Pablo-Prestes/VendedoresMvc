Projeto criado usando .NetCore Mvc, Razor, MySql, BootStrap

Passo para rodar o projeto em sua máquina 

1- Verifique se você tem as principais dependências do projeto .Net 6.0 ou superior e Sdk 6.0 ou superior
 <PackageReference Include="Pomelo.EntityFrameworkCore.MySql" Version="7.0.0" />
 
 <PackageReference Include="MySql.EntityFrameworkCore" Version="7.0.2" />Para utilizar o MySql no projeto

2- Segundo passo trocar a string de conexão com o banco de dados
 appsetings.json  "server=localhost;database=**NomeDaDB**;user=**Usuario**;password=**Senha**"

3- Criar as migrações para o banco de dados
  Em PackgeManagerConsole cria as migrações Add-migration "Nome da migração",
  Atualize o DB com as migrações Update-database. 
  A população do banco de dados irá ocorrer automática em Data/PopulacaoDeDados(Somente na primeira execução do programa)

 4 -  Execute o projeto
