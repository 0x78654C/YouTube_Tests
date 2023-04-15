using Guru99.Src.PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Guru99.Test.Script
{
    public class TestCombo
    {
        private IWebDriver? _driver;
        public DropDown _dropDown;
        public Global _global;


        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _global = new Global();
            _dropDown = new DropDown(_driver, _global.urlGuru);
        }

        [Test]
        [TestCase("sapfico99")]
        public void ItemSelection1(string item)
        {
            var selectedItemText = _dropDown.SelectComboItem(item);
            Assert.That(selectedItemText,Is.EqualTo( "SAP FICO"));
        }

        [Test]
        [TestCase("awlist4227327")]
        public void ItemSelection2(string item)
        {
            var selectedItemText = _dropDown.SelectComboItem(item);
            Assert.That(selectedItemText, Is.EqualTo("SAP Beginner"));
        }

        [Test]
        [TestCase("sap-abap")]
        public void ItemSelection3(string item)
        {
            var selectedItemText = _dropDown.SelectComboItem(item);
            Assert.That(selectedItemText, Is.EqualTo("SAP ABAP"));
        }

        [Test]
        [TestCase("sapbasis")]
        public void ItemSelection4(string item)
        {
            var selectedItemText = _dropDown.SelectComboItem(item);
            Assert.That(selectedItemText, Is.EqualTo("SAP Basis"));
        }

        [TearDown]
        public void CloseConnection()
        {
            _driver.Quit();
        }
    }
}
