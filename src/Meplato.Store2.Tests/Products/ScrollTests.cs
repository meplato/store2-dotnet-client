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
    public class ScrollTests : TestCase
    {
        [Test]
        public async Task ScrollUpdate()
        {
            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            MockFromFile("products.scroll.success.1");
            var response = await service.Scroll().Pin("AD8CCDD5F9").Area("work").Do();
            Assert.That(response, Is.Not.Null);
            Assert.That("store#products", Is.EqualTo(response.Kind));
            Assert.That(response.PageToken, Is.Not.Null);
            Assert.That(response.PageToken, Is.Not.Empty);
            var pageToken = response.PageToken;
            Assert.That(response.TotalItems > 0, Is.EqualTo(true));
            if (response.Items != null)
                foreach (var product in response.Items)
                {
                    Assert.That(product, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Null);
                    Assert.That(product.Kind, Is.Not.Null);
                    Assert.That(product.Kind, Is.Not.Null);
                    Assert.That(product.SelfLink, Is.Not.Null);
                    Assert.That(product.SelfLink, Is.Not.Empty);
                    Assert.That(product.Spn, Is.Not.Null);
                    Assert.That(product.Spn, Is.Not.Empty);
                    Assert.That(product.Name, Is.Not.Null);
                    Assert.That(product.Name, Is.Not.Empty);
                    Assert.That(product.OrderUnit, Is.Not.Null);
                    Assert.That(product.OrderUnit, Is.Not.Empty);
                    Assert.That(product.Price > 0, Is.EqualTo(true));
                    Assert.That(product.Created, Is.Not.Null);
                    Assert.That(product.Updated, Is.Not.Null);
                }

            MockFromFile("products.scroll.success.2");
            response = await service.Scroll().Pin("AD8CCDD5F9").Area("work").PageToken(pageToken).Do();
            Assert.That(response, Is.Not.Null);
            Assert.That("store#products", Is.EqualTo(response.Kind));
            Assert.That(response.PageToken, Is.Not.Null);
            Assert.That(response.PageToken, Is.Not.Empty);
            Assert.That(response.TotalItems > 0, Is.EqualTo(true));
            Assert.That(response.Items, Is.Not.Null);
            if (response.Items != null)
                foreach (var product in response.Items)
                {
                    Assert.That(product, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Empty);
                    Assert.That(product.Kind, Is.Not.Null);
                    Assert.That(product.Kind, Is.Not.Empty);
                    Assert.That(product.SelfLink, Is.Not.Null);
                    Assert.That(product.SelfLink, Is.Not.Empty);
                    Assert.That(product.Spn, Is.Not.Null);
                    Assert.That(product.Spn, Is.Not.Empty);
                    Assert.That(product.Name, Is.Not.Null);
                    Assert.That(product.Name, Is.Not.Empty);
                    Assert.That(product.OrderUnit, Is.Not.Null);
                    Assert.That(product.OrderUnit, Is.Not.Empty);
                    Assert.That(product.Price > 0, Is.EqualTo(true));
                    Assert.That(product.Created, Is.Not.Null);
                    Assert.That(product.Updated, Is.Not.Null);
                }
        }
        
        [Test]
        public async Task ScrollDifferentialUpdate()
        {
            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            MockFromFile("products.scroll.differential.success");
            var response = await service.Scroll().Pin("AD8CCDD5F9").Area("work").Version(3).Mode("diff").Do();
            Assert.That(response, Is.Not.Null);
            Assert.That("store#products", Is.EqualTo(response.Kind));
            Assert.That(response.PageToken,Is.Not.Null);
            Assert.That(response.PageToken, Is.Not.Null);
            Assert.That(response.TotalItems > 0,Is.EqualTo(true));
            if (response.Items != null)
                foreach (var product in response.Items)
                {
                    Assert.That(product, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Null);
                    Assert.That(product.Id, Is.Not.Empty);
                    Assert.That(product.Kind, Is.Not.Null);
                    Assert.That(product.Kind, Is.Not.Empty);
                    Assert.That(product.SelfLink, Is.Not.Null);
                    Assert.That(product.SelfLink, Is.Not.Empty);
                    Assert.That(product.Spn, Is.Not.Null);
                    Assert.That(product.Spn, Is.Not.Empty);
                    Assert.That(product.Mode, Is.Not.Null);
                    Assert.That(product.Mode, Is.Not.Empty);
                    Assert.That(product.Created, Is.Not.Null);
                    Assert.That(product.Updated, Is.Not.Null);
                }
        }
    }
}