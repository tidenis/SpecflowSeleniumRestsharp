using NUnit.Framework;
using SpecflowApiWeb.Drivers;
using SpecflowApiWeb.Pages;

namespace SpecflowApiWeb.StepDefinitions
{
    [Binding]
    public class InterfaceStepDefinitions : SeleniumDriver
    {
        HomePageElements homePageElements = new HomePageElements();

        [Given(@"eu esteja no site ""([^""]*)""")]
        public void GivenEuEstejaNoSite(string site)
        {
            ConfigurarNavegador(site);
        }

        [When(@"eu pesquisar por um modelo ""([^""]*)""")]
        public void WhenEuPesquisarPorUmModelo(string modeloCarro)
        {
            EsperarElementoFicarDisponivelParaEscreverPeloId(homePageElements.barraBuscarId, modeloCarro);
            EsperarElementoFicarClicavelPeloXpath(homePageElements.resultadoModelosXpath);            
        }

        [When(@"selecionar algum modelo disponivel")]
        public void WhenSelecionarAlgumModeloDisponivel()
        {            
            EsperarElementoFicarClicavelPeloXpath(homePageElements.resultadoModeloPesquisadoXpath);
        }

        [Then(@"o sistema apresenta as informacoes do modelo selecionado")]
        public void ThenOSistemaApresentaAsInformacoesDoModeloSelecionado()
        {
            string precoFormatado;            
            string precoVeiculo = (ColetarTextoInternoPeloId(homePageElements.precoVeiculoId));
            precoFormatado = precoVeiculo.Replace("R$ ","");
            precoFormatado = precoFormatado.Replace(".", "");
            int precoInteiro = Int32.Parse(precoFormatado);
            
            Assert.Greater(precoInteiro, 30000);
            FecharNavegador();
        }
    }
}