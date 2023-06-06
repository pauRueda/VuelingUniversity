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
    public class CartPage : CommonPage
    {
        //Constructor
        public CartPage(ISetUpWebDriver setUpWebDriver) : base(setUpWebDriver)
        {

        }

        protected override IWebElement ApartadosBusqueda => throw new NotImplementedException();

        //Define WebElements by: Id, CssSelector or XPath

        private By btn_delete
        {
            get { return By.XPath("//button[@class='btn btn-danger']"); }
        }
        private IWebElement btnDelete
        {
            get { return WebDriver.FindElement(btn_delete); }
        }
        private IWebElement textCart
        {
            get { return WebDriver.FindElementByXPath("//div[@id='content']/p"); }
        }



        //Define functions and actions

        public CartPage deleteProduct()
        {
            new WebDriverWait(WebDriver, TimeSpan.FromSeconds(10))
                .Until(CustomExpectedConditions.ElementIsVisible(btn_delete));
            btnDelete.Click();
            //Este sleep es necesario para esperar a que el texto se actualice despues de borrar el producto
            //No conozco otra forma de hacerlo
            Thread.Sleep(1000);
            Assert.AreEqual("Your shopping cart is empty!", textCart.Text, "Test the cart is empty");
            return this;
        }



    }
}
