using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace YouTube_Tests
{
    public class CreatePlayList
    {
        private IWebDriver? _driver;
        private WebDriverWait? _wait;

        private IList<IWebElement?> _searchResults;

        private IJavaScriptExecutor? js;
        public CreatePlayList(IWebDriver driver)
        {
            this._driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void ScrollDown()
        {
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                for (int i = 0; i < 100; i++)
                {
                    js.ExecuteScript("window.scrollBy(0,500)");
                    Task.Delay(5).Wait();
                }
                Task.Delay(1000).Wait();
            }
            catch { }
        }

        public string SearchResults(string data)
        {
            _searchResults= _wait.Until(w=> w.FindElements(By.XPath($"//a[contains(@title, '{data}')][contains(@href, '/watch?')]")));
            List<string> videoUrls = new List<string>();
            foreach(IWebElement searchResult in _searchResults.Take(30))
                videoUrls.Add(searchResult.GetAttribute("href").Split('=')[1]);
            return "https://www.youtube.com/watch_videos?video_ids=" + string.Join(",", videoUrls);
        }
    }
}
