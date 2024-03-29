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
// Version: 2.1.9
// License: Copyright (c) 2015-2020 Meplato GmbH. All rights reserved.
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

namespace Meplato.Store2.Products
{
	/// <summary>
	///     The Meplato Store API enables technical integration of
	///     customers and partners. 
	/// </summary>
	public class Service
	{
		#region Service
		public const string Title = "Meplato Store API";
		public const string Version = "2.1.9";
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
		///     Create a new product in the given catalog and area.
		/// </summary>
		public CreateService Create() {
			return new CreateService(this);
		}

		/// <summary>
		///     Delete a product.
		/// </summary>
		public DeleteService Delete() {
			return new DeleteService(this);
		}

		/// <summary>
		///     Get returns a single product by its Supplier Part Number (SPN).
		/// </summary>
		public GetService Get() {
			return new GetService(this);
		}

		/// <summary>
		///     Replace all fields of a product. Use Update to update only
		///     certain fields of a product.
		/// </summary>
		public ReplaceService Replace() {
			return new ReplaceService(this);
		}

		/// <summary>
		///     Scroll through products of a catalog (area). If you need to
		///     iterate through all products in a catalog, this is the most
		///     effective way to do so. If you want to search for products, use
		///     the Search endpoint. 
		/// </summary>
		public ScrollService Scroll() {
			return new ScrollService(this);
		}

		/// <summary>
		///     Search for products. Do not use this method for iterating
		///     through all of the products in a catalog; use the Scroll
		///     endpoint instead. It is much more efficient. 
		/// </summary>
		public SearchService Search() {
			return new SearchService(this);
		}

		/// <summary>
		///     Update the fields of a product selectively. Use Replace to
		///     replace the product as a whole.
		/// </summary>
		public UpdateService Update() {
			return new UpdateService(this);
		}

		/// <summary>
		///     Upsert a product in the given catalog and area. Upsert will
		///     create if the product does not exist yet, otherwise it will
		///     update.
		/// </summary>
		public UpsertService Upsert() {
			return new UpsertService(this);
		}
		#endregion // Service
	}

	/// <summary>
	///     Availability details product availability.
	/// </summary>
	public class Availability
	{
		#region Availability

		/// <summary>
		///     Message gives a textual description of the availability
		///     message, e.g. "in stock", "out of stock", "limited
		///     availability", or "on display to order". 
		/// </summary>
		[JsonProperty("message")]
		public string Message { get; set; }

		/// <summary>
		///     Qty describes the quantity for certain kinds of availability
		///     messages. E.g. you can indicate the number of items in stock. 
		/// </summary>
		[JsonProperty("qty")]
		public double? Qty { get; set; }

		/// <summary>
		///     Updated indicates when the availability message has been last
		///     updated. 
		/// </summary>
		[JsonProperty("updated")]
		public string Updated { get; set; }

		#endregion // Availability
	}

	/// <summary>
	///     Blob describes external product data, e.g. an image or a
	///     datasheet.
	/// </summary>
	public class Blob
	{
		#region Blob

		/// <summary>
		///     Kind describes the type of blob, e.g. image, detail, thumbnail,
		///     datasheet, or safetysheet.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Language indicates the language of the blob, e.g. the language
		///     of a datasheet.
		/// </summary>
		[JsonProperty("lang")]
		public string Language { get; set; }

		/// <summary>
		///     Source is either a (relative) file name or a URL.
		/// </summary>
		[JsonProperty("source")]
		public string Source { get; set; }

		/// <summary>
		///     Text gives a textual description the blob.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		/// <summary>
		///     URL is the URL to the blob.
		/// </summary>
		[JsonProperty("url")]
		public string Url { get; set; }

		#endregion // Blob
	}

	/// <summary>
	///     Condition describes a product status, e.g. refurbished or used.
	/// </summary>
	public class Condition
	{
		#region Condition

		/// <summary>
		///     Kind describes the condition, e.g. bargain, new_product,
		///     old_product, new, used, refurbished, or core_product.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Text gives a textual description of the condition.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		#endregion // Condition
	}

	/// <summary>
	///     CreateProduct holds the properties of a new product.
	/// </summary>
	public class CreateProduct
	{
		#region CreateProduct

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		[JsonProperty("asin")]
		public string Asin { get; set; }

		/// <summary>
		///     AutoConfigure is a flag that indicates whether this product can
		///     be configured automatically. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("autoConfigure")]
		public bool? AutoConfigure { get; set; }

		/// <summary>
		///     Availability allows the update of product availability data,
		///     e.g. the number of items in stock or the date when the product
		///     will be available again. 
		/// </summary>
		[JsonProperty("availability")]
		public Availability Availability { get; set; }

		/// <summary>
		///     Blobs specifies external data, e.g. images or datasheets.
		/// </summary>
		[JsonProperty("blobs")]
		public Blob[] Blobs { get; set; }

		/// <summary>
		///     BoostFactor represents a positive or negative boost for the
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("boostFactor")]
		public double? BoostFactor { get; set; }

		/// <summary>
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

		/// <summary>
		///     Brand is the commercial brand name of the product (i.e.
		///     end-consumer recognizable brand name)
		/// </summary>
		[JsonProperty("brand")]
		public string Brand { get; set; }

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		[JsonProperty("catalogManaged")]
		public bool CatalogManaged { get; set; }

		/// <summary>
		///     Categories is a list of (supplier-specific) category names the
		///     product belongs to.
		/// </summary>
		[JsonProperty("categories")]
		public string[] Categories { get; set; }

		/// <summary>
		///     Conditions describes the product conditions, e.g. refurbished
		///     or used.
		/// </summary>
		[JsonProperty("conditions")]
		public Condition[] Conditions { get; set; }

		/// <summary>
		///     Contract represents the contract number to be used when
		///     purchasing this product. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("contract")]
		public string Contract { get; set; }

		/// <summary>
		///     ContractItem represents line number in the contract to be used
		///     when purchasing this product. See also Contract. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("contractItem")]
		public string ContractItem { get; set; }

		/// <summary>
		///     ConversionDenumerator is the denumerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionDenumerator")]
		public double? ConversionDenumerator { get; set; }

		/// <summary>
		///     ConversionNumerator is the numerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionNumerator")]
		public double? ConversionNumerator { get; set; }

		/// <summary>
		///     Country/Region represents the ISO code of the country/region of
		///     origin, i.e. the country/region where the product has been
		///     created/produced, e.g. DE. If unspecified, the field is
		///     initialized with the catalog's country/region field. 
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		///     ContentUnit is the content unit of the product, a 3-character
		///     ISO code (usually project-specific).
		/// </summary>
		[JsonProperty("cu")]
		public string ContentUnit { get; set; }

		/// <summary>
		///     CuPerOu describes the number of content units per order unit,
		///     e.g. the 12 in '1 case contains 12 bottles'.
		/// </summary>
		[JsonProperty("cuPerOu")]
		public double? CuPerOu { get; set; }

		/// <summary>
		///     Currency is the ISO currency code for the prices, e.g. EUR or
		///     GBP. If you pass an empty currency code, it will be initialized
		///     with the catalog's currency. 
		/// </summary>
		[JsonProperty("currency")]
		public string Currency { get; set; }

		/// <summary>
		///     CustField1 is the CUST_FIELD1 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField1")]
		public string CustField1 { get; set; }

		/// <summary>
		///     CustField2 is the CUST_FIELD2 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField2")]
		public string CustField2 { get; set; }

		/// <summary>
		///     CustField3 is the CUST_FIELD3 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField3")]
		public string CustField3 { get; set; }

		/// <summary>
		///     CustField4 is the CUST_FIELD4 of the SAP OCI specification. It
		///     has a maximum length of 20 characters. 
		/// </summary>
		[JsonProperty("custField4")]
		public string CustField4 { get; set; }

		/// <summary>
		///     CustField5 is the CUST_FIELD5 of the SAP OCI specification. It
		///     has a maximum length of 50 characters. 
		/// </summary>
		[JsonProperty("custField5")]
		public string CustField5 { get; set; }

		/// <summary>
		///     CustFields is an array of generic name/value pairs for
		///     customer-specific attributes.
		/// </summary>
		[JsonProperty("custFields")]
		public CustField[] CustFields { get; set; }

		/// <summary>
		///     CustomField10 represents the 10th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField10")]
		public string CustomField10 { get; set; }

		/// <summary>
		///     CustomField11 represents the 11th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField11")]
		public string CustomField11 { get; set; }

		/// <summary>
		///     CustomField12 represents the 12th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField12")]
		public string CustomField12 { get; set; }

		/// <summary>
		///     CustomField13 represents the 13th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField13")]
		public string CustomField13 { get; set; }

		/// <summary>
		///     CustomField14 represents the 14th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField14")]
		public string CustomField14 { get; set; }

		/// <summary>
		///     CustomField15 represents the 15th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField15")]
		public string CustomField15 { get; set; }

		/// <summary>
		///     CustomField16 represents the 16th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField16")]
		public string CustomField16 { get; set; }

		/// <summary>
		///     CustomField17 represents the 17th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField17")]
		public string CustomField17 { get; set; }

		/// <summary>
		///     CustomField18 represents the 18th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField18")]
		public string CustomField18 { get; set; }

		/// <summary>
		///     CustomField19 represents the 19th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField19")]
		public string CustomField19 { get; set; }

		/// <summary>
		///     CustomField20 represents the 20th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField20")]
		public string CustomField20 { get; set; }

		/// <summary>
		///     CustomField21 represents the 21st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField21")]
		public string CustomField21 { get; set; }

		/// <summary>
		///     CustomField22 represents the 22nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField22")]
		public string CustomField22 { get; set; }

		/// <summary>
		///     CustomField23 represents the 23rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField23")]
		public string CustomField23 { get; set; }

		/// <summary>
		///     CustomField24 represents the 24th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField24")]
		public string CustomField24 { get; set; }

		/// <summary>
		///     CustomField25 represents the 25th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField25")]
		public string CustomField25 { get; set; }

		/// <summary>
		///     CustomField26 represents the 26th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField26")]
		public string CustomField26 { get; set; }

		/// <summary>
		///     CustomField27 represents the 27th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField27")]
		public string CustomField27 { get; set; }

		/// <summary>
		///     CustomField28 represents the 28th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField28")]
		public string CustomField28 { get; set; }

		/// <summary>
		///     CustomField29 represents the 29th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField29")]
		public string CustomField29 { get; set; }

		/// <summary>
		///     CustomField30 represents the 30th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField30")]
		public string CustomField30 { get; set; }

		/// <summary>
		///     CustomField31 represents the 31st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField31")]
		public string CustomField31 { get; set; }

		/// <summary>
		///     CustomField32 represents the 32nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField32")]
		public string CustomField32 { get; set; }

		/// <summary>
		///     CustomField33 represents the 33rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField33")]
		public string CustomField33 { get; set; }

		/// <summary>
		///     CustomField34 represents the 34th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField34")]
		public string CustomField34 { get; set; }

		/// <summary>
		///     CustomField35 represents the 35th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField35")]
		public string CustomField35 { get; set; }

		/// <summary>
		///     CustomField36 represents the 36th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField36")]
		public string CustomField36 { get; set; }

		/// <summary>
		///     CustomField37 represents the 37th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField37")]
		public string CustomField37 { get; set; }

		/// <summary>
		///     CustomField38 represents the 38th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField38")]
		public string CustomField38 { get; set; }

		/// <summary>
		///     CustomField39 represents the 39th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField39")]
		public string CustomField39 { get; set; }

		/// <summary>
		///     CustomField40 represents the 40th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField40")]
		public string CustomField40 { get; set; }

		/// <summary>
		///     CustomField41 represents the 41st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField41")]
		public string CustomField41 { get; set; }

		/// <summary>
		///     CustomField42 represents the 42nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField42")]
		public string CustomField42 { get; set; }

		/// <summary>
		///     CustomField43 represents the 43rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField43")]
		public string CustomField43 { get; set; }

		/// <summary>
		///     CustomField44 represents the 44th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField44")]
		public string CustomField44 { get; set; }

		/// <summary>
		///     CustomField45 represents the 45th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField45")]
		public string CustomField45 { get; set; }

		/// <summary>
		///     CustomField46 represents the 46th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField46")]
		public string CustomField46 { get; set; }

		/// <summary>
		///     CustomField47 represents the 47th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField47")]
		public string CustomField47 { get; set; }

		/// <summary>
		///     CustomField48 represents the 48th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField48")]
		public string CustomField48 { get; set; }

		/// <summary>
		///     CustomField49 represents the 49th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField49")]
		public string CustomField49 { get; set; }

		/// <summary>
		///     CustomField50 represents the 50th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField50")]
		public string CustomField50 { get; set; }

		/// <summary>
		///     CustomField6 represents the 6th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField6")]
		public string CustomField6 { get; set; }

		/// <summary>
		///     CustomField7 represents the 7th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField7")]
		public string CustomField7 { get; set; }

		/// <summary>
		///     CustomField8 represents the 8th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField8")]
		public string CustomField8 { get; set; }

		/// <summary>
		///     CustomField9 represents the 9th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField9")]
		public string CustomField9 { get; set; }

		/// <summary>
		///     Datasheet is the name of an datasheet file (in the media files)
		///     or a URL to the datasheet on the internet.
		/// </summary>
		[JsonProperty("datasheet")]
		public string Datasheet { get; set; }

		/// <summary>
		///     Description of the product.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     Eclasses is a list of eCl@ss categories the product belongs to.
		/// </summary>
		[JsonProperty("eclasses")]
		public Eclass[] Eclasses { get; set; }

		/// <summary>
		///     erpGroupSupplier is the material group of the product on the
		///     merchant-/supplier-side.
		/// </summary>
		[JsonProperty("erpGroupSupplier")]
		public string ErpGroupSupplier { get; set; }

		/// <summary>
		///     Excluded is a flag that indicates whether to exclude this
		///     product from the catalog. If true, this product will not be
		///     published into the live area.
		/// </summary>
		[JsonProperty("excluded")]
		public bool Excluded { get; set; }

		/// <summary>
		///     ExtCategory is the EXT_CATEGORY field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategory")]
		public string ExtCategory { get; set; }

		/// <summary>
		///     ExtCategoryID is the EXT_CATEGORY_ID field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategoryId")]
		public string ExtCategoryId { get; set; }

		/// <summary>
		///     ExtConfigForm represents information required to make the
		///     product configurable. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("extConfigForm")]
		public string ExtConfigForm { get; set; }

		/// <summary>
		///     ExtConfigService represents additional information required to
		///     make the product configurable. See also ExtConfigForm. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("extConfigService")]
		public string ExtConfigService { get; set; }

		/// <summary>
		///     ExtProductID is the EXT_PRODUCT_ID field of the SAP OCI
		///     specification. It is e.g. required for configurable/catalog
		///     managed products.
		/// </summary>
		[JsonProperty("extProductId")]
		public string ExtProductId { get; set; }

		/// <summary>
		///     ExtSchemaType is the EXT_SCHEMA_TYPE field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extSchemaType")]
		public string ExtSchemaType { get; set; }

		/// <summary>
		///     Features defines product features, i.e. additional properties
		///     of the product.
		/// </summary>
		[JsonProperty("features")]
		public Feature[] Features { get; set; }

