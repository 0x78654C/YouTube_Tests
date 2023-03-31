using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace YouTube_Tests
{
    public class SearchMusic
    {
        private IWebDriver _driver;
        private WebDriverWait? _wait;

        [FindsBy(How = How.Name, Using = "search_query")]
        private IWebElement _searchBox;


        public SearchMusic(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Search(string searchData)
        {
            if (string.IsNullOrEmpty(searchData))
                return;
            _searchBox.SendKeys(searchData);
            _searchBox.SendKeys(Keys.Enter);
            Task.Delay(2000).Wait();
        }
    }
}
