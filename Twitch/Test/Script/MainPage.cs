using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Twitch.Src.PageObject.Pages;

namespace Twitch.Test.Script
{
    public class MainPage
    {
        private WebDriver _driver;
        private string _url;
        private Cookies _cookie;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _url = Global.url;
            _cookie = new Cookies(_driver, _url);
        }

        [Test]
        public void AcceptCookie()
        {
           _cookie.AcceptCookies();
        }

        [Test]
        public void Login()
        {
            _cookie.Login();
            Task.Delay(1000).Wait();
            _cookie.UserName("testuser");
            _cookie.Password("testPassword");
            _cookie.LoginUser();
        }


        [TearDown]
        public void CloseConnection()
        {
            _driver.Quit();
        }
    }
}
