using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System.Threading;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using OpenQA.Selenium.Support.UI;
using System;
using Vueling.Auto.Template.Common;
using NUnit.Framework;
using System.Xml.Linq;

namespace Vueling.Auto.Template.Webpages
{
    public class CartPage : CommonPage
    {
        //Constructor
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement placeOrderBtn
        {
            get { return WebDriver.FindElementByXPath("//button[text() = 'Place Order']"); }
        }

        private IWebElement nameInput
        {
            get { return WebDriver.FindElementById("name"); }
        }

        private IWebElement countryInput
        {
            get { return WebDriver.FindElementById("country"); }
        }

        private IWebElement cityInput
        {
            get { return WebDriver.FindElementById("city"); }
        }

        private IWebElement cardInput
        {
            get { return WebDriver.FindElementById("card"); }
        }

        private IWebElement monthInput
        {
            get { return WebDriver.FindElementById("month"); }
        }

        private IWebElement yearInput
        {
            get { return WebDriver.FindElementById("year"); }
        }

        private IWebElement purchaseBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"orderModal\"]/div/div/div[3]/button[2]"); }
        }

        private IWebElement reciptOrderBtn
        {
            get { return WebDriver.FindElementByXPath("/html/body/div[10]/div[7]/div/button"); }
        }


        private IWebElement nameProduct
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"tbodyid\"]/tr[1]/td[2]"); }
        }

        private IWebElement productToBeDeleted (int name)
        {          
             { return WebDriver.FindElementByXPath("//*[@id=\"tbodyid\"]/tr[\"'" + name + "\"]/td[4]/a"); }
        }

        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();


        public void placeOrder  ()
        {
            placeOrderBtn.Click();   
            nameInput.SendKeys("pepe");
            cityInput.SendKeys("Barcelona");
            monthInput.SendKeys("6");
            countryInput.SendKeys("España");
            cardInput.SendKeys("465874564564568");
            yearInput.SendKeys("2056");
            purchaseBtn.Click();
            Assert.IsTrue(reciptOrderBtn.Displayed, "El elemento no está visible");
            reciptOrderBtn.Click();
        }

        public String addValue ()
        {
            return nameProduct.Text;
        }

        public void removeValue (int name)
        {   
            if (name < 0 ) { productToBeDeleted(name).Click(); }
            
        }
    }
}
