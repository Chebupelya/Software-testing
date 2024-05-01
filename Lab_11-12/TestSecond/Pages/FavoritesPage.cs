using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12
{
    public class FavoritesPage : AbstractPage
    {
        public FavoritesPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _favoriteProductName = By.XPath("//h3[@class='styles_title__F3uIe']");

        public string GetFavoriteProductName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_favoriteProductName));
            IWebElement FavoriteProductName = driver.FindElement(_favoriteProductName);
            return FavoriteProductName.Text;
        }
    }
}
