#region Copyright and terms of services

// Copyright (c) 2015 Meplato GmbH, Switzerland.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except
// in compliance with the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License
// is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
// or implied. See the License for the specific language governing permissions and limitations under
// the License.

#endregion

using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class SearchTests : TestCase
    {
        [Test]
        public async void SearchUpdate()
        {
            var service = GetProductsService();
            Assert.NotNull(service);

            MockFromFile("products.search.success");
            var response = await service.Search().Pin("AD8CCDD5F9").Area("work").Q("toner").Skip(0).Take(30).Do();
            Assert.NotNull(response);
            Assert.AreEqual("store#products", response.Kind);
            Assert.IsTrue(response.TotalItems > 0);
            Assert.NotNull(response.Items);
            foreach (var product in response.Items)
            {
                Assert.NotNull(product);
                Assert.IsNotNullOrEmpty(product.Id);
                Assert.IsNotNullOrEmpty(product.Kind);
                Assert.IsNotNullOrEmpty(product.SelfLink);
                Assert.IsNotNullOrEmpty(product.Spn);
                Assert.IsNotNullOrEmpty(product.Name);
                Assert.IsNotNullOrEmpty(product.OrderUnit);
                Assert.IsTrue(product.Price > 0);
                Assert.NotNull(product.Created);
                Assert.NotNull(product.Updated);
            }
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Unauthorized")]
        public async void TestSearchUnauthorized()
        {
            MockFromFile("products.search.unauthorized");

            var service = GetProductsService();
            Assert.NotNull(service);
            service.User = "";
            service.Password = "";

            var response = await service.Search().Pin("AD8CCDD5F9").Area("work").Q("toner").Skip(0).Take(30).Do();
            Assert.Null(response);
        }
    }
}