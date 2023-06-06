using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using System;
using Vueling.Auto.Template.Common;
using NUnit.Framework;
using System.Xml.Linq;

namespace Vueling.Auto.Template.Webpages
{
    public class LoginPage : CommonPage
    {
        //Constructor
        public LoginPage (ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement usernameInput
        {
            get { return WebDriver.FindElementById("loginusername"); }
        }

        private IWebElement passwordInput
        {
            get { return WebDriver.FindElementById("loginpassword"); }
        }

        private IWebElement logInBtn
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"logInModal\"]/div/div/div[3]/button[2]"); }
        }

       

        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

        public LoginPage logearse(String user, String passw)
        {
            usernameInput.SendKeys(user);
            passwordInput.SendKeys(passw);
            logInBtn.Click();
           
            return this;
        }

    }
}