		/// <summary>
		///     GLAccount represents the GL account number to use for this
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("glAccount")]
		public string GlAccount { get; set; }

		/// <summary>
		///     GreenLogos is an array of green logo names, which are hosted in
		///     the store, and used to mark products as green.
		/// </summary>
		[JsonProperty("greenLogos")]
		public string[] GreenLogos { get; set; }

		/// <summary>
		///     GTIN is the global trade item number of the product (used to be
		///     EAN).
		/// </summary>
		[JsonProperty("gtin")]
		public string Gtin { get; set; }

		/// <summary>
		///     Hazmats classifies hazardous/dangerous goods.
		/// </summary>
		[JsonProperty("hazmats")]
		public Hazmat[] Hazmats { get; set; }

		/// <summary>
		///     Image is the name of an image file (in the media files) or a
		///     URL to the image on the internet.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		///     Incomplete is a flag that indicates whether this product is
		///     incomplete. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("incomplete")]
		public bool? Incomplete { get; set; }

		/// <summary>
		///     Intrastat specifies required data for Intrastat messages. 
		/// </summary>
		[JsonProperty("intrastat")]
		public Intrastat Intrastat { get; set; }

		/// <summary>
		///     IsPassword is a flag that indicates whether this product will
		///     be used to purchase a password, e.g. for a software product.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("isPassword")]
		public bool? IsPassword { get; set; }

		/// <summary>
		///     KeepPrice is a flag that indicates whether the price of the
		///     product will or will not be calculated by the catalog. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("keepPrice")]
		public bool? KeepPrice { get; set; }

		/// <summary>
		///     Keywords is a list of aliases for the product.
		/// </summary>
		[JsonProperty("keywords")]
		public string[] Keywords { get; set; }

		/// <summary>
		///     Leadtime is the number of days for delivery.
		/// </summary>
		[JsonProperty("leadtime")]
		public double? Leadtime { get; set; }

		/// <summary>
		///     ListPrice is the net list price of the product.
		/// </summary>
		[JsonProperty("listPrice")]
		public double? ListPrice { get; set; }

		/// <summary>
		///     Manufactcode is the manufacturer code as used in the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("manufactcode")]
		public string Manufactcode { get; set; }

		/// <summary>
		///     Manufacturer is the name of the manufacturer.
		/// </summary>
		[JsonProperty("manufacturer")]
		public string Manufacturer { get; set; }

		/// <summary>
		///     Matgroup is the material group of the product on the buy-side.
		/// </summary>
		[JsonProperty("matgroup")]
		public string Matgroup { get; set; }

		/// <summary>
		///     MPN is the manufacturer part number.
		/// </summary>
		[JsonProperty("mpn")]
		public string Mpn { get; set; }

		/// <summary>
		///     MultiSupplierID represents an optional field for the unique
		///     identifier of a supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierId")]
		public string MultiSupplierId { get; set; }

		/// <summary>
		///     MultiSupplierName represents an optional field for the name of
		///     the supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierName")]
		public string MultiSupplierName { get; set; }

		/// <summary>
		///     Name of the product.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     NeedsGoodsReceipt is a flag that indicates whether this product
		///     requires a goods receipt process. Please consult your Store
		///     Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("needsGoodsReceipt")]
		public bool? NeedsGoodsReceipt { get; set; }

		/// <summary>
		///     NFBasePrice represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfBasePrice")]
		public double? NfBasePrice { get; set; }

		/// <summary>
		///     NFBasePriceQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfBasePriceQuantity")]
		public double? NfBasePriceQuantity { get; set; }

		/// <summary>
		///     NFCndID represents the key to calculate metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfCndId")]
		public string NfCndId { get; set; }

		/// <summary>
		///     NFScale represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfScale")]
		public double? NfScale { get; set; }

		/// <summary>
		///     NFScaleQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfScaleQuantity")]
		public double? NfScaleQuantity { get; set; }

		/// <summary>
		///     Orderable is a flag that indicates whether this product will be
		///     orderable to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("orderable")]
		public bool? Orderable { get; set; }

		/// <summary>
		///     OrderUnit is the order unit of the product, a 3-character ISO
		///     code (usually project-specific).
		/// </summary>
		[JsonProperty("ou")]
		public string OrderUnit { get; set; }

		/// <summary>
		///     Price is the net price (per order unit) of the product for the
		///     end-user.
		/// </summary>
		[JsonProperty("price")]
		public double Price { get; set; }

		/// <summary>
		///     PriceFormula represents the formula to calculate the price of
		///     the product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("priceFormula")]
		public string PriceFormula { get; set; }

		/// <summary>
		///     PriceQty is the quantity for which the price is specified
		///     (default: 1.0).
		/// </summary>
		[JsonProperty("priceQty")]
		public double? PriceQty { get; set; }

		/// <summary>
		///     QuantityInterval is the interval in which this product can be
		///     ordered. E.g. if the quantity interval is 5, the end-user can
		///     only order in quantities of 5,10,15 etc. 
		/// </summary>
		[JsonProperty("quantityInterval")]
		public double? QuantityInterval { get; set; }

		/// <summary>
		///     QuantityMax is the maximum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMax")]
		public double? QuantityMax { get; set; }

		/// <summary>
		///     QuantityMin is the minimum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMin")]
		public double? QuantityMin { get; set; }

		/// <summary>
		///     Rateable is a flag that indicates whether the product can be
		///     rated by end-users. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("rateable")]
		public bool? Rateable { get; set; }

		/// <summary>
		///     RateableOnlyIfOrdered is a flag that indicates whether the
		///     product can be rated only after being ordered. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("rateableOnlyIfOrdered")]
		public bool? RateableOnlyIfOrdered { get; set; }

		/// <summary>
		///     References defines cross-product references, e.g. alternatives
		///     or follow-up products.
		/// </summary>
		[JsonProperty("references")]
		public Reference[] References { get; set; }

		/// <summary>
		///     Safetysheet is the name of an safetysheet file (in the media
		///     files) or a URL to the safetysheet on the internet.
		/// </summary>
		[JsonProperty("safetysheet")]
		public string Safetysheet { get; set; }

		/// <summary>
		///     ScalePrices can be used when the price of the product is
		///     dependent on the ordered quantity.
		/// </summary>
		[JsonProperty("scalePrices")]
		public ScalePrice[] ScalePrices { get; set; }

		/// <summary>
		///     Service indicates if the is a good (false) or a service (true).
		///     The default value is false.
		/// </summary>
		[JsonProperty("service")]
		public bool Service { get; set; }

		/// <summary>
		///     SPN is the supplier part number.
		/// </summary>
		[JsonProperty("spn")]
		public string Spn { get; set; }

		/// <summary>
		///     TaxCode to use for this product. This is typically
		///     project-specific.
		/// </summary>
		[JsonProperty("taxCode")]
		public string TaxCode { get; set; }

		/// <summary>
		///     TaxRate for this product, a numeric value between 0.0 and 1.0.
		/// </summary>
		[JsonProperty("taxRate")]
		public double TaxRate { get; set; }

		/// <summary>
		///     Thumbnail is the name of an thumbnail image file (in the media
		///     files) or a URL to the image on the internet.
		/// </summary>
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		/// <summary>
		///     Unspscs is a list of UNSPSC categories the product belongs to.
		/// </summary>
		[JsonProperty("unspscs")]
		public Unspsc[] Unspscs { get; set; }

		/// <summary>
		///     Visible is a flag that indicates whether this product will be
		///     visible to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("visible")]
		public bool? Visible { get; set; }

		#endregion // CreateProduct
	}

	/// <summary>
	///     CreateProductResponse is the outcome of a successful request to
	///     create a product.
	/// </summary>
	public class CreateProductResponse
	{
		#region CreateProductResponse

		/// <summary>
		///     Kind describes this entity.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Link returns a URL to the representation of the newly created
		///     product.
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		#endregion // CreateProductResponse
	}

	/// <summary>
	///     CustField describes a generic name/value pair. Its purpose is
	///     to provide a mechanism for customer-specific fields.
	/// </summary>
	public class CustField
	{
		#region CustField

		/// <summary>
		///     Name is the name of the customer-specific field, e.g. TaxRate.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     Value is the value of the customer-specific field, e.g. 19%.
		/// </summary>
		[JsonProperty("value")]
		public string Value { get; set; }

		#endregion // CustField
	}

	/// <summary>
	///     Eclass is used to tie a product to an eCl@ss schema.
	/// </summary>
	public class Eclass
	{
		#region Eclass

		/// <summary>
		///     Code is the eCl@ss code. Only use digits for encoding, e.g.
		///     19010203.
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		///     Version is the eCl@ss version in the major.minor format, e.g.
		///     5.1 or 7.0.
		/// </summary>
		[JsonProperty("version")]
		public string Version { get; set; }

		#endregion // Eclass
	}

	/// <summary>
	///     Feature describes additional features of a product.
	/// </summary>
	public class Feature
	{
		#region Feature

		/// <summary>
		///     Kind describes the type of feature, e.g. ECLASS-5.1 to describe
		///     a feature of eCl@ss 5.1.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Name specifies the name/code of the feature. If you are
		///     refering to a standard classification like eCl@ss, you should
		///     use the code of the feature. Otherwise, you are free to use a
		///     textual description like "Weight" or "Diameter" or "Voltage". 
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     Unit is a unit of measurement to describe the feature value.
		///     E.g. if you specify the weight, you should probably use KGM as
		///     unit to describe that the weight is given in kilograms. 
		/// </summary>
		[JsonProperty("unit")]
		public string Unit { get; set; }

		/// <summary>
		///     Values describes the feature value(s).
		/// </summary>
		[JsonProperty("values")]
		public string[] Values { get; set; }

		#endregion // Feature
	}

	/// <summary>
	///     Hazmat describes a hazardous/dangerous good.
	/// </summary>
	public class Hazmat
	{
		#region Hazmat

		/// <summary>
		///     Kind describes the classification system, e.g. GGVS.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Text gives a textual description or a code of the harm that the
		///     product can do to people, property, or the environment.
		/// </summary>
		[JsonProperty("text")]
		public string Text { get; set; }

		#endregion // Hazmat
	}

	/// <summary>
	///     Intrastat represents data required for Intrastat messages.
	/// </summary>
	public class Intrastat
	{
		#region Intrastat

		/// <summary>
		///     Code represents an identifier for a product group, e.g. the
		///     tariff code of "85167100" for "Electro-thermic coffee or tea
		///     makers, for domestic use". See
		///     https://www.zolltarifnummern.de/2018 for details. This is a
		///     required field. 
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		///     GrossWeight represents the gross weight of the product. 
		/// </summary>
		[JsonProperty("grossWeight")]
		public double GrossWeight { get; set; }

		/// <summary>
		///     MeansOfTransport indicates how the product was delivered to its
		///     destination, e.g. by air or by train. According to the
		///     INTRASTAT documentation, the following values are permitted
		///     (see
		///     https://www-idev.destatis.de/idev/doc/intra/doc/Intrahandel_Leit
		///     faden.pdf for a complete list): 1 - Maritime traffic 2 - Rail
		///     transport 3 - Road traffic 4 - Air traffic 5 - Mailings /
		///     postal service 7 - Pipings 8 - Inland waterways 9 - Own drive
		///     The value of "6" is missing in that list, and it's not a typo. 
		/// </summary>
		[JsonProperty("meansOfTransport")]
		public string MeansOfTransport { get; set; }

		/// <summary>
		///     NetWeight represents the net weight of the product. 
		/// </summary>
		[JsonProperty("netWeight")]
		public double NetWeight { get; set; }

		/// <summary>
		///     OriginCountry represents the ISO code of the country/region
		///     where the product has been created/produced, e.g. DE. This is a
		///     required field. 
		/// </summary>
		[JsonProperty("originCountry")]
		public string OriginCountry { get; set; }

		/// <summary>
		///     TransactionType indicates the type of transaction, e.g. if it
		///     represents a purchase or a leasing contract. In the INTRASTAT
		///     documentation, this is represented by two digits, e.g. "11" for
		///     a purchase and "14" for leasing. See
		///     https://www-idev.destatis.de/idev/doc/intra/doc/Intrahandel_Leit
		///     faden.pdf for details. 
		/// </summary>
		[JsonProperty("transactionType")]
		public string TransactionType { get; set; }

		/// <summary>
		///     WeightUnit is the ISO code of for NetWeight and/or GrossWeight,
		///     e.g. KGM. 
		/// </summary>
		[JsonProperty("weightUnit")]
		public string WeightUnit { get; set; }

		#endregion // Intrastat
	}

	/// <summary>
	///     Product is a good or service in a catalog.
	/// </summary>
	public class Product
	{
		#region Product

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		[JsonProperty("asin")]
		public string Asin { get; set; }

		/// <summary>
		///     AutoConfigure is a flag that indicates whether this product can
		///     be configured automatically.
		/// </summary>
		[JsonProperty("autoConfigure")]
		public bool? AutoConfigure { get; set; }

		/// <summary>
		///     Availability allows the update of product availability data,
		///     e.g. the number of items in stock or the date when the product
		///     will be available again. 
		/// </summary>
		[JsonProperty("availability")]
		public Availability Availability { get; set; }

		/// <summary>
		///     Blobs specifies external data, e.g. images or datasheets.
		/// </summary>
		[JsonProperty("blobs")]
		public Blob[] Blobs { get; set; }

		/// <summary>
		///     BoostFactor represents a positive or negative boost for the
		///     product.
		/// </summary>
		[JsonProperty("boostFactor")]
		public double? BoostFactor { get; set; }

		/// <summary>
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

		/// <summary>
		///     Brand is the commercial brand name of the product (i.e.
		///     end-consumer recognizable brand name).
		/// </summary>
		[JsonProperty("brand")]
		public string Brand { get; set; }

		/// <summary>
		///     ID of the catalog this products belongs to.
		/// </summary>
		[JsonProperty("catalogId")]
		public long CatalogId { get; set; }

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		[JsonProperty("catalogManaged")]
		public bool CatalogManaged { get; set; }

		/// <summary>
		///     Categories is a list of (supplier-specific) category names the
		///     product belongs to.
		/// </summary>
		[JsonProperty("categories")]
		public string[] Categories { get; set; }

		/// <summary>
		///     Conditions describes the product conditions, e.g. refurbished
		///     or used.
		/// </summary>
		[JsonProperty("conditions")]
		public Condition[] Conditions { get; set; }

		/// <summary>
		///     Contract represents the contract number to be used when
		///     purchasing this product.
		/// </summary>
		[JsonProperty("contract")]
		public string Contract { get; set; }

		/// <summary>
		///     ContractItem represents line number in the contract to be used
		///     when purchasing this product. See also Contract.
		/// </summary>
		[JsonProperty("contractItem")]
		public string ContractItem { get; set; }

		/// <summary>
		///     ConversionDenumerator is the denumerator for calculating price
		///     quantities.
		/// </summary>
		[JsonProperty("conversionDenumerator")]
		public double? ConversionDenumerator { get; set; }

		/// <summary>
		///     ConversionNumerator is the numerator for calculating price
		///     quantities.
		/// </summary>
		[JsonProperty("conversionNumerator")]
		public double? ConversionNumerator { get; set; }

		/// <summary>
		///     Country/Region represents the ISO code of the country/region of
		///     origin, i.e. the country/region where the product has been
		///     created/produced, e.g. DE. If unspecified, the field is
		///     initialized with the catalog's country/region field. 
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		///     Created is the creation date and time of the product.
		/// </summary>
		[JsonProperty("created")]
		public DateTimeOffset? Created { get; set; }

		/// <summary>
		///     ContentUnit is the content unit of the product, a 3-character
		///     ISO code (usually project-specific).
		/// </summary>
		[JsonProperty("cu")]
		public string ContentUnit { get; set; }

		/// <summary>
		///     CuPerOu describes the number of content units per order unit,
		///     e.g. the 12 in '1 case contains 12 bottles'.
		/// </summary>
		[JsonProperty("cuPerOu")]
		public double CuPerOu { get; set; }

		/// <summary>
		///     Currency is the ISO currency code for the prices, e.g. EUR or
		///     GBP. If you pass an empty currency code, it will be initialized
		///     with the catalog's currency. 
		/// </summary>
		[JsonProperty("currency")]
		public string Currency { get; set; }

		/// <summary>
		///     CustField1 is the CUST_FIELD1 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField1")]
		public string CustField1 { get; set; }

		/// <summary>
		///     CustField2 is the CUST_FIELD2 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField2")]
		public string CustField2 { get; set; }

		/// <summary>
		///     CustField3 is the CUST_FIELD3 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField3")]
		public string CustField3 { get; set; }

		/// <summary>
		///     CustField4 is the CUST_FIELD4 of the SAP OCI specification. It
		///     has a maximum length of 20 characters. 
		/// </summary>
		[JsonProperty("custField4")]
		public string CustField4 { get; set; }

		/// <summary>
		///     CustField5 is the CUST_FIELD5 of the SAP OCI specification. It
		///     has a maximum length of 50 characters. 
		/// </summary>
		[JsonProperty("custField5")]
		public string CustField5 { get; set; }

		/// <summary>
		///     CustFields is an array of generic name/value pairs for
		///     customer-specific attributes.
		/// </summary>
		[JsonProperty("custFields")]
		public CustField[] CustFields { get; set; }

		/// <summary>
		///     CustomField10 represents the 10th customer-specific field.
		/// </summary>
		[JsonProperty("customField10")]
		public string CustomField10 { get; set; }

		/// <summary>
		///     CustomField11 represents the 11th customer-specific field.
		/// </summary>
		[JsonProperty("customField11")]
		public string CustomField11 { get; set; }

		/// <summary>
		///     CustomField12 represents the 12th customer-specific field.
		/// </summary>
		[JsonProperty("customField12")]
		public string CustomField12 { get; set; }

		/// <summary>
		///     CustomField13 represents the 13th customer-specific field.
		/// </summary>
		[JsonProperty("customField13")]
		public string CustomField13 { get; set; }

		/// <summary>
		///     CustomField14 represents the 14th customer-specific field.
		/// </summary>
		[JsonProperty("customField14")]
		public string CustomField14 { get; set; }

		/// <summary>
		///     CustomField15 represents the 15th customer-specific field.
		/// </summary>
		[JsonProperty("customField15")]
		public string CustomField15 { get; set; }

		/// <summary>
		///     CustomField16 represents the 16th customer-specific field.
		/// </summary>
		[JsonProperty("customField16")]
		public string CustomField16 { get; set; }

		/// <summary>
		///     CustomField17 represents the 17th customer-specific field.
		/// </summary>
		[JsonProperty("customField17")]
		public string CustomField17 { get; set; }

		/// <summary>
		///     CustomField18 represents the 18th customer-specific field.
		/// </summary>
		[JsonProperty("customField18")]
		public string CustomField18 { get; set; }

		/// <summary>
		///     CustomField19 represents the 19th customer-specific field.
		/// </summary>
		[JsonProperty("customField19")]
		public string CustomField19 { get; set; }

		/// <summary>
		///     CustomField20 represents the 20th customer-specific field.
		/// </summary>
		[JsonProperty("customField20")]
		public string CustomField20 { get; set; }

		/// <summary>
		///     CustomField21 represents the 21st customer-specific field.
		/// </summary>
		[JsonProperty("customField21")]
		public string CustomField21 { get; set; }

		/// <summary>
		///     CustomField22 represents the 22nd customer-specific field.
		/// </summary>
		[JsonProperty("customField22")]
		public string CustomField22 { get; set; }

		/// <summary>
		///     CustomField23 represents the 23rd customer-specific field.
		/// </summary>
		[JsonProperty("customField23")]
		public string CustomField23 { get; set; }

		/// <summary>
		///     CustomField24 represents the 24th customer-specific field.
		/// </summary>
		[JsonProperty("customField24")]
		public string CustomField24 { get; set; }

		/// <summary>
		///     CustomField25 represents the 25th customer-specific field.
		/// </summary>
		[JsonProperty("customField25")]
		public string CustomField25 { get; set; }

		/// <summary>
		///     CustomField26 represents the 26th customer-specific field.
		/// </summary>
		[JsonProperty("customField26")]
		public string CustomField26 { get; set; }

		/// <summary>
		///     CustomField27 represents the 27th customer-specific field.
		/// </summary>
		[JsonProperty("customField27")]
		public string CustomField27 { get; set; }

		/// <summary>
		///     CustomField28 represents the 28th customer-specific field.
		/// </summary>
		[JsonProperty("customField28")]
		public string CustomField28 { get; set; }

		/// <summary>
		///     CustomField29 represents the 29th customer-specific field.
		/// </summary>
		[JsonProperty("customField29")]
		public string CustomField29 { get; set; }

		/// <summary>
		///     CustomField30 represents the 30th customer-specific field.
		/// </summary>
		[JsonProperty("customField30")]
		public string CustomField30 { get; set; }

		/// <summary>
		///     CustomField31 represents the 31st customer-specific field.
		/// </summary>
		[JsonProperty("customField31")]
		public string CustomField31 { get; set; }

		/// <summary>
		///     CustomField32 represents the 32nd customer-specific field.
		/// </summary>
		[JsonProperty("customField32")]
		public string CustomField32 { get; set; }

		/// <summary>
		///     CustomField33 represents the 33rd customer-specific field.
		/// </summary>
		[JsonProperty("customField33")]
		public string CustomField33 { get; set; }

		/// <summary>
		///     CustomField34 represents the 34th customer-specific field.
		/// </summary>
		[JsonProperty("customField34")]
		public string CustomField34 { get; set; }

		/// <summary>
		///     CustomField35 represents the 35th customer-specific field.
		/// </summary>
		[JsonProperty("customField35")]
		public string CustomField35 { get; set; }

		/// <summary>
		///     CustomField36 represents the 36th customer-specific field.
		/// </summary>
		[JsonProperty("customField36")]
		public string CustomField36 { get; set; }

		/// <summary>
		///     CustomField37 represents the 37th customer-specific field.
		/// </summary>
		[JsonProperty("customField37")]
		public string CustomField37 { get; set; }

		/// <summary>
		///     CustomField38 represents the 38th customer-specific field.
		/// </summary>
		[JsonProperty("customField38")]
		public string CustomField38 { get; set; }

		/// <summary>
		///     CustomField39 represents the 39th customer-specific field.
		/// </summary>
		[JsonProperty("customField39")]
		public string CustomField39 { get; set; }

		/// <summary>
		///     CustomField40 represents the 40th customer-specific field.
		/// </summary>
		[JsonProperty("customField40")]
		public string CustomField40 { get; set; }

		/// <summary>
		///     CustomField41 represents the 41st customer-specific field.
		/// </summary>
		[JsonProperty("customField41")]
		public string CustomField41 { get; set; }

		/// <summary>
		///     CustomField42 represents the 42nd customer-specific field.
		/// </summary>
		[JsonProperty("customField42")]
		public string CustomField42 { get; set; }

		/// <summary>
		///     CustomField43 represents the 43rd customer-specific field.
		/// </summary>
		[JsonProperty("customField43")]
		public string CustomField43 { get; set; }

		/// <summary>
		///     CustomField44 represents the 44th customer-specific field.
		/// </summary>
		[JsonProperty("customField44")]
		public string CustomField44 { get; set; }

		/// <summary>
		///     CustomField45 represents the 45th customer-specific field.
		/// </summary>
		[JsonProperty("customField45")]
		public string CustomField45 { get; set; }

		/// <summary>
		///     CustomField46 represents the 46th customer-specific field.
		/// </summary>
		[JsonProperty("customField46")]
		public string CustomField46 { get; set; }

		/// <summary>
		///     CustomField47 represents the 47th customer-specific field.
		/// </summary>
		[JsonProperty("customField47")]
		public string CustomField47 { get; set; }

		/// <summary>
		///     CustomField48 represents the 48th customer-specific field.
		/// </summary>
		[JsonProperty("customField48")]
		public string CustomField48 { get; set; }

		/// <summary>
		///     CustomField49 represents the 49th customer-specific field.
		/// </summary>
		[JsonProperty("customField49")]
		public string CustomField49 { get; set; }

		/// <summary>
		///     CustomField50 represents the 50th customer-specific field.
		/// </summary>
		[JsonProperty("customField50")]
		public string CustomField50 { get; set; }

		/// <summary>
		///     CustomField6 represents the 6th customer-specific field.
		/// </summary>
		[JsonProperty("customField6")]
		public string CustomField6 { get; set; }

		/// <summary>
		///     CustomField7 represents the 7th customer-specific field.
		/// </summary>
		[JsonProperty("customField7")]
		public string CustomField7 { get; set; }

		/// <summary>
		///     CustomField8 represents the 8th customer-specific field.
		/// </summary>
		[JsonProperty("customField8")]
		public string CustomField8 { get; set; }

		/// <summary>
		///     CustomField9 represents the 9th customer-specific field.
		/// </summary>
		[JsonProperty("customField9")]
		public string CustomField9 { get; set; }

		/// <summary>
		///     Datasheet is the name of an datasheet file (in the media files)
		///     or a URL to the datasheet on the internet.
		/// </summary>
		[JsonProperty("datasheet")]
		public string Datasheet { get; set; }

		/// <summary>
		///     DatasheetURL is the URL to the data sheet (if available).
		/// </summary>
		[JsonProperty("datasheetURL")]
		public string DatasheetURL { get; set; }

		/// <summary>
		///     Description of the product.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     Eclasses is a list of eCl@ss categories the product belongs to.
		/// </summary>
		[JsonProperty("eclasses")]
		public Eclass[] Eclasses { get; set; }

		/// <summary>
		///     erpGroupSupplier is the material group of the product on the
		///     merchant-/supplier-side.
		/// </summary>
		[JsonProperty("erpGroupSupplier")]
		public string ErpGroupSupplier { get; set; }

		/// <summary>
		///     Excluded is a flag that indicates whether to exclude this
		///     product from the catalog. If true, this product will not be
		///     published into the live area.
		/// </summary>
		[JsonProperty("excluded")]
		public bool Excluded { get; set; }

		/// <summary>
		///     ExtCategory is the EXT_CATEGORY field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategory")]
		public string ExtCategory { get; set; }

		/// <summary>
		///     ExtCategoryID is the EXT_CATEGORY_ID field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategoryId")]
		public string ExtCategoryId { get; set; }

		/// <summary>
		///     ExtConfigForm represents information required to make the
		///     product configurable.
		/// </summary>
		[JsonProperty("extConfigForm")]
		public string ExtConfigForm { get; set; }

		/// <summary>
		///     ExtConfigService represents additional information required to
		///     make the product configurable. See also ExtConfigForm.
		/// </summary>
		[JsonProperty("extConfigService")]
		public string ExtConfigService { get; set; }

		/// <summary>
		///     ExtProductID is the EXT_PRODUCT_ID field of the SAP OCI
		///     specification. It is e.g. required for configurable/catalog
		///     managed products.
		/// </summary>
		[JsonProperty("extProductId")]
		public string ExtProductId { get; set; }

		/// <summary>
		///     ExtSchemaType is the EXT_SCHEMA_TYPE field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extSchemaType")]
		public string ExtSchemaType { get; set; }

		/// <summary>
		///     Features defines product features, i.e. additional properties
		///     of the product.
		/// </summary>
		[JsonProperty("features")]
		public Feature[] Features { get; set; }

		/// <summary>
		///     GLAccount represents the GL account number to use for this
		///     product.
		/// </summary>
		[JsonProperty("glAccount")]
		public string GlAccount { get; set; }

		/// <summary>
		///     GreenLogos is an array of green logo names, which are hosted in
		///     the store, and used to mark products as green.
		/// </summary>
		[JsonProperty("greenLogos")]
		public string[] GreenLogos { get; set; }

		/// <summary>
		///     GTIN is the global trade item number of the product (used to be
		///     EAN).
		/// </summary>
		[JsonProperty("gtin")]
		public string Gtin { get; set; }

		/// <summary>
		///     Hazmats classifies hazardous/dangerous goods.
		/// </summary>
		[JsonProperty("hazmats")]
		public Hazmat[] Hazmats { get; set; }

		/// <summary>
		///     ID is a unique (internal) identifier of the product.
		/// </summary>
		[JsonProperty("id")]
		public string Id { get; set; }

		/// <summary>
		///     Image is the name of an image file (in the media files) or a
		///     URL to the image on the internet.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		///     ImageURL is the URL to the image.
		/// </summary>
		[JsonProperty("imageURL")]
		public string ImageURL { get; set; }

		/// <summary>
		///     Incomplete is a flag that indicates whether this product is
		///     incomplete.
		/// </summary>
		[JsonProperty("incomplete")]
		public bool? Incomplete { get; set; }

		/// <summary>
		///     Intrastat specifies required data for Intrastat messages. 
		/// </summary>
		[JsonProperty("intrastat")]
		public Intrastat Intrastat { get; set; }

		/// <summary>
		///     IsPassword is a flag that indicates whether this product will
		///     be used to purchase a password, e.g. for a software product.
		/// </summary>
		[JsonProperty("isPassword")]
		public bool? IsPassword { get; set; }

		/// <summary>
		///     KeepPrice is a flag that indicates whether the price of the
		///     product will or will not be calculated by the catalog.
		/// </summary>
		[JsonProperty("keepPrice")]
		public bool? KeepPrice { get; set; }

		/// <summary>
		///     Keywords is a list of aliases for the product.
		/// </summary>
		[JsonProperty("keywords")]
		public string[] Keywords { get; set; }

		/// <summary>
		///     Kind is store#product for a product entity.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Leadtime is the number of days for delivery.
		/// </summary>
		[JsonProperty("leadtime")]
		public double? Leadtime { get; set; }

		/// <summary>
		///     ListPrice is the net list price of the product.
		/// </summary>
		[JsonProperty("listPrice")]
		public double ListPrice { get; set; }

		/// <summary>
		///     Manufactcode is the manufacturer code as used in the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("manufactcode")]
		public string Manufactcode { get; set; }

		/// <summary>
		///     Manufacturer is the name of the manufacturer.
		/// </summary>
		[JsonProperty("manufacturer")]
		public string Manufacturer { get; set; }

		/// <summary>
		///     Matgroup is the material group of the product on the buy-side.
		/// </summary>
		[JsonProperty("matgroup")]
		public string Matgroup { get; set; }

		/// <summary>
		///     MeplatoPrice is the Meplato price of the product.
		/// </summary>
		[JsonProperty("meplatoPrice")]
		public double MeplatoPrice { get; set; }

		/// <summary>
		///     ID of the merchant.
		/// </summary>
		[JsonProperty("merchantId")]
		public long MerchantId { get; set; }

		/// <summary>
		///     Mode is only used for differential downloads and is the type of
		///     change of a product (CREATED, UPDATED, DELETED).
		/// </summary>
		[JsonProperty("mode")]
		public string Mode { get; set; }

		/// <summary>
		///     MPN is the manufacturer part number.
		/// </summary>
		[JsonProperty("mpn")]
		public string Mpn { get; set; }

		/// <summary>
		///     MultiSupplierID represents an optional field for the unique
		///     identifier of a supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierId")]
		public string MultiSupplierId { get; set; }

		/// <summary>
		///     MultiSupplierName represents an optional field for the name of
		///     the supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierName")]
		public string MultiSupplierName { get; set; }

		/// <summary>
		///     Name of the product.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     NeedsGoodsReceipt is a flag that indicates whether this product
		///     requires a goods receipt process.
		/// </summary>
		[JsonProperty("needsGoodsReceipt")]
		public bool? NeedsGoodsReceipt { get; set; }

		/// <summary>
		///     NFBasePrice represents a part for calculating metal surcharges.
		/// </summary>
		[JsonProperty("nfBasePrice")]
		public double? NfBasePrice { get; set; }

		/// <summary>
		///     NFBasePriceQuantity represents a part for calculating metal
		///     surcharges.
		/// </summary>
		[JsonProperty("nfBasePriceQuantity")]
		public double? NfBasePriceQuantity { get; set; }

		/// <summary>
		///     NFCndID represents the key to calculate metal surcharges.
		/// </summary>
		[JsonProperty("nfCndId")]
		public string NfCndId { get; set; }

		/// <summary>
		///     NFScale represents a part for calculating metal surcharges.
		/// </summary>
		[JsonProperty("nfScale")]
		public double? NfScale { get; set; }

		/// <summary>
		///     NFScaleQuantity represents a part for calculating metal
		///     surcharges.
		/// </summary>
		[JsonProperty("nfScaleQuantity")]
		public double? NfScaleQuantity { get; set; }

		/// <summary>
		///     Orderable is a flag that indicates whether this product will be
		///     orderable to the end-user when shopping.
		/// </summary>
		[JsonProperty("orderable")]
		public bool? Orderable { get; set; }

		/// <summary>
		///     OrderUnit is the order unit of the product, a 3-character ISO
		///     code (usually project-specific).
		/// </summary>
		[JsonProperty("ou")]
		public string OrderUnit { get; set; }

		/// <summary>
		///     Price is the net price (per order unit) of the product for the
		///     end-user.
		/// </summary>
		[JsonProperty("price")]
		public double Price { get; set; }

		/// <summary>
		///     PriceFormula represents the formula to calculate the price of
		///     the product.
		/// </summary>
		[JsonProperty("priceFormula")]
		public string PriceFormula { get; set; }

		/// <summary>
		///     PriceQty is the quantity for which the price is specified
		///     (default: 1.0).
		/// </summary>
		[JsonProperty("priceQty")]
		public double PriceQty { get; set; }

		/// <summary>
		///     ID of the project.
		/// </summary>
		[JsonProperty("projectId")]
		public long ProjectId { get; set; }

		/// <summary>
		///     QuantityInterval is the interval in which this product can be
		///     ordered. E.g. if the quantity interval is 5, the end-user can
		///     only order in quantities of 5,10,15 etc. 
		/// </summary>
		[JsonProperty("quantityInterval")]
		public double? QuantityInterval { get; set; }

		/// <summary>
		///     QuantityMax is the maximum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMax")]
		public double? QuantityMax { get; set; }

		/// <summary>
		///     QuantityMin is the minimum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMin")]
		public double? QuantityMin { get; set; }

		/// <summary>
		///     Rateable is a flag that indicates whether the product can be
		///     rated by end-users.
		/// </summary>
		[JsonProperty("rateable")]
		public bool? Rateable { get; set; }

		/// <summary>
		///     RateableOnlyIfOrdered is a flag that indicates whether the
		///     product can be rated only after being ordered.
		/// </summary>
		[JsonProperty("rateableOnlyIfOrdered")]
		public bool? RateableOnlyIfOrdered { get; set; }

		/// <summary>
		///     References defines cross-product references, e.g. alternatives
		///     or follow-up products.
		/// </summary>
		[JsonProperty("references")]
		public Reference[] References { get; set; }

		/// <summary>
		///     Safetysheet is the name of an safetysheet file (in the media
		///     files) or a URL to the safetysheet on the internet.
		/// </summary>
		[JsonProperty("safetysheet")]
		public string Safetysheet { get; set; }

		/// <summary>
		///     SafetysheetURL is the URL to the safety data sheet (if
		///     available).
		/// </summary>
		[JsonProperty("safetysheetURL")]
		public string SafetysheetURL { get; set; }

		/// <summary>
		///     ScalePrices can be used when the price of the product is
		///     dependent on the ordered quantity.
		/// </summary>
		[JsonProperty("scalePrices")]
		public ScalePrice[] ScalePrices { get; set; }

		/// <summary>
		///     URL to this page.
		/// </summary>
		[JsonProperty("selfLink")]
		public string SelfLink { get; set; }

		/// <summary>
		///     Service indicates if the is a good (false) or a service (true).
		///     The default value is false.
		/// </summary>
		[JsonProperty("service")]
		public bool Service { get; set; }

		/// <summary>
		///     SPN is the supplier part number.
		/// </summary>
		[JsonProperty("spn")]
		public string Spn { get; set; }

		/// <summary>
		///     TaxCode to use for this product.
		/// </summary>
		[JsonProperty("taxCode")]
		public string TaxCode { get; set; }

		/// <summary>
		///     TaxRate for this product, a numeric value between 0.0 and 1.0.
		/// </summary>
		[JsonProperty("taxRate")]
		public double TaxRate { get; set; }

		/// <summary>
		///     Thumbnail is the name of an thumbnail image file (in the media
		///     files) or a URL to the image on the internet.
		/// </summary>
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		/// <summary>
		///     ThubmnailURL is the URL to the thumbnail image.
		/// </summary>
		[JsonProperty("thumbnailURL")]
		public string ThumbnailURL { get; set; }

		/// <summary>
		///     Unspscs is a list of UNSPSC categories the product belongs to.
		/// </summary>
		[JsonProperty("unspscs")]
		public Unspsc[] Unspscs { get; set; }

		/// <summary>
		///     Updated is the last modification date and time of the product.
		/// </summary>
		[JsonProperty("updated")]
		public DateTimeOffset? Updated { get; set; }

		/// <summary>
		///     Visible is a flag that indicates whether this product will be
		///     visible to the end-user when shopping.
		/// </summary>
		[JsonProperty("visible")]
		public bool? Visible { get; set; }

		#endregion // Product
	}

	/// <summary>
	///     Reference describes a reference from one product to another
	///     product.
	/// </summary>
	public class Reference
	{
		#region Reference

		/// <summary>
		///     Kind describes the type of reference.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Qty describes the quantity for certain kinds of references.
		///     E.g. the consists_of kind must use the quantity field to be
		///     useful for the end-user. 
		/// </summary>
		[JsonProperty("qty")]
		public double? Qty { get; set; }

		/// <summary>
		///     SPN specifies the supplier product number of the other product.
		/// </summary>
		[JsonProperty("spn")]
		public string Spn { get; set; }

		#endregion // Reference
	}

	/// <summary>
	///     ReplaceProduct replace all properties of an existing product.
	/// </summary>
	public class ReplaceProduct
	{
		#region ReplaceProduct

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		[JsonProperty("asin")]
		public string Asin { get; set; }

		/// <summary>
		///     AutoConfigure is a flag that indicates whether this product can
		///     be configured automatically. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("autoConfigure")]
		public bool? AutoConfigure { get; set; }

		/// <summary>
		///     Availability allows the update of product availability data,
		///     e.g. the number of items in stock or the date when the product
		///     will be available again. 
		/// </summary>
		[JsonProperty("availability")]
		public Availability Availability { get; set; }

		/// <summary>
		///     Blobs contains information about external data, e.g.
		///     attachments like images or datasheets.
		/// </summary>
		[JsonProperty("blobs")]
		public Blob[] Blobs { get; set; }

		/// <summary>
		///     BoostFactor represents a positive or negative boost for the
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("boostFactor")]
		public double? BoostFactor { get; set; }

		/// <summary>
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

		/// <summary>
		///     Brand is the commercial brand name of the product (i.e.
		///     end-consumer recognizable brand name)
		/// </summary>
		[JsonProperty("brand")]
		public string Brand { get; set; }

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		[JsonProperty("catalogManaged")]
		public bool CatalogManaged { get; set; }

		/// <summary>
		///     Categories is a list of (supplier-specific) category names the
		///     product belongs to.
		/// </summary>
		[JsonProperty("categories")]
		public string[] Categories { get; set; }

		/// <summary>
		///     Conditions describes the product conditions, e.g. refurbished
		///     or used.
		/// </summary>
		[JsonProperty("conditions")]
		public Condition[] Conditions { get; set; }

		/// <summary>
		///     Contract represents the contract number to be used when
		///     purchasing this product. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("contract")]
		public string Contract { get; set; }

		/// <summary>
		///     ContractItem represents line number in the contract to be used
		///     when purchasing this product. See also Contract. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("contractItem")]
		public string ContractItem { get; set; }

		/// <summary>
		///     ConversionDenumerator is the denumerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionDenumerator")]
		public double? ConversionDenumerator { get; set; }

		/// <summary>
		///     ConversionNumerator is the numerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionNumerator")]
		public double? ConversionNumerator { get; set; }

		/// <summary>
		///     Country/Region represents the ISO code of the country/region of
		///     origin, i.e. the country/region where the product has been
		///     created/produced, e.g. DE. If unspecified, the field is
		///     initialized with the catalog's country/region field. 
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		///     ContentUnit is the content unit of the product, a 3-character
		///     ISO code (usually project-specific).
		/// </summary>
		[JsonProperty("cu")]
		public string ContentUnit { get; set; }

		/// <summary>
		///     CuPerOu describes the number of content units per order unit,
		///     e.g. the 12 in '1 case contains 12 bottles'.
		/// </summary>
		[JsonProperty("cuPerOu")]
		public double? CuPerOu { get; set; }

		/// <summary>
		///     Currency is the ISO currency code for the prices, e.g. EUR or
		///     GBP. If you pass an empty currency code, it will be initialized
		///     with the catalog's currency. 
		/// </summary>
		[JsonProperty("currency")]
		public string Currency { get; set; }

		/// <summary>
		///     CustField1 is the CUST_FIELD1 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField1")]
		public string CustField1 { get; set; }

		/// <summary>
		///     CustField2 is the CUST_FIELD2 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField2")]
		public string CustField2 { get; set; }

		/// <summary>
		///     CustField3 is the CUST_FIELD3 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField3")]
		public string CustField3 { get; set; }

		/// <summary>
		///     CustField4 is the CUST_FIELD4 of the SAP OCI specification. It
		///     has a maximum length of 20 characters. 
		/// </summary>
		[JsonProperty("custField4")]
		public string CustField4 { get; set; }

		/// <summary>
		///     CustField5 is the CUST_FIELD5 of the SAP OCI specification. It
		///     has a maximum length of 50 characters. 
		/// </summary>
		[JsonProperty("custField5")]
		public string CustField5 { get; set; }

		/// <summary>
		///     CustFields is an array of generic name/value pairs for
		///     customer-specific attributes.
		/// </summary>
		[JsonProperty("custFields")]
		public CustField[] CustFields { get; set; }

		/// <summary>
		///     CustomField10 represents the 10th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField10")]
		public string CustomField10 { get; set; }

		/// <summary>
		///     CustomField11 represents the 11th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField11")]
		public string CustomField11 { get; set; }

		/// <summary>
		///     CustomField12 represents the 12th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField12")]
		public string CustomField12 { get; set; }

		/// <summary>
		///     CustomField13 represents the 13th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField13")]
		public string CustomField13 { get; set; }

		/// <summary>
		///     CustomField14 represents the 14th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField14")]
		public string CustomField14 { get; set; }

		/// <summary>
		///     CustomField15 represents the 15th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField15")]
		public string CustomField15 { get; set; }

		/// <summary>
		///     CustomField16 represents the 16th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField16")]
		public string CustomField16 { get; set; }

		/// <summary>
		///     CustomField17 represents the 17th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField17")]
		public string CustomField17 { get; set; }

		/// <summary>
		///     CustomField18 represents the 18th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField18")]
		public string CustomField18 { get; set; }

		/// <summary>
		///     CustomField19 represents the 19th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField19")]
		public string CustomField19 { get; set; }

		/// <summary>
		///     CustomField20 represents the 20th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField20")]
		public string CustomField20 { get; set; }

		/// <summary>
		///     CustomField21 represents the 21st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField21")]
		public string CustomField21 { get; set; }

		/// <summary>
		///     CustomField22 represents the 22nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField22")]
		public string CustomField22 { get; set; }

		/// <summary>
		///     CustomField23 represents the 23rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField23")]
		public string CustomField23 { get; set; }

		/// <summary>
		///     CustomField24 represents the 24th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField24")]
		public string CustomField24 { get; set; }

		/// <summary>
		///     CustomField25 represents the 25th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField25")]
		public string CustomField25 { get; set; }

		/// <summary>
		///     CustomField26 represents the 26th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField26")]
		public string CustomField26 { get; set; }

		/// <summary>
		///     CustomField27 represents the 27th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField27")]
		public string CustomField27 { get; set; }

		/// <summary>
		///     CustomField28 represents the 28th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField28")]
		public string CustomField28 { get; set; }

		/// <summary>
		///     CustomField29 represents the 29th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField29")]
		public string CustomField29 { get; set; }

		/// <summary>
		///     CustomField30 represents the 30th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField30")]
		public string CustomField30 { get; set; }

		/// <summary>
		///     CustomField31 represents the 31st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField31")]
		public string CustomField31 { get; set; }

		/// <summary>
		///     CustomField32 represents the 32nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField32")]
		public string CustomField32 { get; set; }

		/// <summary>
		///     CustomField33 represents the 33rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField33")]
		public string CustomField33 { get; set; }

		/// <summary>
		///     CustomField34 represents the 34th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField34")]
		public string CustomField34 { get; set; }

		/// <summary>
		///     CustomField35 represents the 35th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField35")]
		public string CustomField35 { get; set; }

		/// <summary>
		///     CustomField36 represents the 36th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField36")]
		public string CustomField36 { get; set; }

		/// <summary>
		///     CustomField37 represents the 37th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField37")]
		public string CustomField37 { get; set; }

		/// <summary>
		///     CustomField38 represents the 38th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField38")]
		public string CustomField38 { get; set; }

		/// <summary>
		///     CustomField39 represents the 39th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField39")]
		public string CustomField39 { get; set; }

		/// <summary>
		///     CustomField40 represents the 40th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField40")]
		public string CustomField40 { get; set; }

		/// <summary>
		///     CustomField41 represents the 41st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField41")]
		public string CustomField41 { get; set; }

		/// <summary>
		///     CustomField42 represents the 42nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField42")]
		public string CustomField42 { get; set; }

		/// <summary>
		///     CustomField43 represents the 43rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField43")]
		public string CustomField43 { get; set; }

		/// <summary>
		///     CustomField44 represents the 44th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField44")]
		public string CustomField44 { get; set; }

		/// <summary>
		///     CustomField45 represents the 45th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField45")]
		public string CustomField45 { get; set; }

		/// <summary>
		///     CustomField46 represents the 46th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField46")]
		public string CustomField46 { get; set; }

		/// <summary>
		///     CustomField47 represents the 47th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField47")]
		public string CustomField47 { get; set; }

		/// <summary>
		///     CustomField48 represents the 48th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField48")]
		public string CustomField48 { get; set; }

		/// <summary>
		///     CustomField49 represents the 49th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField49")]
		public string CustomField49 { get; set; }

		/// <summary>
		///     CustomField50 represents the 50th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField50")]
		public string CustomField50 { get; set; }

		/// <summary>
		///     CustomField6 represents the 6th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField6")]
		public string CustomField6 { get; set; }

		/// <summary>
		///     CustomField7 represents the 7th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField7")]
		public string CustomField7 { get; set; }

		/// <summary>
		///     CustomField8 represents the 8th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField8")]
		public string CustomField8 { get; set; }

		/// <summary>
		///     CustomField9 represents the 9th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField9")]
		public string CustomField9 { get; set; }

		/// <summary>
		///     Datasheet is the name of an datasheet file (in the media files)
		///     or a URL to the datasheet on the internet.
		/// </summary>
		[JsonProperty("datasheet")]
		public string Datasheet { get; set; }

		/// <summary>
		///     Description of the product.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     Eclasses is a list of eCl@ss categories the product belongs to.
		/// </summary>
		[JsonProperty("eclasses")]
		public Eclass[] Eclasses { get; set; }

		/// <summary>
		///     erpGroupSupplier is the material group of the product on the
		///     merchant-/supplier-side.
		/// </summary>
		[JsonProperty("erpGroupSupplier")]
		public string ErpGroupSupplier { get; set; }

		/// <summary>
		///     Excluded is a flag that indicates whether to exclude this
		///     product from the catalog. If true, this product will not be
		///     published into the live area.
		/// </summary>
		[JsonProperty("excluded")]
		public bool Excluded { get; set; }

		/// <summary>
		///     ExtCategory is the EXT_CATEGORY field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategory")]
		public string ExtCategory { get; set; }

		/// <summary>
		///     ExtCategoryID is the EXT_CATEGORY_ID field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategoryId")]
		public string ExtCategoryId { get; set; }

		/// <summary>
		///     ExtConfigForm represents information required to make the
		///     product configurable. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("extConfigForm")]
		public string ExtConfigForm { get; set; }

		/// <summary>
		///     ExtConfigService represents additional information required to
		///     make the product configurable. See also ExtConfigForm. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("extConfigService")]
		public string ExtConfigService { get; set; }

		/// <summary>
		///     ExtProductID is the EXT_PRODUCT_ID field of the SAP OCI
		///     specification. It is e.g. required for configurable/catalog
		///     managed products.
		/// </summary>
		[JsonProperty("extProductId")]
		public string ExtProductId { get; set; }

		/// <summary>
		///     ExtSchemaType is the EXT_SCHEMA_TYPE field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extSchemaType")]
		public string ExtSchemaType { get; set; }

		/// <summary>
		///     Features defines product features, i.e. additional properties
		///     of the product.
		/// </summary>
		[JsonProperty("features")]
		public Feature[] Features { get; set; }

		/// <summary>
		///     GLAccount represents the GL account number to use for this
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("glAccount")]
		public string GlAccount { get; set; }

		/// <summary>
		///     GreenLogos is an array of green logo names, which are hosted in
		///     the store, and used to mark products as green.
		/// </summary>
		[JsonProperty("greenLogos")]
		public string[] GreenLogos { get; set; }

		/// <summary>
		///     GTIN is the global trade item number of the product (used to be
		///     EAN).
		/// </summary>
		[JsonProperty("gtin")]
		public string Gtin { get; set; }

		/// <summary>
		///     Hazmats classifies hazardous/dangerous goods.
		/// </summary>
		[JsonProperty("hazmats")]
		public Hazmat[] Hazmats { get; set; }

		/// <summary>
		///     Image is the name of an image file (in the media files) or a
		///     URL to the image on the internet.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		///     Incomplete is a flag that indicates whether this product is
		///     incomplete. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("incomplete")]
		public bool? Incomplete { get; set; }

		/// <summary>
		///     Intrastat specifies required data for Intrastat messages. 
		/// </summary>
		[JsonProperty("intrastat")]
		public Intrastat Intrastat { get; set; }

		/// <summary>
		///     IsPassword is a flag that indicates whether this product will
		///     be used to purchase a password, e.g. for a software product.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("isPassword")]
		public bool? IsPassword { get; set; }

		/// <summary>
		///     KeepPrice is a flag that indicates whether the price of the
		///     product will or will not be calculated by the catalog. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("keepPrice")]
		public bool? KeepPrice { get; set; }

		/// <summary>
		///     Keywords is a list of aliases for the product.
		/// </summary>
		[JsonProperty("keywords")]
		public string[] Keywords { get; set; }

		/// <summary>
		///     Leadtime is the number of days for delivery.
		/// </summary>
		[JsonProperty("leadtime")]
		public double? Leadtime { get; set; }

		/// <summary>
		///     ListPrice is the net list price of the product.
		/// </summary>
		[JsonProperty("listPrice")]
		public double? ListPrice { get; set; }

		/// <summary>
		///     Manufactcode is the manufacturer code as used in the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("manufactcode")]
		public string Manufactcode { get; set; }

		/// <summary>
		///     Manufacturer is the name of the manufacturer.
		/// </summary>
		[JsonProperty("manufacturer")]
		public string Manufacturer { get; set; }

		/// <summary>
		///     Matgroup is the material group of the product on the buy-side.
		/// </summary>
		[JsonProperty("matgroup")]
		public string Matgroup { get; set; }

		/// <summary>
		///     MPN is the manufacturer part number.
		/// </summary>
		[JsonProperty("mpn")]
		public string Mpn { get; set; }

		/// <summary>
		///     MultiSupplierID represents an optional field for the unique
		///     identifier of a supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierId")]
		public string MultiSupplierId { get; set; }

		/// <summary>
		///     MultiSupplierName represents an optional field for the name of
		///     the supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierName")]
		public string MultiSupplierName { get; set; }

		/// <summary>
		///     Name of the product.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     NeedsGoodsReceipt is a flag that indicates whether this product
		///     requires a goods receipt process. Please consult your Store
		///     Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("needsGoodsReceipt")]
		public bool? NeedsGoodsReceipt { get; set; }

		/// <summary>
		///     NFBasePrice represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfBasePrice")]
		public double? NfBasePrice { get; set; }

		/// <summary>
		///     NFBasePriceQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfBasePriceQuantity")]
		public double? NfBasePriceQuantity { get; set; }

		/// <summary>
		///     NFCndID represents the key to calculate metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfCndId")]
		public string NfCndId { get; set; }

		/// <summary>
		///     NFScale represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfScale")]
		public double? NfScale { get; set; }

		/// <summary>
		///     NFScaleQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfScaleQuantity")]
		public double? NfScaleQuantity { get; set; }

		/// <summary>
		///     Orderable is a flag that indicates whether this product will be
		///     orderable to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("orderable")]
		public bool? Orderable { get; set; }

		/// <summary>
		///     OrderUnit is the order unit of the product, a 3-character ISO
		///     code (usually project-specific).
		/// </summary>
		[JsonProperty("ou")]
		public string OrderUnit { get; set; }

		/// <summary>
		///     Price is the net price (per order unit) of the product for the
		///     end-user.
		/// </summary>
		[JsonProperty("price")]
		public double Price { get; set; }

		/// <summary>
		///     PriceFormula represents the formula to calculate the price of
		///     the product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("priceFormula")]
		public string PriceFormula { get; set; }

		/// <summary>
		///     PriceQty is the quantity for which the price is specified
		///     (default: 1.0).
		/// </summary>
		[JsonProperty("priceQty")]
		public double PriceQty { get; set; }

		/// <summary>
		///     QuantityInterval is the interval in which this product can be
		///     ordered. E.g. if the quantity interval is 5, the end-user can
		///     only order in quantities of 5,10,15 etc. 
		/// </summary>
		[JsonProperty("quantityInterval")]
		public double? QuantityInterval { get; set; }

		/// <summary>
		///     QuantityMax is the maximum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMax")]
		public double? QuantityMax { get; set; }

		/// <summary>
		///     QuantityMin is the minimum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMin")]
		public double? QuantityMin { get; set; }

		/// <summary>
		///     Rateable is a flag that indicates whether the product can be
		///     rated by end-users. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("rateable")]
		public bool? Rateable { get; set; }

		/// <summary>
		///     RateableOnlyIfOrdered is a flag that indicates whether the
		///     product can be rated only after being ordered. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("rateableOnlyIfOrdered")]
		public bool? RateableOnlyIfOrdered { get; set; }

		/// <summary>
		///     References defines cross-product references, e.g. alternatives
		///     or follow-up products.
		/// </summary>
		[JsonProperty("references")]
		public Reference[] References { get; set; }

		/// <summary>
		///     Safetysheet is the name of an safetysheet file (in the media
		///     files) or a URL to the safetysheet on the internet.
		/// </summary>
		[JsonProperty("safetysheet")]
		public string Safetysheet { get; set; }

		/// <summary>
		///     ScalePrices can be used when the price of the product is
		///     dependent on the ordered quantity.
		/// </summary>
		[JsonProperty("scalePrices")]
		public ScalePrice[] ScalePrices { get; set; }

		/// <summary>
		///     Service indicates if the is a good (false) or a service (true).
		///     The default value is false.
		/// </summary>
		[JsonProperty("service")]
		public bool Service { get; set; }

		/// <summary>
		///     TaxCode to use for this product. This is typically
		///     project-specific.
		/// </summary>
		[JsonProperty("taxCode")]
		public string TaxCode { get; set; }

		/// <summary>
		///     TaxRate for this product, a numeric value between 0.0 and 1.0.
		/// </summary>
		[JsonProperty("taxRate")]
		public double TaxRate { get; set; }

		/// <summary>
		///     Thumbnail is the name of an thumbnail image file (in the media
		///     files) or a URL to the image on the internet.
		/// </summary>
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		/// <summary>
		///     Unspscs is a list of UNSPSC categories the product belongs to.
		/// </summary>
		[JsonProperty("unspscs")]
		public Unspsc[] Unspscs { get; set; }

		/// <summary>
		///     Visible is a flag that indicates whether this product will be
		///     visible to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("visible")]
		public bool? Visible { get; set; }

		#endregion // ReplaceProduct
	}

	/// <summary>
	///     ReplaceProductResponse is the outcome of a successful
	///     replacement of a product.
	/// </summary>
	public class ReplaceProductResponse
	{
		#region ReplaceProductResponse

		/// <summary>
		///     Kind describes this entity.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Link returns a URL to the representation of the replaced
		///     product.
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		#endregion // ReplaceProductResponse
	}

	/// <summary>
	///     ScalePrice describes a price that is dependent on the ordered
	///     quantity.
	/// </summary>
	public class ScalePrice
	{
		#region ScalePrice

		/// <summary>
		///     LBound is the lower bound when this price will become
		///     effective.
		/// </summary>
		[JsonProperty("lbound")]
		public double Lbound { get; set; }

		/// <summary>
		///     ListPrice is the list price for the given lower bound.
		/// </summary>
		[JsonProperty("listPrice")]
		public double? ListPrice { get; set; }

		/// <summary>
		///     MeplatoPrice is the Meplato price for the given lower bound.
		/// </summary>
		[JsonProperty("meplatoPrice")]
		public double? MeplatoPrice { get; set; }

		/// <summary>
		///     Price is the net price for the given lower bound.
		/// </summary>
		[JsonProperty("price")]
		public double Price { get; set; }

		#endregion // ScalePrice
	}

	/// <summary>
	///     ScrollResponse is a slice of products from a catalog.
	/// </summary>
	public class ScrollResponse
	{
		#region ScrollResponse

		/// <summary>
		///     Items is the slice of products of this result.
		/// </summary>
		[JsonProperty("items")]
		public Product[] Items { get; set; }

		/// <summary>
		///     Kind is store#products/scroll for this kind of response.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     NextLink returns the URL to the next slice of products (if
		///     any).
		/// </summary>
		[JsonProperty("nextLink")]
		public string NextLink { get; set; }

		/// <summary>
		///     PageToken needs to be passed to get the next slice of products.
		///     It is blank if there are no more products. Instead of using
		///     pageToken for your next request, you can also follow nextLink.
		/// </summary>
		[JsonProperty("pageToken")]
		public string PageToken { get; set; }

		/// <summary>
		///     PreviousLink returns the URL of the previous slice of products
		///     (if any).
		/// </summary>
		[JsonProperty("previousLink")]
		public string PreviousLink { get; set; }

		/// <summary>
		///     SelfLink returns the URL to this page.
		/// </summary>
		[JsonProperty("selfLink")]
		public string SelfLink { get; set; }

		/// <summary>
		///     TotalItems describes the total number of products found.
		/// </summary>
		[JsonProperty("totalItems")]
		public long TotalItems { get; set; }

		#endregion // ScrollResponse
	}

	/// <summary>
	///     SearchResponse is a partial listing of products.
	/// </summary>
	public class SearchResponse
	{
		#region SearchResponse

		/// <summary>
		///     Items is the slice of products of this result.
		/// </summary>
		[JsonProperty("items")]
		public Product[] Items { get; set; }

		/// <summary>
		///     Kind is store#products/search for this kind of response.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     NextLink returns the URL to the next slice of products (if
		///     any).
		/// </summary>
		[JsonProperty("nextLink")]
		public string NextLink { get; set; }

		/// <summary>
		///     PreviousLink returns the URL of the previous slice of products
		///     (if any).
		/// </summary>
		[JsonProperty("previousLink")]
		public string PreviousLink { get; set; }

		/// <summary>
		///     SelfLink returns the URL to this page.
		/// </summary>
		[JsonProperty("selfLink")]
		public string SelfLink { get; set; }

		/// <summary>
		///     TotalItems describes the total number of products found.
		/// </summary>
		[JsonProperty("totalItems")]
		public long TotalItems { get; set; }

		#endregion // SearchResponse
	}

	/// <summary>
	///     Unspsc is used to tie a product to a UNSPSC schema.
	/// </summary>
	public class Unspsc
	{
		#region Unspsc

		/// <summary>
		///     Code is the UNSPSC code. Only use digits for encoding, e.g.
		///     43211503.
		/// </summary>
		[JsonProperty("code")]
		public string Code { get; set; }

		/// <summary>
		///     Version is the UNSPSC version in the major.minor format, e.g.
		///     16.0901.
		/// </summary>
		[JsonProperty("version")]
		public string Version { get; set; }

		#endregion // Unspsc
	}

	/// <summary>
	///     UpdateProduct holds the properties of a product that need to be
	///     updated.
	/// </summary>
	[Serializable]
	public class UpdateProduct : ISerializable
	{
		#region UpdateProduct

		#region Asin
		private string _asin;
		private bool _hasAsin;

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		public string Asin
		{
			get => _asin;
			set
			{
				_asin = value;
				_hasAsin = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetAsin()
		{
			_asin = null;
			_hasAsin = false;
		}

		#endregion // Asin

		#region AutoConfigure
		private bool? _autoConfigure;
		private bool _hasAutoConfigure;

		/// <summary>
		///     AutoConfigure is a flag that indicates whether this product can
		///     be configured automatically. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		public bool? AutoConfigure
		{
			get => _autoConfigure;
			set
			{
				_autoConfigure = value;
				_hasAutoConfigure = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetAutoConfigure()
		{
			_autoConfigure = null;
			_hasAutoConfigure = false;
		}

		#endregion // AutoConfigure

		#region Availability
		private Availability _availability;
		private bool _hasAvailability;

		/// <summary>
		///     Availability allows the update of product availability data,
		///     e.g. the number of items in stock or the date when the product
		///     will be available again. 
		/// </summary>
		public Availability Availability
		{
			get => _availability;
			set
			{
				_availability = value;
				_hasAvailability = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetAvailability()
		{
			_availability = null;
			_hasAvailability = false;
		}

		#endregion // Availability

		#region Blobs
		private Blob[] _blobs;
		private bool _hasBlobs;

		/// <summary>
		///     Blobs specifies external data, e.g. images or datasheets.
		/// </summary>
		public Blob[] Blobs
		{
			get => _blobs;
			set
			{
				_blobs = value;
				_hasBlobs = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetBlobs()
		{
			_blobs = null;
			_hasBlobs = false;
		}

		#endregion // Blobs

		#region BoostFactor
		private double? _boostFactor;
		private bool _hasBoostFactor;

		/// <summary>
		///     BoostFactor represents a positive or negative boost for the
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public double? BoostFactor
		{
			get => _boostFactor;
			set
			{
				_boostFactor = value;
				_hasBoostFactor = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetBoostFactor()
		{
			_boostFactor = null;
			_hasBoostFactor = false;
		}

		#endregion // BoostFactor

		#region Bpn
		private string _bpn;
		private bool _hasBpn;

		/// <summary>
		///     BPN is the buyer part number of the product.
		/// </summary>
		public string Bpn
		{
			get => _bpn;
			set
			{
				_bpn = value;
				_hasBpn = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetBpn()
		{
			_bpn = null;
			_hasBpn = false;
		}

		#endregion // Bpn

		#region Brand
		private string _brand;
		private bool _hasBrand;

		/// <summary>
		///     Brand is the commercial brand name of the product (i.e.
		///     end-consumer recognizable brand name)
		/// </summary>
		public string Brand
		{
			get => _brand;
			set
			{
				_brand = value;
				_hasBrand = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetBrand()
		{
			_brand = null;
			_hasBrand = false;
		}

		#endregion // Brand

		#region CatalogManaged
		private bool? _catalogManaged;
		private bool _hasCatalogManaged;

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		public bool? CatalogManaged
		{
			get => _catalogManaged;
			set
			{
				_catalogManaged = value;
				_hasCatalogManaged = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCatalogManaged()
		{
			_catalogManaged = null;
			_hasCatalogManaged = false;
		}

		#endregion // CatalogManaged

		#region Categories
		private string[] _categories;
		private bool _hasCategories;

		/// <summary>
		///     Categories is a list of (supplier-specific) category names the
		///     product belongs to.
		/// </summary>
		public string[] Categories
		{
			get => _categories;
			set
			{
				_categories = value;
				_hasCategories = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCategories()
		{
			_categories = null;
			_hasCategories = false;
		}

		#endregion // Categories

		#region Conditions
		private Condition[] _conditions;
		private bool _hasConditions;

		/// <summary>
		///     Conditions describes the product conditions, e.g. refurbished
		///     or used.
		/// </summary>
		public Condition[] Conditions
		{
			get => _conditions;
			set
			{
				_conditions = value;
				_hasConditions = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetConditions()
		{
			_conditions = null;
			_hasConditions = false;
		}

		#endregion // Conditions

		#region Contract
		private string _contract;
		private bool _hasContract;

		/// <summary>
		///     Contract represents the contract number to be used when
		///     purchasing this product. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		public string Contract
		{
			get => _contract;
			set
			{
				_contract = value;
				_hasContract = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetContract()
		{
			_contract = null;
			_hasContract = false;
		}

		#endregion // Contract

		#region ContractItem
		private string _contractItem;
		private bool _hasContractItem;

		/// <summary>
		///     ContractItem represents line number in the contract to be used
		///     when purchasing this product. See also Contract. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		public string ContractItem
		{
			get => _contractItem;
			set
			{
				_contractItem = value;
				_hasContractItem = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetContractItem()
		{
			_contractItem = null;
			_hasContractItem = false;
		}

		#endregion // ContractItem

		#region ConversionDenumerator
		private double? _conversionDenumerator;
		private bool _hasConversionDenumerator;

		/// <summary>
		///     ConversionDenumerator is the denumerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public double? ConversionDenumerator
		{
			get => _conversionDenumerator;
			set
			{
				_conversionDenumerator = value;
				_hasConversionDenumerator = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetConversionDenumerator()
		{
			_conversionDenumerator = null;
			_hasConversionDenumerator = false;
		}

		#endregion // ConversionDenumerator

		#region ConversionNumerator
		private double? _conversionNumerator;
		private bool _hasConversionNumerator;

		/// <summary>
		///     ConversionNumerator is the numerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public double? ConversionNumerator
		{
			get => _conversionNumerator;
			set
			{
				_conversionNumerator = value;
				_hasConversionNumerator = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetConversionNumerator()
		{
			_conversionNumerator = null;
			_hasConversionNumerator = false;
		}

		#endregion // ConversionNumerator

		#region Country
		private string _country;
		private bool _hasCountry;

		/// <summary>
		///     Country/Region represents the ISO code of the country/region of
		///     origin, i.e. the country/region where the product has been
		///     created/produced, e.g. DE. If unspecified, the field is
		///     initialized with the catalog's country/region field. 
		/// </summary>
		public string Country
		{
			get => _country;
			set
			{
				_country = value;
				_hasCountry = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCountry()
		{
			_country = null;
			_hasCountry = false;
		}

		#endregion // Country

		#region ContentUnit
		private string _cu;
		private bool _hasContentUnit;

		/// <summary>
		///     ContentUnit is the content unit of the product, a 3-character
		///     ISO code (usually project-specific).
		/// </summary>
		public string ContentUnit
		{
			get => _cu;
			set
			{
				_cu = value;
				_hasContentUnit = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetContentUnit()
		{
			_cu = null;
			_hasContentUnit = false;
		}

		#endregion // ContentUnit

		#region CuPerOu
		private double? _cuPerOu;
		private bool _hasCuPerOu;

		/// <summary>
		///     CuPerOu describes the number of content units per order unit,
		///     e.g. the 12 in '1 case contains 12 bottles'.
		/// </summary>
		public double? CuPerOu
		{
			get => _cuPerOu;
			set
			{
				_cuPerOu = value;
				_hasCuPerOu = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCuPerOu()
		{
			_cuPerOu = null;
			_hasCuPerOu = false;
		}

		#endregion // CuPerOu

		#region Currency
		private string _currency;
		private bool _hasCurrency;

		/// <summary>
		///     Currency is the ISO currency code for the prices, e.g. EUR or
		///     GBP. If you pass an empty currency code, it will be initialized
		///     with the catalog's currency. 
		/// </summary>
		public string Currency
		{
			get => _currency;
			set
			{
				_currency = value;
				_hasCurrency = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCurrency()
		{
			_currency = null;
			_hasCurrency = false;
		}

		#endregion // Currency

		#region CustField1
		private string _custField1;
		private bool _hasCustField1;

		/// <summary>
		///     CustField1 is the CUST_FIELD1 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		public string CustField1
		{
			get => _custField1;
			set
			{
				_custField1 = value;
				_hasCustField1 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustField1()
		{
			_custField1 = null;
			_hasCustField1 = false;
		}

		#endregion // CustField1

		#region CustField2
		private string _custField2;
		private bool _hasCustField2;

		/// <summary>
		///     CustField2 is the CUST_FIELD2 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		public string CustField2
		{
			get => _custField2;
			set
			{
				_custField2 = value;
				_hasCustField2 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustField2()
		{
			_custField2 = null;
			_hasCustField2 = false;
		}

		#endregion // CustField2

		#region CustField3
		private string _custField3;
		private bool _hasCustField3;

		/// <summary>
		///     CustField3 is the CUST_FIELD3 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		public string CustField3
		{
			get => _custField3;
			set
			{
				_custField3 = value;
				_hasCustField3 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustField3()
		{
			_custField3 = null;
			_hasCustField3 = false;
		}

		#endregion // CustField3

		#region CustField4
		private string _custField4;
		private bool _hasCustField4;

		/// <summary>
		///     CustField4 is the CUST_FIELD4 of the SAP OCI specification. It
		///     has a maximum length of 20 characters. 
		/// </summary>
		public string CustField4
		{
			get => _custField4;
			set
			{
				_custField4 = value;
				_hasCustField4 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustField4()
		{
			_custField4 = null;
			_hasCustField4 = false;
		}

		#endregion // CustField4

		#region CustField5
		private string _custField5;
		private bool _hasCustField5;

		/// <summary>
		///     CustField5 is the CUST_FIELD5 of the SAP OCI specification. It
		///     has a maximum length of 50 characters. 
		/// </summary>
		public string CustField5
		{
			get => _custField5;
			set
			{
				_custField5 = value;
				_hasCustField5 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustField5()
		{
			_custField5 = null;
			_hasCustField5 = false;
		}

		#endregion // CustField5

		#region CustFields
		private CustField[] _custFields;
		private bool _hasCustFields;

		/// <summary>
		///     CustFields is an array of generic name/value pairs for
		///     customer-specific attributes.
		/// </summary>
		public CustField[] CustFields
		{
			get => _custFields;
			set
			{
				_custFields = value;
				_hasCustFields = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustFields()
		{
			_custFields = null;
			_hasCustFields = false;
		}

		#endregion // CustFields

		#region CustomField10
		private string _customField10;
		private bool _hasCustomField10;

		/// <summary>
		///     CustomField10 represents the 10th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField10
		{
			get => _customField10;
			set
			{
				_customField10 = value;
				_hasCustomField10 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField10()
		{
			_customField10 = null;
			_hasCustomField10 = false;
		}

		#endregion // CustomField10

		#region CustomField11
		private string _customField11;
		private bool _hasCustomField11;

		/// <summary>
		///     CustomField11 represents the 11th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField11
		{
			get => _customField11;
			set
			{
				_customField11 = value;
				_hasCustomField11 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField11()
		{
			_customField11 = null;
			_hasCustomField11 = false;
		}

		#endregion // CustomField11

		#region CustomField12
		private string _customField12;
		private bool _hasCustomField12;

		/// <summary>
		///     CustomField12 represents the 12th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField12
		{
			get => _customField12;
			set
			{
				_customField12 = value;
				_hasCustomField12 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField12()
		{
			_customField12 = null;
			_hasCustomField12 = false;
		}

		#endregion // CustomField12

		#region CustomField13
		private string _customField13;
		private bool _hasCustomField13;

		/// <summary>
		///     CustomField13 represents the 13th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField13
		{
			get => _customField13;
			set
			{
				_customField13 = value;
				_hasCustomField13 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField13()
		{
			_customField13 = null;
			_hasCustomField13 = false;
		}

		#endregion // CustomField13

		#region CustomField14
		private string _customField14;
		private bool _hasCustomField14;

		/// <summary>
		///     CustomField14 represents the 14th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField14
		{
			get => _customField14;
			set
			{
				_customField14 = value;
				_hasCustomField14 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField14()
		{
			_customField14 = null;
			_hasCustomField14 = false;
		}

		#endregion // CustomField14

		#region CustomField15
		private string _customField15;
		private bool _hasCustomField15;

		/// <summary>
		///     CustomField15 represents the 15th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField15
		{
			get => _customField15;
			set
			{
				_customField15 = value;
				_hasCustomField15 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField15()
		{
			_customField15 = null;
			_hasCustomField15 = false;
		}

		#endregion // CustomField15

		#region CustomField16
		private string _customField16;
		private bool _hasCustomField16;

		/// <summary>
		///     CustomField16 represents the 16th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField16
		{
			get => _customField16;
			set
			{
				_customField16 = value;
				_hasCustomField16 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField16()
		{
			_customField16 = null;
			_hasCustomField16 = false;
		}

		#endregion // CustomField16

		#region CustomField17
		private string _customField17;
		private bool _hasCustomField17;

		/// <summary>
		///     CustomField17 represents the 17th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField17
		{
			get => _customField17;
			set
			{
				_customField17 = value;
				_hasCustomField17 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField17()
		{
			_customField17 = null;
			_hasCustomField17 = false;
		}

		#endregion // CustomField17

		#region CustomField18
		private string _customField18;
		private bool _hasCustomField18;

		/// <summary>
		///     CustomField18 represents the 18th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField18
		{
			get => _customField18;
			set
			{
				_customField18 = value;
				_hasCustomField18 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField18()
		{
			_customField18 = null;
			_hasCustomField18 = false;
		}

		#endregion // CustomField18

		#region CustomField19
		private string _customField19;
		private bool _hasCustomField19;

		/// <summary>
		///     CustomField19 represents the 19th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField19
		{
			get => _customField19;
			set
			{
				_customField19 = value;
				_hasCustomField19 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField19()
		{
			_customField19 = null;
			_hasCustomField19 = false;
		}

		#endregion // CustomField19

		#region CustomField20
		private string _customField20;
		private bool _hasCustomField20;

		/// <summary>
		///     CustomField20 represents the 20th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField20
		{
			get => _customField20;
			set
			{
				_customField20 = value;
				_hasCustomField20 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField20()
		{
			_customField20 = null;
			_hasCustomField20 = false;
		}

		#endregion // CustomField20

		#region CustomField21
		private string _customField21;
		private bool _hasCustomField21;

		/// <summary>
		///     CustomField21 represents the 21st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField21
		{
			get => _customField21;
			set
			{
				_customField21 = value;
				_hasCustomField21 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField21()
		{
			_customField21 = null;
			_hasCustomField21 = false;
		}

		#endregion // CustomField21

		#region CustomField22
		private string _customField22;
		private bool _hasCustomField22;

		/// <summary>
		///     CustomField22 represents the 22nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField22
		{
			get => _customField22;
			set
			{
				_customField22 = value;
				_hasCustomField22 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField22()
		{
			_customField22 = null;
			_hasCustomField22 = false;
		}

		#endregion // CustomField22

		#region CustomField23
		private string _customField23;
		private bool _hasCustomField23;

		/// <summary>
		///     CustomField23 represents the 23rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField23
		{
			get => _customField23;
			set
			{
				_customField23 = value;
				_hasCustomField23 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField23()
		{
			_customField23 = null;
			_hasCustomField23 = false;
		}

		#endregion // CustomField23

		#region CustomField24
		private string _customField24;
		private bool _hasCustomField24;

		/// <summary>
		///     CustomField24 represents the 24th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField24
		{
			get => _customField24;
			set
			{
				_customField24 = value;
				_hasCustomField24 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField24()
		{
			_customField24 = null;
			_hasCustomField24 = false;
		}

		#endregion // CustomField24

		#region CustomField25
		private string _customField25;
		private bool _hasCustomField25;

		/// <summary>
		///     CustomField25 represents the 25th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField25
		{
			get => _customField25;
			set
			{
				_customField25 = value;
				_hasCustomField25 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField25()
		{
			_customField25 = null;
			_hasCustomField25 = false;
		}

		#endregion // CustomField25

		#region CustomField26
		private string _customField26;
		private bool _hasCustomField26;

		/// <summary>
		///     CustomField26 represents the 26th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField26
		{
			get => _customField26;
			set
			{
				_customField26 = value;
				_hasCustomField26 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField26()
		{
			_customField26 = null;
			_hasCustomField26 = false;
		}

		#endregion // CustomField26

		#region CustomField27
		private string _customField27;
		private bool _hasCustomField27;

		/// <summary>
		///     CustomField27 represents the 27th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField27
		{
			get => _customField27;
			set
			{
				_customField27 = value;
				_hasCustomField27 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField27()
		{
			_customField27 = null;
			_hasCustomField27 = false;
		}

		#endregion // CustomField27

		#region CustomField28
		private string _customField28;
		private bool _hasCustomField28;

		/// <summary>
		///     CustomField28 represents the 28th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField28
		{
			get => _customField28;
			set
			{
				_customField28 = value;
				_hasCustomField28 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField28()
		{
			_customField28 = null;
			_hasCustomField28 = false;
		}

		#endregion // CustomField28

		#region CustomField29
		private string _customField29;
		private bool _hasCustomField29;

		/// <summary>
		///     CustomField29 represents the 29th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField29
		{
			get => _customField29;
			set
			{
				_customField29 = value;
				_hasCustomField29 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField29()
		{
			_customField29 = null;
			_hasCustomField29 = false;
		}

		#endregion // CustomField29

		#region CustomField30
		private string _customField30;
		private bool _hasCustomField30;

		/// <summary>
		///     CustomField30 represents the 30th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField30
		{
			get => _customField30;
			set
			{
				_customField30 = value;
				_hasCustomField30 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField30()
		{
			_customField30 = null;
			_hasCustomField30 = false;
		}

		#endregion // CustomField30

		#region CustomField31
		private string _customField31;
		private bool _hasCustomField31;

		/// <summary>
		///     CustomField31 represents the 31st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField31
		{
			get => _customField31;
			set
			{
				_customField31 = value;
				_hasCustomField31 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField31()
		{
			_customField31 = null;
			_hasCustomField31 = false;
		}

		#endregion // CustomField31

		#region CustomField32
		private string _customField32;
		private bool _hasCustomField32;

		/// <summary>
		///     CustomField32 represents the 32nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField32
		{
			get => _customField32;
			set
			{
				_customField32 = value;
				_hasCustomField32 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField32()
		{
			_customField32 = null;
			_hasCustomField32 = false;
		}

		#endregion // CustomField32

		#region CustomField33
		private string _customField33;
		private bool _hasCustomField33;

		/// <summary>
		///     CustomField33 represents the 33rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField33
		{
			get => _customField33;
			set
			{
				_customField33 = value;
				_hasCustomField33 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField33()
		{
			_customField33 = null;
			_hasCustomField33 = false;
		}

		#endregion // CustomField33

		#region CustomField34
		private string _customField34;
		private bool _hasCustomField34;

		/// <summary>
		///     CustomField34 represents the 34th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField34
		{
			get => _customField34;
			set
			{
				_customField34 = value;
				_hasCustomField34 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField34()
		{
			_customField34 = null;
			_hasCustomField34 = false;
		}

		#endregion // CustomField34

		#region CustomField35
		private string _customField35;
		private bool _hasCustomField35;

		/// <summary>
		///     CustomField35 represents the 35th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField35
		{
			get => _customField35;
			set
			{
				_customField35 = value;
				_hasCustomField35 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField35()
		{
			_customField35 = null;
			_hasCustomField35 = false;
		}

		#endregion // CustomField35

		#region CustomField36
		private string _customField36;
		private bool _hasCustomField36;

		/// <summary>
		///     CustomField36 represents the 36th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField36
		{
			get => _customField36;
			set
			{
				_customField36 = value;
				_hasCustomField36 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField36()
		{
			_customField36 = null;
			_hasCustomField36 = false;
		}

		#endregion // CustomField36

		#region CustomField37
		private string _customField37;
		private bool _hasCustomField37;

		/// <summary>
		///     CustomField37 represents the 37th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField37
		{
			get => _customField37;
			set
			{
				_customField37 = value;
				_hasCustomField37 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField37()
		{
			_customField37 = null;
			_hasCustomField37 = false;
		}

		#endregion // CustomField37

		#region CustomField38
		private string _customField38;
		private bool _hasCustomField38;

		/// <summary>
		///     CustomField38 represents the 38th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField38
		{
			get => _customField38;
			set
			{
				_customField38 = value;
				_hasCustomField38 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField38()
		{
			_customField38 = null;
			_hasCustomField38 = false;
		}

		#endregion // CustomField38

		#region CustomField39
		private string _customField39;
		private bool _hasCustomField39;

		/// <summary>
		///     CustomField39 represents the 39th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField39
		{
			get => _customField39;
			set
			{
				_customField39 = value;
				_hasCustomField39 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField39()
		{
			_customField39 = null;
			_hasCustomField39 = false;
		}

		#endregion // CustomField39

		#region CustomField40
		private string _customField40;
		private bool _hasCustomField40;

		/// <summary>
		///     CustomField40 represents the 40th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField40
		{
			get => _customField40;
			set
			{
				_customField40 = value;
				_hasCustomField40 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField40()
		{
			_customField40 = null;
			_hasCustomField40 = false;
		}

		#endregion // CustomField40

		#region CustomField41
		private string _customField41;
		private bool _hasCustomField41;

		/// <summary>
		///     CustomField41 represents the 41st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField41
		{
			get => _customField41;
			set
			{
				_customField41 = value;
				_hasCustomField41 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField41()
		{
			_customField41 = null;
			_hasCustomField41 = false;
		}

		#endregion // CustomField41

		#region CustomField42
		private string _customField42;
		private bool _hasCustomField42;

		/// <summary>
		///     CustomField42 represents the 42nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField42
		{
			get => _customField42;
			set
			{
				_customField42 = value;
				_hasCustomField42 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField42()
		{
			_customField42 = null;
			_hasCustomField42 = false;
		}

		#endregion // CustomField42

		#region CustomField43
		private string _customField43;
		private bool _hasCustomField43;

		/// <summary>
		///     CustomField43 represents the 43rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField43
		{
			get => _customField43;
			set
			{
				_customField43 = value;
				_hasCustomField43 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField43()
		{
			_customField43 = null;
			_hasCustomField43 = false;
		}

		#endregion // CustomField43

		#region CustomField44
		private string _customField44;
		private bool _hasCustomField44;

		/// <summary>
		///     CustomField44 represents the 44th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField44
		{
			get => _customField44;
			set
			{
				_customField44 = value;
				_hasCustomField44 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField44()
		{
			_customField44 = null;
			_hasCustomField44 = false;
		}

		#endregion // CustomField44

		#region CustomField45
		private string _customField45;
		private bool _hasCustomField45;

		/// <summary>
		///     CustomField45 represents the 45th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField45
		{
			get => _customField45;
			set
			{
				_customField45 = value;
				_hasCustomField45 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField45()
		{
			_customField45 = null;
			_hasCustomField45 = false;
		}

		#endregion // CustomField45

		#region CustomField46
		private string _customField46;
		private bool _hasCustomField46;

		/// <summary>
		///     CustomField46 represents the 46th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField46
		{
			get => _customField46;
			set
			{
				_customField46 = value;
				_hasCustomField46 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField46()
		{
			_customField46 = null;
			_hasCustomField46 = false;
		}

		#endregion // CustomField46

		#region CustomField47
		private string _customField47;
		private bool _hasCustomField47;

		/// <summary>
		///     CustomField47 represents the 47th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField47
		{
			get => _customField47;
			set
			{
				_customField47 = value;
				_hasCustomField47 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField47()
		{
			_customField47 = null;
			_hasCustomField47 = false;
		}

		#endregion // CustomField47

		#region CustomField48
		private string _customField48;
		private bool _hasCustomField48;

		/// <summary>
		///     CustomField48 represents the 48th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField48
		{
			get => _customField48;
			set
			{
				_customField48 = value;
				_hasCustomField48 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField48()
		{
			_customField48 = null;
			_hasCustomField48 = false;
		}

		#endregion // CustomField48

		#region CustomField49
		private string _customField49;
		private bool _hasCustomField49;

		/// <summary>
		///     CustomField49 represents the 49th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField49
		{
			get => _customField49;
			set
			{
				_customField49 = value;
				_hasCustomField49 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField49()
		{
			_customField49 = null;
			_hasCustomField49 = false;
		}

		#endregion // CustomField49

		#region CustomField50
		private string _customField50;
		private bool _hasCustomField50;

		/// <summary>
		///     CustomField50 represents the 50th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string CustomField50
		{
			get => _customField50;
			set
			{
				_customField50 = value;
				_hasCustomField50 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField50()
		{
			_customField50 = null;
			_hasCustomField50 = false;
		}

		#endregion // CustomField50

		#region CustomField6
		private string _customField6;
		private bool _hasCustomField6;

		/// <summary>
		///     CustomField6 represents the 6th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public string CustomField6
		{
			get => _customField6;
			set
			{
				_customField6 = value;
				_hasCustomField6 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField6()
		{
			_customField6 = null;
			_hasCustomField6 = false;
		}

		#endregion // CustomField6

		#region CustomField7
		private string _customField7;
		private bool _hasCustomField7;

		/// <summary>
		///     CustomField7 represents the 7th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public string CustomField7
		{
			get => _customField7;
			set
			{
				_customField7 = value;
				_hasCustomField7 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField7()
		{
			_customField7 = null;
			_hasCustomField7 = false;
		}

		#endregion // CustomField7

		#region CustomField8
		private string _customField8;
		private bool _hasCustomField8;

		/// <summary>
		///     CustomField8 represents the 8th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public string CustomField8
		{
			get => _customField8;
			set
			{
				_customField8 = value;
				_hasCustomField8 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField8()
		{
			_customField8 = null;
			_hasCustomField8 = false;
		}

		#endregion // CustomField8

		#region CustomField9
		private string _customField9;
		private bool _hasCustomField9;

		/// <summary>
		///     CustomField9 represents the 9th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public string CustomField9
		{
			get => _customField9;
			set
			{
				_customField9 = value;
				_hasCustomField9 = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetCustomField9()
		{
			_customField9 = null;
			_hasCustomField9 = false;
		}

		#endregion // CustomField9

		#region Datasheet
		private string _datasheet;
		private bool _hasDatasheet;

		/// <summary>
		///     Datasheet is the name of an datasheet file (in the media files)
		///     or a URL to the datasheet on the internet.
		/// </summary>
		public string Datasheet
		{
			get => _datasheet;
			set
			{
				_datasheet = value;
				_hasDatasheet = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetDatasheet()
		{
			_datasheet = null;
			_hasDatasheet = false;
		}

		#endregion // Datasheet

		#region Description
		private string _description;
		private bool _hasDescription;

		/// <summary>
		///     Description of the product.
		/// </summary>
		public string Description
		{
			get => _description;
			set
			{
				_description = value;
				_hasDescription = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetDescription()
		{
			_description = null;
			_hasDescription = false;
		}

		#endregion // Description

		#region Eclasses
		private Eclass[] _eclasses;
		private bool _hasEclasses;

		/// <summary>
		///     Eclasses is a list of eCl@ss categories the product belongs to.
		/// </summary>
		public Eclass[] Eclasses
		{
			get => _eclasses;
			set
			{
				_eclasses = value;
				_hasEclasses = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetEclasses()
		{
			_eclasses = null;
			_hasEclasses = false;
		}

		#endregion // Eclasses

		#region ErpGroupSupplier
		private string _erpGroupSupplier;
		private bool _hasErpGroupSupplier;

		/// <summary>
		///     erpGroupSupplier is the material group of the product on the
		///     merchant-/supplier-side.
		/// </summary>
		public string ErpGroupSupplier
		{
			get => _erpGroupSupplier;
			set
			{
				_erpGroupSupplier = value;
				_hasErpGroupSupplier = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetErpGroupSupplier()
		{
			_erpGroupSupplier = null;
			_hasErpGroupSupplier = false;
		}

		#endregion // ErpGroupSupplier

		#region Excluded
		private bool? _excluded;
		private bool _hasExcluded;

		/// <summary>
		///     Excluded is a flag that indicates whether to exclude this
		///     product from the catalog. If true, this product will not be
		///     published into the live area.
		/// </summary>
		public bool? Excluded
		{
			get => _excluded;
			set
			{
				_excluded = value;
				_hasExcluded = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExcluded()
		{
			_excluded = null;
			_hasExcluded = false;
		}

		#endregion // Excluded

		#region ExtCategory
		private string _extCategory;
		private bool _hasExtCategory;

		/// <summary>
		///     ExtCategory is the EXT_CATEGORY field of the SAP OCI
		///     specification.
		/// </summary>
		public string ExtCategory
		{
			get => _extCategory;
			set
			{
				_extCategory = value;
				_hasExtCategory = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtCategory()
		{
			_extCategory = null;
			_hasExtCategory = false;
		}

		#endregion // ExtCategory

		#region ExtCategoryId
		private string _extCategoryId;
		private bool _hasExtCategoryId;

		/// <summary>
		///     ExtCategoryID is the EXT_CATEGORY_ID field of the SAP OCI
		///     specification.
		/// </summary>
		public string ExtCategoryId
		{
			get => _extCategoryId;
			set
			{
				_extCategoryId = value;
				_hasExtCategoryId = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtCategoryId()
		{
			_extCategoryId = null;
			_hasExtCategoryId = false;
		}

		#endregion // ExtCategoryId

		#region ExtConfigForm
		private string _extConfigForm;
		private bool _hasExtConfigForm;

		/// <summary>
		///     ExtConfigForm represents information required to make the
		///     product configurable. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		public string ExtConfigForm
		{
			get => _extConfigForm;
			set
			{
				_extConfigForm = value;
				_hasExtConfigForm = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtConfigForm()
		{
			_extConfigForm = null;
			_hasExtConfigForm = false;
		}

		#endregion // ExtConfigForm

		#region ExtConfigService
		private string _extConfigService;
		private bool _hasExtConfigService;

		/// <summary>
		///     ExtConfigService represents additional information required to
		///     make the product configurable. See also ExtConfigForm. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public string ExtConfigService
		{
			get => _extConfigService;
			set
			{
				_extConfigService = value;
				_hasExtConfigService = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtConfigService()
		{
			_extConfigService = null;
			_hasExtConfigService = false;
		}

		#endregion // ExtConfigService

		#region ExtProductId
		private string _extProductId;
		private bool _hasExtProductId;

		/// <summary>
		///     ExtProductID is the EXT_PRODUCT_ID field of the SAP OCI
		///     specification. It is e.g. required for configurable/catalog
		///     managed products.
		/// </summary>
		public string ExtProductId
		{
			get => _extProductId;
			set
			{
				_extProductId = value;
				_hasExtProductId = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtProductId()
		{
			_extProductId = null;
			_hasExtProductId = false;
		}

		#endregion // ExtProductId

		#region ExtSchemaType
		private string _extSchemaType;
		private bool _hasExtSchemaType;

		/// <summary>
		///     ExtSchemaType is the EXT_SCHEMA_TYPE field of the SAP OCI
		///     specification.
		/// </summary>
		public string ExtSchemaType
		{
			get => _extSchemaType;
			set
			{
				_extSchemaType = value;
				_hasExtSchemaType = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetExtSchemaType()
		{
			_extSchemaType = null;
			_hasExtSchemaType = false;
		}

		#endregion // ExtSchemaType

		#region Features
		private Feature[] _features;
		private bool _hasFeatures;

		/// <summary>
		///     Features defines product features, i.e. additional properties
		///     of the product.
		/// </summary>
		public Feature[] Features
		{
			get => _features;
			set
			{
				_features = value;
				_hasFeatures = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetFeatures()
		{
			_features = null;
			_hasFeatures = false;
		}

		#endregion // Features

		#region GlAccount
		private string _glAccount;
		private bool _hasGlAccount;

		/// <summary>
		///     GLAccount represents the GL account number to use for this
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public string GlAccount
		{
			get => _glAccount;
			set
			{
				_glAccount = value;
				_hasGlAccount = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetGlAccount()
		{
			_glAccount = null;
			_hasGlAccount = false;
		}

		#endregion // GlAccount

		#region GreenLogos
		private string[] _greenLogos;
		private bool _hasGreenLogos;

		/// <summary>
		///     GreenLogos is an array of green logo names, which are hosted in
		///     the store, and used to mark products as green.
		/// </summary>
		public string[] GreenLogos
		{
			get => _greenLogos;
			set
			{
				_greenLogos = value;
				_hasGreenLogos = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetGreenLogos()
		{
			_greenLogos = null;
			_hasGreenLogos = false;
		}

		#endregion // GreenLogos

		#region Gtin
		private string _gtin;
		private bool _hasGtin;

		/// <summary>
		///     GTIN is the global trade item number of the product (used to be
		///     EAN).
		/// </summary>
		public string Gtin
		{
			get => _gtin;
			set
			{
				_gtin = value;
				_hasGtin = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetGtin()
		{
			_gtin = null;
			_hasGtin = false;
		}

		#endregion // Gtin

		#region Hazmats
		private Hazmat[] _hazmats;
		private bool _hasHazmats;

		/// <summary>
		///     Hazmats classifies hazardous/dangerous goods.
		/// </summary>
		public Hazmat[] Hazmats
		{
			get => _hazmats;
			set
			{
				_hazmats = value;
				_hasHazmats = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetHazmats()
		{
			_hazmats = null;
			_hasHazmats = false;
		}

		#endregion // Hazmats

		#region Image
		private string _image;
		private bool _hasImage;

		/// <summary>
		///     Image is the name of an image file (in the media files) or a
		///     URL to the image on the internet.
		/// </summary>
		public string Image
		{
			get => _image;
			set
			{
				_image = value;
				_hasImage = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetImage()
		{
			_image = null;
			_hasImage = false;
		}

		#endregion // Image

		#region Incomplete
		private bool? _incomplete;
		private bool _hasIncomplete;

		/// <summary>
		///     Incomplete is a flag that indicates whether this product is
		///     incomplete. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public bool? Incomplete
		{
			get => _incomplete;
			set
			{
				_incomplete = value;
				_hasIncomplete = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetIncomplete()
		{
			_incomplete = null;
			_hasIncomplete = false;
		}

		#endregion // Incomplete

		#region Intrastat
		private Intrastat _intrastat;
		private bool _hasIntrastat;

		/// <summary>
		///     Intrastat specifies required data for Intrastat messages. 
		/// </summary>
		public Intrastat Intrastat
		{
			get => _intrastat;
			set
			{
				_intrastat = value;
				_hasIntrastat = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetIntrastat()
		{
			_intrastat = null;
			_hasIntrastat = false;
		}

		#endregion // Intrastat

		#region IsPassword
		private bool? _isPassword;
		private bool _hasIsPassword;

		/// <summary>
		///     IsPassword is a flag that indicates whether this product will
		///     be used to purchase a password, e.g. for a software product.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public bool? IsPassword
		{
			get => _isPassword;
			set
			{
				_isPassword = value;
				_hasIsPassword = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetIsPassword()
		{
			_isPassword = null;
			_hasIsPassword = false;
		}

		#endregion // IsPassword

		#region KeepPrice
		private bool? _keepPrice;
		private bool _hasKeepPrice;

		/// <summary>
		///     KeepPrice is a flag that indicates whether the price of the
		///     product will or will not be calculated by the catalog. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		public bool? KeepPrice
		{
			get => _keepPrice;
			set
			{
				_keepPrice = value;
				_hasKeepPrice = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetKeepPrice()
		{
			_keepPrice = null;
			_hasKeepPrice = false;
		}

		#endregion // KeepPrice

		#region Keywords
		private string[] _keywords;
		private bool _hasKeywords;

		/// <summary>
		///     Keywords is a list of aliases for the product.
		/// </summary>
		public string[] Keywords
		{
			get => _keywords;
			set
			{
				_keywords = value;
				_hasKeywords = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetKeywords()
		{
			_keywords = null;
			_hasKeywords = false;
		}

		#endregion // Keywords

		#region Leadtime
		private double? _leadtime;
		private bool _hasLeadtime;

		/// <summary>
		///     Leadtime is the number of days for delivery.
		/// </summary>
		public double? Leadtime
		{
			get => _leadtime;
			set
			{
				_leadtime = value;
				_hasLeadtime = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetLeadtime()
		{
			_leadtime = null;
			_hasLeadtime = false;
		}

		#endregion // Leadtime

		#region ListPrice
		private double? _listPrice;
		private bool _hasListPrice;

		/// <summary>
		///     ListPrice is the net list price of the product.
		/// </summary>
		public double? ListPrice
		{
			get => _listPrice;
			set
			{
				_listPrice = value;
				_hasListPrice = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetListPrice()
		{
			_listPrice = null;
			_hasListPrice = false;
		}

		#endregion // ListPrice

		#region Manufactcode
		private string _manufactcode;
		private bool _hasManufactcode;

		/// <summary>
		///     Manufactcode is the manufacturer code as used in the SAP OCI
		///     specification.
		/// </summary>
		public string Manufactcode
		{
			get => _manufactcode;
			set
			{
				_manufactcode = value;
				_hasManufactcode = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetManufactcode()
		{
			_manufactcode = null;
			_hasManufactcode = false;
		}

		#endregion // Manufactcode

		#region Manufacturer
		private string _manufacturer;
		private bool _hasManufacturer;

		/// <summary>
		///     Manufacturer is the name of the manufacturer.
		/// </summary>
		public string Manufacturer
		{
			get => _manufacturer;
			set
			{
				_manufacturer = value;
				_hasManufacturer = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetManufacturer()
		{
			_manufacturer = null;
			_hasManufacturer = false;
		}

		#endregion // Manufacturer

		#region Matgroup
		private string _matgroup;
		private bool _hasMatgroup;

		/// <summary>
		///     Matgroup is the material group of the product on the buy-side.
		/// </summary>
		public string Matgroup
		{
			get => _matgroup;
			set
			{
				_matgroup = value;
				_hasMatgroup = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetMatgroup()
		{
			_matgroup = null;
			_hasMatgroup = false;
		}

		#endregion // Matgroup

		#region Mpn
		private string _mpn;
		private bool _hasMpn;

		/// <summary>
		///     MPN is the manufacturer part number.
		/// </summary>
		public string Mpn
		{
			get => _mpn;
			set
			{
				_mpn = value;
				_hasMpn = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetMpn()
		{
			_mpn = null;
			_hasMpn = false;
		}

		#endregion // Mpn

		#region MultiSupplierId
		private string _multiSupplierId;
		private bool _hasMultiSupplierId;

		/// <summary>
		///     MultiSupplierID represents an optional field for the unique
		///     identifier of a supplier in a multi-supplier catalog.
		/// </summary>
		public string MultiSupplierId
		{
			get => _multiSupplierId;
			set
			{
				_multiSupplierId = value;
				_hasMultiSupplierId = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetMultiSupplierId()
		{
			_multiSupplierId = null;
			_hasMultiSupplierId = false;
		}

		#endregion // MultiSupplierId

		#region MultiSupplierName
		private string _multiSupplierName;
		private bool _hasMultiSupplierName;

		/// <summary>
		///     MultiSupplierName represents an optional field for the name of
		///     the supplier in a multi-supplier catalog.
		/// </summary>
		public string MultiSupplierName
		{
			get => _multiSupplierName;
			set
			{
				_multiSupplierName = value;
				_hasMultiSupplierName = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetMultiSupplierName()
		{
			_multiSupplierName = null;
			_hasMultiSupplierName = false;
		}

		#endregion // MultiSupplierName

		#region Name
		private string _name;
		private bool _hasName;

		/// <summary>
		///     Name of the product.
		/// </summary>
		public string Name
		{
			get => _name;
			set
			{
				_name = value;
				_hasName = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetName()
		{
			_name = null;
			_hasName = false;
		}

		#endregion // Name

		#region NeedsGoodsReceipt
		private bool? _needsGoodsReceipt;
		private bool _hasNeedsGoodsReceipt;

		/// <summary>
		///     NeedsGoodsReceipt is a flag that indicates whether this product
		///     requires a goods receipt process. Please consult your Store
		///     Manager before setting a value for this field.
		/// </summary>
		public bool? NeedsGoodsReceipt
		{
			get => _needsGoodsReceipt;
			set
			{
				_needsGoodsReceipt = value;
				_hasNeedsGoodsReceipt = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNeedsGoodsReceipt()
		{
			_needsGoodsReceipt = null;
			_hasNeedsGoodsReceipt = false;
		}

		#endregion // NeedsGoodsReceipt

		#region NfBasePrice
		private double? _nfBasePrice;
		private bool _hasNfBasePrice;

		/// <summary>
		///     NFBasePrice represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public double? NfBasePrice
		{
			get => _nfBasePrice;
			set
			{
				_nfBasePrice = value;
				_hasNfBasePrice = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNfBasePrice()
		{
			_nfBasePrice = null;
			_hasNfBasePrice = false;
		}

		#endregion // NfBasePrice

		#region NfBasePriceQuantity
		private double? _nfBasePriceQuantity;
		private bool _hasNfBasePriceQuantity;

		/// <summary>
		///     NFBasePriceQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public double? NfBasePriceQuantity
		{
			get => _nfBasePriceQuantity;
			set
			{
				_nfBasePriceQuantity = value;
				_hasNfBasePriceQuantity = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNfBasePriceQuantity()
		{
			_nfBasePriceQuantity = null;
			_hasNfBasePriceQuantity = false;
		}

		#endregion // NfBasePriceQuantity

		#region NfCndId
		private string _nfCndId;
		private bool _hasNfCndId;

		/// <summary>
		///     NFCndID represents the key to calculate metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public string NfCndId
		{
			get => _nfCndId;
			set
			{
				_nfCndId = value;
				_hasNfCndId = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNfCndId()
		{
			_nfCndId = null;
			_hasNfCndId = false;
		}

		#endregion // NfCndId

		#region NfScale
		private double? _nfScale;
		private bool _hasNfScale;

		/// <summary>
		///     NFScale represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		public double? NfScale
		{
			get => _nfScale;
			set
			{
				_nfScale = value;
				_hasNfScale = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNfScale()
		{
			_nfScale = null;
			_hasNfScale = false;
		}

		#endregion // NfScale

		#region NfScaleQuantity
		private double? _nfScaleQuantity;
		private bool _hasNfScaleQuantity;

		/// <summary>
		///     NFScaleQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public double? NfScaleQuantity
		{
			get => _nfScaleQuantity;
			set
			{
				_nfScaleQuantity = value;
				_hasNfScaleQuantity = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetNfScaleQuantity()
		{
			_nfScaleQuantity = null;
			_hasNfScaleQuantity = false;
		}

		#endregion // NfScaleQuantity

		#region Orderable
		private bool? _orderable;
		private bool _hasOrderable;

		/// <summary>
		///     Orderable is a flag that indicates whether this product will be
		///     orderable to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		public bool? Orderable
		{
			get => _orderable;
			set
			{
				_orderable = value;
				_hasOrderable = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetOrderable()
		{
			_orderable = null;
			_hasOrderable = false;
		}

		#endregion // Orderable

		#region OrderUnit
		private string _ou;
		private bool _hasOrderUnit;

		/// <summary>
		///     OrderUnit is the order unit of the product, a 3-character ISO
		///     code (usually project-specific).
		/// </summary>
		public string OrderUnit
		{
			get => _ou;
			set
			{
				_ou = value;
				_hasOrderUnit = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetOrderUnit()
		{
			_ou = null;
			_hasOrderUnit = false;
		}

		#endregion // OrderUnit

		#region Price
		private double? _price;
		private bool _hasPrice;

		/// <summary>
		///     Price is the net price (per order unit) of the product for the
		///     end-user.
		/// </summary>
		public double? Price
		{
			get => _price;
			set
			{
				_price = value;
				_hasPrice = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetPrice()
		{
			_price = null;
			_hasPrice = false;
		}

		#endregion // Price

		#region PriceFormula
		private string _priceFormula;
		private bool _hasPriceFormula;

		/// <summary>
		///     PriceFormula represents the formula to calculate the price of
		///     the product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		public string PriceFormula
		{
			get => _priceFormula;
			set
			{
				_priceFormula = value;
				_hasPriceFormula = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetPriceFormula()
		{
			_priceFormula = null;
			_hasPriceFormula = false;
		}

		#endregion // PriceFormula

		#region PriceQty
		private double? _priceQty;
		private bool _hasPriceQty;

		/// <summary>
		///     PriceQty is the quantity for which the price is specified
		///     (default: 1.0).
		/// </summary>
		public double? PriceQty
		{
			get => _priceQty;
			set
			{
				_priceQty = value;
				_hasPriceQty = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetPriceQty()
		{
			_priceQty = null;
			_hasPriceQty = false;
		}

		#endregion // PriceQty

		#region QuantityInterval
		private double? _quantityInterval;
		private bool _hasQuantityInterval;

		/// <summary>
		///     QuantityInterval is the interval in which this product can be
		///     ordered. E.g. if the quantity interval is 5, the end-user can
		///     only order in quantities of 5,10,15 etc. 
		/// </summary>
		public double? QuantityInterval
		{
			get => _quantityInterval;
			set
			{
				_quantityInterval = value;
				_hasQuantityInterval = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetQuantityInterval()
		{
			_quantityInterval = null;
			_hasQuantityInterval = false;
		}

		#endregion // QuantityInterval

		#region QuantityMax
		private double? _quantityMax;
		private bool _hasQuantityMax;

		/// <summary>
		///     QuantityMax is the maximum order quantity for this product.
		/// </summary>
		public double? QuantityMax
		{
			get => _quantityMax;
			set
			{
				_quantityMax = value;
				_hasQuantityMax = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetQuantityMax()
		{
			_quantityMax = null;
			_hasQuantityMax = false;
		}

		#endregion // QuantityMax

		#region QuantityMin
		private double? _quantityMin;
		private bool _hasQuantityMin;

		/// <summary>
		///     QuantityMin is the minimum order quantity for this product.
		/// </summary>
		public double? QuantityMin
		{
			get => _quantityMin;
			set
			{
				_quantityMin = value;
				_hasQuantityMin = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetQuantityMin()
		{
			_quantityMin = null;
			_hasQuantityMin = false;
		}

		#endregion // QuantityMin

		#region Rateable
		private bool? _rateable;
		private bool _hasRateable;

		/// <summary>
		///     Rateable is a flag that indicates whether the product can be
		///     rated by end-users. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		public bool? Rateable
		{
			get => _rateable;
			set
			{
				_rateable = value;
				_hasRateable = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetRateable()
		{
			_rateable = null;
			_hasRateable = false;
		}

		#endregion // Rateable

		#region RateableOnlyIfOrdered
		private bool? _rateableOnlyIfOrdered;
		private bool _hasRateableOnlyIfOrdered;

		/// <summary>
		///     RateableOnlyIfOrdered is a flag that indicates whether the
		///     product can be rated only after being ordered. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		public bool? RateableOnlyIfOrdered
		{
			get => _rateableOnlyIfOrdered;
			set
			{
				_rateableOnlyIfOrdered = value;
				_hasRateableOnlyIfOrdered = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetRateableOnlyIfOrdered()
		{
			_rateableOnlyIfOrdered = null;
			_hasRateableOnlyIfOrdered = false;
		}

		#endregion // RateableOnlyIfOrdered

		#region References
		private Reference[] _references;
		private bool _hasReferences;

		/// <summary>
		///     References defines cross-product references, e.g. alternatives
		///     or follow-up products.
		/// </summary>
		public Reference[] References
		{
			get => _references;
			set
			{
				_references = value;
				_hasReferences = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetReferences()
		{
			_references = null;
			_hasReferences = false;
		}

		#endregion // References

		#region Safetysheet
		private string _safetysheet;
		private bool _hasSafetysheet;

		/// <summary>
		///     Safetysheet is the name of an safetysheet file (in the media
		///     files) or a URL to the safetysheet on the internet.
		/// </summary>
		public string Safetysheet
		{
			get => _safetysheet;
			set
			{
				_safetysheet = value;
				_hasSafetysheet = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetSafetysheet()
		{
			_safetysheet = null;
			_hasSafetysheet = false;
		}

		#endregion // Safetysheet

		#region ScalePrices
		private ScalePrice[] _scalePrices;
		private bool _hasScalePrices;

		/// <summary>
		///     ScalePrices can be used when the price of the product is
		///     dependent on the ordered quantity.
		/// </summary>
		public ScalePrice[] ScalePrices
		{
			get => _scalePrices;
			set
			{
				_scalePrices = value;
				_hasScalePrices = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetScalePrices()
		{
			_scalePrices = null;
			_hasScalePrices = false;
		}

		#endregion // ScalePrices

		#region Service
		private bool? _service;
		private bool _hasService;

		/// <summary>
		///     Service indicates if the is a good (false) or a service (true).
		///     The default value is false.
		/// </summary>
		public bool? Service
		{
			get => _service;
			set
			{
				_service = value;
				_hasService = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetService()
		{
			_service = null;
			_hasService = false;
		}

		#endregion // Service

		#region TaxCode
		private string _taxCode;
		private bool _hasTaxCode;

		/// <summary>
		///     TaxCode to use for this product. This is typically
		///     project-specific.
		/// </summary>
		public string TaxCode
		{
			get => _taxCode;
			set
			{
				_taxCode = value;
				_hasTaxCode = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetTaxCode()
		{
			_taxCode = null;
			_hasTaxCode = false;
		}

		#endregion // TaxCode

		#region TaxRate
		private double? _taxRate;
		private bool _hasTaxRate;

		/// <summary>
		///     TaxRate for this product, a numeric value between 0.0 and 1.0.
		/// </summary>
		public double? TaxRate
		{
			get => _taxRate;
			set
			{
				_taxRate = value;
				_hasTaxRate = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetTaxRate()
		{
			_taxRate = null;
			_hasTaxRate = false;
		}

		#endregion // TaxRate

		#region Thumbnail
		private string _thumbnail;
		private bool _hasThumbnail;

		/// <summary>
		///     Thumbnail is the name of an thumbnail image file (in the media
		///     files) or a URL to the image on the internet.
		/// </summary>
		public string Thumbnail
		{
			get => _thumbnail;
			set
			{
				_thumbnail = value;
				_hasThumbnail = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetThumbnail()
		{
			_thumbnail = null;
			_hasThumbnail = false;
		}

		#endregion // Thumbnail

		#region Unspscs
		private Unspsc[] _unspscs;
		private bool _hasUnspscs;

		/// <summary>
		///     Unspscs is a list of UNSPSC categories the product belongs to.
		/// </summary>
		public Unspsc[] Unspscs
		{
			get => _unspscs;
			set
			{
				_unspscs = value;
				_hasUnspscs = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetUnspscs()
		{
			_unspscs = null;
			_hasUnspscs = false;
		}

		#endregion // Unspscs

		#region Visible
		private bool? _visible;
		private bool _hasVisible;

		/// <summary>
		///     Visible is a flag that indicates whether this product will be
		///     visible to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		public bool? Visible
		{
			get => _visible;
			set
			{
				_visible = value;
				_hasVisible = true;
			}
		}

		/// <summary>
		///     Reset the property.
		/// </summary>
		public void ResetVisible()
		{
			_visible = null;
			_hasVisible = false;
		}

		#endregion // Visible

		/// <summary>
		///     Serialize the data.
		/// </summary>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (_hasAsin)
			{
				info.AddValue("asin", _asin);
			}
			if (_hasAutoConfigure)
			{
				info.AddValue("autoConfigure", _autoConfigure);
			}
			if (_hasAvailability)
			{
				info.AddValue("availability", _availability);
			}
			if (_hasBlobs)
			{
				info.AddValue("blobs", _blobs);
			}
			if (_hasBoostFactor)
			{
				info.AddValue("boostFactor", _boostFactor);
			}
			if (_hasBpn)
			{
				info.AddValue("bpn", _bpn);
			}
			if (_hasBrand)
			{
				info.AddValue("brand", _brand);
			}
			if (_hasCatalogManaged)
			{
				info.AddValue("catalogManaged", _catalogManaged);
			}
			if (_hasCategories)
			{
				info.AddValue("categories", _categories);
			}
			if (_hasConditions)
			{
				info.AddValue("conditions", _conditions);
			}
			if (_hasContract)
			{
				info.AddValue("contract", _contract);
			}
			if (_hasContractItem)
			{
				info.AddValue("contractItem", _contractItem);
			}
			if (_hasConversionDenumerator)
			{
				info.AddValue("conversionDenumerator", _conversionDenumerator);
			}
			if (_hasConversionNumerator)
			{
				info.AddValue("conversionNumerator", _conversionNumerator);
			}
			if (_hasCountry)
			{
				info.AddValue("country", _country);
			}
			if (_hasContentUnit)
			{
				info.AddValue("cu", _cu);
			}
			if (_hasCuPerOu)
			{
				info.AddValue("cuPerOu", _cuPerOu);
			}
			if (_hasCurrency)
			{
				info.AddValue("currency", _currency);
			}
			if (_hasCustField1)
			{
				info.AddValue("custField1", _custField1);
			}
			if (_hasCustField2)
			{
				info.AddValue("custField2", _custField2);
			}
			if (_hasCustField3)
			{
				info.AddValue("custField3", _custField3);
			}
			if (_hasCustField4)
			{
				info.AddValue("custField4", _custField4);
			}
			if (_hasCustField5)
			{
				info.AddValue("custField5", _custField5);
			}
			if (_hasCustFields)
			{
				info.AddValue("custFields", _custFields);
			}
			if (_hasCustomField10)
			{
				info.AddValue("customField10", _customField10);
			}
			if (_hasCustomField11)
			{
				info.AddValue("customField11", _customField11);
			}
			if (_hasCustomField12)
			{
				info.AddValue("customField12", _customField12);
			}
			if (_hasCustomField13)
			{
				info.AddValue("customField13", _customField13);
			}
			if (_hasCustomField14)
			{
				info.AddValue("customField14", _customField14);
			}
			if (_hasCustomField15)
			{
				info.AddValue("customField15", _customField15);
			}
			if (_hasCustomField16)
			{
				info.AddValue("customField16", _customField16);
			}
			if (_hasCustomField17)
			{
				info.AddValue("customField17", _customField17);
			}
			if (_hasCustomField18)
			{
				info.AddValue("customField18", _customField18);
			}
			if (_hasCustomField19)
			{
				info.AddValue("customField19", _customField19);
			}
			if (_hasCustomField20)
			{
				info.AddValue("customField20", _customField20);
			}
			if (_hasCustomField21)
			{
				info.AddValue("customField21", _customField21);
			}
			if (_hasCustomField22)
			{
				info.AddValue("customField22", _customField22);
			}
			if (_hasCustomField23)
			{
				info.AddValue("customField23", _customField23);
			}
			if (_hasCustomField24)
			{
				info.AddValue("customField24", _customField24);
			}
			if (_hasCustomField25)
			{
				info.AddValue("customField25", _customField25);
			}
			if (_hasCustomField26)
			{
				info.AddValue("customField26", _customField26);
			}
			if (_hasCustomField27)
			{
				info.AddValue("customField27", _customField27);
			}
			if (_hasCustomField28)
			{
				info.AddValue("customField28", _customField28);
			}
			if (_hasCustomField29)
			{
				info.AddValue("customField29", _customField29);
			}
			if (_hasCustomField30)
			{
				info.AddValue("customField30", _customField30);
			}
			if (_hasCustomField31)
			{
				info.AddValue("customField31", _customField31);
			}
			if (_hasCustomField32)
			{
				info.AddValue("customField32", _customField32);
			}
			if (_hasCustomField33)
			{
				info.AddValue("customField33", _customField33);
			}
			if (_hasCustomField34)
			{
				info.AddValue("customField34", _customField34);
			}
			if (_hasCustomField35)
			{
				info.AddValue("customField35", _customField35);
			}
			if (_hasCustomField36)
			{
				info.AddValue("customField36", _customField36);
			}
			if (_hasCustomField37)
			{
				info.AddValue("customField37", _customField37);
			}
			if (_hasCustomField38)
			{
				info.AddValue("customField38", _customField38);
			}
			if (_hasCustomField39)
			{
				info.AddValue("customField39", _customField39);
			}
			if (_hasCustomField40)
			{
				info.AddValue("customField40", _customField40);
			}
			if (_hasCustomField41)
			{
				info.AddValue("customField41", _customField41);
			}
			if (_hasCustomField42)
			{
				info.AddValue("customField42", _customField42);
			}
			if (_hasCustomField43)
			{
				info.AddValue("customField43", _customField43);
			}
			if (_hasCustomField44)
			{
				info.AddValue("customField44", _customField44);
			}
			if (_hasCustomField45)
			{
				info.AddValue("customField45", _customField45);
			}
			if (_hasCustomField46)
			{
				info.AddValue("customField46", _customField46);
			}
			if (_hasCustomField47)
			{
				info.AddValue("customField47", _customField47);
			}
			if (_hasCustomField48)
			{
				info.AddValue("customField48", _customField48);
			}
			if (_hasCustomField49)
			{
				info.AddValue("customField49", _customField49);
			}
			if (_hasCustomField50)
			{
				info.AddValue("customField50", _customField50);
			}
			if (_hasCustomField6)
			{
				info.AddValue("customField6", _customField6);
			}
			if (_hasCustomField7)
			{
				info.AddValue("customField7", _customField7);
			}
			if (_hasCustomField8)
			{
				info.AddValue("customField8", _customField8);
			}
			if (_hasCustomField9)
			{
				info.AddValue("customField9", _customField9);
			}
			if (_hasDatasheet)
			{
				info.AddValue("datasheet", _datasheet);
			}
			if (_hasDescription)
			{
				info.AddValue("description", _description);
			}
			if (_hasEclasses)
			{
				info.AddValue("eclasses", _eclasses);
			}
			if (_hasErpGroupSupplier)
			{
				info.AddValue("erpGroupSupplier", _erpGroupSupplier);
			}
			if (_hasExcluded)
			{
				info.AddValue("excluded", _excluded);
			}
			if (_hasExtCategory)
			{
				info.AddValue("extCategory", _extCategory);
			}
			if (_hasExtCategoryId)
			{
				info.AddValue("extCategoryId", _extCategoryId);
			}
			if (_hasExtConfigForm)
			{
				info.AddValue("extConfigForm", _extConfigForm);
			}
			if (_hasExtConfigService)
			{
				info.AddValue("extConfigService", _extConfigService);
			}
			if (_hasExtProductId)
			{
				info.AddValue("extProductId", _extProductId);
			}
			if (_hasExtSchemaType)
			{
				info.AddValue("extSchemaType", _extSchemaType);
			}
			if (_hasFeatures)
			{
				info.AddValue("features", _features);
			}
			if (_hasGlAccount)
			{
				info.AddValue("glAccount", _glAccount);
			}
			if (_hasGreenLogos)
			{
				info.AddValue("greenLogos", _greenLogos);
			}
			if (_hasGtin)
			{
				info.AddValue("gtin", _gtin);
			}
			if (_hasHazmats)
			{
				info.AddValue("hazmats", _hazmats);
			}
			if (_hasImage)
			{
				info.AddValue("image", _image);
			}
			if (_hasIncomplete)
			{
				info.AddValue("incomplete", _incomplete);
			}
			if (_hasIntrastat)
			{
				info.AddValue("intrastat", _intrastat);
			}
			if (_hasIsPassword)
			{
				info.AddValue("isPassword", _isPassword);
			}
			if (_hasKeepPrice)
			{
				info.AddValue("keepPrice", _keepPrice);
			}
			if (_hasKeywords)
			{
				info.AddValue("keywords", _keywords);
			}
			if (_hasLeadtime)
			{
				info.AddValue("leadtime", _leadtime);
			}
			if (_hasListPrice)
			{
				info.AddValue("listPrice", _listPrice);
			}
			if (_hasManufactcode)
			{
				info.AddValue("manufactcode", _manufactcode);
			}
			if (_hasManufacturer)
			{
				info.AddValue("manufacturer", _manufacturer);
			}
			if (_hasMatgroup)
			{
				info.AddValue("matgroup", _matgroup);
			}
			if (_hasMpn)
			{
				info.AddValue("mpn", _mpn);
			}
			if (_hasMultiSupplierId)
			{
				info.AddValue("multiSupplierId", _multiSupplierId);
			}
			if (_hasMultiSupplierName)
			{
				info.AddValue("multiSupplierName", _multiSupplierName);
			}
			if (_hasName)
			{
				info.AddValue("name", _name);
			}
			if (_hasNeedsGoodsReceipt)
			{
				info.AddValue("needsGoodsReceipt", _needsGoodsReceipt);
			}
			if (_hasNfBasePrice)
			{
				info.AddValue("nfBasePrice", _nfBasePrice);
			}
			if (_hasNfBasePriceQuantity)
			{
				info.AddValue("nfBasePriceQuantity", _nfBasePriceQuantity);
			}
			if (_hasNfCndId)
			{
				info.AddValue("nfCndId", _nfCndId);
			}
			if (_hasNfScale)
			{
				info.AddValue("nfScale", _nfScale);
			}
			if (_hasNfScaleQuantity)
			{
				info.AddValue("nfScaleQuantity", _nfScaleQuantity);
			}
			if (_hasOrderable)
			{
				info.AddValue("orderable", _orderable);
			}
			if (_hasOrderUnit)
			{
				info.AddValue("ou", _ou);
			}
			if (_hasPrice)
			{
				info.AddValue("price", _price);
			}
			if (_hasPriceFormula)
			{
				info.AddValue("priceFormula", _priceFormula);
			}
			if (_hasPriceQty)
			{
				info.AddValue("priceQty", _priceQty);
			}
			if (_hasQuantityInterval)
			{
				info.AddValue("quantityInterval", _quantityInterval);
			}
			if (_hasQuantityMax)
			{
				info.AddValue("quantityMax", _quantityMax);
			}
			if (_hasQuantityMin)
			{
				info.AddValue("quantityMin", _quantityMin);
			}
			if (_hasRateable)
			{
				info.AddValue("rateable", _rateable);
			}
			if (_hasRateableOnlyIfOrdered)
			{
				info.AddValue("rateableOnlyIfOrdered", _rateableOnlyIfOrdered);
			}
			if (_hasReferences)
			{
				info.AddValue("references", _references);
			}
			if (_hasSafetysheet)
			{
				info.AddValue("safetysheet", _safetysheet);
			}
			if (_hasScalePrices)
			{
				info.AddValue("scalePrices", _scalePrices);
			}
			if (_hasService)
			{
				info.AddValue("service", _service);
			}
			if (_hasTaxCode)
			{
				info.AddValue("taxCode", _taxCode);
			}
			if (_hasTaxRate)
			{
				info.AddValue("taxRate", _taxRate);
			}
			if (_hasThumbnail)
			{
				info.AddValue("thumbnail", _thumbnail);
			}
			if (_hasUnspscs)
			{
				info.AddValue("unspscs", _unspscs);
			}
			if (_hasVisible)
			{
				info.AddValue("visible", _visible);
			}
		}

		#endregion // UpdateProduct
	}

	/// <summary>
	///     UpdateProductResponse is the outcome of a successful request to
	///     update a product.
	/// </summary>
	public class UpdateProductResponse
	{
		#region UpdateProductResponse

		/// <summary>
		///     Kind describes this entity.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Link returns a URL to the representation of the updated
		///     product.
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		#endregion // UpdateProductResponse
	}

	/// <summary>
	///     UpsertProduct holds the properties of the product to create or
	///     update.
	/// </summary>
	public class UpsertProduct
	{
		#region UpsertProduct

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		[JsonProperty("asin")]
		public string Asin { get; set; }

		/// <summary>
		///     AutoConfigure is a flag that indicates whether this product can
		///     be configured automatically. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("autoConfigure")]
		public bool? AutoConfigure { get; set; }

		/// <summary>
		///     Availability allows the update of product availability data,
		///     e.g. the number of items in stock or the date when the product
		///     will be available again. 
		/// </summary>
		[JsonProperty("availability")]
		public Availability Availability { get; set; }

		/// <summary>
		///     Blobs specifies external data, e.g. images or datasheets.
		/// </summary>
		[JsonProperty("blobs")]
		public Blob[] Blobs { get; set; }

		/// <summary>
		///     BoostFactor represents a positive or negative boost for the
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("boostFactor")]
		public double? BoostFactor { get; set; }

		/// <summary>
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

		/// <summary>
		///     Brand is the commercial brand name of the product (i.e.
		///     end-consumer recognizable brand name)
		/// </summary>
		[JsonProperty("brand")]
		public string Brand { get; set; }

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		[JsonProperty("catalogManaged")]
		public bool CatalogManaged { get; set; }

		/// <summary>
		///     Categories is a list of (supplier-specific) category names the
		///     product belongs to.
		/// </summary>
		[JsonProperty("categories")]
		public string[] Categories { get; set; }

		/// <summary>
		///     Conditions describes the product conditions, e.g. refurbished
		///     or used.
		/// </summary>
		[JsonProperty("conditions")]
		public Condition[] Conditions { get; set; }

		/// <summary>
		///     Contract represents the contract number to be used when
		///     purchasing this product. Please consult your Store Manager
		///     before setting a value for this field.
		/// </summary>
		[JsonProperty("contract")]
		public string Contract { get; set; }

		/// <summary>
		///     ContractItem represents line number in the contract to be used
		///     when purchasing this product. See also Contract. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("contractItem")]
		public string ContractItem { get; set; }

		/// <summary>
		///     ConversionDenumerator is the denumerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionDenumerator")]
		public double? ConversionDenumerator { get; set; }

		/// <summary>
		///     ConversionNumerator is the numerator for calculating price
		///     quantities. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("conversionNumerator")]
		public double? ConversionNumerator { get; set; }

		/// <summary>
		///     Country/Region represents the ISO code of the country/region of
		///     origin, i.e. the country/region where the product has been
		///     created/produced, e.g. DE. If unspecified, the field is
		///     initialized with the catalog's country/region field. 
		/// </summary>
		[JsonProperty("country")]
		public string Country { get; set; }

		/// <summary>
		///     ContentUnit is the content unit of the product, a 3-character
		///     ISO code (usually project-specific).
		/// </summary>
		[JsonProperty("cu")]
		public string ContentUnit { get; set; }

		/// <summary>
		///     CuPerOu describes the number of content units per order unit,
		///     e.g. the 12 in '1 case contains 12 bottles'.
		/// </summary>
		[JsonProperty("cuPerOu")]
		public double? CuPerOu { get; set; }

		/// <summary>
		///     Currency is the ISO currency code for the prices, e.g. EUR or
		///     GBP. If you pass an empty currency code, it will be initialized
		///     with the catalog's currency. 
		/// </summary>
		[JsonProperty("currency")]
		public string Currency { get; set; }

		/// <summary>
		///     CustField1 is the CUST_FIELD1 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField1")]
		public string CustField1 { get; set; }

		/// <summary>
		///     CustField2 is the CUST_FIELD2 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField2")]
		public string CustField2 { get; set; }

		/// <summary>
		///     CustField3 is the CUST_FIELD3 of the SAP OCI specification. It
		///     has a maximum length of 10 characters. 
		/// </summary>
		[JsonProperty("custField3")]
		public string CustField3 { get; set; }

		/// <summary>
		///     CustField4 is the CUST_FIELD4 of the SAP OCI specification. It
		///     has a maximum length of 20 characters. 
		/// </summary>
		[JsonProperty("custField4")]
		public string CustField4 { get; set; }

		/// <summary>
		///     CustField5 is the CUST_FIELD5 of the SAP OCI specification. It
		///     has a maximum length of 50 characters. 
		/// </summary>
		[JsonProperty("custField5")]
		public string CustField5 { get; set; }

		/// <summary>
		///     CustFields is an array of generic name/value pairs for
		///     customer-specific attributes.
		/// </summary>
		[JsonProperty("custFields")]
		public CustField[] CustFields { get; set; }

		/// <summary>
		///     CustomField10 represents the 10th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField10")]
		public string CustomField10 { get; set; }

		/// <summary>
		///     CustomField11 represents the 11th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField11")]
		public string CustomField11 { get; set; }

		/// <summary>
		///     CustomField12 represents the 12th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField12")]
		public string CustomField12 { get; set; }

		/// <summary>
		///     CustomField13 represents the 13th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField13")]
		public string CustomField13 { get; set; }

		/// <summary>
		///     CustomField14 represents the 14th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField14")]
		public string CustomField14 { get; set; }

		/// <summary>
		///     CustomField15 represents the 15th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField15")]
		public string CustomField15 { get; set; }

		/// <summary>
		///     CustomField16 represents the 16th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField16")]
		public string CustomField16 { get; set; }

		/// <summary>
		///     CustomField17 represents the 17th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField17")]
		public string CustomField17 { get; set; }

		/// <summary>
		///     CustomField18 represents the 18th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField18")]
		public string CustomField18 { get; set; }

		/// <summary>
		///     CustomField19 represents the 19th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField19")]
		public string CustomField19 { get; set; }

		/// <summary>
		///     CustomField20 represents the 20th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField20")]
		public string CustomField20 { get; set; }

		/// <summary>
		///     CustomField21 represents the 21st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField21")]
		public string CustomField21 { get; set; }

		/// <summary>
		///     CustomField22 represents the 22nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField22")]
		public string CustomField22 { get; set; }

		/// <summary>
		///     CustomField23 represents the 23rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField23")]
		public string CustomField23 { get; set; }

		/// <summary>
		///     CustomField24 represents the 24th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField24")]
		public string CustomField24 { get; set; }

		/// <summary>
		///     CustomField25 represents the 25th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField25")]
		public string CustomField25 { get; set; }

		/// <summary>
		///     CustomField26 represents the 26th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField26")]
		public string CustomField26 { get; set; }

		/// <summary>
		///     CustomField27 represents the 27th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField27")]
		public string CustomField27 { get; set; }

		/// <summary>
		///     CustomField28 represents the 28th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField28")]
		public string CustomField28 { get; set; }

		/// <summary>
		///     CustomField29 represents the 29th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField29")]
		public string CustomField29 { get; set; }

		/// <summary>
		///     CustomField30 represents the 30th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField30")]
		public string CustomField30 { get; set; }

		/// <summary>
		///     CustomField31 represents the 31st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField31")]
		public string CustomField31 { get; set; }

		/// <summary>
		///     CustomField32 represents the 32nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField32")]
		public string CustomField32 { get; set; }

		/// <summary>
		///     CustomField33 represents the 33rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField33")]
		public string CustomField33 { get; set; }

		/// <summary>
		///     CustomField34 represents the 34th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField34")]
		public string CustomField34 { get; set; }

		/// <summary>
		///     CustomField35 represents the 35th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField35")]
		public string CustomField35 { get; set; }

		/// <summary>
		///     CustomField36 represents the 36th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField36")]
		public string CustomField36 { get; set; }

		/// <summary>
		///     CustomField37 represents the 37th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField37")]
		public string CustomField37 { get; set; }

		/// <summary>
		///     CustomField38 represents the 38th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField38")]
		public string CustomField38 { get; set; }

		/// <summary>
		///     CustomField39 represents the 39th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField39")]
		public string CustomField39 { get; set; }

		/// <summary>
		///     CustomField40 represents the 40th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField40")]
		public string CustomField40 { get; set; }

		/// <summary>
		///     CustomField41 represents the 41st customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField41")]
		public string CustomField41 { get; set; }

		/// <summary>
		///     CustomField42 represents the 42nd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField42")]
		public string CustomField42 { get; set; }

		/// <summary>
		///     CustomField43 represents the 43rd customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField43")]
		public string CustomField43 { get; set; }

		/// <summary>
		///     CustomField44 represents the 44th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField44")]
		public string CustomField44 { get; set; }

		/// <summary>
		///     CustomField45 represents the 45th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField45")]
		public string CustomField45 { get; set; }

		/// <summary>
		///     CustomField46 represents the 46th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField46")]
		public string CustomField46 { get; set; }

		/// <summary>
		///     CustomField47 represents the 47th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField47")]
		public string CustomField47 { get; set; }

		/// <summary>
		///     CustomField48 represents the 48th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField48")]
		public string CustomField48 { get; set; }

		/// <summary>
		///     CustomField49 represents the 49th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField49")]
		public string CustomField49 { get; set; }

		/// <summary>
		///     CustomField50 represents the 50th customer-specific field.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("customField50")]
		public string CustomField50 { get; set; }

		/// <summary>
		///     CustomField6 represents the 6th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField6")]
		public string CustomField6 { get; set; }

		/// <summary>
		///     CustomField7 represents the 7th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField7")]
		public string CustomField7 { get; set; }

		/// <summary>
		///     CustomField8 represents the 8th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField8")]
		public string CustomField8 { get; set; }

		/// <summary>
		///     CustomField9 represents the 9th customer-specific field. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("customField9")]
		public string CustomField9 { get; set; }

		/// <summary>
		///     Datasheet is the name of an datasheet file (in the media files)
		///     or a URL to the datasheet on the internet.
		/// </summary>
		[JsonProperty("datasheet")]
		public string Datasheet { get; set; }

		/// <summary>
		///     Description of the product.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///     Eclasses is a list of eCl@ss categories the product belongs to.
		/// </summary>
		[JsonProperty("eclasses")]
		public Eclass[] Eclasses { get; set; }

		/// <summary>
		///     erpGroupSupplier is the material group of the product on the
		///     merchant-/supplier-side.
		/// </summary>
		[JsonProperty("erpGroupSupplier")]
		public string ErpGroupSupplier { get; set; }

		/// <summary>
		///     Excluded is a flag that indicates whether to exclude this
		///     product from the catalog. If true, this product will not be
		///     published into the live area.
		/// </summary>
		[JsonProperty("excluded")]
		public bool Excluded { get; set; }

		/// <summary>
		///     ExtCategory is the EXT_CATEGORY field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategory")]
		public string ExtCategory { get; set; }

		/// <summary>
		///     ExtCategoryID is the EXT_CATEGORY_ID field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extCategoryId")]
		public string ExtCategoryId { get; set; }

		/// <summary>
		///     ExtConfigForm represents information required to make the
		///     product configurable. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("extConfigForm")]
		public string ExtConfigForm { get; set; }

		/// <summary>
		///     ExtConfigService represents additional information required to
		///     make the product configurable. See also ExtConfigForm. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("extConfigService")]
		public string ExtConfigService { get; set; }

		/// <summary>
		///     ExtProductID is the EXT_PRODUCT_ID field of the SAP OCI
		///     specification. It is e.g. required for configurable/catalog
		///     managed products.
		/// </summary>
		[JsonProperty("extProductId")]
		public string ExtProductId { get; set; }

		/// <summary>
		///     ExtSchemaType is the EXT_SCHEMA_TYPE field of the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("extSchemaType")]
		public string ExtSchemaType { get; set; }

		/// <summary>
		///     Features defines product features, i.e. additional properties
		///     of the product.
		/// </summary>
		[JsonProperty("features")]
		public Feature[] Features { get; set; }

		/// <summary>
		///     GLAccount represents the GL account number to use for this
		///     product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("glAccount")]
		public string GlAccount { get; set; }

		/// <summary>
		///     GreenLogos is an array of green logo names, which are hosted in
		///     the store, and used to mark products as green.
		/// </summary>
		[JsonProperty("greenLogos")]
		public string[] GreenLogos { get; set; }

		/// <summary>
		///     GTIN is the global trade item number of the product (used to be
		///     EAN).
		/// </summary>
		[JsonProperty("gtin")]
		public string Gtin { get; set; }

		/// <summary>
		///     Hazmats classifies hazardous/dangerous goods.
		/// </summary>
		[JsonProperty("hazmats")]
		public Hazmat[] Hazmats { get; set; }

		/// <summary>
		///     Image is the name of an image file (in the media files) or a
		///     URL to the image on the internet.
		/// </summary>
		[JsonProperty("image")]
		public string Image { get; set; }

		/// <summary>
		///     Incomplete is a flag that indicates whether this product is
		///     incomplete. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("incomplete")]
		public bool? Incomplete { get; set; }

		/// <summary>
		///     Intrastat specifies required data for Intrastat messages. 
		/// </summary>
		[JsonProperty("intrastat")]
		public Intrastat Intrastat { get; set; }

		/// <summary>
		///     IsPassword is a flag that indicates whether this product will
		///     be used to purchase a password, e.g. for a software product.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("isPassword")]
		public bool? IsPassword { get; set; }

		/// <summary>
		///     KeepPrice is a flag that indicates whether the price of the
		///     product will or will not be calculated by the catalog. Please
		///     consult your Store Manager before setting a value for this
		///     field.
		/// </summary>
		[JsonProperty("keepPrice")]
		public bool? KeepPrice { get; set; }

		/// <summary>
		///     Keywords is a list of aliases for the product.
		/// </summary>
		[JsonProperty("keywords")]
		public string[] Keywords { get; set; }

		/// <summary>
		///     Leadtime is the number of days for delivery.
		/// </summary>
		[JsonProperty("leadtime")]
		public double? Leadtime { get; set; }

		/// <summary>
		///     ListPrice is the net list price of the product.
		/// </summary>
		[JsonProperty("listPrice")]
		public double? ListPrice { get; set; }

		/// <summary>
		///     Manufactcode is the manufacturer code as used in the SAP OCI
		///     specification.
		/// </summary>
		[JsonProperty("manufactcode")]
		public string Manufactcode { get; set; }

		/// <summary>
		///     Manufacturer is the name of the manufacturer.
		/// </summary>
		[JsonProperty("manufacturer")]
		public string Manufacturer { get; set; }

		/// <summary>
		///     Matgroup is the material group of the product on the buy-side.
		/// </summary>
		[JsonProperty("matgroup")]
		public string Matgroup { get; set; }

		/// <summary>
		///     MPN is the manufacturer part number.
		/// </summary>
		[JsonProperty("mpn")]
		public string Mpn { get; set; }

		/// <summary>
		///     MultiSupplierID represents an optional field for the unique
		///     identifier of a supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierId")]
		public string MultiSupplierId { get; set; }

		/// <summary>
		///     MultiSupplierName represents an optional field for the name of
		///     the supplier in a multi-supplier catalog.
		/// </summary>
		[JsonProperty("multiSupplierName")]
		public string MultiSupplierName { get; set; }

		/// <summary>
		///     Name of the product. The product name is a required field
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     NeedsGoodsReceipt is a flag that indicates whether this product
		///     requires a goods receipt process. Please consult your Store
		///     Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("needsGoodsReceipt")]
		public bool? NeedsGoodsReceipt { get; set; }

		/// <summary>
		///     NFBasePrice represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfBasePrice")]
		public double? NfBasePrice { get; set; }

		/// <summary>
		///     NFBasePriceQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfBasePriceQuantity")]
		public double? NfBasePriceQuantity { get; set; }

		/// <summary>
		///     NFCndID represents the key to calculate metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfCndId")]
		public string NfCndId { get; set; }

		/// <summary>
		///     NFScale represents a part for calculating metal surcharges.
		///     Please consult your Store Manager before setting a value for
		///     this field.
		/// </summary>
		[JsonProperty("nfScale")]
		public double? NfScale { get; set; }

		/// <summary>
		///     NFScaleQuantity represents a part for calculating metal
		///     surcharges. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("nfScaleQuantity")]
		public double? NfScaleQuantity { get; set; }

		/// <summary>
		///     Orderable is a flag that indicates whether this product will be
		///     orderable to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("orderable")]
		public bool? Orderable { get; set; }

		/// <summary>
		///     OrderUnit is the order unit of the product, a 3-character ISO
		///     code (usually project-specific). OrderUnit is a required field.
		/// </summary>
		[JsonProperty("ou")]
		public string OrderUnit { get; set; }

		/// <summary>
		///     Price is the net price (per order unit) of the product for the
		///     end-user. Price is a required field.
		/// </summary>
		[JsonProperty("price")]
		public double Price { get; set; }

		/// <summary>
		///     PriceFormula represents the formula to calculate the price of
		///     the product. Please consult your Store Manager before setting a
		///     value for this field.
		/// </summary>
		[JsonProperty("priceFormula")]
		public string PriceFormula { get; set; }

		/// <summary>
		///     PriceQty is the quantity for which the price is specified
		///     (default: 1.0).
		/// </summary>
		[JsonProperty("priceQty")]
		public double? PriceQty { get; set; }

		/// <summary>
		///     QuantityInterval is the interval in which this product can be
		///     ordered. E.g. if the quantity interval is 5, the end-user can
		///     only order in quantities of 5,10,15 etc. 
		/// </summary>
		[JsonProperty("quantityInterval")]
		public double? QuantityInterval { get; set; }

		/// <summary>
		///     QuantityMax is the maximum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMax")]
		public double? QuantityMax { get; set; }

		/// <summary>
		///     QuantityMin is the minimum order quantity for this product.
		/// </summary>
		[JsonProperty("quantityMin")]
		public double? QuantityMin { get; set; }

		/// <summary>
		///     Rateable is a flag that indicates whether the product can be
		///     rated by end-users. Please consult your Store Manager before
		///     setting a value for this field.
		/// </summary>
		[JsonProperty("rateable")]
		public bool? Rateable { get; set; }

		/// <summary>
		///     RateableOnlyIfOrdered is a flag that indicates whether the
		///     product can be rated only after being ordered. Please consult
		///     your Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("rateableOnlyIfOrdered")]
		public bool? RateableOnlyIfOrdered { get; set; }

		/// <summary>
		///     References defines cross-product references, e.g. alternatives
		///     or follow-up products.
		/// </summary>
		[JsonProperty("references")]
		public Reference[] References { get; set; }

		/// <summary>
		///     Safetysheet is the name of an safetysheet file (in the media
		///     files) or a URL to the safetysheet on the internet.
		/// </summary>
		[JsonProperty("safetysheet")]
		public string Safetysheet { get; set; }

		/// <summary>
		///     ScalePrices can be used when the price of the product is
		///     dependent on the ordered quantity.
		/// </summary>
		[JsonProperty("scalePrices")]
		public ScalePrice[] ScalePrices { get; set; }

		/// <summary>
		///     Service indicates if the is a good (false) or a service (true).
		///     The default value is false.
		/// </summary>
		[JsonProperty("service")]
		public bool Service { get; set; }

		/// <summary>
		///     SPN is the supplier part number. SPN is a required field.
		/// </summary>
		[JsonProperty("spn")]
		public string Spn { get; set; }

		/// <summary>
		///     TaxCode to use for this product. This is typically
		///     project-specific.
		/// </summary>
		[JsonProperty("taxCode")]
		public string TaxCode { get; set; }

		/// <summary>
		///     TaxRate for this product, a numeric value between 0.0 and 1.0.
		/// </summary>
		[JsonProperty("taxRate")]
		public double TaxRate { get; set; }

		/// <summary>
		///     Thumbnail is the name of an thumbnail image file (in the media
		///     files) or a URL to the image on the internet.
		/// </summary>
		[JsonProperty("thumbnail")]
		public string Thumbnail { get; set; }

		/// <summary>
		///     Unspscs is a list of UNSPSC categories the product belongs to.
		/// </summary>
		[JsonProperty("unspscs")]
		public Unspsc[] Unspscs { get; set; }

		/// <summary>
		///     Visible is a flag that indicates whether this product will be
		///     visible to the end-user when shopping. Please consult your
		///     Store Manager before setting a value for this field.
		/// </summary>
		[JsonProperty("visible")]
		public bool? Visible { get; set; }

		#endregion // UpsertProduct
	}

	/// <summary>
	///     UpsertProductResponse is the outcome of a successful request to
	///     upsert a product.
	/// </summary>
	public class UpsertProductResponse
	{
		#region UpsertProductResponse

		/// <summary>
		///     Kind describes this entity.
		/// </summary>
		[JsonProperty("kind")]
		public string Kind { get; set; }

		/// <summary>
		///     Link returns a URL to the representation of the created or
		///     updated product.
		/// </summary>
		[JsonProperty("link")]
		public string Link { get; set; }

		#endregion // UpsertProductResponse
	}

	/// <summary>
	///     CreateService: Create a new product in the given catalog and
	///     area.
	/// </summary>
	public class CreateService
	{
		#region CreateService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private CreateProduct _product;

		/// <summary>
		///     Creates a new instance of CreateService.
		/// </summary>
		public CreateService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public CreateService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public CreateService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     Product properties of the new product.
		/// </summary>
		public CreateService Product(CreateProduct product)
		{
			_product = product;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<CreateProductResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products";
			var response = await _service.Client.Execute(
				HttpMethod.Post,
				uriTemplate,
				parameters,
				headers,
				_product);
			return response.GetBodyJSON<CreateProductResponse>();
		}

		#endregion // CreateService
	}

	/// <summary>
	///     DeleteService: Delete a product.
	/// </summary>
	public class DeleteService
	{
		#region DeleteService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private string _spn;

		/// <summary>
		///     Creates a new instance of DeleteService.
		/// </summary>
		public DeleteService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public DeleteService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public DeleteService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     SPN is the supplier part number of the product to delete.
		/// </summary>
		public DeleteService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/{spn}";
			await _service.Client.Execute(
				HttpMethod.Delete,
				uriTemplate,
				parameters,
				headers,
				null);
		}

		#endregion // DeleteService
	}

	/// <summary>
	///     GetService: Get returns a single product by its Supplier Part
	///     Number (SPN).
	/// </summary>
	public class GetService
	{
		#region GetService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private string _spn;

		/// <summary>
		///     Creates a new instance of GetService.
		/// </summary>
		public GetService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public GetService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public GetService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     SPN is the supplier part number of the product to get.
		/// </summary>
		public GetService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<Product> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/{spn}";
			var response = await _service.Client.Execute(
				HttpMethod.Get,
				uriTemplate,
				parameters,
				headers,
				null);
			return response.GetBodyJSON<Product>();
		}

		#endregion // GetService
	}

	/// <summary>
	///     ReplaceService: Replace all fields of a product. Use Update to
	///     update only certain fields of a product.
	/// </summary>
	public class ReplaceService
	{
		#region ReplaceService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private string _spn;
		private ReplaceProduct _product;

		/// <summary>
		///     Creates a new instance of ReplaceService.
		/// </summary>
		public ReplaceService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public ReplaceService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public ReplaceService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     New properties of the product.
		/// </summary>
		public ReplaceService Product(ReplaceProduct product)
		{
			_product = product;
			return this;
		}

		/// <summary>
		///     SPN is the supplier part number of the product to replace.
		/// </summary>
		public ReplaceService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<ReplaceProductResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/{spn}";
			var response = await _service.Client.Execute(
				HttpMethod.Put,
				uriTemplate,
				parameters,
				headers,
				_product);
			return response.GetBodyJSON<ReplaceProductResponse>();
		}

		#endregion // ReplaceService
	}

	/// <summary>
	///     ScrollService: Scroll through products of a catalog (area). If
	///     you need to iterate through all products in a catalog, this is
	///     the most effective way to do so. If you want to search for
	///     products, use the Search endpoint. 
	/// </summary>
	public class ScrollService
	{
		#region ScrollService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;

		/// <summary>
		///     Creates a new instance of ScrollService.
		/// </summary>
		public ScrollService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public ScrollService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     Mode can be used in combination with version to specify if the
		///     result should include all products for the specific version of
		///     the catalog (full), or just the products that changed from the
		///     previous version (diff). If the mode is "diff", the type of
		///     change to the product can be found in the attribute "mode" and
		///     has the following values: "Created", "Updated", "Deleted". 
		/// </summary>
		public ScrollService Mode(string mode)
		{
			_opt["mode"] = mode;
			return this;
		}

		/// <summary>
		///     PageToken must be passed in the 2nd and all consective requests
		///     to get the next page of results. You do not need to pass the
		///     page token manually. You should just follow the nextUrl link in
		///     the metadata to get the next slice of data. If there is no
		///     nextUrl returned, you have reached the last page of products
		///     for the given catalog. A scroll request is kept alive for 2
		///     minutes. If you fail to ask for the next slice of products
		///     within this period, a new scroll request will be created and
		///     you start over at the first page of results. 
		/// </summary>
		public ScrollService PageToken(string pageToken)
		{
			_opt["pageToken"] = pageToken;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public ScrollService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     Version of the catalog to be retrieved
		/// </summary>
		public ScrollService Version(long version)
		{
			_opt["version"] = version;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<ScrollResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			if (_opt.ContainsKey("mode"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["mode"] = string.Format("{0}", _opt["mode"]);
			}
			if (_opt.ContainsKey("pageToken"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["pageToken"] = string.Format("{0}", _opt["pageToken"]);
			}
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			if (_opt.ContainsKey("version"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["version"] = string.Format("{0}", _opt["version"]);
			}

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/scroll{?pageToken,mode,version}";
			var response = await _service.Client.Execute(
				HttpMethod.Get,
				uriTemplate,
				parameters,
				headers,
				null);
			return response.GetBodyJSON<ScrollResponse>();
		}

		#endregion // ScrollService
	}

	/// <summary>
	///     SearchService: Search for products. Do not use this method for
	///     iterating through all of the products in a catalog; use the
	///     Scroll endpoint instead. It is much more efficient. 
	/// </summary>
	public class SearchService
	{
		#region SearchService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;

		/// <summary>
		///     Creates a new instance of SearchService.
		/// </summary>
		public SearchService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public SearchService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public SearchService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     Q defines are full text query.
		/// </summary>
		public SearchService Q(string q)
		{
			_opt["q"] = q;
			return this;
		}

		/// <summary>
		///     Skip specifies how many products to skip (default 0).
		/// </summary>
		public SearchService Skip(long skip)
		{
			_opt["skip"] = skip;
			return this;
		}

		/// <summary>
		///     Sort order, e.g. name, spn, id or -created (default: score).
		/// </summary>
		public SearchService Sort(string sort)
		{
			_opt["sort"] = sort;
			return this;
		}

		/// <summary>
		///     Take defines how many products to return (max 100, default 20).
		/// </summary>
		public SearchService Take(long take)
		{
			_opt["take"] = take;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<SearchResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			if (_opt.ContainsKey("q"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["q"] = string.Format("{0}", _opt["q"]);
			}
			if (_opt.ContainsKey("skip"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["skip"] = string.Format("{0}", _opt["skip"]);
			}
			if (_opt.ContainsKey("sort"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["sort"] = string.Format("{0}", _opt["sort"]);
			}
			if (_opt.ContainsKey("take"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["take"] = string.Format("{0}", _opt["take"]);
			}

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products{?q,skip,take,sort}";
			var response = await _service.Client.Execute(
				HttpMethod.Get,
				uriTemplate,
				parameters,
				headers,
				null);
			return response.GetBodyJSON<SearchResponse>();
		}

		#endregion // SearchService
	}

	/// <summary>
	///     UpdateService: Update the fields of a product selectively. Use
	///     Replace to replace the product as a whole.
	/// </summary>
	public class UpdateService
	{
		#region UpdateService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private string _spn;
		private UpdateProduct _product;

		/// <summary>
		///     Creates a new instance of UpdateService.
		/// </summary>
		public UpdateService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public UpdateService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public UpdateService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     Products properties of the updated product.
		/// </summary>
		public UpdateService Product(UpdateProduct product)
		{
			_product = product;
			return this;
		}

		/// <summary>
		///     SPN is the supplier part number of the product to update.
		/// </summary>
		public UpdateService Spn(string spn)
		{
			_spn = spn;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<UpdateProductResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);
			// UriTemplates package wants path parameters as strings
			parameters["spn"] = string.Format("{0}", _spn);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/{spn}";
			var response = await _service.Client.Execute(
				HttpMethod.Post,
				uriTemplate,
				parameters,
				headers,
				_product);
			return response.GetBodyJSON<UpdateProductResponse>();
		}

		#endregion // UpdateService
	}

	/// <summary>
	///     UpsertService: Upsert a product in the given catalog and area.
	///     Upsert will create if the product does not exist yet, otherwise
	///     it will update.
	/// </summary>
	public class UpsertService
	{
		#region UpsertService

		private readonly Service _service;
		private readonly IDictionary<string, object> _opt = new Dictionary<string, object>();
		private readonly IDictionary<string, string> _hdr = new Dictionary<string, string>();

		private string _pin;
		private string _area;
		private UpsertProduct _product;

		/// <summary>
		///     Creates a new instance of UpsertService.
		/// </summary>
		public UpsertService(Service service)
		{
			_service = service;
		}

		/// <summary>
		///     Area of the catalog, e.g. work or live.
		/// </summary>
		public UpsertService Area(string area)
		{
			_area = area;
			return this;
		}

		/// <summary>
		///     PIN of the catalog.
		/// </summary>
		public UpsertService Pin(string pin)
		{
			_pin = pin;
			return this;
		}

		/// <summary>
		///     Product properties of the new product.
		/// </summary>
		public UpsertService Product(UpsertProduct product)
		{
			_product = product;
			return this;
		}

		/// <summary>
		///     Execute the operation.
		/// </summary>
		public async Task<UpsertProductResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/upsert";
			var response = await _service.Client.Execute(
				HttpMethod.Post,
				uriTemplate,
				parameters,
				headers,
				_product);
			return response.GetBodyJSON<UpsertProductResponse>();
		}

		#endregion // UpsertService
	}
}

