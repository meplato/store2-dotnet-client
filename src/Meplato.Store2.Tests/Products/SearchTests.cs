#region Copyright and terms of services

// Copyright (c) 2015 Meplato GmbH.
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

using System.Threading.Tasks;
using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class SearchTests : TestCase
    {
        [Test]
        public async Task SearchUpdate()
        {
            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            MockFromFile("products.search.success");
            var response = await service.Search().Pin("AD8CCDD5F9").Area("work").Q("toner").Skip(0).Take(30).Do();
            Assert.That(response, Is.Not.Null);
            Assert.That("store#products", Is.EqualTo(response.Kind));
            Assert.That(response.TotalItems > 0, Is.EqualTo(true));
            Assert.That(response.Items, Is.Not.Null);
            foreach (var product in response.Items)
            {
                Assert.That(product, Is.Not.Null);
                Assert.That(product.Id,Is.Not.Null);
                Assert.That(product.Id, Is.Not.Empty);
                Assert.That("store#product", Is.EqualTo(product.Kind));
                Assert.That(product.SelfLink, Is.Not.Null);
                Assert.That(product.SelfLink, Is.Not.Empty);
                Assert.That(product.Spn, Is.Not.Null);
                Assert.That(product.Spn, Is.Not.Empty);
                Assert.That(product.Name,Is.Not.Null);
                Assert.That(product.Name, Is.Not.Empty);
                Assert.That(product.OrderUnit, Is.Not.Null);
                Assert.That(product.OrderUnit, Is.Not.Empty);
                Assert.That(product.Price > 0,Is.EqualTo(true));
                Assert.That(product.Created, Is.Not.Null);
                Assert.That(product.Updated, Is.Not.Null);
            }
        }

        [Test]
        public void TestSearchUnauthorized()
        {
            MockFromFile("products.search.unauthorized");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);
            service.User = "";
            service.Password = "";

            Assert.ThrowsAsync<ServiceException>(
                () => service.Search().Pin("AD8CCDD5F9").Area("work").Q("toner").Skip(0).Take(30).Do());
        }
    }
}