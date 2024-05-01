using OpenQA.Selenium;

namespace Lab11_12
{
    public class Steps
    {
        IWebDriver? driver;

        public void InitBrowser()
        {
            driver = DriverInstance.GetInstance(DriverInstance.BrowserType.MsEdge);
        }
        public void CloseBrowser()
        {
            DriverInstance.CloseBrowser();
        }

        public void GoToKufarPage()
        {
            KufarPage kufarPage = new KufarPage(driver);
            kufarPage.GoToMainPage();
        }
        public void CloseWarninigAndAdv()
        {
            KufarPage kufarPage = new KufarPage(driver);
            kufarPage.ClosingPolicyAndAdvertisingWindows();
        }
        
        public void ChangeRegion()
        {
            KufarPage page = new KufarPage(driver);
            Thread.Sleep(3000);
            page.ChangeRegionToGrodno();
        }
        public void InputSearch()
        {
            KufarPage page = new KufarPage(driver);
            page.InputSomeProductInSearch();
        }
        public string GetProductRegion()
        {
            KufarPage page = new KufarPage(driver);
            return page.GetRegionOfProductPage();
        }
        public string GetValueFromDescription()
        {
            KufarPage kufarPage = new KufarPage(driver);
            return kufarPage.GetValueField();
        }


        public string GetSeller()
        {
            KufarPage kufarPage = new KufarPage(driver);
            return kufarPage.GetSeller();
        }

        public string GetCurrentFilterAndRegionName()
        {
            KufarPage kufarPage = new KufarPage(driver);
            return kufarPage.GetCurrentFilterAndRegionName();
        }
    }
}
