using OpenQA.Selenium;

public class BasePage
{
    protected IWebDriver Driver;

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
}
