Feature: Interface

Acessar o site e consultar um veiculo

Scenario: Consultar carro no site
	Given eu esteja no site "https://hportal.webmotors.com.br/"
	When eu pesquisar por um modelo "corolla"
	And selecionar algum modelo disponivel
	Then o sistema apresenta as informacoes do modelo selecionado