using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System.Threading;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using OpenQA.Selenium.Support.UI;
using System;
using Vueling.Auto.Template.Common;

namespace Vueling.Auto.Template.Webpages
{
    public class CompraPage : CommonPage
    {
        //Constructor
        public CompraPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath


        protected By _laptopImg
        {
            get { return By.XPath("//*[@id=\"imgp\"]/div/img"); }
        }

        private IWebElement laptopImg
        {
            get { return WebDriver.FindElement(_laptopImg); }
        }

        private IWebElement addToCartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"tbodyid\"]/div[2]/div/a"); }
        }

        private IWebElement cartBtn
        {
            get { return WebDriver.FindElementById("cartur"); }
        }
            
            

        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();
     

        public void addToCart ()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).
              Until(CustomExpectedConditions.ElementIsVisible(_laptopImg));
            addToCartBtn.Click();
            cartBtn.Click();
        }
    }
}
