using System;
using System.ComponentModel;
using System.Xml.Serialization;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>
    [Serializable]
    [XmlType(AnonymousType = true)]
	[XmlRoot(Namespace = "", IsNullable = false)]
	public class Price
	{
        /// <remarks/>
		public string ArticleNumber { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string Date { get; set; }

        /// <remarks/>
        public string FromQuantity { get; set; }

        /// <remarks/>
        public string Percent { get; set; }

        /// <remarks/>
        [XmlElement("Price")]
		public string PriceValue { get; set; }

        /// <remarks/>
        public string PriceList { get; set; }

        /// <summary>This field is Read-Only in Fortnox</summary>
        [ReadOnly(true)]
		public string url { get; set; }
    }
}
