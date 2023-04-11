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

        [FindsBy(How = How.TagName, Using = "iframe")]
        private IList<IWebElement> _iframes;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'mat-focus-indicator solo-button mat-button mat-button-base mat-raised-button')]")]
        private IWebElement? _acceptButton;

        [FindsBy(How = How.XPath, Using = "//iframe[contains(@id, 'a077aa5e')]")]
        private IWebElement? _demoV1;


        [FindsBy(How = How.XPath, Using = "html/body/a/img")]
        private IWebElement? _frameClick;


        public IFrames(IWebDriver driver, string url)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void AcceptCookies(IWebDriver driver)
        {
            _acceptButton.SendKeys("Enter");
        }

        public void EnterV1(IWebDriver driver)
        {
            //Task.Delay(100).Wait();
            //_driver.SwitchTo().ParentFrame();
            //_driver.SwitchTo().Frame("a077aa5e");
            var iframe = _driver.FindElement(By.XPath("//*[@href='http://www.guru99.com/live-selenium-project.html']"));
            Task.Delay(100).Wait();
            iframe.Click();
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
            var countiFrames = _iframes.Count();
            for (int i = 0; i < countiFrames; i++)
            {
                _driver.SwitchTo().ParentFrame();
                _driver.SwitchTo().Frame(i);
                list.Add(GetElementName());
            }
            return list;
        }


        private string GetElementName()
        {
            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
            var name = javaScriptExecutor.ExecuteScript("return self.name");
            return name.ToString();
        }
    }
}
