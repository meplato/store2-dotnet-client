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
    public class DeleteTests : TestCase
    {
        [Test]
        public async void TestDelete()
        {
            MockFromFile("products.delete.success");

            var service = GetProductsService();
            Assert.NotNull(service);

            service.Delete().Pin("AD8CCDD5F9").Area("work").Spn("50763599").Do();
        }

        [Test]
        [ExpectedException(typeof(ServiceException), ExpectedMessage = "Product not found")]
        public async void TestGetNotFound()
        {
            MockFromFile("products.delete.not_found");

            var service = GetProductsService();
            Assert.NotNull(service);

            service.Delete().Pin("AD8CCDD5F9").Area("work").Spn("no-such-product").Do();
        }
    }
}