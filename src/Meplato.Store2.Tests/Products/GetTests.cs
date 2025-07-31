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
    public class GetTests : TestCase
    {
        [Test]
        public async Task TestGet()
        {
            MockFromFile("products.get.success");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            var product = await service.Get().Pin("AD8CCDD5F9").Area("work").Spn("50763599").Do();
            Assert.That(product, Is.Not.Null);
            Assert.That(product.Id, Is.Not.Null);
            Assert.That(product.Id, Is.Not.Empty);
            Assert.That(product.Spn, Is.Not.Null);
            Assert.That(product.Spn, Is.Not.Null);
            Assert.That(product.Name, Is.Not.Null);
            Assert.That(product.Name, Is.Not.Empty);
            Assert.That(product.Price, Is.GreaterThan(0.0));
            Assert.That(product.OrderUnit, Is.Not.Null);
            Assert.That(product.OrderUnit, Is.Not.Null);
            Assert.That(product.Created, Is.Not.Null);
            Assert.That(product.Updated, Is.Not.Null);

            Assert.That(product.Conditions, Is.Not.Null);
            Assert.That(1,Is.EqualTo(product.Conditions.Length));
            Assert.That("new_product", Is.EqualTo(product.Conditions[0].Kind));


            Assert.That(product.CustFields, Is.Not.Null);
            Assert.That(1, Is.EqualTo(product.CustFields.Length));
            Assert.That("Steuersatz", Is.EqualTo(product.CustFields[0].Name));
            Assert.That("19%", Is.EqualTo(product.CustFields[0].Value));

            Assert.That(product.Blobs, Is.Not.Null);
            Assert.That(1, Is.EqualTo(product.Blobs.Length));
            Assert.That("normal", Is.EqualTo(product.Blobs[0].Kind));
            Assert.That("Normalbild", Is.EqualTo(product.Blobs[0].Text));
            Assert.That("50763599.jpg", Is.EqualTo(product.Blobs[0].Source));
            Assert.That(product.Blobs[0].Language,Is.Null);
        }

        [Test]
        public void TestGetNotFound()
        {
            MockFromFile("products.get.not_found");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            Assert.ThrowsAsync<ServiceException>(
                () => service.Get().Pin("AD8CCDD5F9").Area("work").Spn("no-such-product").Do());
        }

        [Test]
        public void TestGetUnauthorized()
        {
            MockFromFile("products.get.unauthorized");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);
            service.User = "";
            service.Password = "";

            Assert.ThrowsAsync<ServiceException>(
                () => service.Get().Pin("AD8CCDD5F9").Area("work").Spn("no-such-product").Do());
        }
    }
}