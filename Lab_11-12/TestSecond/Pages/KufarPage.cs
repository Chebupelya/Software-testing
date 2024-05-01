using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab11_12
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



        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(data.url);
        }

        public void AuthorizeUser(User user, KufarPage kufarPage, LoginPage loginPage)
        {
            kufarPage.ClosingPolicyAndAdvertisingWindows();
            kufarPage.ClickSignInButton();
            loginPage.Login(user);
            kufarPage.CloseSecondAd();
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

        public void ClickLikeButton()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"adview_content\"]/div[1]/div[2]/div[2]/div")).Click();
            Thread.Sleep(3000);
        }

        public void ClickProfileIcon()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileIconButton));
            driver.FindElement(_profileIconButton).Click();
        }
        public void ClickProfileSettings()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileSettingsButton));
            driver.FindElement(_profileSettingsButton).Click();
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

        public void ClickProfileFavorites()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileFavoritesButton));
            driver.FindElement(_profileFavoritesButton).Click();
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

        public void ChangeRegionToGrodno()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[1]/div/select")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[1]/div/select/option[5]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[2]/div/select")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[2]/div/select/option[2]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/button")).Click();
            Thread.Sleep(3000);
        }
        public void InputSomeProductInSearch()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div[1]/div/div/input")).SendKeys("дом");
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div[1]/div/div/button[2]")).Click();
            Thread.Sleep(3000);

        }

        public void ClickProduct()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[4]/div[1]/div/div/div[2]/div/div/section[2]/a/div[1]/div/div[2]")).Click();
            Thread.Sleep(3000);
            string parentWindowHandle = driver.CurrentWindowHandle;
            foreach (string windowHandle in driver.WindowHandles)
            {
                if (windowHandle != parentWindowHandle)
                {
                    driver.SwitchTo().Window(windowHandle);
                    break;
                }
            }
        }
        public string GetRegionOfProductPage()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[4]/div[1]/div/div/div[2]/div/div/section[1]/a/div[2]/div[2]/p"));
            return spanElement.Text;
        }
        public void ClickSignInButton()
        {
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_signInButton));
            driver.FindElement(_signInButton).Click();
        }

        public void CloseWarningWindow()
        {
            driver.FindElement(By.XPath("//*[@id=\"error-portal\"]/div/div/img")).Click();
        }
        //*[@id="ai-form"]/div[4]/div/div[1]/div[1]/textarea
        public void EnteringSymbolsInDescriptionField()
        {
            Thread.Sleep(5000);
            driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[4]/div/div[1]/div[1]/textarea")).SendKeys(data.description);
        }
        
        public string GetValueField()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[4]/p/span"));
            return spanElement.Text;
        }
        public void ClickProfile()
        {  
            driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[3]/div[3]/div/div/svg")).Click();
        }
        public IWebDriver GetDriver()
        {
            return driver;
        }
        public void PutSeller()
        {
            driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[7]/div[2]/div/div/div[2]/input")).SendKeys(data.seller);
        }
        public string GetSeller()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[7]/div[1]/span"));
            return spanElement.Text;
        }
        public void PutBadNumber()
        {
            driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[7]/div[4]/div[1]/div/div[2]/input")).SendKeys(data.badNumber);
        }
        public string GetNumber()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[7]/div[1]/span"));
            return spanElement.Text;
        }
        public string GetBadNumber()
        {
            return data.badNumber;
        }
        public void InputSomeWordsInSearch()
        {
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div/div/div/input")).Click();
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div[1]/div/div/input")).SendKeys(data.someWords);
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div[1]/div/div/button[2]")).Click();
            Thread.Sleep(3000);
        }
        //*[@id="main-content"]/div[4]/div[1]/div/div/div[1]/div[3]/div/div/div
        public string GetNameOfProductFromSearch()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[4]/div[1]/div/div/div[1]/div[3]/div/div/div"));
            
            return Utils.RemoveQuotes(spanElement.Text);
        }
        public string GetSomeWords()
        {
            return data.someWords;
        }
        public void ClickOnFilter()
        {
            driver.FindElement(By.XPath("//*[@id=\"14000\"]/span")).Click();
        }
        public string GetCorrectFilterName()
        {
            return data.correctFilterName;
        }
        public string GetCurrentFilterName()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[4]/div/div/div/div/h1"));
            return spanElement.Text;
        }
        public string GetCorrectFilterAndRegionName()
        {
            return data.correctRegionAndFilter;
        }
        public string GetCurrentFilterAndRegionName()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"main-content\"]/div[4]/div/div/div/div/h1"));
            return spanElement.Text;
        }
    }
}
