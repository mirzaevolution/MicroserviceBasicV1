using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.OrderHistoryAPI.Models
{
    public class OrderHistory
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderCreated { get; set; } = DateTime.UtcNow;
    }
}
