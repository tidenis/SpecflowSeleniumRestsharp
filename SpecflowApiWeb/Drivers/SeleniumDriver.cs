using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SpecflowApiWeb.Drivers
{
    public class SeleniumDriver
    {
        public WebDriver driver;
        public WebDriverWait wait;

        public void ConfigurarNavegador(string url)
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            driver.Manage().Window.Maximize();
            driver.Url = url;
        }

        public void FecharNavegador()
        {
            driver.Close();
            driver.Quit();
        }

        private void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private void Escrever(By by, string value)
        {
            try
            {
                driver.FindElement(by).Clear();
                driver.FindElement(by).SendKeys(value);
                //Precisei colocar o envio do espaço porque o searchBar não retornava o modelo
                //as vezes a busca nao funciona mesmo com o espaco
                driver.FindElement(by).SendKeys(Keys.Space);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        private string ColetarTextoInterno(By by)
        {
            try
            {               
                driver.SwitchTo().Window(driver.WindowHandles[1]);
                return driver.FindElement(by).Text;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void EsperarElementoFicarClicavelPeloId(string id)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
            Click(By.Id(id));
        }

        public void EsperarElementoFicarClicavelPeloXpath(string xpath)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(xpath)));
            Click(By.XPath(xpath));
        }

        public void EsperarElementoFicarDisponivelParaEscreverPeloId(string id, string valor)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(id)));
            Escrever(By.Id(id), valor);
        }

        public string ColetarTextoInternoPeloXpath(string xpath)
        {            
            return ColetarTextoInterno(By.XPath(xpath));
        }

        public string ColetarTextoInternoPeloId(string id)
        {
            return ColetarTextoInterno(By.Id(id));
        }
    }
}