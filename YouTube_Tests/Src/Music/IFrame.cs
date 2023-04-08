using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V109.DOM;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;


namespace YouTube_Tests.Src.Music
{
    public class IFrame
    {
        private IWebDriver _driver;
        private WebDriverWait? _wait;

        [FindsBy(How = How.TagName, Using = "iframe")]
        private IList<IWebElement> _iframes;

        public IFrame(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
        }

        /// <summary>
        /// Count iframes in main page
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public int CountIFrames(IWebDriver driver) => _iframes.Count();

        public void SwitchIframes(IWebDriver driver)
        {
            var iCount = _iframes.Count();
            for(int i =0; i<iCount; i++)
                driver.SwitchTo().Frame(i);
        }
    }
}
