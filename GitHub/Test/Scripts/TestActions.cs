using OpenQA.Selenium;
using GitHub.Src.PageObject.Pages;
using OpenQA.Selenium.Chrome;

namespace GitHub.Test.Scripts
{
    public class TestActions
    {

        private IWebDriver? _driver;
        private GitHubAction? _gitHubAction;
        private Global? _global;
        
        [SetUp]
        public void Initialization() 
        { 
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _gitHubAction = new GitHubAction(_driver);
            _global = new Global();
        }
        
        
        [Test]
        public void GetStarsXterminal()
        {
            _driver.Navigate().GoToUrl(_global._xterminalUrl);
            var stars = _gitHubAction.Stars();
            TestContext.WriteLine(stars);
            Assert.IsNotNull(stars);
            _driver.Quit();
        }

        [Test]
        public void GetStarsCiare()
        {
            _driver.Navigate().GoToUrl(_global._ciareUrl);
            var stars = _gitHubAction.Stars();
            TestContext.WriteLine(stars);
            _driver.Quit();
            Assert.IsNotNull(stars);
        }

        [Test]
        public void RepoCountPublic()
        {
            _driver.Navigate().GoToUrl(_global._gitHubUrl);
            var countRepos = _gitHubAction.RepoCount();
            TestContext.WriteLine(countRepos);
            Assert.IsNotNull(countRepos);
            _driver.Quit();
        }


        [Test]
        public void Followers()
        {
            _driver.Navigate().GoToUrl(_global._gitHubUrl);
            var followers = _gitHubAction.Followers();
            TestContext.WriteLine(followers);
            Assert.IsNotNull(followers);
            _driver.Quit();
        }

        [Test]
        public void Following()
        {
            _driver.Navigate().GoToUrl(_global._gitHubUrl);
            var following = _gitHubAction.Following();
            TestContext.WriteLine(following);
            Assert.IsNotNull(following);
            _driver.Quit();
        }

        [Test]
        public void ListPublicRepos()
        {
            _driver.Navigate().GoToUrl(_global._gitRepos);
            var listRepos = string.Join(Environment.NewLine, _gitHubAction.ListRepos());
            TestContext.WriteLine(listRepos);
            Assert.IsNotNull(listRepos);
            _driver.Quit();
        }
    }
}
