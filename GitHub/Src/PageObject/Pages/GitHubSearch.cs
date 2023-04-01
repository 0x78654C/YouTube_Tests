using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GitHub.Src.PageObject.Pages
{
    public class GitHubSearch
    {
        private IWebDriver? _driver;

        [FindsBy(How = How.Name, Using = "q")]
        [CacheLookup]
        private IWebElement _search;

        [FindsBy(How = How.XPath, Using = "//*[(@data-total-pages)]")]
        [CacheLookup]
        private IWebElement _pagesSeachCount;

        public GitHubSearch(IWebDriver driver)
        {
            this._driver = driver;
            PageFactory.InitElements(_driver, this);
        }

        public void Search(string searchData)
        {
            if (string.IsNullOrEmpty(searchData))
                return;
            _search.SendKeys(searchData);
            _search.SendKeys(Keys.Enter);
        }

        public string PagesSeachCount() => _pagesSeachCount.Text;
    }
}
