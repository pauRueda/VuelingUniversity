using AventStack.ExtentReports;
using NUnit.Framework;
using Vueling.Auto.Template.Webpages;
using Vueling.Auto.Template.SetUp;
using Vueling.Auto.Template.WebPages.Base;
using System.Threading;
using System;

namespace Vueling.Auto.Template.Tests
{
    [TestFixture]
    class E2ECompraTest : TestSetCleanBase
    {
        [TestCase(1)]
        public void testSearchRandomFlights(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            DateTime ida = new DateTime(2023, 6, 9);
            DateTime vuelta = new DateTime(2023, 6, 15);


            homePage.acceptCookies();
            homePage.addInfoFlight(ida, vuelta);

        }

        [TestCase(1)]
        public void testSantiagoChileToBcn(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            string origin = "Santiago de Chile";
            string destination = "Barcelona";
            string month = "Septiembre";
            DateTime vuelta = new DateTime(2023, 6, 15);

            homePage.acceptCookies();
            homePage.addOriginAndDestination(origin, destination);
            homePage.selectValidDates(month);
            homePage.selectPassengers();

        }
    }

}
