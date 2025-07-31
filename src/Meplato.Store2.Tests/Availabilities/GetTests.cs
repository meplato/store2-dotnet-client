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

namespace Meplato.Store2.Tests.Availabilities
{
    [TestFixture]
    public class GetTests : TestCase
    {
        [Test]
        public async Task TestGet()
        {
            MockFromFile("availabilities.get.success");

            var service = GetAvailabilitiesService();
            Assert.That(service, Is.Not.Null);

            var response = await service.Get().Spn("1234").Do();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Kind, Is.Not.Null);
            Assert.That("store#availabilities/getResponse", Is.EqualTo(response.Kind));
            Assert.That(response.Items, Is.Not.Null);
            foreach (var availability in response.Items)
            {
                Assert.That("1234", Is.EqualTo(availability.Spn));
            }
        }

        [Test]
        public async Task TestGetNotFound()
        {
            MockFromFile("availabilities.get.not_found");

            var service = GetAvailabilitiesService();
            Assert.That(service, Is.Not.Null);

            var response = await service.Get().Spn("no-such-product").Do();
            Assert.That(response, Is.Not.Null);
            Assert.That(response.Kind, Is.Not.Null);
            Assert.That("store#availabilities/getResponse", Is.EqualTo(response.Kind));
            Assert.That(response.Items, Is.Null);
        }
    }
}