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
    public class PrivacyErrorPage : CommonPage
    {
        //Constructor
        public PrivacyErrorPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }


        //Define WebElements by: Id, CssSelector or XPath

        private IWebElement moreDetailsBtn
        {
            get { return WebDriver.FindElementById("details-button"); }
        }

        private IWebElement procedBtn
        {
            get { return WebDriver.FindElementById("proceed-link"); }
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        //Define functions and actions
        public PrivacyErrorPage skipPrivacyErrorPage()
        {
            moreDetailsBtn.Click();
            procedBtn.Click();
            return this;
        }
    }
}
