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
using Meplato.Store2.Products;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class UpdateTests : TestCase
    {
        [Test]
        public async Task TestUpdate()
        {
            MockFromFile("products.update.success");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            var update = new UpdateProduct
            {
                Name = "Produkt 1000 (NEU!)",
                Price = 2.50,
                OrderUnit = "PCE"
            };

            var response = await service.Update().Pin("AD8CCDD5F9").Area("work").Spn("MBA").Product(update).Do();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Link, Is.Not.Null);
            Assert.That(response.Link, Is.Not.Empty);
            Assert.That("store#productsUpdateResponse", Is.EqualTo(response.Kind));
        }

        [Test]
        public void TestJsonSerialization()
        {
            // attributes which are not set are not serialized
            {
                var update = new UpdateProduct
                {
                    Name = "Produkt 1000 (NEU!)",
                    Price = 2.99,
                    OrderUnit = "PCE",
                    CustomField12 = "37751543"
                };
                var expected = "{\"customField12\":\"37751543\",\"name\":\"Produkt 1000 (NEU!)\",\"ou\":\"PCE\",\"price\":2.99}";
                Assert.That(expected, Is.EqualTo(JsonConvert.SerializeObject(update)));
            }
            // attributes explicitly set to null are serialized unlike omitted ones
            {
                var update = new UpdateProduct
                {
                    Price = 45.29,
                    OrderUnit = "C62",
                    // reset current value
                    QuantityMin = null,
                    QuantityMax = null,
                };
                var expected = "{\"ou\":\"C62\",\"price\":45.29,\"quantityMax\":null,\"quantityMin\":null}";
                Assert.That(expected, Is.EqualTo(JsonConvert.SerializeObject(update)));
            }
        }

    }
}