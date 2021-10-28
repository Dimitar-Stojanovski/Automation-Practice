using AutomationPractice.Utils.Action_Methods;
using AutomationPractice.Utils.Custom_Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using SeleniumExtras.WaitHelpers;
using System.Threading;
using System.Collections;

namespace AutomationPractice.Pages
{
    public class AddProductPage:MethodsCollection
    {
        private IWebDriver driver = null;
        private WebDriverWait wait = null;
        private Actions action = null;
        private SelectElement select = null;
        By _productsCategories = new ContainsClassPath("menu-content", "/li");
        By _dressCategory = new IDPath("categories_block_left", "/div/ul/li");
        By _dressHeader = new ContainsClassPath("product-listing", "/span[1]");
        By _size = new IDPath("ul_layered_id_attribute_group_1", "/li/div");
        By _chekers = new IDPath("ul_layered_id_attribute_group_1", "/li/div");
        By _cottonChecker = By.Id("uniform-layered_id_feature_5");
        By _inStockChecker = By.Id("uniform-layered_quantity_1");
        By _leftSliderBtn = new IDPath("layered_price_slider", "/a[1]");
        By _RightSliderBtn = new IDPath("layered_price_slider", "/a[2]");
        By _addToCartBtn = By.XPath("//*[@title = 'Add to cart']");
        By _productSuccessHeader = new ClassPath("cross", "/../h2");
        By _productDetails = new ClassPath("layer_cart_product_info", "/span");
        By _continueShoppingBtn = By.XPath("//*[@title = 'Continue shopping']");
        By _navigateToCategory = new ClassPath("breadcrumb clearfix", "/a");
        By _productSortDrpDwn = By.Id("selectProductSort");
        By _quickViewSpan = By.LinkText("Quick view");
        By _quantityButtons = new IDPath("quantity_wanted_p", "/a");                          //*[@id='quantity_wanted_p']/a
        By _iframeLoc = By.XPath("//*[contains(@id, 'fancybox')]");
        By _quantityField = By.Id("quantity_wanted");
        By _colourField = new IDPath("color_to_pick_list", "/li");
        By _imagChoosing = new IDPath("thumbs_list_frame", "/li");
        By _addToCartInIframe = By.Name("Submit");
        By _shoppingCart = By.XPath("//*[@title = 'View my shopping cart']");
        By _cardSummary = new IDPath("cart_summary", "/thead/tr/th");
        By _proceedToCheckOutBtn = By.LinkText("Proceed to checkout");
        By _productImageLink = By.XPath("//*[@class = 'product_img_link' and @title = 'Printed Dress']");
       
        private string[] _categoriesTitles = { "Women", "Dresses", "T-shirts" };
        private string[] _categoryDressTitles = { "Casual Dresses", "Evening Dresses", "Summer Dresses" };
        private string[] _sizesTitles = { "S", "M", "L"};
        private string[] _productDetailsTitles = { "Product", "Collour and Quantity" };
        private string[] _navigationCategoryTitles = { "Home", "Women", "Products" };
        private string[] _increaseDecreaseQty = { "Decrease", "Increase" };
        private string[] _summaryTitles = { "Product", "Description", "Avail.", "Unit price", "Qty", "Total", "Empty" };


        public AddProductPage(IWebDriver driver, WebDriverWait wait, Actions action) : base(driver, wait, action)
        {
            this.driver = driver;
            this.wait = wait;
            this.action = action;
            
        }

        public void ChooseProductCategory(string _titles)
        {
            int index = Array.IndexOf(_categoriesTitles, _titles);
            webElements(_productsCategories)[index].Click();
            
        }

        public void ChooseDressCategory(string _titles)
        {
            int index = Array.IndexOf(_categoryDressTitles, _titles);
            webElements(_dressCategory)[index].Click();
        }

        public string GetTitleInDressCategory()
        {
            return GetTextFromElement(_dressHeader);
        }
        
        public void SelectSize(string _titles)
        {
            int index = Array.IndexOf(_sizesTitles, _titles);
            webElements(_size)[index].Click();
        }

        public void SelectCotton()
        {
            webElement(_cottonChecker).Click();
        }

        public void SelectInStock()
        {
            webElement(_inStockChecker).Click();
        }

        public void ModifyLeftSlider(int x, int y)
        {
            ActionDragAndDrop(_leftSliderBtn, x, y);
        }

        public void ModifyRightSlider(int x, int y)
        {
            ActionDragAndDrop(_RightSliderBtn, x, y);
        }

        public void ClickAddToCartBtn()
        {
            webElement(_addToCartBtn).Click();
        }

        public bool IsAddToCartBtnPresent()
        {
            return ElementIsDisplayed(_addToCartBtn);
        }

        public bool IsProductCompleteTextDisplayed(string _value)
        {
            return TextInElement(_productSuccessHeader, _value);
        }

        public string VerifyProductDetails(int index, string _titles)
        {
            index = Array.IndexOf(_productDetailsTitles, _titles);
            return GetTextFromElements(_productDetails, index);
        }

        public void ClickOnContinueShoppingBtn()
        {
            webElement(_continueShoppingBtn).Click();
        }

        public bool IsContinueShoppingBtnDisplayed()
        {
            return ElementIsDisplayed(_continueShoppingBtn);
        }

        public void NavigateToCategories(string _title)
        {
            int index = Array.IndexOf(_navigationCategoryTitles, _title);
            webElements(_navigateToCategory)[index].Click();
        }

        public void SelectSortByDropDown(string _titles)
        {
            select = new SelectElement(driver.FindElement(_productSortDrpDwn));
            select.SelectByText(_titles);
            
        }

        public void ClickOnQuickViewSpan()
        {
            ActionElement(_quickViewSpan);
            webElement(_quickViewSpan).Click();
        }

        public bool IsQuickViewDisplayed()
        {
            return ElementIsDisplayed(_quickViewSpan);
        }

        public void SwitchToIframeProduct()
        {
            switchToFrame(_iframeLoc);
        }

        

        public void EnterQuantity(int number, string _titles)
        {
            int index = Array.IndexOf(_increaseDecreaseQty, _titles);
            for (int i = 0; i <= number; i++)
            {
                webElements(_quantityButtons)[index].Click();
            }
        }

        public void ChooseColour(int index)
        {
            webElements(_colourField)[index].Click();
        }
        
        public void ClearQuantityField()
        {
            webElement(_quantityField).Clear();
        }

        public void ChoosePicture(int index)
        {
            webElements(_imagChoosing)[index].Click();
        }

        public void ClickAddToCartInIframe()
        {
            webElement(_addToCartInIframe).Click();
        }

        public bool IsAddToCartIframeDisplayed()
        {
            return ElementIsDisplayed(_addToCartInIframe);
        }

        public void ClickOnShoppingCart()
        {
            webElement(_shoppingCart).Click();
        }

        public string VerifySummaryTitles(string _titles)
        {
            int index = Array.IndexOf(_summaryTitles, _titles);
            return GetTextFromElements(_cardSummary, index);
        }

        public void ClickProceedToCheckout()
        {
            webElement(_proceedToCheckOutBtn).Click();
        }

        public void MoveToProductImageLink()
        {
            ActionElement(_productImageLink);
        }
    }
}
