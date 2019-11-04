using System;
using System.Collections.Generic;

namespace FxStore.OrderHistories.Worker
{
    public partial class OrderHistories
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderCreated { get; set; }
    }
}
