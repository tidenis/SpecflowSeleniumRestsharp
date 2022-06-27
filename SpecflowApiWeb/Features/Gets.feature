Feature: Gets

Realizar get para obter os dados desejados

@tag1
Scenario: Realizar get no endpoint make
	Given eu tenha acesso ao endpoint "/api/OnlineChallenge/Make"
	When eu enviar uma requisicao get em "/api/OnlineChallenge/Make"
	Then o sistema retorna sucesso
	And retorna o response make

Scenario: Realizar get no endpoint Model
	Given eu tenha acesso ao endpoint "/api/OnlineChallenge/Model"
	And tenha um make valido
	When eu enviar uma requisicao enviando um makeid em "/api/OnlineChallenge/Model"
	Then o sistema retorna sucesso
	And retorna o response model