using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Lab11_12
{
    public class KufarTests
    {
        IWebDriver? driver;

        KufarPage kufarPage;
        LoginPage loginPage;
        AccountPage accountPage;
        FavoritesPage favoritesPage;
        CartPage cartPage;
        KufarMarketPage kufarMarketPage;
        PostingAdPage postingPage;

        string? productName;

        User user = UserCreator.UserWitchInfoFromFile();
        Data data = new Data();
        private Steps steps = new Steps();

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
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            DriverInstance.CloseBrowser();
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
        public void AddItemToCart()
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
        public void DisplayingProductsBySearchAndBySpecificRegion()
        {
            steps.CloseWarninigAndAdv();
            steps.ChangeRegion();
            steps.InputSearch();
            Assert.IsTrue(steps.GetProductRegion() == data.region);
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

        [Test]
        public void EnteringLargeNumberOfCharactersInTheNameFieldAnAd()
        {
            //steps.AuthorizeUser(user);
            steps.PutBadSeller();
            Assert.IsFalse(data.seller == steps.GetSeller());
        }
        [Test]
        public void EnteringAnIncorrectPhoneNumberAnAd()
        {

            //steps.AuthorizeUser(user);
            steps.PutBadNumber();
            Assert.IsFalse(data.badNumber == steps.GetNumber());
        }
        [Test]
        public void SearchForProductsEnteredString()
        {
            steps.CloseWarninigAndAdv();
            steps.InputSomeSearch();
            Assert.IsTrue(steps.GetNameOfProductFromSearch() == data.someWords);
        }
        [Test]
        public void FilteringProductsInTheSearch()
        {
            steps.CloseWarninigAndAdv();
            steps.ClickOnFilter();
            Assert.IsTrue(data.correctFilterName == steps.GetCurrentFilterName());
        }
        [Test]
        public void DisplayingProductsByCategoryAndBySpecificRegion()
        {
            steps.CloseWarninigAndAdv();
            steps.ChangeRegion();
            steps.ClickOnFilter();
            Assert.IsTrue(data.correctRegionAndFilter == steps.GetCurrentFilterAndRegionName());
        }
    }
}
