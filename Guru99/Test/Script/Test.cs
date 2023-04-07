﻿using Guru99.Src.PageObject.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Guru99.Test.Script
{
    public class Test
    {
        private IWebDriver? _driver;
        public IFrames _iframes;
        public Global _global;



        [SetUp]
        public void Initialization()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _global = new Global();
            _iframes = new IFrames(_driver,_global.urlGuru);

        }

        [Test]
        public void AcceptCookies() => _iframes.AcceptCookies(_driver);


        [Test]
        public void CountIframes()
        {
            var countFrames = _iframes.CountIFrames(_driver);
            TestContext.WriteLine(countFrames);
            _driver.Quit();
        }

        [Test]
        public void ListFrames() 
        {
            var listFrames = _iframes.ListFrames(_driver);
            foreach(var frame in listFrames)
            {
                TestContext.WriteLine(frame);
            }
        }
    }
}