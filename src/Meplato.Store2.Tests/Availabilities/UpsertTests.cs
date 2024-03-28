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
using Meplato.Store2.Availabilities;
using NUnit.Framework;

namespace Meplato.Store2.Tests.Availabilities
{
    [TestFixture]
    public class UpsertTests : TestCase
    {
        [Test]
        public async Task TestUpsert()
        {
            MockFromFile("availabilities.upsert.success");

            var service = GetAvailabilitiesService();
            Assert.NotNull(service);

            var data = new UpsertRequest
            {
                Message = "not in stock",
                Quantity = 0,
                Updated = "Q1/2024",
                Region = "AQ",
				ZipCode = "1234"
            };

            var response = await service.Upsert().Spn("1234").Availability(data).Do();
            Assert.NotNull(response);
            Assert.IsNotNull(response.Kind);
            Assert.AreEqual("store#availabilities/upsertResponse", response.Kind);
            Assert.IsNotNull(response.Link);
        }
    }
}