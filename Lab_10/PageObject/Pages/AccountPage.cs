using OpenQA.Selenium;

namespace Lab10
{
    public class AccountPage : AbstractPage
    {
        private string url = "https://www.kufar.by/account/settings/personal_info";
        Data data = new Data();
        private readonly By _NameField = By.XPath("//*[@id=\"name\"]");
        private readonly By _BirthDateField = By.XPath("//*[@id=\"dateOfBirth\"]");
        private readonly By _BirthDateError = By.XPath("//*[text()='Ого, вы прибыли из будущего? Укажите реальную дату.']");
        private readonly By _SaveChangesButton = By.XPath("//*[text()='Сохранить изменения']");
        private readonly By _AccountNameField = By.XPath("//*[@id=\"personal_info_form\"]/div[2]/div/div[1]/span/p[1]");


        public AccountPage(IWebDriver webDriver) : base(webDriver) { }
        public override void GoToMainPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void InputBadName()
        {
            Thread.Sleep(2000);
            driver.FindElement(_NameField).Clear();
            driver.FindElement(_NameField).SendKeys(data.badName);
        }
        public void InputBadDateOfBirth()
        {
            Thread.Sleep(2000);
            driver.FindElement(_BirthDateField).Clear();
            driver.FindElement(_BirthDateField).SendKeys("23.02.2025");
        }
        public void SaveChanges()
        {
            Thread.Sleep(2000);
            driver.FindElement(_SaveChangesButton).Click();
        }

        public string GetAccountName()
        {
            IWebElement spanElement = driver.FindElement(_AccountNameField);
            return spanElement.Text;
        }
        public string GetBirthDateError()
        {
            IWebElement spanElement = driver.FindElement(_BirthDateError);
            return spanElement.Text;
        }
    }
}
