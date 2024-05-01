using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace Lab11_12
{
    public class PostingAdPage : AbstractPage
    {
        Data data = new Data();
        public PostingAdPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _descriptionFieldInAd = By.XPath("//*[@id=\"ai-form\"]/div[4]/div/div[1]/div[1]/textarea");
        private readonly By _postAdButton = By.XPath("//form[@id='ai-form']/button[text()='Подать объявление']");
        private readonly By _descriptionField = By.XPath("//form[@id='ai-form']/div[4]/p/span");
        private readonly By _imageSpace = By.XPath("//div[@class='styles_dropzone__djtt6']");
        private readonly By _imageError = By.XPath("//form[@id='ai-form']/div[2]");
        private readonly By _imageInput = By.Id("imageLoaderDropzone");

        public void InputDataLess20SymbolsInDescriptionField()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_descriptionFieldInAd));
            Thread.Sleep(1000);
            driver.FindElement(_descriptionFieldInAd).SendKeys(data.description);
        }
        public void PostAnAd()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 200);");
            Thread.Sleep(2000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_postAdButton));
            driver.FindElement(_postAdButton).Click();
        }

        public string GetValueField()
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_descriptionField));
            var element = driver.FindElement(_descriptionField);
            return element.GetCssValue("color");
        }
        
        public void ChooseImageLarger10MB()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(_imageSpace));

            IWebElement imageInput = driver.FindElement(_imageInput);

            imageInput.SendKeys(data.imagePath);
        }

        public string GetImageError()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_imageError));
            IWebElement spanElement = driver.FindElement(_imageError);
            return spanElement.Text;
        }
    }
}
