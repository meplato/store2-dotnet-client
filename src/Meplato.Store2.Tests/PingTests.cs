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

namespace Meplato.Store2.Tests
{
    [TestFixture]
    public class PingTests : TestCase
    {
        [Test]
        public async void TestPing()
        {
            MockFromFile("ping.success");
            var service = GetRootService();
            Assert.IsNotNull(service);
            service.Ping().Do();
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Unauthorized")]
        public async void TestPingUnauthorized()
        {
            //MockFromFile("ping.unauthorized");
            Mock(new Response(401, "{\"error\":{\"message\":\"Unauthorized\"}}"));

            var service = GetRootService();
            service.User = "";
            service.Password = "";
            service.Ping().Do();
        }

        [Test]
        [ExpectedException(typeof (ServiceException), ExpectedMessage = "Request failed")]
        public async void TestPingInternalError()
        {
            MockFromFile("ping.internal_error");

            var service = GetRootService();
            service.User = "";
            service.Password = "";
            service.Ping().Do();
        }
    }
}