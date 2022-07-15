using Joes_Pizza_Test.pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;

namespace Joes_Pizza_Test
{
    [Binding]
    public class PizzaPurchasingSteps
    {
        //Create objects 
        Pages_ElementsDefinition elm = new Pages_ElementsDefinition();
        IWebDriver webDriver = new FirefoxDriver();

        [Given(@"launch joe's pizza website")]
        public void GivenLaunchJoeSPizzaWebsite()
        {
            webDriver.Navigate().GoToUrl("https://localhost:44379/");
            elm = new Pages_ElementsDefinition(webDriver);
        }

        [Then(@"Click on Navbar Menu Link")]
        public void ThenClickOnNavbarMenuLink()
        {
            elm.ClickInkMenuNavbar();
        }

        [Then(@"Menu page should be displayed")]
        public void ThenMenuPageShouldBeDisplayed()
        {
            //Using Assert to verify the existence of the Menu page
            Assert.That(elm.IslnkMenuPageExist, Is.True);
        }

        [Then(@"select pizza")]
        public void GivenSelectPizza()
        {
            elm.ClickbtnAddToCart1();
            elm.ClickbtnAddToCart2();
            elm.ClickbtnAddToCart3();
            elm.ClickbtnAddToCart1();

            //if the customer clicks on the same product, an popup alert message will be shown.
            elm.ClickbtnPopupAlert();           
        }

        [Then(@"Click on Cart Icon")]
        public void GivenClickOnCartIcon()
        {
            //Click on the cart icon to display the Order Checkout page
            elm.ClickCart();
        }

        [Then(@"Order Checkout page should be displayed")]
        public void ThenOrderCheckoutPageShouldBeDisplayed()
        {
            
            //Using Assert to verify the existence of the Order Checkout page
            Assert.That(elm.IslnkCheckoutPageExist, Is.True);
        }

        [Then(@"change the quantity in Checkout page")]
        public void ThenChangeTheQuantityInCheckoutPage()
        {
            //The customer can increase or decrease the quantity or even delete the item from the cart.
            //NOTE:These IWebElement numbers are constantly changing automatically.
            //elm.ClickbtnIncrease1();
            //elm.ClickbtnIncrease1();
            //elm.ClickbtnIncrease2();
            //elm.ClickbtnDecrease();
            //elm.ClickbtnDeleteItem();
        }
        [Then(@"Click on Proceed button")]
        public void ThenClickOnProceedButton()
        {
            elm.ClickbtnProceed();
        }

        [Then(@"Payment section should be displayed")]
        public void ThenPaymentSectionShouldBeDisplayed()
        {
            //Using Assert to verify the existence of the Payment section
            Assert.That(elm.IsPaymentSectionExist, Is.True);  
        }

        [Then(@"fill the input fields")]
        public void ThenFillTheInputFields()
        {
            elm.FilltxtFullName();
            elm.FilltxtEmail();
            elm.FilltxtAddress();
            elm.FilltxtCCName();
            elm.FilltxtCCNumber();
            elm.FilltxtCCExpiration();
            elm.FilltxtCCcvv();
        }


        [Then(@"Click on Pay button")]
        public void ThenClickOnCheckoutButton()
        {
            //Click on the pay button to display the Order Confirmation page
            elm.ClickbtnPay();
        }

        [Then(@"Order Confirmation page should be displayed")]
        public void ThenOrderConfirmationPageShouldBeDisplayed()
        {            
            //Using Assert to verify the existence of the Order Confirmation page
            Assert.That(elm.IslnkOrderConfirmationPageExist, Is.True);
        }
    }
}
