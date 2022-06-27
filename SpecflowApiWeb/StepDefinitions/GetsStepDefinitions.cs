using SpecflowApiWeb.Helpers;

namespace SpecflowApiWeb.StepDefinitions
{
    [Binding]
    public class GetsStepDefinitions
    {        
        RestSharpHelpers restSharpHelpers = new RestSharpHelpers(); 
        int MakeIDValido;

        [Given(@"eu tenha acesso ao endpoint ""([^""]*)""")]
        public void GivenEuTenhaAcessoAoEndpoint(string endpoint)
        {
            restSharpHelpers.ConfiguraEndpoint(endpoint);
        }

        [Given(@"tenha um make valido")]
        public void GivenTenhaUmMakeValido()
        {
            MakeIDValido = restSharpHelpers.ConsultaMakeIDValido();
        }

        [When(@"eu enviar uma requisicao get em ""([^""]*)""")]
        public void WhenEuEnviarUmaRequisicaoGetEm(string endpoint)
        {
            restSharpHelpers.EnviaRequisicaoGet(endpoint);
        }

        [When(@"eu enviar uma requisicao enviando um makeid em ""([^""]*)""")]
        public void WhenEuEnviarUmaRequisicaoEnviandoUmMakeidEm(string endpoint)
        {
            Dictionary<string, int> parametros = new Dictionary<string, int>()
            {
                {
                    "MakeID", MakeIDValido
                }
            };
            restSharpHelpers.EnviaRequisicaoGet(endpoint, parametros);
        }

        [Then(@"o sistema retorna sucesso")]
        public void ThenOSistemaRetornaSucesso()
        {
            restSharpHelpers.ValidaRetornoSucesso();
        }     

        [Then(@"retorna o response make")]
        public void ThenRetornaOResponseMake()
        {
            restSharpHelpers.ValidaBodyResponseMake();
        }     

        [Then(@"retorna o response model")]
        public void ThenRetornaOResponseModel()
        {
            restSharpHelpers.ValidaBodyResponseModel();
        }
    }
}