using GitHub.Src.PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace GitHub.Test.Scripts
{
    public class TestSearch
    {

        private IWebDriver? _driver;
        public GitHubSearch _gitHubSearch;
        public Global _global;

        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _gitHubSearch = new GitHubSearch(_driver);
            _global = new Global();
        }

        [Test]
        public void Search()
        {
            _driver.Navigate().GoToUrl(_global._gitHub);
            _gitHubSearch.Search(_global._searchData);
        }
    }
}
