namespace Lab10
{
    public class KufarTests
    {
        User user = UserCreator.UserWitchInfoFromFile();
        Data data = new Data();
        private Steps steps = new Steps();
        string ProductName;

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
        public void AddItemToFavorite()
        {
            steps.GoToKufarPage();
            steps.AuthorizeUser(user);
            ProductName = steps.OpenFirstProductCard();
            steps.LikeProduct();
            steps.ClickProfileIcon();
            steps.ClickProfileFavorites();
            Assert.IsTrue(steps.GetFavoriteProductName() == ProductName);
        }
        [Test]
        public void AddItemToBusket()
        {
            steps.GoToKufarPage();
            steps.AuthorizeUser(user);
            steps.TickKufarMarket();
            steps.ShowAnnouncements();
            ProductName = steps.OpenFirstProductCard();
            steps.AddToBusket();
            steps.GoToBusket();     
            Assert.IsTrue(steps.GetBusketProductName() == ProductName);
        }

        [Test]
        public void CheckingTheLowerThresholdForTheNumberOfCharactersInTheDescriptionFieldInAd()
        {
            steps.GoToKufarPage();
            steps.AuthorizeUser(user);
            steps.PlaceAnAd();
            steps.InputDataLess20SymbolsInDescriptionField();
            steps.PostAnAd();
            Assert.IsTrue(data.descColor == steps.GetValueFromDescription());
        }

        [Test]
        public void DisplayingProductsBySearchAndBySpecificRegion()
        {
            steps.ChangeRegion();
            steps.InputSearch();
            Assert.IsTrue(steps.GetProductRegion() == data.region);
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
            steps.InputSomeSearch();
            Assert.IsTrue(steps.GetNameOfProductFromSearch() == data.someWords);
        }
        [Test]
        public void FilteringProductsInTheSearch()
        {
            steps.ClickOnFilter();
            Assert.IsTrue(data.correctFilterName == steps.GetCurrentFilterName());
        }
        [Test]
        public void DisplayingProductsByCategoryAndBySpecificRegion()
        {
            steps.ChangeRegion();
            steps.ClickOnFilter();
            Assert.IsTrue(data.correctRegionAndFilter == steps.GetCurrentFilterAndRegionName());
        }
    }
}
