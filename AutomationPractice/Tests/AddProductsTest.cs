using AutomationPractice.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AutomationPractice.Tests
{
    public class AddProductsTest:BaseTest
    {
        string _messageProductSuccess = "Product successfully added to your shopping cart";
       
        [Test]
        public void ChooseSeveralProducts()
        {
            Assert.Multiple(() =>
            {
                addProductPage.ChooseProductCategory("Dresses");
                addProductPage.ChooseDressCategory("Casual Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "CASUAL DRESSES ");
                addProductPage.SelectSize("S");
                addProductPage.SelectSize("M");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.SelectCotton();
                addProductPage.SelectInStock();
                addProductPage.ModifyLeftSlider(90,0);
                addProductPage.ModifyRightSlider(80, 0);
                Assert.True(addProductPage.IsAddToCartBtnPresent());
                addProductPage.ClickAddToCartBtn();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(StaticVariables._ProductSuccessfullyAddedMessage));
                Assert.AreEqual(addProductPage.VerifyProductDetails(0, "Product"), "Printed Dress");
                Assert.AreEqual(addProductPage.VerifyProductDetails(1, "Collour and Quantity"), "Orange, S");
                Assert.True(addProductPage.IsContinueShoppingBtnDisplayed());
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.NavigateToCategories("Products");
                addProductPage.ChooseDressCategory("Evening Dresses");
                Assert.AreEqual(addProductPage.GetTitleInDressCategory(), "EVENING DRESSES ");
                addProductPage.SelectSortByDropDown("Product Name: A to Z");
                js.ExecuteScript("window.scrollBy(0,500)");
                addProductPage.MoveToProductImageLink();
                Assert.True(addProductPage.IsQuickViewDisplayed());
                addProductPage.ClickOnQuickViewSpan();
                addProductPage.SwitchToIframeProduct();
                addProductPage.ChoosePicture(0);
                addProductPage.ChoosePicture(1);
                addProductPage.EnterQuantity(15, "Increase");
                //Thread.Sleep(500);
                addProductPage.EnterQuantity(7, "Decrease");
                addProductPage.ChooseColour(1);
                Assert.True(addProductPage.IsAddToCartIframeDisplayed());
                addProductPage.ClickAddToCartInIframe();
                addProductPage.SwitchToParentFrame();
                Assert.IsTrue(addProductPage.IsProductCompleteTextDisplayed(_messageProductSuccess));
                addProductPage.ClickOnContinueShoppingBtn();
                js.ExecuteScript("window.scrollBy(0, -500)");
                addProductPage.ClickOnShoppingCart();
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Product"), "Product");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Description"), "Description");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Avail."), "Avail.");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Unit price"), "Unit price");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Qty"), "Qty");
                Assert.AreEqual(addProductPage.VerifySummaryTitles("Total"), "Total");
                js.ExecuteScript("window.scrollBy(0, 500)");
                addProductPage.ClickProceedToCheckout();
                
                Thread.Sleep(5000);
            });
            
        }
    }
}
