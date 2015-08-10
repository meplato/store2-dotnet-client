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

using NUnit.Framework;

namespace Meplato.Store2.Tests.Products
{
    [TestFixture]
    public class ScrollTests : TestCase
    {
        [Test]
        public async void ScrollUpdate()
        {
            var service = GetProductsService();
            Assert.NotNull(service);

            MockFromFile("products.scroll.success.1");
            var response = await service.Scroll().Pin("AD8CCDD5F9").Area("work").Do();
            Assert.NotNull(response);
            Assert.AreEqual("store#products", response.Kind);
            Assert.IsNotNullOrEmpty(response.PageToken);
            var pageToken = response.PageToken;
            Assert.IsTrue(response.TotalItems > 0);
            if (response.Items != null)
            {
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

            MockFromFile("products.scroll.success.2");
            response = await service.Scroll().Pin("AD8CCDD5F9").Area("work").PageToken(pageToken).Do();
            Assert.NotNull(response);
            Assert.AreEqual("store#products", response.Kind);
            Assert.IsNotNullOrEmpty(response.PageToken);
            Assert.IsTrue(response.TotalItems > 0);
            Assert.NotNull(response.Items);
            if (response.Items != null)
            {
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
        }
    }
}