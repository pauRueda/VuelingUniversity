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
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace Vueling.Auto.Template.Webpages
{
    public class HomePage : CommonPage
    {
        //Constructor
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement Buscador
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'About us']"); }
        }

        private IWebElement loginBtn
        {
            get { return WebDriver.FindElementById("login2"); }
        }

        private IWebElement cartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"cartur\"]"); }
        }

        protected By _logOut
        {
            get { return By.Id("logout2"); }
        }

        private IWebElement logOut
        {
            get { return WebDriver.FindElement(_logOut); }
        }
        private IWebElement laptopBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Laptops']"); }
        }

        private IWebElement phoneBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Phones']"); }
        }

        private IWebElement monitorBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Monitors']"); }
        }

        private IWebElement findLaptop(string laptopName)
        {
            return WebDriver.FindElementByXPath("//a[text()='" + laptopName + "']");
        }

        private IWebElement checkLogin
        {
            get { return WebDriver.FindElementById("nameofuser"); }
        }

        private IWebElement goHomeBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"navbarExample\"]/ul/li[1]/a"); }
        }


        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

        List<String> cartItems;


        public HomePage logearseBtn ()
        {
            loginBtn.Click();
            cartItems = new List<String>();
            return this;
        }

        public void setCartItems (String value)
        {
            cartItems.Add(value);
        }

        public List<String> getCartItems () {
            return cartItems;
        }

        public int getCartItemsLength()
        {
            return cartItems.Count;
        }


        public void buscarLaptop (String laptopName, String username)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).
              Until(CustomExpectedConditions.ElementIsVisible(_logOut));
            Assert.AreEqual(checkLogin.Text, "Welcome " + username, "Los nombre de usuario no coincieden");
            laptopBtn.Click();
            findLaptop(laptopName).Click();
        }

        public void buscarPhone(String phoneName, String username)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).
              Until(CustomExpectedConditions.ElementIsVisible(_logOut));
            Assert.AreEqual(checkLogin.Text, "Welcome " + username, "Los nombre de usuario no coincieden");
            phoneBtn.Click();
            findLaptop(phoneName).Click();
        }

        public void buscarMonitor(String monitorName, String username)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).
              Until(CustomExpectedConditions.ElementIsVisible(_logOut));
            Assert.AreEqual(checkLogin.Text, "Welcome " + username, "Los nombre de usuario no coincieden");
            monitorBtn.Click();
            findLaptop(monitorName).Click();
        }

        public void goHome ()
        {
            goHomeBtn.Click();
        }

        public void goToCart ()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout)).
             Until(CustomExpectedConditions.ElementIsVisible(_logOut));
            cartBtn.Click();
        }

        public int findNumberInList (String name)
        {
            for (int i = 0; cartItems.Count < i; i++)
            {
                if (cartItems[i] == name)
                {
                    return i;
                }
                
            }
            return -2;
        }
    }
}
