using OpenQA.Selenium;


namespace Lab10.Pages
{
    public class CartPage : AbstractPage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver) { }
        
        private readonly By _cartProductName = By.XPath("//div[@class='styles_adSubject__tPnKx']");

        public string GetBusketProductName()
        {
            IWebElement BusketProductName = driver.FindElement(_cartProductName);
            return BusketProductName.Text;
        }
    }
}
