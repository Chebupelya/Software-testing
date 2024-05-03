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

        [SetUp]
        public void Init()
        {

            if (driver == null)
            {
                driver = DriverInstance.GetInstance(DriverInstance.BrowserType.MsEdge);
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
            DriverInstance.CloseBrowser();
        }

        [Test]
        public void EnteringSpecialCharactersInTheUserName()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, loginPage);
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
            kufarPage.AuthorizeUser(user, loginPage);
            kufarPage.ClickProfileIcon();
            kufarPage.ClickProfileSettings();
            accountPage.InputBadDateOfBirth();
            Assert.IsTrue(accountPage.GetBirthDateError() == data.birthDateError);
        }

        [Test]
        public void AddItemToFavorite()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, loginPage);
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
            kufarPage.AuthorizeUser(user, loginPage);
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
            kufarPage.AuthorizeUser(user, loginPage);
            kufarPage.PlaceAnAd();
            postingPage.InputDataLess20SymbolsInDescriptionField();
            postingPage.PostAnAd();
            Assert.IsTrue(data.descriptionColor == postingPage.GetValueField());
        }

        [Test]
        public void AddingAnImageLargerThan10MBToTheProductPhotoWhenPostingAnAd()
        {
            kufarPage.GoToMainPage();
            kufarPage.AuthorizeUser(user, loginPage);
            kufarPage.PlaceAnAd();
            postingPage.ChooseImageLarger10MB();
            Assert.IsTrue(postingPage.GetImageError() == data.imageError);
        }

        [Test]
        public void SearchForProductsByEnteredStringInTheSearchEngine()
        {
            kufarPage.GoToMainPage();
            kufarPage.SearchForProducts(data.searchString);
            kufarPage.ClickMagnifierIcon();
            Assert.IsTrue(kufarPage.GetSearchResultsName().Contains(data.searchString));
        }

        [Test]
        public void FilteringProductsInTheSearch()
        {
            kufarPage.GoToMainPage();
            kufarPage.ClickCategoryButton();
            kufarPage.ChooseMicrobusCategory();
            kufarPage.ChooseMarkFilter();
            kufarPage.ClickShowButton();
            Assert.IsTrue(data.correctFilterName == kufarPage.GetCurrentFilterName());
        }
        
        [Test]
        public void DisplayingProductsBySearchAndBySpecificRegion()
        {
            kufarPage.GoToMainPage();
            kufarPage.ChangeRegionToMinsk();
            kufarPage.InputSearchVolkswagenT4();
            kufarPage.ClickMagnifierIcon();
            string searchResult = kufarPage.GetNameOfSearchResult();
            Assert.IsTrue(searchResult.Contains(data.region) && searchResult.Contains(data.inputSearch));
        }

        [Test]
        public void DisplayingProductsByCategoryAndBySpecificRegion()
        {
            kufarPage.GoToMainPage();
            kufarPage.ChangeRegionToMinsk();
            kufarPage.ChooseCategoryButton();
            kufarPage.ChooseMicrobusCategory();
            Assert.IsFalse(kufarPage.CheckProductRegion());
        }
    }
}
