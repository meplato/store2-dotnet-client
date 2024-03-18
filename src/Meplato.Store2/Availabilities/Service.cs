#region Copyright and terms of services
// Copyright (c) 2013-present Meplato GmbH.
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

// THIS FILE IS AUTO-GENERATED. DO NOT MODIFY!

// The file implements the Meplato Store API.
//
// Author:  Meplato API Team <support@meplato.com>
// Version: 2.2.0
// License: Copyright (c) 2015-2023 Meplato GmbH. All rights reserved.
// See <a href="https://developer.meplato.com/store2/#terms">Terms of Service</a>
// See <a href="https://developer.meplato.com/store2/">External documentation</a>

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Meplato.Store2;

namespace Meplato.Store2.Availabilities
{
	/// <summary>
	///     The Meplato Store API enables technical integration of
	///     customers and partners. 
	/// </summary>
	public class Service
	{
		#region Service
		public const string Title = "Meplato Store API";
		public const string Version = "2.2.0";
		public const string UserAgent = "meplato-csharp-client/2.0";
		public const string DefaultBaseURL = "https://store.meplato.com/api/v2";

		/// <summary>
		///     Initializes a new <see cref="Service"/>.
		/// </summary>
		/// <param name="client">Client to use for requests</param>
		public Service(IClient client)
		{
			Client = client;
			BaseURL = DefaultBaseURL;
		}

		/// <summary>
		///     Returns the <see cref="IClient"/> to perform requests.
		/// </summary>
		public IClient Client { get; private set; }

		/// <summary>
		///     Represents the BaseURL to use for requests (default is <see
		///     cref="DefaultBaseURL"/>).
		/// </summary>
		public string BaseURL { get; set; }

		/// <summary>
		///     Specifies the username to authenticate requests.
		/// </summary>
		public string User { get; set; }

		/// <summary>
		///     Specifies the password to authenticate requests.
		/// </summary>
		public string Password { get; set; }

		/// <summary>
		///     Returns the authentication header for HTTP Basic Author
		///     <code>null</code> for unauthenticated requests.
		/// </summary>
		public string GetAuthorizationHeader()
		{
			if (!string.IsNullOrEmpty(User) || !string.IsNullOrEmpty(Password))
			{
				string userPass = "";
				if (!string.IsNullOrEmpty(User))
				{
					userPass = User;
				}
				userPass = userPass + ":";
				if (!string.IsNullOrEmpty(Password))
				{
					userPass = userPass + Password;
				}
				var bytes = Encoding.UTF8.GetBytes(userPass);
				var credentials = Convert.ToBase64String(bytes);
				return "Basic " + credentials;
			}
			return null;
		}

		/// <summary>
		///     Delete availability information of a product. It is an
		///     asynchronous operation.
		/// </summary>
		public DeleteService Delete() {
			return new DeleteService(this);
		}

		/// <summary>
		///     Read availability information of a product
		/// </summary>
		public GetService Get() {
			return new GetService(this);
		}

		/// <summary>
		///     Update or create availability information of a product. It is
		///     an asynchronous operation.
		/// </summary>
		public UpsertService Upsert() {
			return new UpsertService(this);
		}
		#endregion // Service
	}

	/// <summary>
	///     Availability information of a product in a location
	/// </summary>
	public class Availability
	{
		#region Availability

		/// <summary>
		///     Contains the stock state description; i.e. in stock; out of
		///     stock; limited availability; on display to order
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		///     Unique internal identifier of the merchant
		/// </summary>
		[JsonProperty("mpcc")]
		public string Mpcc { get; set; }

		/// <summary>
		///     Reflects the amount of items available
		/// </summary>
		[JsonProperty("quantity")]
		public double? Quantity { get; set; }

		/// <summary>
		///     2-letter ISO code of the country/region where the product is
		///     stored
		/// </summary>
		[JsonProperty("region")]
		public string Region { get; set; }

		/// <summary>
		///     Merchant's unique identifier of a product
		/// </summary>
		[JsonProperty("spn")]
		public string Spn { get; set; }

		/// <summary>
		///     Update date given by the merchant i.e. Q4/2022, 2022/10/12
		/// </summary>
		[JsonProperty("updated")]
		public string Updated { get; set; }

		/// <summary>
		///     Zip code where the product is stored
		/// </summary>
		[JsonProperty("zipCode")]
		public string ZipCode { get; set; }

		#endregion // Availability
	}

	/// <summary>
	///     DeleteResponse is the outcome of a successful request to delete
	///     an availability.
	/// </summary>
	public class DeleteResponse
	{
		#region DeleteResponse

		/// <summary>
		///     Kind describes this entity, it will be
		///     store#availability/deleteResponse.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		#endregion // DeleteResponse
	}

	/// <summary>
	///     GetResponse is the collection of availability information for
	///     an SPN.
	/// </summary>
	public class GetResponse
	{
		#region GetResponse

		/// <summary>
		///     Collection of availability information associated with an SPN
		///     for a merchant.
		/// </summary>
		[JsonProperty("items")]
		public Availability[] Items { get; set; }

