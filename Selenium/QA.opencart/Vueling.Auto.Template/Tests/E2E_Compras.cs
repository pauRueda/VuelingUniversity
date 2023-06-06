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
        String name = "Pau";
        String lastName = "Garcia";

        [TestCase(1), Order(1)]
        public void registerNewUser (int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            registerPage = new RegisterPage(setUpWebDriver); 
            homePage.checkSponsorExists("Nintendo");
            homePage.registerUser();
            privacyErrorPage.skipPrivacyErrorPage();
            registerPage.register(name,lastName,"password@gmail.com","654210236","123456789","123456789");
        }

        [TestCase(1),Order(2)]
        public void login (int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com","123456789");

        }

        [TestCase(1), Order(3)]
        public void buyADesktop (int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            checkOutPage = new CheckOutPage(setUpWebDriver);
            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com", "123456789");
            homePage.addDesktopToCart();
            homePage.goToCheckOut();

            checkOutPage.addBillingDetails(name,lastName,"a","c/a","c/b","Barcelona","05268");
            checkOutPage.confirmButtons();
        }

        [TestCase(1), Order(4)]
        public void buyALaptop (int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            checkOutPage = new CheckOutPage(setUpWebDriver);
            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com", "123456789");
            homePage.addLaptopToCart();
            homePage.goToCheckOut();

            checkOutPage.addBillingDetails(name, lastName, "a", "c/a", "c/b", "Barcelona", "05268");
            checkOutPage.confirmButtons();
        }

        [TestCase(1), Order(5)]
        public void buyATablet(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            checkOutPage = new CheckOutPage(setUpWebDriver);
            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com", "123456789");
            homePage.addTabletToCart();
            homePage.goToCheckOut();

            checkOutPage.addBillingDetails(name, lastName, "a", "c/a", "c/b", "Barcelona", "05268");
            checkOutPage.confirmButtons();
        }

        [TestCase(1), Order(6)]
        public void buyAMp3(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            checkOutPage = new CheckOutPage(setUpWebDriver);
            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com", "123456789");
            homePage.addMp3ToCart();
            homePage.goToCheckOut();

            checkOutPage.addBillingDetails(name, lastName, "a", "c/a", "c/b", "Barcelona", "05268");
            checkOutPage.confirmButtons();
        }

        [TestCase(1), Order(4)]
        public void deleteAnItem(int scenario)
        {

            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            privacyErrorPage = new PrivacyErrorPage(setUpWebDriver);
            checkOutPage = new CheckOutPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);


            homePage.login();
            privacyErrorPage.skipPrivacyErrorPage();
            loginPage.login("password@gmail.com", "123456789");
            homePage.addDesktopToCart();
            homePage.goToCart();
            cartPage.deleteProduct();

        }

    }

}
