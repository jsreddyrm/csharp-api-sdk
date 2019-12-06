using System;
using System.Collections.Generic;
using Newtonsoft.Json;

// ReSharper disable UnusedMember.Global
// ReSharper disable InconsistentNaming

namespace FortnoxAPILibrary.Entities
{
    /// <remarks/>

    
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class Vouchers
    {
        /// <remarks/>
        [JsonProperty]
        public List<VoucherSubset> VoucherSubset { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TotalResources { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string TotalPages { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string CurrentPage { get; set; }
    }

    /// <remarks/>
    
    
    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class VoucherSubset
    {

        /// <remarks/>
        [JsonProperty]
        public string ReferenceNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string ReferenceType { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherNumber { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string VoucherSeries { get; set; }

        /// <remarks/>
        [JsonProperty]
        public string Year { get; set; }

        /// <remarks/>
        [JsonProperty(PropertyName = "@url")]
        public string Url { get; set; }
    }
}
