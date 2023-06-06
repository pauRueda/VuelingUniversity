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
    public class RegisterPage : CommonPage
    {
        //Constructor
        public RegisterPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath

        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement detailsBtn
        {
            get { return WebDriver.FindElementById("details-button"); }
        }

        private IWebElement procedBtn
        {
            get { return WebDriver.FindElementById("proceed-link"); }
        }

        private IWebElement firstNameInput
        {
            get { return WebDriver.FindElementById("input-firstname"); }
        }

        private IWebElement lastNameInput
        {
            get { return WebDriver.FindElementById("input-lastname"); }
        }

        private IWebElement emailInput
        {
            get { return WebDriver.FindElementById("input-email"); }
        }

        private IWebElement phoneInput
        {
            get { return WebDriver.FindElementById("input-telephone"); }
        }

        private IWebElement passwordInput
        {
            get { return WebDriver.FindElementById("input-password"); }
        }

        private IWebElement confirmPasswordInput
        {
            get { return WebDriver.FindElementById("input-confirm"); }
        }

        private IWebElement agreePrivacyPolicy
        {
            get { return WebDriver.FindElementByXPath("//input[@type='checkbox']"); }
        }
        private IWebElement continueBtn
        {
            get { return WebDriver.FindElementByCssSelector("input.btn.btn-primary"); }
        }


        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();

    

        public void register (String name, String lastName, String email, String phone, String password, String confirmPassword)
        {
            firstNameInput.SendKeys(name);
            lastNameInput.SendKeys(lastName);
            emailInput.SendKeys(email);
            phoneInput.SendKeys(phone);
            passwordInput.SendKeys(password);
            confirmPasswordInput.SendKeys(confirmPassword);
            agreePrivacyPolicy.Click();
            continueBtn.Click();
        }


        }
}
