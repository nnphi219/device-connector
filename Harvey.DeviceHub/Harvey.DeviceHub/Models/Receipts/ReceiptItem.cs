namespace Harvey.DeviceHub.Models.Receipts
{
    public class ReceiptItem
    {
        public int No { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
    }
}