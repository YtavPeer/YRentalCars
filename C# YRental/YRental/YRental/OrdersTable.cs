//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YRental
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdersTable
    {
        public int Order_ID { get; set; }
        public int Car_ID { get; set; }
        public string Start_Date { get; set; }
        public string Return_Estimate_Date { get; set; }
        public string Returm_Real_Date { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Order_Status { get; set; }
    }
}