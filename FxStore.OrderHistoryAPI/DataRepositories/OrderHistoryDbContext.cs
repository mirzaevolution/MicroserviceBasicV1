using FxStore.OrderHistoryAPI.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FxStore.OrderHistoryAPI.DataRepositories
{
    public class OrderHistoryDbContext : DbContext
    {
        public OrderHistoryDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<OrderHistory> OrderHistories { get; set; }
    }
}
