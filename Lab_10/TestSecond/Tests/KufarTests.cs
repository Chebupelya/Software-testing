namespace Lab10
{
    public class KufarTests
    {
        User user = UserCreator.UserWitchInfoFromFile();
        Data data = new Data();
        private Steps steps = new Steps();

        [SetUp]
        public void Init()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void Cleanup()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void EnteringSpecialCharactersInTheUserName()
        {
            steps.GoToKufarPage();
            steps.AuthorizeUser(user);
            steps.ClickProfileIcon();
            steps.ClickProfileSettings();
            steps.InputBadName();
            steps.ClickSaveChanges();
            Assert.IsTrue(steps.GetAccountName() == data.badName);
        }
        
        [Test]
        public void EnteringIncorrectDateOfBirthInProfile()
        {
            steps.GoToKufarPage();
            steps.AuthorizeUser(user);
            steps.ClickProfileIcon();
            steps.ClickProfileSettings();
            steps.InputBadDateOfBirth();
            Assert.IsTrue(steps.GetBirthDateError() == data.birthdateerror);
        }

        [Test]
        public void TestAddItemToFavorite()
        {
            steps.CloseWarninigAndAdv();
            steps.LikeAndOpenFavoritePage(user);
            Assert.IsTrue(steps.GetPageTitle() == data.titleGifts);
        }
        [Test]
        public void TestAddItemToBasket()
        {
            steps.CloseWarninigAndAdvForMarket();
            Assert.IsTrue(steps.GetMarketPageTitle() == data.correctNameTitleProduct);
            steps.AddProductToBusketAndOpenProduct();
            Assert.IsTrue(steps.GetMarketPageTitle() == data.correctNameTitleProduct);
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
        public void CheckingTheLowerThresholdForTheNumberOfCharactersInTheDescriptionField()
        {
            steps.CloseWarninigAndAdv();
            steps.OpenSubmitAndEnteringDescription(user);
            Assert.IsTrue(Utils.GetQuantitySymbols(data.desc) == steps.GetValueFromDescription());
        }

        [Test]
        public void EnteringLargeNumberOfCharactersInTheNameFieldAnAd()
        {
            steps.AuthorizeUser(user);
            steps.PutBadSeller();
            Assert.IsFalse(data.seller == steps.GetSeller());
        }
        [Test]
        public void EnteringAnIncorrectPhoneNumberAnAd()
        {

            steps.AuthorizeUser(user);
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
