using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using Xunit;

namespace coreDeployTest
{
    
    public class UnitTest1:BaseTest
    {
        [Fact]
        public void SearchAndVerifyTitle()
        {
            using (var driver = GetDriver())
            {
                driver.Navigate().GoToUrl(Url);
                
                IWebElement SearchText=_wait.Until
                    (ExpectedConditions.ElementExists
                    (
                        By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[1]/div/div[1]/input")
                    ));
                SearchText.Click();
                SearchText.SendKeys("Mehmet Serçe .Net video ve makaleleri");
                IWebElement SearchButton = _wait.Until
                    (ExpectedConditions.ElementExists
                    (
                        By.XPath("//*[@id=\"tsf\"]/div[2]/div/div[3]/center/input[1]")
                    ));
                SearchButton.Click();
                IWebElement firstLink = _wait.Until
                    (ExpectedConditions.ElementToBeClickable
                    (
                        By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div[1]/a/h3")

                    ));
                firstLink.Click();
                string getir = driver.Title;
                Assert.Equal("Mehmet Serçe, .Net Video ve Makaleleri", getir);
            }
        }
    }
}
