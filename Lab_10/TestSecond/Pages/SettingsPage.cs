using OpenQA.Selenium;

public class SettingsPage : BasePage
{
    public SettingsPage(IWebDriver driver) : base(driver) { }

    private IWebElement NameField => Driver.FindElement(By.Id("name"));
    private IWebElement SaveButton => Driver.FindElement(By.CssSelector("button[type='submit']"));

    public void EnterName(string name)
    {
        NameField.Clear();
        NameField.SendKeys(name);
    }

    public void SaveChanges()
    {
        SaveButton.Click();
    }
}
