# Chamados Noris
Este projeto utiliza as seguintes dependencias:
* Node 18.14.0
* Dotnet Core 7.0 (ef core 7.0.5)
* Angular 15.1.5

Após a instalação dessas dependencias basta executar o migration seguindo abaixo:
* Para executar a migration do auth e dos chamados execute o comando:
* * Context/Auth 
* * * dotnet ef --startup-project ..\..\Web\IdentityServer migrations add InitialCreate -o Data/Migrations	
* * * dotnet ef --startup-project ..\..\Web\IdentityServer database update  
* * Context/Chamados
* * * dotnet ef --startup-project ..\..\Web\ChamadosApi migrations add InitialCreate -o Data/Migrations	
* * * dotnet ef --startup-project ..\..\Web\ChamadosApi database update  

Para a execução do site localmente é importante que tenha o ChamadosApi e IdentityServer rodando juntos para isso execute os comandos
cd  Web\IdentityServer
dotnet run 
cd ..\..\Web\ChamadosApi
dotnet run 
cd ..\..\Web\Angular
na primeira vez, rodar o comando: npm install
ng serve 

Caso queira debugar um dos serviços, basta selecionar o mesmo como projeto principal em sua IDE e executar, não e necessario executar o comando.

Ambos os serviços web são auto gerenciados portanto para publicação não e necessário muito basta executar o comando 
cd  Web\IdentityServer
 
 Atualizar banco de dados - novos campos
 dotnet ef --startup-project ..\..\Web\ChamadosApi migrations add "V##" -o Data/Migrations


https://localhost:5001/.well-known/openid-configuration

dotnet run .\IdentityServer.dll --urls=https://localhost:5001/ 
dotnet run environment=development .\ChamadosApi.dll --urls=https://localhost:5000/  
ng build --base-href='/basepath/'   

Publicação
Para publicar execute os comandos abaixo:
cd  Web\IdentityServer
dotnet publish -c Release -o C:\temp\publish\release\identityserver

cd  Web\ChamadosApi
dotnet publish -c Release -o C:\temp\publish\release\chamadosapi

cd  Web\EnviarEmailApi
dotnet publish -c Release -o C:\temp\publish\release\emailapi

cd  Web\Angular
npm run publish

Usuario para acesso remoto:
ex-fmarcos
#Nemak@2021

Login prod externo e autenticacao maquina virtual 
am\ex-fmarcos
#Nemak@2021

Chave github
ohl5qbvpbqyeufjn4xmgm37nuez2uqwpzee742iabistitngyr3a