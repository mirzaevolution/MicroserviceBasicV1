using System;

namespace FxStore.OrderHistories.Worker
{
    public class OrderDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
