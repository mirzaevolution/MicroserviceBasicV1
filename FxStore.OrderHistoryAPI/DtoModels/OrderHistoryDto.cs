using System;

namespace FxStore.OrderHistoryAPI.DtoModels
{
    public class OrderHistoryDto
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime? OrderCreated { get; set; } = DateTime.UtcNow;
    }
}
