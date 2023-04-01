using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace GitHub.Src.PageObject.Pages
{
    public class GitHubAction
    {
        private IWebDriver _driver;

        [FindsBy(How = How.ClassName, Using = "js-social-count")]
        [CacheLookup]
        private IWebElement _stars;

        [FindsBy(How = How.ClassName, Using = "Counter")]
        [CacheLookup]
        private IWebElement _repoCount;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '?tab=followers')]")]
        [CacheLookup]
        private IWebElement _followers;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href, '?tab=following')]")]
        [CacheLookup]
        private IWebElement _following;

        [FindsBy(How = How.XPath, Using = "//*[(@itemprop = 'name codeRepository')]")]
        [CacheLookup]
        private IList<IWebElement> _listRepos;

        public GitHubAction(IWebDriver driver) {

            this._driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public string Stars() => _stars.Text;

        public string RepoCount() => _repoCount.Text;

        public string Followers() => _followers.Text;
        public string Following() => _following.Text;
        public List<string> ListRepos()
        {
            var listR = new List<string>();
            foreach (var repo in _listRepos)
                listR.Add(repo.Text);
            return listR;
        }
    }
}
