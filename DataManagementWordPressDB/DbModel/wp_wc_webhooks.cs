//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataManagementWordPressDB.DbModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class wp_wc_webhooks
    {
        public decimal webhook_id { get; set; }
        public string status { get; set; }
        public string name { get; set; }
        public decimal user_id { get; set; }
        public string delivery_url { get; set; }
        public string secret { get; set; }
        public string topic { get; set; }
        public System.DateTime date_created { get; set; }
        public System.DateTime date_created_gmt { get; set; }
        public System.DateTime date_modified { get; set; }
        public System.DateTime date_modified_gmt { get; set; }
        public short api_version { get; set; }
        public short failure_count { get; set; }
        public sbyte pending_delivery { get; set; }
    }
}
