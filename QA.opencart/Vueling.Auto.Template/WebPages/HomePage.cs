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
using System.Xml.Linq;

namespace Vueling.Auto.Template.Webpages
{
    public class HomePage : CommonPage
    {
        //Constructor
        public HomePage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath

        private IWebElement myAccountBtn
        {
            get { return WebDriver.FindElementByXPath("//a[@title='My Account']"); }
        }


        private IWebElement registerBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Register']"); }
        }

        private IWebElement loginBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Login']"); }
        }

        private IWebElement desktopBtn
        {
            get { return WebDriver.FindElementByXPath("//a[@class = 'dropdown-toggle' and text() = 'Desktops']"); }
        }

        private IWebElement laptopBtn
        {
            get { return WebDriver.FindElementByXPath("//a[@class = 'dropdown-toggle' and text() = 'Laptops & Notebooks']"); }
        }

        private IWebElement tabletBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Tablets']"); }
        }

        private IWebElement Mp3Btn
        {
            get { return WebDriver.FindElementByXPath("//a[@class = 'dropdown-toggle' and text() = 'MP3 Players']"); }
        }

        private IWebElement showMacDesktopsBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Mac (1)']"); }
        }

        private IWebElement showLaptopsBtn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Show All Laptops & Notebooks']"); }
        }

        private IWebElement showMp3Btn
        {
            get { return WebDriver.FindElementByXPath("//a[text() = 'Show All MP3 Players']"); }
        }

        private IWebElement addToCartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"content\"]/div[2]/div/div/div[2]/div[2]/button[1]"); }
        }

        private IWebElement addLaptopToCartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"content\"]/div[4]/div[1]/div/div[2]/div[2]/button[1]"); }
        }

        private IWebElement addTabletToCartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"content\"]/div[2]/div/div/div[2]/div[2]/button[1]"); }
        }

        private IWebElement addMp3ToCartBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"content\"]/div[4]/div[1]/div/div[2]/div[2]/button[1]"); }
        }

        private By _cartBtn
        {
            get { return By.XPath("//a[@title = 'Shopping Cart']"); }
        }

        private IWebElement cartBtn
        {
            get { return WebDriver.FindElement(_cartBtn); }
        }

        private By btn_checkOut
        {
            get { return By.XPath("//a[@title = 'Checkout']"); }
        }
        private IWebElement btnCheckOut
        {
            get { return WebDriver.FindElement(btn_checkOut); }
        }

        private IWebElement confirmAdition
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"button-cart\"]"); }
        }

        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

    

        public void checkSponsorExists (String name)
        {
            Assert.AreEqual(name, WebDriver.FindElementByXPath("//div[@id='carousel0']//img[contains(@alt, '" + name + "')]").GetAttribute("alt"));
        }

        public void registerUser ()
        {
            myAccountBtn.Click();
            registerBtn.Click();
        }

        public void login()
        {
            myAccountBtn.Click();
            loginBtn.Click();
        }

        public void addDesktopToCart () {
            desktopBtn.Click();
            showMacDesktopsBtn.Click();
            addToCartBtn.Click();
        }

        public void addLaptopToCart()
        {
            laptopBtn.Click();
            showLaptopsBtn.Click();
            addLaptopToCartBtn.Click();
            confirmAdition.Click();
        }

        public void addTabletToCart()
        {
            tabletBtn.Click();
            addTabletToCartBtn.Click();
        }

        public void addMp3ToCart()
        {
            Mp3Btn.Click();
            showMp3Btn.Click();
            addMp3ToCartBtn.Click();
        }


        public HomePage goToCheckOut()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10))
                .Until(CustomExpectedConditions.ElementIsClickable(btn_checkOut));
            btnCheckOut.Click();
            return this;
        }
        public HomePage goToCart()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10))
                .Until(CustomExpectedConditions.ElementIsClickable(_cartBtn));
            cartBtn.Click();
            return this;

        }


    }
}
