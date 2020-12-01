# Interest Rate

Projeto Realizado para o desafio da Softplan

<b> Qual arquitetura foi escolhida? </b> </br>
R - Foi utilizado o .net core 2.2 com o conceito de DDD e utilizando command e handler, além de estar rodando no docker.

<b> Porque foi escolhido essa arquitetura? </b> </br>
R- Foi escolhida pois o .net core é um cross plataform, sendo facilmente colocado junto ao docker em qualquer ambiente, além do conceito de DDD utilizando command e handler, separando cada responsabilidade, dando facil entendimento e manutenção do código, bem como seu ciclo de vida facilmente utilizável.

<b> Quais APIs e endpoints foram desenvolvidos? </b></br>
R- Foram criados duas APIs e 3 endpoints.

<b> Explicando cada API </b></br>
A primeira API é a de Interest Rate, onde nela contém o endpoint de taxaJuros, onde retornará a taxa de juros que é de 0,01. </br>
A segunda API é a de Interest Calculation, onde nela contém dois endpoints, o de calculajuros, onde retornará o seguinte cálculo de juros:</br>
Valor Inicial * (1 + juros) ^ Tempo</br>
Valor inicial é um decimal recebido como parâmetro.</br>
Valor do Juros sendo consultado na API de Interest Rate.</br>
Tempo é um inteiro, que representa meses, também recebido como parâmetro.</br>
^ representa a operação de potência.</br>
Resultado final sendo truncado (sem arredondamento) em duas casas decimais.</br></br>

<b>Passo a passo para configurar e utilizar o sistema</b>
- Primeiro realize o clone do projeto
- Após o clone, vá até a pasta .docker e abra um prompt de comando
- Tenha o docker instalado na maquina, caso não tenha, realize o download no seguinte link: https://www.docker.com/get-started
- Depois escreva a seguinte instrução: docker-compose up -d --build interest-rate-api interest-calculation-api
- Está instrução irá rodar as imagens do interest-rate-api e do interest-calculation-api, onde nele estarão as nossas APIs
- Após ter terminado de configurar as imagens, utilize a instrução: docker ps
- Verifique se apareceram duas imagens, com os nomes interest-rate-api e interest-calculation-api, além de ambas estarem com o status Up
- Caso esteja tudo certo, acesso os seguintes links no seu navegador: http://localhost:5033/interestRate/swagger/index.html e http://localhost:5034/interestCalculation/swagger/index.html
- Neles contém toda a documentação de cada endpoint
