using OpenQA.Selenium;

public class ProfilePage : BasePage
{
    public ProfilePage(IWebDriver driver) : base(driver) { }

    private IWebElement SettingsLink => Driver.FindElement(By.LinkText("Настройки"));

    public SettingsPage GoToSettings()
    {
        SettingsLink.Click();
        return new SettingsPage(Driver);
    }
}
