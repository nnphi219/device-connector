using System;
using System.Collections.Generic;

namespace Harvey.DeviceHub.Models.Receipts
{
    public class Receipt
    {
        public string BillNo { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CashierName { get; set; }
        public string CounterName { get; set; }
        public double TotalAmount { get; set; }
        public double GTSAmount { get; set; }
        public int NetQuantity { get; set; }
        public double NetTotal { get; set; }
        public int ExchangeDayQuantity { get; set; }
        public IList<ReceiptItem> Items { get; set; }
    }
}