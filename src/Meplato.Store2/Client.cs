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

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Resta.UriTemplates;

namespace Meplato.Store2
{
    /// <summary>
    ///     Client implements <see cref="IClient" /> with System.Net.Http and JSON.Net.
    /// </summary>
    public class Client : IClient
    {
        /// <summary>
        ///     User Agent for .NET Clients.
        /// </summary>
        public const string UserAgent = "meplato-api-csharp-client/2.0.0";

        /// <summary>
        ///     Execute runs a HTTP request/response with the API endpoint.
        /// </summary>
        /// <typeparam name="T">Expected result type</typeparam>
        /// <param name="method">HTTP method, e.g. POST or GET</param>
        /// <param name="uriTemplate">URI Template as of RFC 6570</param>
        /// <param name="parameters">Query String Parameters</param>
        /// <param name="headers">Headers key/value pairs</param>
        /// <param name="body">Body</param>
        /// <returns>A <see cref="Task{T}" /> with an <see cref="IResponse" /></returns>
        /// <exception cref="ServiceException">A <see cref="ServiceException" /> is thrown if something goes wrong.</exception>
        public async Task<IResponse> Execute(HttpMethod method, string uriTemplate,
            IDictionary<string, object> parameters,
            IDictionary<string, string> headers, object body)
        {
            var template = new UriTemplate(uriTemplate);
            var url = template.Resolve(parameters);

            using (var client = new HttpClient())
            {
                // Always use application/json
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Always add a User-Agent
                var request = new HttpRequestMessage(method, url);
                request.Headers.Add("User-Agent", UserAgent);
                foreach (var kv in headers)
                    request.Headers.Add(kv.Key, kv.Value);
                if (body != null)
                {
                    var content = body is string ? (string) body : JsonConvert.SerializeObject(body);
                    request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                }

                // Perform HTTP request and wrap response in IResponse
                try
                {
                    var httpResponse = await client.SendAsync(request);
                    var response = new Response(httpResponse);

                    if (httpResponse.IsSuccessStatusCode)
                        return response;

                    throw ServiceException.FromResponse(response);
                }
                catch (ServiceException)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new ServiceException("Request failed", null, e);
                }
            }
        }
    }
}