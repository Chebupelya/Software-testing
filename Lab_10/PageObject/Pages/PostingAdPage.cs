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


        private readonly By _DescriptionFieldInAd = By.XPath("//*[@id=\"ai-form\"]/div[4]/div/div[1]/div[1]/textarea");
        private readonly By _PostAdButton = By.XPath("//*[@id=\"ai-form\"]/button");
        private readonly By _DescriptionField = By.XPath("//form[@id='ai-form']/div[4]/p/span");
        private readonly By _DescriptionHeader = By.XPath("//*[text()='Описание']");

        public override void GoToMainPage()
        {
        }
        
        public void InputDataLess20SymbolsInDescriptionField()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_DescriptionFieldInAd));
            driver.FindElement(_DescriptionFieldInAd).SendKeys(data.desc);
        }
        public void PostAnAd()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
            driver.FindElement(_PostAdButton).Click();
        }
        
        public string GetValueField()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", _DescriptionHeader);
            var element = driver.FindElement(By.CssSelector("form#ai-form > div:nth-child(4) > p > span"));
            return element.GetCssValue("color");
        }
    }
}
