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
    public class StorePageTest : BasePageTest
    {

        private ProductCategoryBarPage prodCatPage;
        private ProductsListPage prodListPage;
        private ProductPage prodPage;
        private CheckoutPage checkoutPage;
        private UserPage userPage;
        private ResultPage resultPage;
        private UserFactory factory;
        private User user;

        [SetUp()]
        public void SetUpStore()
        {
            _bar = new MainMenuBarPage(_driver);
        }

        [Test()]
        public void MainTest()
        {
            for (int i = 0; i < 4; i++)
            {
                AddRandomProduct();
            }
            _bar.openCheckout();
            OrderListCheck();
            AddUser();
            ResultCheck();
        }

        private void AddRandomProduct()
        {
            _bar.HoverProductCategory();
            prodCatPage = new ProductCategoryBarPage(_driver);
            prodCatPage.SelectRandom();
            prodListPage = new ProductsListPage(_driver, _bar);
            prodListPage.VerifyRandomCategoryChoose(prodCatPage.choosenElementText).randomProductChose();
            prodPage = new ProductPage(_driver, _bar);
            prodPage.VerifyGoodProdLoaded(prodListPage.ChosenItemName).AddRandomCountOfProductToCart().VerifyAmount();
            _bar.openHome();
        }

        private void OrderListCheck()
        {
            checkoutPage = new CheckoutPage(_driver, _bar);
            checkoutPage.readValues().compareOrders().ContinueClick();
        }

        private void AddUser()
        {
            factory = new UserFactory();
            userPage = new UserPage(_driver, _bar);
            user = factory.CreateRandomUser(userPage.GetAviableCountries());
            userPage.SetUser(user).SelectShippingSame().SetAll().Calculate().Purchase().GetShippingPrice();
        }

        private void ResultCheck()
        {
            resultPage = new ResultPage(_driver, _bar);
            resultPage.VerifyOrder().verifyShipment().VerifyTotalOrderWithShipment();
        }

    }
}
