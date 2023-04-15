using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace Guru99.Src.PageObject.Pages
{
    public class EmailSubmition
    {
        private IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = "//input[@placeholder = 'Enter Email']")]
        private IWebElement _emailTextBox;


        [FindsBy(How = How.Id, Using = "philadelphia-field-submit")]
        private IWebElement _submitMail;

        public EmailSubmition(IWebDriver driver, string url)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
        }

        public void SubmitEmail(string email)
        {
            _emailTextBox.SendKeys(email);
            _submitMail.SendKeys("ENTER");
        }
    }
}
