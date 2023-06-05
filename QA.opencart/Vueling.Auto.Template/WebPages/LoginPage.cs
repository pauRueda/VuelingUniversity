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
    public class LoginPage : CommonPage
    {
        //Constructor
        public LoginPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath

        private IWebElement emailInput
        {
            get { return WebDriver.FindElementById("input-email"); }
        }

        private IWebElement passwordInput
        {
            get { return WebDriver.FindElementById("input-password"); }
        }

        private IWebElement loginBtn
        {
            get { return WebDriver.FindElementByCssSelector("input.btn"); }
        }
   
        private IWebElement homeBtn
        {
            get { return WebDriver.FindElementByXPath("//div[@id='logo']/h1/a"); }
        }


        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();


        //Define functions and actions

        public LoginPage login (string email, string password)
        {
            emailInput.SendKeys(email);
            passwordInput.SendKeys(password);
            loginBtn.Click();
            homeBtn.Click();
            return this;
        }



    }
}
