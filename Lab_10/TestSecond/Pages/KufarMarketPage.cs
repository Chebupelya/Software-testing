using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class KufarMarketPage : AbstractPage
    {
        private string url = "https://www.kufar.by/l?b2c=1&cmp=1&cnd=2&sort=lst.d&pls_source=blognewgoods&pls_medium=article&pls_campaign=newgoods_kufarmarketis_pr_31.08.22&site=kufarby&utm_source=blognewgoods&utm_medium=article&utm_campaign=newgoods_kufarmarketis_pr_31.08.22";
        private string urlProduct = "https://www.kufar.by/item/233030986?rank=2&searchId=944575da55bbfce3d76c81065a3714092328";
            //"https://www.kufar.by/item/164272339?rank=3&searchId=e014ad1c694b3c944be57b8f46abff2e879b";
        
        public KufarMarketPage(IWebDriver webDriver) : base(webDriver) { }
        public override void GoToMainPage()
        {
            driver.Navigate().GoToUrl(url);
        }
        public void GoToProductPage()
        {
            driver.Navigate().GoToUrl(urlProduct);
        }
        public string GetPageTitle()
        {
            return driver.Title;
        }

        
        public void ClickAddBusketButton()
        {
            Thread.Sleep(3000);
            //driver.FindElement(By.XPath("//*[@id=\"adview_content\"]/div[2]/div[2]/div/button")).Click();
            driver.FindElement(By.XPath("//button[@data-name='checkout_button' and @type='button' and contains(@class, 'styles_button__oKUgO') and contains(@class, 'styles_ecom_outline__AEDgz') and contains(@class, 'styles_size-m__NgAcw') and contains(@class, 'styles_block___PraQ') and contains(@class, 'styles_directCheckoutButton__U0Awu') and text()='Купить сейчас']\n")).Click();
            Thread.Sleep(5000);
        }
        public void ClosingPolicyAndAdvertisingWindows()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(@class, 'styles_button__oKUgO') and contains(@class, 'styles_default__ws8JN') and contains(@class, 'styles_size-m__NgAcw') and contains(@class, 'styles_block___PraQ') and text()='Принять']")));

            // Нажатие на кнопку
            acceptButton.Click();
            //driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div[3]/div/div[2]/button")).Click();
        }
        public void ClickBusketButton()
        {   
            driver.FindElement(By.XPath("//*[@id=\"header\"]/div/div/div/div[2]/div[2]/a")).Click();
        }
        public void ClickBusketProduct()
        {           
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div[2]/div/div/div[2]/div/div[2]/div")).Click();
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

    }
}
