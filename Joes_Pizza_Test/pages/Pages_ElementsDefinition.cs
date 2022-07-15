using OpenQA.Selenium;

namespace Joes_Pizza_Test.pages
{
    public class Pages_ElementsDefinition
    {
        public IWebDriver WebDriver { get; }
        public Pages_ElementsDefinition(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
        public Pages_ElementsDefinition() { }

        //UI elements
        //Menu Page Elements
        public IWebElement InkMenuNavbar => WebDriver.FindElement(By.XPath("//a[@href='/Home/Menu']"));
        public IWebElement lnkMenuPage => WebDriver.FindElement(By.CssSelector("#gtco-menu"));
        public IWebElement btnAddToCart1 => WebDriver.FindElement(By.XPath("//a[@href='/Home/AddToCart/3']"));
        public IWebElement btnAddToCart2 => WebDriver.FindElement(By.XPath("//a[@href='/Home/AddToCart/4']"));
        public IWebElement btnAddToCart3 => WebDriver.FindElement(By.XPath("//a[@href='/Home/AddToCart/5']"));
        public IWebElement btnPopupAlert => WebDriver.FindElement(By.CssSelector(".ok"));
        public IWebElement lnkCart => WebDriver.FindElement(By.XPath("//a[@href='/Home/OrderCheckout']"));

        //Order Checkout Page Elements
        //NOTE:These IWebElement numbers are constantly changing automatically.
        public IWebElement btnIncrease1 => WebDriver.FindElement(By.XPath("//a[@href='/Home/IncreaseQuantity/388']"));
        public IWebElement btnIncrease2 => WebDriver.FindElement(By.XPath("//a[@href='/Home/IncreaseQuantity/389']"));
        public IWebElement btnDecrease1 => WebDriver.FindElement(By.XPath("//a[@href='/Home/DecreaseQuantity/388']"));
        public IWebElement btnDeleteItem => WebDriver.FindElement(By.XPath("//a[@href='/Home/DeleteItem/390']"));
        public IWebElement lnkCheckoutPage => WebDriver.FindElement(By.CssSelector("#gtco-OrderCheckout"));

        //Payment Section's Elements 
        public IWebElement PaymentSection => WebDriver.FindElement(By.CssSelector("#DivPayment"));
        public IWebElement btnProceed => WebDriver.FindElement(By.CssSelector("#btnProceed"));
        public IWebElement txtFullName => WebDriver.FindElement(By.CssSelector("#fullName"));
        public IWebElement txtEmail => WebDriver.FindElement(By.CssSelector("#email"));
        public IWebElement txtAddress => WebDriver.FindElement(By.CssSelector("#address"));
        public IWebElement txtCCName => WebDriver.FindElement(By.CssSelector("#cc-name"));
        public IWebElement txtCCNumber => WebDriver.FindElement(By.CssSelector("#cc-number"));
        public IWebElement txtCCExpiration => WebDriver.FindElement(By.CssSelector("#cc-expiration"));
        public IWebElement txtCCcvv => WebDriver.FindElement(By.CssSelector("#cc-cvv"));
        public IWebElement btnPay => WebDriver.FindElement(By.CssSelector("#btnPay"));
        

        //Order Confirmation Page Elements
        public IWebElement lnkOrderConfirmationPage => WebDriver.FindElement(By.CssSelector("#gtco-OrderConfirmation"));


        //Menu Page Methods
        public void ClickInkMenuNavbar() => InkMenuNavbar.Click();
        public bool IslnkMenuPageExist() => lnkMenuPage.Displayed;
        public void ClickbtnAddToCart1() => btnAddToCart1.Click();
        public void ClickbtnAddToCart2() => btnAddToCart2.Click();
        public void ClickbtnAddToCart3() => btnAddToCart3.Click();
        public void ClickbtnPopupAlert() => btnPopupAlert.Click();
        public void ClickCart() => lnkCart.Click();

        //Order Checkout Page Methods
        public bool IslnkCheckoutPageExist() => lnkCheckoutPage.Displayed;
        public void ClickbtnIncrease1() => btnIncrease1.Click();
        public void ClickbtnIncrease2() => btnIncrease2.Click();
        public void ClickbtnDecrease() => btnDecrease1.Click();
        public void ClickbtnDeleteItem() => btnDeleteItem.Click();
        public void ClickbtnProceed() => btnProceed.Click();

        //Payment Section's Methods 
        public bool IsPaymentSectionExist() => PaymentSection.Displayed;
        public void FilltxtFullName() => txtFullName.SendKeys("Shatha Alkulaib");
        public void FilltxtEmail() => txtEmail.SendKeys("shatha.alkulaib@gmail.com");
        public void FilltxtAddress() => txtAddress.SendKeys("Al-Hufof, Building 6990");
        public void FilltxtCCName() => txtCCName.SendKeys("Shatha Alkulaib");
        public void FilltxtCCNumber() => txtCCNumber.SendKeys("4929970221286666");
        public void FilltxtCCExpiration() => txtCCExpiration.SendKeys("12/22");
        public void FilltxtCCcvv() => txtCCcvv.SendKeys("854");
        public void ClickbtnPay() => btnPay.Click();

        //Order Confirmation Page Methods
        public bool IslnkOrderConfirmationPageExist() => lnkOrderConfirmationPage.Displayed;
    }
}
