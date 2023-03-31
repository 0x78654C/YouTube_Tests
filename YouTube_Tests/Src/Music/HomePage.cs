using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace YouTube_Tests.Src.Music
{
    public class HomePage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//button[@aria-label='Accept the use of cookies and other data for the purposes described']")]
        private IWebElement? _acceptButton;

        IJavaScriptExecutor js;
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void AcceptCookies()
        {
            try
            {
                _acceptButton.Click();
                Task.Delay(1000).Wait();
            }
            catch (NoSuchElementException) { }
        }
    }
}