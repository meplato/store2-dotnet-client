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

using System.Net.Http;
using NUnit.Framework;

namespace Meplato.Store2.Tests
{
    [TestFixture]
    public class MockClientTests : TestCase
    {
        [Test]
        public async void TestExecuteSuccess()
        {
            var client = new MockClient
            {
                Exception = null,
                Response = new Response(200, "{}")
            };

            var response = await client.Execute(HttpMethod.Get, "http://localhost/", null, null, null);
            Assert.NotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("{}", response.GetBodyString());
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Exception raised")]
        public async void TestExecuteThrowsFromException()
        {
            var client = new MockClient
            {
                Exception = new ServiceException("Exception raised", null, null),
                Response = new Response(200, "{\"error\":{\"message\":\"Something went wrong\"}}")
            };

            var response = await client.Execute(HttpMethod.Get, "http://localhost/", null, null, null);
            Assert.NotNull(response);
            Assert.AreEqual(200, response.StatusCode);
            Assert.AreEqual("{\"error\":{\"message\":\"Something went wrong\"}}", response.GetBodyString());
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Something went wrong")]
        public async void TestExecuteThrowsFromResponse()
        {
            var client = new MockClient
            {
                Exception = null,
                Response = new Response(500, "{\"error\":{\"message\":\"Something went wrong\"}}")
            };

            var response = await client.Execute(HttpMethod.Get, "http://localhost/", null, null, null);
            Assert.NotNull(response);
            Assert.AreEqual(500, response.StatusCode);
            Assert.AreEqual("{\"error\":{\"message\":\"Something went wrong\"}}", response.GetBodyString());
        }
    }
}