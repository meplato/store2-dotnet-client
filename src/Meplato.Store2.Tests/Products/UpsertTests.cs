﻿#region Copyright and terms of services

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
using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class UpsertTests : TestCase
    {
        [Test]
        public async Task TestUpsert()
        {
            MockFromFile("products.upsert.success");

            var service = GetProductsService();
            Assert.That(service, Is.Not.Null);

            var data = new UpsertProduct
            {
                Spn = "1000",
                Name = "Produkt 1000",
                Price = 4.99,
                OrderUnit = "PCE"
            };

            var response = await service.Upsert().Pin("AD8CCDD5F9").Area("work").Product(data).Do();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Link, Is.Not.Null);
            Assert.That(response.Link, Is.Not.Empty);
            Assert.That("store#productsUpsertResponse", Is.EqualTo(response.Kind));
        }
    }
}