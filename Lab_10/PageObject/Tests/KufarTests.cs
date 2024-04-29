using Lab10.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Lab10
{
    public class KufarTests
    {
        IWebDriver driver;

        KufarPage kufarPage;
        LoginPage loginPage;
        AccountPage accountPage;
        FavoritesPage favoritesPage;
        CartPage cartPage;
        KufarMarketPage kufarMarketPage;
        PostingAdPage postingPage;

        Data data;
        string? productName;
        private string[] user;

        public KufarTests()
        {
            data = new Data();
            user = new string[] { data.login, data.password };
        }

        [SetUp]
        public void Init()
        {
            if (driver == null)
            {
                driver = new EdgeDriver();
            }
            driver.Manage().Window.Maximize();
            kufarPage = new KufarPage(driver);
            loginPage = new LoginPage(driver);
            accountPage = new AccountPage(driver);
            favoritesPage = new FavoritesPage(driver);
            cartPage = new CartPage(driver);
            kufarMarketPage = new KufarMarketPage(driver);
            postingPage = new PostingAdPage(driver);
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
        }

        [Test]
        public void EnteringSpecialCharactersInTheUserName()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, kufarPage, loginPage);
            kufarPage.ClickProfileIcon();
            kufarPage.ClickProfileSettings();
            accountPage.InputBadName();
            accountPage.SaveChanges();
            Assert.IsTrue(accountPage.GetAccountName() == data.badName);
        }
        
        [Test]
        public void EnteringIncorrectDateOfBirthInProfile()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, kufarPage, loginPage);
            kufarPage.ClickProfileIcon();
            kufarPage.ClickProfileSettings();
            accountPage.InputBadDateOfBirth();
            Assert.IsTrue(accountPage.GetBirthDateError() == data.birthDateError);
        }

        [Test]
        public void AddItemToFavorite()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, kufarPage, loginPage);
            productName = kufarPage.ClickFirstProductCard();
            kufarPage.LikeProduct();
            kufarPage.ClickProfileIcon();
            kufarPage.ClickProfileFavorites();
            Assert.IsTrue(favoritesPage.GetFavoriteProductName() == productName);
        }
        [Test]
        public void AddItemToBusket()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, kufarPage, loginPage);
            kufarPage.TickKufarMarket();
            kufarPage.ShowAnnouncements();
            productName = kufarPage.ClickFirstProductCard();
            kufarMarketPage.AddToCart();
            kufarMarketPage.GoToCart();     
            Assert.IsTrue(cartPage.GetBusketProductName() == productName);
        }

        [Test]
        public void CheckingTheLowerThresholdForTheNumberOfCharactersInTheDescriptionFieldInAd()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, kufarPage, loginPage);
            kufarPage.PlaceAnAd();
            postingPage.InputDataLess20SymbolsInDescriptionField();
            postingPage.PostAnAd();
            Assert.IsTrue(data.descriptionColor == postingPage.GetValueField());
        }
    }
}
