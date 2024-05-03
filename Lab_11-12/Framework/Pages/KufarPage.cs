using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
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
        private readonly By _searchInputField = By.XPath("//input[@data-testid='searchbar-input']");
        private readonly By _magnifierIcon = By.XPath("//button[@class='styles_search_button__Ro1wM']");
        private readonly By _searchResultsName = By.XPath("//div[@id='main-content']/div[6]/div/div/div[2]/div/h1");
        private readonly By _categoriesButton = By.XPath("//button[@data-name='category-chip']/span[text()='Категории']");
        private readonly By _subCategoryName = By.XPath("//div[@id='__next']/div/div[2]/div/div/div/div[2]");
        private readonly By _vehicleType = By.XPath("//span[text()='Микроавтобус']");
        private readonly By _markFilter = By.XPath("//div[@data-testid='kufar-auto-filter-cars_brand_v2']/div/div");
        private readonly By _markFilterInput = By.XPath("//input[contains(@class, 'styles_input__1pDT9') and @placeholder='Марка']");
        private readonly By _markOption = By.XPath("//div[@data-testid='select-search-option' and text()='Volkswagen']");
        private readonly By _showButton = By.XPath("//button[@data-cy='filters-auto-submit-button' and contains(text(), 'Показать')]");
        private readonly By _searchWithFilterHeader = By.XPath("//section[@id='listings_content']/div/div/div[2]/h1");
        private readonly By _regionField = By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/button");
        private readonly By _regionList = By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[1]/div/select");
        private readonly By _minskRegionInRegionList = By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[1]/div/select/option[2]");
        private readonly By _acceptRegionButton = By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/button");



        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(data.url);
        }

        public void AuthorizeUser(User user, LoginPage loginPage)
        {
            ClosingPolicyAndAdvertisingWindows();
            ClickSignInButton();
            loginPage.Login(user);
            CloseSecondAd();
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

        public void SearchForProducts(string str)
        {
            ClosingPolicyAndAdvertisingWindows();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchInputField));
            driver.FindElement(_searchInputField).Click();
            driver.FindElement(_searchInputField).SendKeys(str);
        }
        
        public void ClickMagnifierIcon()
        {
            Thread.Sleep(2000);
            driver.FindElement(_magnifierIcon).Click();
            //CloseSecondAd();
        }
        
        public void ClickCategoryButton()
        {
            ClosingPolicyAndAdvertisingWindows();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_categoriesButton));
            driver.FindElement(_categoriesButton).Click();
        }
        
        public void ChooseMicrobusCategory()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_subCategoryName));
            IWebElement menu = driver.FindElement(_subCategoryName);
            actions.MoveToElement(menu).Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(_vehicleType));
            IWebElement submenu = driver.FindElement(_vehicleType);
            actions.MoveToElement(submenu).Click().Perform();
        }
        
        public void ChooseMarkFilter()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_markFilter));
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 300);");
            driver.FindElement(_markFilter).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_markFilterInput)).SendKeys("Volkswagen");
            driver.FindElement(_markOption).Click();
        }
        
        public void ClickShowButton()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_showButton));
            driver.FindElement(_showButton).Click();
        }



        public void ChangeRegionToMinsk()
        {
            ClosingPolicyAndAdvertisingWindows();
            driver.FindElement(_regionField).Click();
            driver.FindElement(_regionList).Click();
            driver.FindElement(_minskRegionInRegionList).Click();
            //driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[2]/div/select")).Click();
            //driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[3]/div/div/div/div[2]/div/select/option[2]")).Click();
            driver.FindElement(_acceptRegionButton).Click();
        }
        public void InputSearchVolkswagenT4()
        {
            CloseSecondAd();
            driver.FindElement(_searchInputField).Click();
            driver.FindElement(_searchInputField).SendKeys(data.inputSearch);
            //driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/div[2]/div/div[1]/div/div/button[2]")).Click();
        }

        public string GetRegionOfProductPage()
        {
            IWebElement spanElement = driver.FindElement(By.XPath(""));
            return spanElement.Text;
        }
        public void ClickSignInButton()
        {
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_signInButton));
            driver.FindElement(_signInButton).Click();
        }
        
        public string GetValueField()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[4]/p/span"));
            return spanElement.Text;
        }


        public string GetSeller()
        {
            IWebElement spanElement = driver.FindElement(By.XPath("//*[@id=\"ai-form\"]/div[7]/div[1]/span"));
            return spanElement.Text;
        }

        public string GetSearchResultsName()
        {
            CloseSecondAd();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchResultsName));
            IWebElement spanElement = driver.FindElement(_searchResultsName);
            return Utils.RemoveQuotes(spanElement.Text);
        }
        
        public string GetNameOfSearchResult()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchResultsName));
            IWebElement spanElement = driver.FindElement(_searchResultsName);
            return Utils.RemoveQuotes(spanElement.Text);
        }
        
        public string GetProductNameFromSearchResult()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchResultsName));
            IWebElement spanElement = driver.FindElement(_searchResultsName);
            return Utils.RemoveQuotes(spanElement.Text);
        }

        public string GetCorrectFilterName()
        {
            return data.correctFilterName;
        }
        public string GetCurrentFilterName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchWithFilterHeader));
            IWebElement spanElement = driver.FindElement(_searchWithFilterHeader);
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
