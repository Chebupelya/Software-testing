using OpenQA.Selenium;

public class HomePage : BasePage
{
    public HomePage(IWebDriver driver) : base(driver) { }

    private IWebElement ProfileIcon => Driver.FindElement(By.CssSelector("div[data-testid='user_profile_pic'] span"));

    public ProfilePage ClickProfileIcon()
    {
        ProfileIcon.Click();
        return new ProfilePage(Driver);
    }
}
