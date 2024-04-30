using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _loginField = By.XPath("//*[@id=\"login\"]");
        private readonly By _passwordField = By.XPath("//*[@id=\"password\"]");
        private readonly By _signInSubmitButton = By.XPath("//*[@id=\"__next\"]/div[3]/div/form/div[4]/button");
        //private readonly By _signInSubmitButton = By.XPath("//form[@data-name='form_login']/div[5]/button");


        public void Login(string[] user)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_loginField));
            driver.FindElement(_loginField).SendKeys(user[0]);
            wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
            driver.FindElement(_passwordField).SendKeys(user[1]);
            wait.Until(ExpectedConditions.ElementIsVisible(_signInSubmitButton));
            driver.FindElement(_signInSubmitButton).Click();
        }
    }
}
