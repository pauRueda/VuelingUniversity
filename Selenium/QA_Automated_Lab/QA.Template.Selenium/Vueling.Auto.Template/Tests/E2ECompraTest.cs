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
        public void compraLaptop(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);  
            compraPage = new CompraPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.logearseBtn();
            loginPage.logearse("a", "a");
            homePage.buscarLaptop("Sony vaio i5", "a");
            compraPage.addToCart();
            cartPage.placeOrder();
        }

        [TestCase(1)]
        public void compraPhone (int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            compraPage = new CompraPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.logearseBtn();
            loginPage.logearse("a", "a");
            homePage.buscarPhone("Samsung galaxy s6", "a");
            compraPage.addToCart();
            cartPage.placeOrder();
        }

        [TestCase(1)]
        public void compraMonitor(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            compraPage = new CompraPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.logearseBtn();
            loginPage.logearse("a", "a");
            homePage.buscarMonitor("ASUS Full HD", "a");
            compraPage.addToCart();
            cartPage.placeOrder();
        }

        [TestCase(1)]
        public void comprobarVariosItemsEnCarro(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            compraPage = new CompraPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.logearseBtn();
            loginPage.logearse("a", "a");
            homePage.buscarLaptop("Sony vaio i5", "a");
            compraPage.addToCart();
            homePage.setCartItems(cartPage.addValue());
            homePage.goHome();
            homePage.buscarPhone("Samsung galaxy s6", "a");
            compraPage.addToCart();
            homePage.setCartItems(cartPage.addValue());
            
            Assert.GreaterOrEqual(homePage.getCartItemsLength(),1);
        }

        [TestCase(1)]
        public void eliminarItems(int scenario)
        {
            homePage = new HomePage(setUpWebDriver);
            loginPage = new LoginPage(setUpWebDriver);
            compraPage = new CompraPage(setUpWebDriver);
            cartPage = new CartPage(setUpWebDriver);
            homePage.logearseBtn();
            loginPage.logearse("a", "a");
            homePage.goToCart();
            cartPage.removeValue(homePage.findNumberInList("Samsung galaxy s6"));
            //Assert.GreaterOrEqual(homePage.getCartItemsLength(), 1);
        }

    }

}
