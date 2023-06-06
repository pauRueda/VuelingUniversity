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
        protected override IWebElement ApartadosBusqueda => throw new System.NotImplementedException();


        private By input_origin
        {
            get { return By.XPath("//div[@data-field = 'origin']"); }
        }
        private IWebElement inputOrigin
        {
            get { return WebDriver.FindElement(input_origin); }
        }

        private IWebElement inputDestination
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field = 'destination']"); }
        }
        private IWebElement inputAirport(string name)
        {
            return WebDriver.FindElementByXPath("//div[@data-field='origin']//div[@class='city' and text()='" + name + "']");
        }
        private IWebElement inputAirportDestination(string name)
        {
            return WebDriver.FindElementByXPath("//div[@data-field='destination']//div[@class='city' and text()='" + name + "']");
        }

        private IWebElement btnSearch
        {
            get { return WebDriver.FindElementById("searcher_submit_buttons"); }
        }

        private IWebElement btnNextMth
        {
            get { return WebDriver.FindElementByXPath("//span[@class = 'icon-chevron-green-arrow']"); }
        }

        private IWebElement monthTitle
        {
            get { return WebDriver.FindElementByXPath("//span[@class = 'month']"); }
        }
        private IWebElement btnPlusAdult
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='adult']//span[@class='icon-plus pax-icon']"); }
        }
        private IWebElement btnPlusChild
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='child']//span[@class='icon-plus pax-icon']"); }
        }
        private IWebElement btnPlusBaby
        {
            get { return WebDriver.FindElementByXPath("//div[@data-field='infant']//span[@class='icon-plus pax-icon']"); }
        }

        private IWebElement departureDate
        {
            get { return WebDriver.FindElementByXPath("//div[@class = 'departure-date']"); }
        }

        private IWebElement returnDate
        {
            get { return WebDriver.FindElementByXPath("//*[@id=\"searcher\"]/div[2]/div[2]/p"); }
        }



        public void addInfoFlight(DateTime ida, DateTime vuelta)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(input_origin));
            inputOrigin.Click();
            inputAirport("Barcelona").Click();
            inputAirportDestination("Buenos Aires").Click();

            clickDate(ida);
            clickDate(vuelta);
            btnSearch.Click();

        }

        public void clickDate(DateTime date)
        {
            long timestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
            WebDriver.FindElementByXPath("//div[@data-time = '" + timestamp + "']").Click();

        }
        public void acceptCookies()
        {

            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
            .Until(ExpectedConditions.ElementIsVisible(By.Id("ensCloseBanner")));

            // Encontrar el botón de aceptar cookies y hacer clic en él
            IWebElement acceptButton = WebDriver.FindElementById("ensCloseBanner");
            acceptButton.Click();

        }

        public void addOriginAndDestination(String origin, String destination)
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(WaitTimeout))
                .Until(CustomExpectedConditions.ElementIsVisible(input_origin));
            inputOrigin.Click();
            inputAirport(origin).Click();
            inputAirportDestination(destination).Click();
        }

        public void selectValidDates(string month)
        {
            DateTime date = new DateTime(2023, 9, 1);
            bool validDateFound = false;
            while (monthTitle.Text != month.ToUpper())
            {
                btnNextMth.Click();
            }

            while (!validDateFound)
            {
                long timestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
                var daySelector = WebDriver.FindElementByXPath("//div[@data-time = '" + timestamp + "']");
                if (daySelector.GetAttribute("class").Contains("is-available"))
                {
                    daySelector.Click();
                    validDateFound = true;
                }
                else
                {
                    date = date.AddDays(1);
                }
            }
            date = date.AddDays(11);
            validDateFound = false;
            while (!validDateFound)
            {
                long timestamp = new DateTimeOffset(date).ToUnixTimeMilliseconds();
                var daySelector = WebDriver.FindElementByXPath("//div[@data-time = '" + timestamp + "']");
                if (daySelector.GetAttribute("class").Contains("is-available"))
                {
                    daySelector.Click();
                    validDateFound = true;
                }
                else
                {
                    date = date.AddDays(1);
                }
            }

        }

        public void selectPassengers()
        {
            btnPlusAdult.Click();
            btnPlusChild.Click();
            btnPlusBaby.Click();
            btnPlusAdult.Click();
            assertTheSearch();
            btnSearch.Click();
        }

        public void assertTheSearch()
        {
            string[] originDivided = inputOrigin.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            string[] destinationDivided = inputDestination.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            Assert.AreEqual(originDivided[originDivided.Length - 1], "Santiago De Chile", "Check the origin");
            Assert.AreEqual(destinationDivided[destinationDivided.Length - 1], "Barcelona", "Check the destination");

            Assert.AreEqual(departureDate.Text, "Vie, 1 Sept", "Check the departure Date");
            Assert.AreEqual(returnDate.Text, "Mar, 12 Sept", "Check the return Date");
        }
    }
}
