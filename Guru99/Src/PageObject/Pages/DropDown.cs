using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Guru99.Src.PageObject.Pages
{
    public class DropDown
    {
        private IWebDriver _driver;


        public DropDown(IWebDriver driver, string url)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
            driver.Navigate().GoToUrl(url);
        }

        public string SelectComboItem(string item) 
        {
            var dropBox = new SelectElement(_driver.FindElement(By.Id("awf_field-91977689")));
            dropBox.SelectByValue(item);
            var text =  _driver.FindElement(By.XPath($"//option[@value = '{item}']")).Text; 
            return text;
        }
    }
}
