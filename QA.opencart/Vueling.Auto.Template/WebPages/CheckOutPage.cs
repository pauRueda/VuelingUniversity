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
using OpenQA.Selenium.Interactions;

namespace Vueling.Auto.Template.Webpages
{
    public class CheckOutPage : CommonPage
    {
        //Constructor
        public CheckOutPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }
        //Define WebElements by: Id, CssSelector or XPath
        private IWebElement newDetails
        {
            get { return WebDriver.FindElementByXPath("//input[@type='radio' and @value='new']"); }
        }
        private IWebElement firstNameInput
        {
            get { return WebDriver.FindElementById("input-payment-firstname"); }
        }

        private IWebElement lastNameInput
        {
            get { return WebDriver.FindElementById("input-payment-lastname"); }
        }
        private IWebElement companyInput
        {
            get { return WebDriver.FindElementById("input-payment-company"); }
        }
        private IWebElement addres1Input
        {
            get { return WebDriver.FindElementById("input-payment-address-1"); }
        }
        private IWebElement addres2Input
        {
            get { return WebDriver.FindElementById("input-payment-address-2"); }
        }
        private IWebElement cityInput
        {
            get { return WebDriver.FindElementById("input-payment-city"); }
        }
        private IWebElement postCodeInput
        {
            get { return WebDriver.FindElementById("input-payment-postcode"); }
        }

        private IWebElement countrySelector
        {
            get { return WebDriver.FindElementById("input-payment-country"); }
        }
        private IWebElement zoneSelector
        {
            get { return WebDriver.FindElementById("input-payment-zone"); }
        }
        private IWebElement continueBtn
        {
            get { return WebDriver.FindElementById("button-payment-address"); }
        }
        private IWebElement closeBanner
        {
            get { return WebDriver.FindElementById("bitnami-close-banner-button"); }
        }
        private IWebElement banner
        {
            get { return WebDriver.FindElementById("bitnami-banner"); }
        }

        private By btn_ContinueDelivery
        {
            get { return By.Id("button-shipping-address"); }
        }
        private IWebElement btnContinueDelivery
        {
            get { return WebDriver.FindElement(btn_ContinueDelivery); }
        }
        private By btn_ContinueMethod
        {
            get { return By.Id("button-shipping-method"); }
        }
        private IWebElement btnContinueMethod
        {
            get { return WebDriver.FindElement(btn_ContinueMethod); }
        }
        private By btn_ContinuePayment
        {
            get { return By.Id("button-payment-method"); }
        }
        private IWebElement btnContinuePayment
        {
            get { return WebDriver.FindElement(btn_ContinuePayment); }
        }
        private IWebElement checkBoxTerms
        {
            get { return WebDriver.FindElementByXPath("//input[@type='checkbox']"); }
        }
        private By btn_Confirm
        {
            get { return By.Id("button-confirm"); }
        }
        //*[@id="button-payment-address"]
        private IWebElement btnConfirm
        {
            get { return WebDriver.FindElement(btn_Confirm); }
        }
        private IWebElement h1TextOrderConfirmed
        {
            get { return WebDriver.FindElementByXPath("//div[@id='content']/h1"); }
        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();


        //Define functions and actions
        public CheckOutPage addBillingDetails(String name, String lastName, String company, String addres1, String addres2, String city,String postCode)
        {
            newDetails.Click();
            firstNameInput.SendKeys(name);
            lastNameInput.SendKeys(lastName);
            companyInput.SendKeys(company);
            addres1Input.SendKeys(addres1);
            addres2Input.SendKeys(addres2);
            cityInput.SendKeys(city);
            postCodeInput.SendKeys(postCode);

            SelectElement selectCountry = new SelectElement(countrySelector);
            selectCountry.SelectByText("Italy");
            SelectElement selectZone = new SelectElement(zoneSelector);
            selectZone.SelectByText("Pisa");


            Actions actions = new Actions(WebDriver);
            // Mover el ratón sobre el elemento
            actions.MoveToElement(banner).Perform();
            closeBanner.Click();

            continueBtn.Click();
            return this;
        }

        public CheckOutPage confirmButtons()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(btn_ContinueDelivery));
            btnContinueDelivery.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(btn_ContinueMethod));
            btnContinueMethod.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(btn_ContinuePayment));
            checkBoxTerms.Click();
            btnContinuePayment.Click();
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(btn_Confirm));
            btnConfirm.Click();
            return this;
        }

    }
}
