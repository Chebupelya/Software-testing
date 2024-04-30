using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab10
{
    public class PostingAdPage : AbstractPage
    {
        Data data = new Data();
        public PostingAdPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _descriptionFieldInAd = By.XPath("//*[@id=\"ai-form\"]/div[4]/div/div[1]/div[1]/textarea");
        private readonly By _postAdButton = By.XPath("//*[@id=\"ai-form\"]/button");
        private readonly By _descriptionField = By.XPath("//form[@id='ai-form']/div[4]/p/span");
        
        public void InputDataLess20SymbolsInDescriptionField()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_descriptionFieldInAd));
            driver.FindElement(_descriptionFieldInAd).SendKeys(data.description);
        }
        public void PostAnAd()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            Thread.Sleep(1000);
            driver.FindElement(_postAdButton).Click();
        }
        
        public string GetValueField()
        {
            Thread.Sleep(1000);
            var element = driver.FindElement(_descriptionField);
            return element.GetCssValue("color");
        }
    }
}
