using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using OpenQA.Selenium.Chrome;


namespace Router
{
    public class Tests
    {
        private WebDriver? _driver;
        private string _url;
        
        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public async Task BasicAuth()
        {
            NetworkAuthenticationHandler handler = new NetworkAuthenticationHandler()
            {
                UriMatcher = (d) => d.Host.Contains("http://172.16.0.1/"),
                Credentials = new PasswordCredentials("admin", "password")
            };

            INetwork networkInterceptor = _driver.Manage().Network;
            networkInterceptor.AddAuthenticationHandler(handler);
            await networkInterceptor.StartMonitoring();
        }
    }
}