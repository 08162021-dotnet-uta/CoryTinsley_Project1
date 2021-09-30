using System;
using System.Collections.Generic;

#nullable disable

namespace Project0.StoreApplication.Storage.Models
{
    public partial class OrderProduct
    {
        public short OrderProductId { get; set; }
        public short OrderId { get; set; }
        public short ProductId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
