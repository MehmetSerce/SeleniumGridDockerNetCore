
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace coreDeployTest
{
    public abstract class BaseTest
    {
        private IWebDriver _driver;
        public WebDriverWait _wait;

        public string Url => "http://www.google.com";

        public IWebDriver GetDriver()
        {
            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.BrowserVersion, "70.0.3538.110");
            capabilities.SetCapability(CapabilityType.Platform, "LINUX");
            capabilities.SetCapability(CapabilityType.PlatformName, "LINUX");
            if (_driver == null)
            {
                _driver = new RemoteWebDriver(new Uri("http://3.122.10.57:4444/wd/hub/"), capabilities, TimeSpan.FromSeconds(600));
            }
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            return _driver;
        }
    }
}
