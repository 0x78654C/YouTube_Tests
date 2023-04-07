using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guru99.Src.PageObject.Pages
{
    public class IFrames
    {
        private IWebDriver _driver;
        private WebDriverWait? _wait;

        [FindsBy(How = How.ClassName, Using = "mat-raised-button")]
        private IList<IWebElement> _iframes;

        [FindsBy(How = How.Id, Using = "save")]
        private IWebElement? _acceptButton;


        public IFrames(IWebDriver driver, string url)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void AcceptCookies(IWebDriver driver)
        {
            _acceptButton.Click();
            Task.Delay(500).Wait();
        }

        /// <summary>
        /// Count iframes in main page
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public int CountIFrames(IWebDriver driver) => _iframes.Count();


        /// <summary>
        /// List all frames.
        /// </summary>
        /// <param name="driver"></param>
        public List<string> ListFrames(IWebDriver driver)
        {
            var list = new List<string>();
            foreach (var iframe in _iframes)
                list.Add(iframe.Text);
            return list;
        }
    }
}
