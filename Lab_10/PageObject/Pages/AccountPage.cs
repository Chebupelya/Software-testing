using OpenQA.Selenium;

namespace Lab10
{
    public class AccountPage : AbstractPage
    {
        public AccountPage(IWebDriver webDriver) : base(webDriver) { }

        Data data = new Data();

        private readonly By _nameField = By.XPath("//*[@id=\"name\"]");
        private readonly By _birthDateField = By.XPath("//*[@id=\"dateOfBirth\"]");
        private readonly By _birthDateError = By.XPath("//*[text()='Ого, вы прибыли из будущего? Укажите реальную дату.']");
        private readonly By _saveChangesButton = By.XPath("//*[text()='Сохранить изменения']");
        private readonly By _accountNameField = By.XPath("//*[@id=\"personal_info_form\"]/div[2]/div/div[1]/span/p[1]");
        

        public void InputBadName()
        {
            Thread.Sleep(2000);
            driver.FindElement(_nameField).Clear();
            driver.FindElement(_nameField).SendKeys(data.badName);
        }
        public void InputBadDateOfBirth()
        {
            Thread.Sleep(2000);
            driver.FindElement(_birthDateField).Clear();
            driver.FindElement(_birthDateField).SendKeys("23.02.2025");
        }
        public void SaveChanges()
        {
            Thread.Sleep(2000);
            driver.FindElement(_saveChangesButton).Click();
        }

        public string GetAccountName()
        {
            IWebElement spanElement = driver.FindElement(_accountNameField);
            return spanElement.Text;
        }
        public string GetBirthDateError()
        {
            IWebElement spanElement = driver.FindElement(_birthDateError);
            return spanElement.Text;
        }
    }
}
