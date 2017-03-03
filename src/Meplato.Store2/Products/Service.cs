#region Copyright and terms of services
// Copyright (c) 2015-2016 Meplato GmbH, Switzerland.
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
// Version: 2.0.1
// License: Copyright (c) 2015-2017 Meplato GmbH, Switzerland. All rights reserved.
// See <a href="https://developer.meplato.com/store2/#terms">Terms of Service</a>
// See <a href="https://developer.meplato.com/store2/">External documentation</a>

using System;
using System.Collections.Generic;
using System.Net.Http;
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
		public const string Version = "2.0.1";
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
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

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
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

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
		///     GBP.
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
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

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
	public class UpdateProduct
	{
		#region UpdateProduct

		/// <summary>
		///     ASIN is the unique Amazon article number of the product.
		/// </summary>
		[JsonProperty("asin")]
		public string Asin { get; set; }

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
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

		/// <summary>
		///     CatalogManaged is a flag that indicates whether this product is
		///     configurable (or catalog managed in OCI parlance).
		/// </summary>
		[JsonProperty("catalogManaged")]
		public bool? CatalogManaged { get; set; }

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
		public bool? Excluded { get; set; }

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
		public double? Price { get; set; }

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
		public bool? Service { get; set; }

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
		public double? TaxRate { get; set; }

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
		///     BPN is the buyer part number of the product.
		/// </summary>
		[JsonProperty("bpn")]
		public string Bpn { get; set; }

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
		public async void Do()
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
		///     Execute the operation.
		/// </summary>
		public async Task<ScrollResponse> Do()
			{
			// Make a copy of the parameters and add the path parameters to it
			var parameters = new Dictionary<string, object>();
			// UriTemplates package wants path parameters as strings
			parameters["area"] = string.Format("{0}", _area);
			if (_opt.ContainsKey("pageToken"))
			{
				// UriTemplates package wants query parameters as strings
				parameters["pageToken"] = string.Format("{0}", _opt["pageToken"]);
			}
			// UriTemplates package wants path parameters as strings
			parameters["pin"] = string.Format("{0}", _pin);

			// Make a copy of the header parameters and set UA
			var headers = new Dictionary<string, string>();
			string authorization = _service.GetAuthorizationHeader();
			if (!string.IsNullOrEmpty(authorization))
			{
				headers["Authorization"] = authorization;
			}

			var uriTemplate = _service.BaseURL + "/catalogs/{pin}/{area}/products/scroll{?pageToken}";
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

