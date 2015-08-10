﻿#region Copyright and terms of services

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

using Meplato.Store2.Products;
using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class ReplaceTests : TestCase
    {
        [Test]
        public async void TestReplace()
        {
            MockFromFile("products.replace.success");

            var service = GetProductsService();
            Assert.NotNull(service);

            var replace = new ReplaceProduct
            {
                Name = "MacBook Air 11in (NEU!)",
                Price = 1225.50,
                OrderUnit = "PCE"
            };

            var response = await service.Replace().Pin("AD8CCDD5F9").Area("work").Id("1000@12").Product(replace).Do();
            Assert.NotNull(response);
            Assert.IsNotNullOrEmpty(response.Link);
            Assert.IsNotNullOrEmpty(response.Id);
        }
    }
}