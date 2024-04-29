using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class KufarPage : AbstractPage
    {
        Data data = new Data();
        public KufarPage(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _FirstAdButton = By.XPath("//button[contains(@class, 'styles_button__oKUgO') and text()='Принять']");
        private readonly By _SecondAdButton = By.XPath("//*[text()='Закрыть']");
        private readonly By _SignInButton = By.XPath("//*[text()='Войти']");
        private readonly By _LoginField = By.XPath("//*[@id=\"login\"]");
        private readonly By _PasswordField = By.XPath("//*[@id=\"password\"]");
        private readonly By _SignInSubmitButton = By.XPath("//*[@id=\"__next\"]/div[3]/div/form/div[4]/button");
        private readonly By _ProfileIconButton = By.XPath("//div[@data-testid='user_profile_pic']/span/span");
        private readonly By _ProfileSettingsButton = By.XPath("//*[text()='Настройки']");
        private readonly By _ProfileFavoritesButton = By.XPath("//*[text()='Избранное']");
        private readonly By _FirstProductCard = By.XPath("//div[@data-name='listings']/div/div/section");
        private readonly By _FirstProductCardName = By.XPath("//div[@data-name='listings']/div/div/section/a/div[2]/h3");
        private readonly By _FavoriteCardName = By.XPath("//h3[@class='styles_title__F3uIe']");
        private readonly By _BusketCardName = By.XPath("//div[@class='styles_adSubject__tPnKx']");
        private readonly By _LikeButton = By.XPath("//div[@data-name='add_favorite_ad']");
        private readonly By _KufarMarketCheckbox = By.XPath("//p[text()='Товары от Куфар Маркета']");
        private readonly By _ShowAnnouncementsButton = By.XPath("//button[@data-name='filter-submit-button']");
        private readonly By _AddToBusketButton = By.XPath("//div[@class='styles_adViewContainer__NlMUv']/button");
        private readonly By _GoToBusketButton = By.XPath("//a[@data-cy='navigate_to_cart_button']");
        private readonly By _PlaceAnAdButton = By.XPath("//div[@data-name='add-item-button']");
        


        public string GetPageTitle()
        {
            return driver.Title;
        }

        public override void GoToMainPage()
        {
            driver.Navigate().GoToUrl(data.url);
        }
        public void ClosingPolicyAndAdvertisingWindows()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(_FirstAdButton));

            acceptButton.Click();
        }
        public void CloseSecondAd()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(_SecondAdButton));

            acceptButton.Click();
        }



        
        public void GoToProductPage()
        {
            driver.Navigate().GoToUrl(data.urlProduct);
        }

        
        public void ClickProfileIcon()
        {
            driver.FindElement(_ProfileIconButton).Click();
        }

        public string GetBirthDateError()
        {
            IWebElement spanElement = driver.FindElement(_FirstProductCardName);
            return spanElement.Text;
        }
        public string ClickFirstProductCard()
        {
            Thread.Sleep(3000);
            IWebElement Element = driver.FindElement(_FirstProductCardName);
            string ElementText = Element.Text;
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_FirstProductCard));
            driver.FindElement(_FirstProductCard).Click();
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
            driver.FindElement(_LikeButton).Click();
        }
        public void TickKufarMarket()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300);");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_KufarMarketCheckbox));
            driver.FindElement(_KufarMarketCheckbox).Click();
        }
        public void ShowAnnouncements()
        {
            driver.FindElement(_ShowAnnouncementsButton).Click();
        }
        public void AddToBusket()
        {
            driver.FindElement(_AddToBusketButton).Click();
        }
        public void GoToBusket()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_GoToBusketButton));
            driver.FindElement(_GoToBusketButton).Click();
        }
        
        public void PlaceAnAd()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_PlaceAnAdButton));
            driver.FindElement(_PlaceAnAdButton).Click();
        }
        public void ClickProfileSettings()
        {
            driver.FindElement(_ProfileSettingsButton).Click();
        }
        
        public void ClickProfileFavorites()
        {
            driver.FindElement(_ProfileFavoritesButton).Click();
        }

        public string GetFavoriteProductName()
        {
            IWebElement FavoriteProductName = driver.FindElement(_FavoriteCardName);
            return FavoriteProductName.Text;
        }
        
        public string GetBusketProductName()
        {
            IWebElement BusketProductName = driver.FindElement(_BusketCardName);
            return BusketProductName.Text;
        }

        public void ClickFavorites()
        {
            driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[2]/div[1]")).Click();
            Thread.Sleep(3000);
        }
        public void ClickFavoriteProduct()
        {
            driver.FindElement(By.XPath("//*[@id=\"__next\"]/div[1]/div/div[2]/div[1]/div[2]/div[2]/div[2]/div/a[1]/div[1]/div/div[2]")).Click();
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
            driver.FindElement(_SignInButton).Click();
        }
        public void Login(User user)
        {
            Thread.Sleep(3000);
            driver.FindElement(_LoginField).SendKeys(user.username);
            driver.FindElement(_PasswordField).SendKeys(user.password);
            driver.FindElement(_SignInSubmitButton).Click();
            
        }
        public void CloseWarningWindow()
        {
            driver.FindElement(By.XPath("//*[@id=\"error-portal\"]/div/div/img")).Click();
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
