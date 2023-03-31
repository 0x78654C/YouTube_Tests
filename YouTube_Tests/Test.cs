using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace YouTube_Tests
{
    public class Test
    {
        private IWebDriver? _driver;
        private HomePage? _page;
        private SearchMusic? _searchMusic;
        private CreatePlayList? _createPlayList;
        private FinalPage?   _finalPage;
        string url = "https://www.youtube.com";

        [SetUp]
        public void InitScript()
        {
            _driver = new ChromeDriver();
            _page = new HomePage(_driver);
            _driver.Navigate().GoToUrl(url);
        }

        [Test]
        public void RunTest()
        {
            _page = new HomePage(_driver);
            _page.AcceptCookies();
           
            _searchMusic = new SearchMusic(_driver);
            _searchMusic.Search("Nature Music");
            
            _createPlayList = new CreatePlayList(_driver);
            _createPlayList.ScrollDown();
            
            string playList = _createPlayList.SearchResults("Nature");
            _finalPage = new FinalPage(_driver);
            _finalPage.PlayListPlay(playList);
        }
    }
}
