using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSecond.Tests
{
    [TestFixture]
    public class KufarTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://kufar.by");
            // Тут должна быть логика для входа в аккаунт
        }

        [Test]
        public void ChangeUserNameTest()
        {
            var homePage = new HomePage(driver);
            var profilePage = homePage.ClickProfileIcon();
            var settingsPage = profilePage.GoToSettings();
            settingsPage.EnterName(@"\(^_^)/");
            settingsPage.SaveChanges();

            // Здесь должна быть проверка успешности изменения имени
        }

        [Test]
        public void ChangeUserBirthdateTest()
        {
            var homePage = new HomePage(driver);
            var profilePage = homePage.ClickProfileIcon();
            var settingsPage = profilePage.GoToSettings();
            //settingsPage.EnterBirthdate("23.02.2025");
            settingsPage.SaveChanges();

            // Здесь должна быть проверка успешности изменения даты рождения
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
