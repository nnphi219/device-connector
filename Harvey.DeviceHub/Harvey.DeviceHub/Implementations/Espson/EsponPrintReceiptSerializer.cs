using Harvey.DeviceHub.Models.Receipts;
using Newtonsoft.Json;
using PrinterUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;

namespace Harvey.DeviceHub.Implementations.Espson
{
    public class EsponPrintReceiptSerializer : ISerializer<byte[]>
    {
        public byte[] Serialize(string data)
        {
            var receipt = JsonConvert.DeserializeObject<Receipt>(data);
            var result = GenerateReceipt(receipt);
            return result;
        }

        private byte[] GenerateReceipt(Receipt receipt)
        {
            var togLogoPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\Images\\tog-logo.png";

            PrinterUtility.EscPosEpsonCommands.EscPosEpson obj = new PrinterUtility.EscPosEpsonCommands.EscPosEpson();
            var BytesValue = Encoding.ASCII.GetBytes(string.Empty);
            BytesValue = PrintExtensions.AddBytes(BytesValue, ImageToByteArray(togLogoPath));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleWidth6());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.FontSelect.FontA());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("TOG Connection Pte Ltd\n"));

            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("201 Victoria Street .#05-04\n\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("SINGAPORE - 188067\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("Phone: 66341967\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("E-mail: test@gmail.com\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("GST Reg No: 201229862H\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, 
                Encoding.ASCII.GetBytes($"Bill No: {receipt.BillNo}  Date: {receipt.CreatedDate.ToString("dd/MM/yyyy")}\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue,
                Encoding.ASCII.GetBytes($"Cashier: {receipt.CashierName}  Couter: {receipt.CounterName}\n"));

            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes("No  Itm                      Qty      Net   Total\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());

            if (receipt.Items.Any())
            {
                foreach (var item in receipt.Items)
                {
                    BytesValue = PrintExtensions.AddBytes(BytesValue, string.Format("{0}{1,-40}{2,6}{3,9}{4,9:N2}\n", 
                                                                                    item.No, item.Name, item.Quantity, item.Price,  item.Amount));
                }
            }

            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes($" Total Amount:           {receipt.TotalAmount}\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes($" (GST S$ {receipt.GTSAmount} Inclusive)\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, Encoding.ASCII.GetBytes($" Net Qty: {receipt.NetQuantity}    Net Total:  {receipt.NetTotal}\n"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());

            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, 
                Encoding.ASCII.GetBytes($"Retain Your Receipt for Exchange within {receipt.ExchangeDayQuantity} Days For Selected Items Only!Thanks!Please Come again\n"));
            
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Separator());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Lf());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Center());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.CharSize.DoubleHeight6());
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.BarCode.Code128("12345"));
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.QrCode.Print("12345", PrinterUtility.Enums.QrCodeSize.Grande));
            BytesValue = PrintExtensions.AddBytes(BytesValue, "-------------------Thank you for coming------------------------\n");
            BytesValue = PrintExtensions.AddBytes(BytesValue, obj.Alignment.Left());
            BytesValue = PrintExtensions.AddBytes(BytesValue, CutPage());

            return BytesValue;
        }

        public byte[] CutPage()
        {
            List<byte> oby = new List<byte>();
            oby.Add(Convert.ToByte(Convert.ToChar(0x1D)));
            oby.Add(Convert.ToByte('V'));
            oby.Add((byte)66);
            oby.Add((byte)3);
            return oby.ToArray();
        }

        public byte[] ImageToByteArray(string path)
        {
            byte[] imgdata = System.IO.File.ReadAllBytes(path);

            return imgdata;
        }
    }
}