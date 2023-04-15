using Guru99.Src.PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Guru99.Test.Script
{
    public class TestEmailSubmition
    {
        private IWebDriver? _driver;
        private EmailSubmition _submition;
        public Global _global;


        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _global = new Global();
            _submition = new EmailSubmition(_driver, _global.urlGuru);
        }

        [Test]
        [TestCase("new@email.com")]
        [TestCase("new1@email.com")]
        [TestCase("new2@email.com")]
        [TestCase("new3@email.com")]
        [TestCase("new4@email.com")]
        [TestCase("new5@email.com")]
        public void SubmitMails(string email)
        {
            _submition.SubmitEmail(email);
        }

        [TearDown]
        public void Cleanup() { _driver.Quit(); }
    }
}
