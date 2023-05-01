using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Twitch.Src.PageObject.Pages
{
    public class Cookies
    {

        private IWebDriver _driver;
        private WebDriverWait? _wait;
        private string _search = "";

        [FindsBy(How = How.XPath, Using = "//button[@data-a-target ='consent-banner-accept']")]
        [CacheLookup]
        private IWebElement _acceptCookies;

        [FindsBy(How = How.XPath, Using = "//button[@data-a-target = 'login-button']")]
        [CacheLookup]
        private IWebElement _login;

        [FindsBy(How = How.XPath, Using = "//button[@data-a-target = 'passport-login-button']")]
        [CacheLookup]
        private IWebElement _loginUser;

        [FindsBy(How = How.Id, Using = "login-username")]
        [CacheLookup]
        private IWebElement _userName;

        [FindsBy(How = How.Id, Using = "password-input")]
        [CacheLookup]
        private IWebElement _password;


        public Cookies(IWebDriver driver, string url)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
        }

        public void AcceptCookies()
        {
            try
            {
                Task.Delay(2000).Wait();
                _acceptCookies.Click();
            }
            catch (NoSuchElementException) { }
        }


        public void Login()
        {
            try
            {
                _login.Click();
            }
            catch (NoSuchElementException) { }
        }

        public void UserName(string userName)
        {

            //_wait.Until(ExpectedConditions.ElementIsVisible(_userName)).Click();
            _userName.SendKeys(userName);

        }

         
        public void Password(string password) => _password.SendKeys(password);

        public void LoginUser()
        {
            try
            {
                _loginUser.Click();
            }
            catch (NoSuchElementException) { }
        }
    }
}
