using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class KufarPage : AbstractPage
    {
        Data data = new Data();
        public KufarPage(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _firstAdButton = By.XPath("//button[contains(@class, 'styles_button__oKUgO') and text()='Принять']");
        private readonly By _secondAdButton = By.XPath("//*[text()='Закрыть']");
        private readonly By _signInButton = By.XPath("//*[text()='Войти']");
        private readonly By _profileIconButton = By.XPath("//div[@data-testid='user_profile_pic']/span/span");
        private readonly By _profileSettingsButton = By.XPath("//*[text()='Настройки']");
        private readonly By _profileFavoritesButton = By.XPath("//*[text()='Избранное']");
        private readonly By _firstProductCard = By.XPath("//div[@data-name='listings']/div/div/section");
        private readonly By _firstProductCardName = By.XPath("//div[@data-name='listings']/div/div/section/a/div[2]/h3");
        private readonly By _likeButton = By.XPath("//div[@data-name='add_favorite_ad']");
        private readonly By _kufarMarketCheckbox = By.XPath("//p[text()='Товары от Куфар Маркета']");
        private readonly By _showAnnouncementsButton = By.XPath("//button[@data-name='filter-submit-button']");
        private readonly By _placeAnAdButton = By.XPath("//div[@data-name='add-item-button']");

        public void AuthorizeUser(string[] user, KufarPage kufarPage, LoginPage loginPage)
        {
            kufarPage.ClosingPolicyAndAdvertisingWindows();
            kufarPage.ClickSignInButton();
            loginPage.Login(user);
            kufarPage.CloseSecondAd();
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(data.url);
        }
        public void ClosingPolicyAndAdvertisingWindows()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(_firstAdButton));
            acceptButton.Click();
        }
        public void CloseSecondAd()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(_secondAdButton));
            acceptButton.Click();
        }
        
        public void ClickProfileIcon()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileIconButton));
            driver.FindElement(_profileIconButton).Click();
        }

        public string GetBirthDateError()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_firstProductCardName));
            IWebElement spanElement = driver.FindElement(_firstProductCardName);
            return spanElement.Text;
        }
        public string ClickFirstProductCard()
        {
            Thread.Sleep(5000);
            IWebElement Element = driver.FindElement(_firstProductCardName);
            string ElementText = Element.Text;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_firstProductCard));
            driver.FindElement(_firstProductCard).Click();
            string parentWindowHandle = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != parentWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
            return ElementText;
        }
        public void LikeProduct()
        {
            Thread.Sleep(13000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_likeButton));
            driver.FindElement(_likeButton).Click();
        }
        public void TickKufarMarket()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300);");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_kufarMarketCheckbox));
            driver.FindElement(_kufarMarketCheckbox).Click();
        }
        public void ShowAnnouncements()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_showAnnouncementsButton));
            driver.FindElement(_showAnnouncementsButton).Click();
        }
        
        public void PlaceAnAd()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_placeAnAdButton));
            driver.FindElement(_placeAnAdButton).Click();
        }
        public void ClickProfileSettings()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileSettingsButton));
            driver.FindElement(_profileSettingsButton).Click();
        }
        
        public void ClickProfileFavorites()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileFavoritesButton));
            driver.FindElement(_profileFavoritesButton).Click();
        }

        public void ClickSignInButton()
        {
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_signInButton));
            driver.FindElement(_signInButton).Click();
        }
        
    }
}
