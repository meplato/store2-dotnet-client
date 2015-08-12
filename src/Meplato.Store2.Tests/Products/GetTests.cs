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
    public class GetTests : TestCase
    {
        [Test]
        public async void TestGet()
        {
            MockFromFile("products.get.success");

            var service = GetProductsService();
            Assert.NotNull(service);

            var product = await service.Get().Pin("AD8CCDD5F9").Area("work").Spn("50763599").Do();
            Assert.NotNull(product);
            Assert.IsNotNullOrEmpty(product.Id);
            Assert.IsNotNullOrEmpty(product.Spn);
            Assert.IsNotNullOrEmpty(product.Name);
            Assert.Greater(product.Price, 0.0);
            Assert.IsNotNullOrEmpty(product.OrderUnit);
            Assert.NotNull(product.Created);
            Assert.NotNull(product.Updated);

            Assert.NotNull(product.Conditions);
            Assert.AreEqual(1, product.Conditions.Length);
            Assert.AreEqual("new_product", product.Conditions[0].Kind);

            Assert.NotNull(product.CustFields);
            Assert.AreEqual(1, product.CustFields.Length);
            Assert.AreEqual("Steuersatz", product.CustFields[0].Name);
            Assert.AreEqual("19%", product.CustFields[0].Value);

            Assert.NotNull(product.Blobs);
            Assert.AreEqual(1, product.Blobs.Length);
            Assert.AreEqual("normal", product.Blobs[0].Kind);
            Assert.AreEqual("Normalbild", product.Blobs[0].Text);
            Assert.AreEqual("50763599.jpg", product.Blobs[0].Source);
            Assert.IsNull(product.Blobs[0].Language);
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Product not found")]
        public async void TestGetNotFound()
        {
            MockFromFile("products.get.not_found");

            var service = GetProductsService();
            Assert.NotNull(service);

            var product = await service.Get().Pin("AD8CCDD5F9").Area("work").Spn("no-such-product").Do();
            Assert.Null(product);
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Unauthorized")]
        public async void TestGetUnauthorized()
        {
            MockFromFile("products.get.unauthorized");

            var service = GetProductsService();
            Assert.NotNull(service);
            service.User = "";
            service.Password = "";

            var product = await service.Get().Pin("AD8CCDD5F9").Area("work").Spn("no-such-product").Do();
            Assert.Null(product);
        }
    }
}