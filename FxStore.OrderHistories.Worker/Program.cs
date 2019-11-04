using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace FxStore.OrderHistories.Worker
{
    class Program
    {
        private static OrderHistoryRepoContext _context;

        static Program()
        {
            try
            {
                _context = new OrderHistoryRepoContext();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Listen()
        {
            try
            {
                IConnectionFactory connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };
                using(IConnection connection = connectionFactory.CreateConnection())
                {
                    using(IModel channel = connection.CreateModel())
                    {
                        channel.QueueDeclare(queue:"OrderHistoryRepo", durable: false, exclusive: false, autoDelete: false, arguments: null);

                        channel.BasicQos(0, 1, false);
                        EventingBasicConsumer consumer = new EventingBasicConsumer(channel);
                        consumer.Registered += (s, e) =>
                        {
                            Console.WriteLine("** Order History Worker Register **");
                            Console.WriteLine("Press [ENTER] to quit");
                        };
                        consumer.Shutdown += (s, e) =>
                        {
                            Console.WriteLine("** Order History Worker Stopped **");
                        };
                        consumer.Received += (s, payload) =>
                        {
                            string payloadInJson = Encoding.UTF8.GetString(payload.Body);
                            Console.WriteLine("[*] Receiving order");
                            Console.WriteLine("[*] Deserializing object...");
                            OrderDto orderDto = JsonConvert.DeserializeObject<OrderDto>(payloadInJson);
                            try
                            {
                                Console.WriteLine("[*] Inserting to databse...");
                                _context.OrderHistories.Add(new OrderHistories
                                {
                                    Id = orderDto.Id,
                                    OrderCreated = DateTime.UtcNow,
                                    ProductId = orderDto.ProductId,
                                    Quantity = orderDto.Quantity,
                                    UserId = orderDto.UserId
                                });
                                if (_context.SaveChanges() > 0)
                                {
                                    Console.WriteLine("[*] Order has been inserted successfully");
                                }
                                else
                                {
                                    Console.WriteLine("[*] Order failed to insert");
                                }
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine("[*] Error while inserting data to table");
                                Console.WriteLine(ex);
                            }
                            finally
                            {
                                channel.BasicAck(payload.DeliveryTag,false);
                            }
                        };
                        channel.BasicConsume("OrderHistoryRepo", false, consumer);
                        Console.ReadLine();
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        static void Main(string[] args)
        {
            Listen();
        }
    }
}
