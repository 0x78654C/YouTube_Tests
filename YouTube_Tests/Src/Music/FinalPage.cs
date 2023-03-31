using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace YouTube_Tests.Src.Music
{
    public class FinalPage
    {

        private IWebDriver _driver;
        private WebDriverWait _wait;

        [FindsBy(How = How.ClassName, Using = "ytp-play-button")]
        private IWebElement? _playPlayList;
        public FinalPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        public void PlayListPlay(string playList)
        {
            _driver.Navigate().GoToUrl(playList);
            _playPlayList.Click();
        }
    }
}
