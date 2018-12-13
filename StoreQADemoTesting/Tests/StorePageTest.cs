using NUnit.Framework;
using StoreQADemoTesting.Model;
using StoreQADemoTesting.Pages;
using StoreQADemoTesting.Pages.Checkout;
using StoreQADemoTesting.Pages.ProductCategoryPage;
using StoreQADemoTesting.Pages.Tests;
using StoreQADemoTesting.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQADemoTesting.Pages.Tests
{
    [TestFixture()]
    public class StorePageTest : BaseTest
    {

        private ProductCategoryBarPage prodCatPage;
        private ProductsListPage prodListPage;
        private ProductPage prodPage;
        private CheckoutPage checkoutPage;
        private UserPage userPage;
        private ResultPage resultPage;
        private UserFactory factory;
        private User user;
        private CurrentOrderHolderSingleton _single;

        [SetUp()]
        public void SetUpStore()
        {
            _single = CurrentOrderHolderSingleton.Instance;
            
        }

        [Test()]
        public void MainTest()
        {
            for (int i = 0; i < 4; i++)
            {
                AddRandomProduct();
            }
            OpenCheckoutOnMenuBar();
            OrderListCheck();
            AddUser();
            ResultCheck();
        }

        private void OpenCheckoutOnMenuBar()
        {
            MainMenuBarPage bar = new MainMenuBarPage(_driver);
            bar.OpenCheckout();
        }

        private void AddRandomProduct()
        {
            MainMenuBarPage bar = new MainMenuBarPage(_driver);
            bar.HoverProductCategory();
            prodCatPage = new ProductCategoryBarPage(_driver);
            prodCatPage.SelectRandom();
            prodListPage = new ProductsListPage(_driver);
            prodListPage.VerifyRandomCategoryChoose(prodCatPage.choosenElementText).RandomProductChose();
            prodPage = new ProductPage(_driver);
            prodPage.VerifyGoodProdLoaded(prodListPage.ChosenItemName).AddRandomCountOfProductToCart().VerifyAmount();
            bar.OpenHome();
        }

        private void OrderListCheck()
        {
            checkoutPage = new CheckoutPage(_driver);
            checkoutPage.ReadValues().CompareOrders().ContinueClick();
        }

        private void AddUser()
        {
            factory = new UserFactory();
            userPage = new UserPage(_driver);
            user = factory.CreateRandomUser(userPage.GetAviableCountries());
            userPage.SetUser(user).SelectShippingSame().SetAll().Calculate().Purchase().GetShippingPrice();
        }

        private void ResultCheck()
        {
            resultPage = new ResultPage(_driver);
            resultPage.VerifyOrder().VerifyShipment().VerifyTotalOrderWithShipment();
        }

    }
}