		/// <summary>
		///     Kind is store#availability/getResponse for this kind of
		///     response.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		#endregion // GetResponse
	}

	/// <summary>
	///     UpsertRequest holds the properties of the availability
	///     information to create or update.
	/// </summary>
	public class UpsertRequest
	{
		#region UpsertRequest

		/// <summary>
		///     Contains the stock state description; i.e. in stock; out of
		///     stock; limited availability; on display to order
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		///     Unique internal identifier of the merchant (optional)
		/// </summary>
		[JsonProperty("mpcc")]
		public string Mpcc { get; set; }

		/// <summary>
		///     Reflects the amount of items available
		/// </summary>
		[JsonProperty("quantity")]
		public double? Quantity { get; set; }

		/// <summary>
		///     2-letter ISO code of the country/region where the product is
		///     stored
		/// </summary>
		[JsonProperty("region")]
		public string Region { get; set; }

		/// <summary>
		///     Update date given by the merchant i.e. Q4/2022, 2022/10/12
		/// </summary>
		[JsonProperty("updated")]
		public string Updated { get; set; }

		/// <summary>
		///     Zip code where the product is stored
		/// </summary>
		[JsonProperty("zipCode")]
		public string ZipCode { get; set; }

		#endregion // UpsertRequest
	}

	/// <summary>
	///     UpsertResponse is the outcome of a successful request to upsert
	///     an availability.
	/// </summary>
	public class UpsertResponse
	{
		#region UpsertResponse

		/// <summary>
		///     Kind describes this entity, it will be
		///     store#availability/upsertResponse.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Link includes the URL where this resource will be available
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		#endregion // UpsertResponse
	}

	/// <summary>
	///     DeleteService: Delete availability information of a product. It
	///     is an asynchronous operation.
	/// </summary>
	public class DeleteService
	{
		#region DeleteService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _spn;

		/// <summary>
		///     Creates a new instance of DeleteService.
		/// </summary>
		public DeleteService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     2-letter ISO code of the country/region where the product is
		///     stored
		/// </summary>
		public DeleteService Region(string region)
		{
			_opt["region"] = region;
			return this;
		}

		/// <summary>
		///     SPN is the unique identifier of a product within a merchant.
		/// </summary>
		public DeleteService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Zip code where the product is stored
		/// </summary>
		public DeleteService ZipCode(string zipCode)
		{
			_opt["zipCode"] = zipCode;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<DeleteResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			if (_opt.ContainsKey("region"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["region"] = string.Format("{0}", _opt["region"]);
			}
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);
			if (_opt.ContainsKey("zipCode"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["zipCode"] = string.Format("{0}", _opt["zipCode"]);
			}

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/products/{spn}/availabilities{?region,zipCode}";
			var response = await _service.Client.Execute(
				HttpMethod.Delete,
				uriTemplate,
				parameters,
				headers,
				null);
			return response.GetBodyJSON<DeleteResponse>();
		}

		#endregion // DeleteService
	}

	/// <summary>
	///     GetService: Read availability information of a product
	/// </summary>
	public class GetService
	{
		#region GetService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _spn;

		/// <summary>
		///     Creates a new instance of GetService.
		/// </summary>
		public GetService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     2-letter ISO code of the country/region where the product is
		///     stored
		/// </summary>
		public GetService Region(string region)
		{
			_opt["region"] = region;
			return this;
		}

		/// <summary>
		///     SPN is the unique identifier of a product within a merchant.
		/// </summary>
		public GetService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Zip code where the product is stored
		/// </summary>
		public GetService ZipCode(string zipCode)
		{
			_opt["zipCode"] = zipCode;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<GetResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			if (_opt.ContainsKey("region"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["region"] = string.Format("{0}", _opt["region"]);
			}
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);
			if (_opt.ContainsKey("zipCode"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["zipCode"] = string.Format("{0}", _opt["zipCode"]);
			}

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/products/{spn}/availabilities{?region,zipCode}";
			var response = await _service.Client.Execute(
				HttpMethod.Get,
				uriTemplate,
				parameters,
				headers,
				null);
			return response.GetBodyJSON<GetResponse>();
		}

		#endregion // GetService
	}

	/// <summary>
	///     UpsertService: Update or create availability information of a
	///     product. It is an asynchronous operation.
	/// </summary>
	public class UpsertService
	{
		#region UpsertService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _spn;
		private UpsertRequest _availability;

		/// <summary>
		///     Creates a new instance of UpsertService.
		/// </summary>
		public UpsertService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Availability properties of the product.
		/// </summary>
		public UpsertService Availability(UpsertRequest availability)
		{
			_availability = availability;
			return this;
		}

		/// <summary>
		///     SPN is the unique identifier of a product within a merchant.
		/// </summary>
		public UpsertService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<UpsertResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/products/{spn}/availabilities";
			var response = await _service.Client.Execute(
				HttpMethod.Post,
				uriTemplate,
				parameters,
				headers,
				_availability);
			return response.GetBodyJSON<UpsertResponse>();
		}

		#endregion // UpsertService
	}
}

